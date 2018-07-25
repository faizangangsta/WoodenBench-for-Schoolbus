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
            if (ValidateSession())
            {
                if (CurrentUser.UserGroup.IsAdmin)
                {
                    switch (DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", reqId), out UserChangeRequest request))
                    {
                        case DBQueryStatus.ONE_RESULT:
                            request.SolverID = CurrentUser.ObjectId;
                            switch (mode)
                            {
                                case "0":
                                    //Accepted
                                    request.Status = UCRProcessStatus.Accepted;
                                    break;
                                case "1":
                                    //Refused
                                    UCRRefusedReasons reason = Enum.Parse<UCRRefusedReasons>(detail);
                                    request.Status = UCRProcessStatus.Refused;
                                    request.ProcessResultReason = reason;
                                    break;
                                default: return RequestIllegal;
                            }
                            if (DataBaseOperation.UpdateData(ref request) != DBQueryStatus.ONE_RESULT) return DataBaseError;
                            if (request.Status == UCRProcessStatus.Accepted)
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
                                        if (DataBaseOperation.UpdateData(ref user) != DBQueryStatus.ONE_RESULT)
                                        {
                                            LW.E("Admin->UCRProcess: Failed to Save user data");
                                            return DataBaseError;
                                        }
                                        
                                        InternalMessage message_User = new InternalMessage() { _Type = GlobalMessageTypes.UCR_Procceed_TO_User, DataObject = request, User = user, ObjectId = request.UserID };
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
