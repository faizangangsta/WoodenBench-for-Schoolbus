using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Database;
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
                    switch (DBOperations.QuerySingleData(new DBQuery().WhereEqualTo("objectId", reqId), out UserChangeRequest request))
                    {
                        case DatabaseResult.ONE_RESULT:
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
                            if (DBOperations.UpdateData(request) != (DatabaseResult)1) return WebAPIResponseCollections.DataBaseError;
                            if (request.Status == UserChangeRequestProcessStatus.Accepted)
                            {
                                switch (DBOperations.QuerySingleData(new DBQuery().WhereEqualTo("objectId", request.UserID), out UserObject user))
                                {
                                    case DatabaseResult.ONE_RESULT:
                                        switch (request.RequestTypes)
                                        {
                                            case UserChangeRequestTypes.真实姓名:
                                                user.RealName = request.NewContent;
                                                break;
                                            case UserChangeRequestTypes.手机号码:
                                                user.PhoneNumber = request.NewContent;
                                                break;
                                            default: return WebAPIResponseCollections.SpecialisedInfo("提交成功，部分内容需要手动修改");
                                        }
                                        MessagingSystem.onChangeRequest_Solved(request, SessionUser);
                                        break;
                                    default: return WebAPIResponseCollections.DataBaseError;
                                }
                            }
                            return WebAPIResponseCollections.SpecialisedInfo("提交成功");
                        default: return WebAPIResponseCollections.DataBaseError;
                    }
                }
                else return WebAPIResponseCollections.UserGroupError;
            }
            else return WebAPIResponseCollections.SessionError;
        }
    }
}
