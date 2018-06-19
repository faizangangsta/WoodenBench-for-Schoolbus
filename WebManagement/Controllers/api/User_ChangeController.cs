using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
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
            if (SessionVerify.Length != 2) return WebAPIResponseCollections.RequestIllegal;
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
                    case "notice":
                        //user.WebNotiSeen = (bool)Equals2Obj;
                        break;
                    case "firstlogin":
                        //user.FirstLogin = (bool)Equals2Obj;
                        break;
                    default:

                        break;
                }


                if (Database.Database.UpdateData(user) == 0)
                {
                    DBQuery query = new DBQuery();
                    query.WhereEqualTo("objectId", SessionUser.objectId);
                    switch (Database.Database.QueryMultipleData(query, out List<UserObject> UserList))
                    {
                        case DatabaseOperationResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                        case DatabaseOperationResult.NO_RESULTS: return WebAPIResponseCollections.DatabaseError;
                        default:
                            Dictionary<string, string> dict = UserList[0].ToDictionary();
                            string NewSession = Sessions.RenewSession(SessionVerify[1], Request.Headers["User-Agent"], UserList[0]);
                            Response.Cookies.Append("Session", NewSession, new Microsoft.AspNetCore.Http.CookieOptions() { Path = "/" });
                            dict.Add("ErrCode", "0");
                            dict.Add("ErrMessage", "null");
                            dict.Add("updated_At", DateTime.Now.ToString());
                            return dict;
                    }
                }
                else return WebAPIResponseCollections.InternalError;
            }
            else return WebAPIResponseCollections.RequestIllegal;
        }
    }
}