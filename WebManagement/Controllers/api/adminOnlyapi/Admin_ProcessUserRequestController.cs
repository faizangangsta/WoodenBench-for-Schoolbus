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
    public class Admin_ProcessUserRequest : WebAPIController
    {
        [HttpGet]
        public IEnumerable Get(string reqId, string mode, string detail)
        {
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject SessionUser))
            {
                if (SessionUser.UserGroup.IsAdmin)
                {
                    switch (DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", reqId), out UserChangeRequest request))
                    {
                        case DBQueryStatus.ONE_RESULT:
                            request.SolverID = SessionUser.objectId;
                            switch (mode)
                            {
                                case "0":
                                    //Accepted
                                    request.Status = UserChangeRequestProcessStatus.Accepted;
                                    break;
                                case "1":
                                    //Refused
                                    UserChangeRequestRefusedReasons reason = Enum.Parse<UserChangeRequestRefusedReasons>(detail);
                                    request.Status = UserChangeRequestProcessStatus.Refused;
                                    request.ProcessResultReason = reason;
                                    break;
                                default: return RequestIllegal;
                            }
                            if (DataBaseOperation.UpdateData(request) != (DBQueryStatus)1) return DataBaseError;
                            if (request.Status == UserChangeRequestProcessStatus.Accepted)
                            {
                                switch (DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", request.UserID), out UserObject user))
                                {
                                    case DBQueryStatus.ONE_RESULT:
                                        switch (request.RequestTypes)
                                        {
                                            case UserChangeRequestTypes.真实姓名:
                                                user.RealName = request.NewContent;
                                                break;
                                            case UserChangeRequestTypes.手机号码:
                                                user.PhoneNumber = request.NewContent;
                                                break;
                                            default: return SpecialisedInfo("提交成功，部分内容需要手动修改");
                                        }
                                        GlobalMessage message_User = new GlobalMessage() { type = GlobalMessageTypes.UCR_Procced_TO_User, dataObject = request, user = user, objectId = request.UserID };
                                        MessagingSystem.AddMessageProcesses(message_User);
                                        break;
                                    default: return DataBaseError;
                                }
                            }
                            return SpecialisedInfo("提交成功");
                        default: return DataBaseError;
                    }
                }
                else return UserGroupError;
            }
            else return SessionError;
        }
    }
}
