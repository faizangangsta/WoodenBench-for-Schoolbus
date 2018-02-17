using cn.bmob.io;
using cn.bmob.response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WoodenBench.StaticClasses;
using WoodenBench.Users;
using static WebAPIServices.GlobalApplication;

namespace WebAPIServices.Controllers
{

    public class usr_LoginController : ApiController
    {
        public IEnumerable Get(string UserName, string PasswordHASH, string SALT)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", UserName);
            try
            {
                Task<QueryCallbackData<AllUserObject>> UsrNameResult;
                UsrNameResult = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UsrTable, UserNameQuery);
                UsrNameResult.Wait();
                if (UsrNameResult.Result.results.Count != 0)
                {
                    string sPass = Crypto.SHA256Encrypt(UsrNameResult.Result.results[0].Password + SALT);
                    if (sPass == PasswordHASH)
                    {
                        AllUserObject FoundUser = UsrNameResult.Result.results[0];
                        FoundUser.Password = sPass;
                        dict = ObjToDict.UsrInfo2Dict(FoundUser);
                        dict.Add("ErrCode", "0");
                        dict.Add("ErrMessage", "null");
                        return dict;
                    }
                    else
                    {
                        dict.Add("ErrCode", "1");
                        dict.Add("ErrMessage", "UserName or Password Not Correct");
                    }
                }
                else
                {
                    dict.Add("ErrCode", "1");
                    dict.Add("ErrMessage", "UserName or Password Not Correct");
                }
            }

            catch (Exception e)
            {
                dict.Add("ErrCode", "999");
                dict.Add("ErrMessage", e.Message);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return dict;
        }
    }
    public class usr_QueryController : ApiController
    {
        // GET: api/UserLogon
        public IEnumerable Get(string ColName, string EqualsTo)
        {
            object Equals2Obj = EqualsTo;
            if (Int32.TryParse((string)Equals2Obj, out int EqInt)) Equals2Obj = EqInt;
            else if (((string)Equals2Obj).ToLower() == "true") Equals2Obj = true;
            else if (((string)Equals2Obj).ToLower() == "false") Equals2Obj = false;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            BmobQuery query = new BmobQuery();
            query.WhereEqualTo(ColName, Equals2Obj);

            Task<QueryCallbackData<AllUserObject>> FindRst = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UsrTable, query);
            FindRst.Wait();
            if (FindRst.IsCompleted)
            {
                dict.Add("ErrCode", "0");
                dict.Add("ErrMessage", "null");
                dict.Add("count", FindRst.Result.results.Count.ToString());
                foreach (AllUserObject userObj in FindRst.Result.results)
                {
                    Dictionary<string, string> tmpDict = ObjToDict.UsrInfo2Dict(userObj);
                    string UsrInfo = SimpleJson.SimpleJson.SerializeObject(tmpDict);
                    dict.Add("num_" + FindRst.Result.results.IndexOf(userObj).ToString() + "", UsrInfo);
                }
            }
            else
            {
                dict.Add("ErrCode", "999");
                dict.Add("ErrMessage", "Something went wrong...");
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return dict;
        }
    }

    public class usr_ChangePropertyController : ApiController
    {
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
                Task<QueryCallbackData<AllUserObject>> UsrNameResult;
                UsrNameResult = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UsrTable, UserNameQuery);
                UsrNameResult.Wait();
                if (UsrNameResult.IsCompleted && UsrNameResult.Result.results.Count != 0)
                {
                    AllUserObject user = new AllUserObject();
                    user.objectId = UsrNameResult.Result.results[0].objectId;
                    string tmpVerify = Crypto.SHA256Encrypt(Content + Crypto.SHA256Encrypt(user.Password + Ticket) + Ticket);
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
                                user.isFstLogin = (bool)Equals2Obj;
                                break;
                            default:

                                break;
                        }

                        Task<UpdateCallbackData> taskupdate = _Bmob.UpdateTaskAsync(user);
                        taskupdate.Wait();
                        if (taskupdate.IsCompleted)
                        {
                            UsrNameResult = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UsrTable, UserNameQuery);
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
