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
    public class User_ChangeController : WebAPIController
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
            if (int.TryParse((string)Equals2Obj, out int EqInt)) Equals2Obj = EqInt;
            else if (((string)Equals2Obj).ToLower() == "true") Equals2Obj = true;
            else if (((string)Equals2Obj).ToLower() == "false") Equals2Obj = false;
            string[] SessionVerify = STAMP.Split("_v3_");
            if (SessionVerify.Length != 2) return RequestIllegal;
            if (ValidateSession() && SessionVerify[0] == Cryptography.SHA256Encrypt(CurrentUser.ObjectId + Content + SessionVerify[1]))
            {
                //user.objectId = SessionUser.objectId;
                //user.UserGroup = SessionUser.UserGroup;
                switch (Column.ToLower())
                {
                    case "realname":
                        CurrentUser.RealName = (string)Equals2Obj;
                        break;
                    case "password":
                        CurrentUser.Password = (string)Equals2Obj;
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

                var _tempUser = CurrentUser;
                if (DataBaseOperation.UpdateData(ref _tempUser) == 0)
                {
                    Dictionary<string, string> dict = CurrentUser.ToDictionary();
                    UpdateUser(_tempUser);
                    dict.Add("ErrCode", "0");
                    dict.Add("ErrMessage", "null");
                    dict.Add("updated_At", DateTime.Now.ToString());
                    return dict;
                }
                else return InternalError;
            }
            else return RequestIllegal;
        }
    }
}