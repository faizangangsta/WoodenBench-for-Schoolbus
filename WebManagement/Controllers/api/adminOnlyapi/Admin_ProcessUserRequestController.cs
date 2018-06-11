using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/ProcessUserRequest")]
    public class Admin_ProcessUserRequest : Controller
    {
        [HttpGet]
        public IEnumerable Get(string reqId, string mode, string detail)
        {
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject SessionUser))
            {
                if (SessionUser.UserGroup.IsAdmin)
                {
                    switch (Database.QuerySingleData(new DatabaseQuery().WhereEqualTo("objectId", reqId), out UserChangeRequest request))
                    {
                        case DatabaseQueryResult.ONE_RESULT:
                            request.SolverID = SessionUser.objectId;
                            switch (mode)
                            {
                                case "0":
                                    //Accepted
                                    request.Status = UserChangeRequestProcessStatus.Accepted;
                                    break;
                                case "1":
                                    //Refused
                                    UserChangeRequestRefusedReasons reason = (UserChangeRequestRefusedReasons)Enum.Parse(typeof(UserChangeRequestRefusedReasons), detail);
                                    request.Status = UserChangeRequestProcessStatus.Refused;
                                    request.ProcessResultReason = reason;
                                    break;
                                default: return WebAPIResponseCollections.RequestIllegal;
                            }
                            if (Database.UpdateData(request) == -1) return WebAPIResponseCollections.DatabaseError;
                            else
                            {
                                MessagingSystem.onChangeRequest_Solved(request, SessionUser);
                                return WebAPIResponseCollections.SpecialisedInfo("修改成功");
                            }
                        case DatabaseQueryResult.NO_RESULTS:
                        case DatabaseQueryResult.MORE_RESULTS:
                        case DatabaseQueryResult.INTERNAL_ERROR:
                        default: return WebAPIResponseCollections.DatabaseError;
                    }
                }
                else return WebAPIResponseCollections.UserGroupError;
            }
            else return WebAPIResponseCollections.SessionError;
        }
    }
}
