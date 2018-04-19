using cn.bmob.io;
using cn.bmob.response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBServicePlatform.Databases;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/users/Change")]
    public class User_ChangeController : Controller
    {
        [HttpGet]
        /// <summary>
        /// Change the user data
        /// </summary>
        /// <param name="UserID">User name</param>
        /// <param name="Column">Column to be changed</param>
        /// <param name="Content">RAW value</param>
        /// <param name="STAMP">Time Stamp and hash</param>
        /// <param name="Ticket">Random string</param>
        /// <returns></returns>
        public IEnumerable Get(string UserID, string Column, string Content, string STAMP)
        {
            object Equals2Obj = Content;
            if (Int32.TryParse((string)Equals2Obj, out int EqInt)) Equals2Obj = EqInt;
            else if (((string)Equals2Obj).ToLower() == "true") Equals2Obj = true;
            else if (((string)Equals2Obj).ToLower() == "false") Equals2Obj = false;
            string[] SessionVerify = STAMP.Split("_v3_");
            if (SessionVerify.Length != 2) return WebAPIResponseErrors.RequestIllegal;
            try
            {
                if (Sessions.OnSessionReceived(SessionVerify[1], Request.Headers["User-Agent"], out UserObject SessionUser) &&
                    SessionVerify[0] == Crypto.SHA256Encrypt(SessionUser.objectId + Content + SessionVerify[1]))
                {
                    UserObject user = new UserObject();
                    //user.objectId = SessionUser.objectId;
                    //user.UserGroup = SessionUser.UserGroup;
                    switch (Column.ToLower())
                    {
                        case "realname":
                            user.RealName = (string)Equals2Obj;
                            break;
                        case "password":
                            user.Password = (string)Equals2Obj;
                            break;
                        case "wechatid":
                            if (Equals2Obj.ToString().ToLower() == "null") Equals2Obj = "####";
                            user.WeChatID = (string)Equals2Obj;
                            break;
                        case "notice":
                            user.WebNotiSeen = (bool)Equals2Obj;
                            break;
                        case "firstlogin":
                            user.FirstLogin = (bool)Equals2Obj;
                            break;
                        default:

                            break;
                    }

                    Task<UpdateCallbackData> taskupdate = _Bmob.UpdateTaskAsync(WBConsts.TABLE_Gen_UserTable, SessionUser.objectId, user);
                    taskupdate.Wait();
                    if (taskupdate.IsCompleted)
                    {
                        DatabaseQuery query = new DatabaseQuery();
                        query.WhereEqualTo("objectId", SessionUser.objectId);
                        switch (Database.QueryData(query, out List<UserObject> UserList))
                        {
                            case -1: return WebAPIResponseErrors.InternalError;
                            case 0: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                            default:
                                Dictionary<string, string> dict = UserList[0].ToDictionary();
                                string NewSession = Sessions.RenewSession(SessionVerify[1], Request.Headers["User-Agent"], UserList[0]);
                                Response.Cookies.Append("Session", NewSession, new Microsoft.AspNetCore.Http.CookieOptions() { Path = "/" });
                                dict.Add("ErrCode", "0");
                                dict.Add("ErrMessage", "null");
                                dict.Add("updated_At", taskupdate.Result.updatedAt);
                                return dict;
                        }
                    }
                    else return WebAPIResponseErrors.InternalError;
                }
                else return WebAPIResponseErrors.RequestIllegal;
            }
            catch (Exception e)
            {
                return WebAPIResponseErrors.SpecialisedError(e.Message);
            }
        }
    }
}
