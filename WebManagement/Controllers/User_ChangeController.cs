using cn.bmob.io;
using cn.bmob.response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
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
        /// <param name="Username">User name</param>
        /// <param name="Column">Column to be changed</param>
        /// <param name="Content">RAW value</param>
        /// <param name="STAMP">Time Stamp and hash</param>
        /// <param name="Ticket">Random string</param>
        /// <returns></returns>
        public IEnumerable Get(string Username, string Column, string Content, string STAMP, string Ticket)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            object Equals2Obj = Content;
            if (Int32.TryParse((string)Equals2Obj, out int EqInt)) Equals2Obj = EqInt;
            else if (((string)Equals2Obj).ToLower() == "true") Equals2Obj = true;
            else if (((string)Equals2Obj).ToLower() == "false") Equals2Obj = false;

            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", Username);
            try
            {
                var UsrNameResult = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UserTable, UserNameQuery);
                UsrNameResult.Wait();
                if (UsrNameResult.IsCompleted && UsrNameResult.Result.results.Count != 0)
                {
                    AllUserObject user = new AllUserObject();
                    user.objectId = UsrNameResult.Result.results[0].objectId;
                    user.UserGroup = UsrNameResult.Result.results[0].UserGroup;
                    string tmpVerify = Crypto.SHA256Encrypt(Content + Crypto.SHA256Encrypt(UsrNameResult.Result.results[0].Password + Ticket) + Ticket);
                    if (STAMP == tmpVerify)
                    {
                        switch (Column.ToLower())
                        {
                            case "realname":
                                user.RealName = (string)Equals2Obj;
                                break;
                            case "password":
                                user.Password = (string)Equals2Obj;
                                break;
                            case "wechatid":
                                if (Equals2Obj.ToString() == "null") Equals2Obj = "####";
                                user.WeChatID = (string)Equals2Obj;
                                break;
                            case "notice":
                                user.WebNotiSeen = (bool)Equals2Obj;
                                break;
                            case "firstlogin":
                                user.FirstLogin = (bool)Equals2Obj;
                                break;
                            case "parent":
                                user.UserGroup.ChildIds = ((string)Equals2Obj).Split(';');
                                break;
                            default:

                                break;
                        }

                        Task<UpdateCallbackData> taskupdate = _Bmob.UpdateTaskAsync(user);
                        taskupdate.Wait();
                        if (taskupdate.IsCompleted)
                        {
                            UsrNameResult = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UserTable, UserNameQuery);
                            UsrNameResult.Wait();

                            AllUserObject FoundUser = UsrNameResult.Result.results[0];
                            FoundUser.Password = Crypto.SHA256Encrypt(FoundUser.Password + Ticket);
                            dict = ObjToDict.UsrInfo2Dict(FoundUser);
                            dict.Add("ErrCode", "0");
                            dict.Add("ErrMessage", "null");
                            dict.Add("updated_At", taskupdate.Result.updatedAt);

                        }
                        else
                        {
                            dict.Add("ErrCode", "998");
                            dict.Add("ErrMessage", taskupdate.Exception.Message);
                        }
                    }
                    else
                    {
                        dict.Add("ErrCode", "2");
                        dict.Add("ErrMessage", "Ticket has something wrong with it.");
                    }
                }
            }
            catch (Exception e)
            {
                dict.Add("ErrCode", "999");
                dict.Add("ErrMessage", e.Message);
            }
            return dict;
        }

    }
}
