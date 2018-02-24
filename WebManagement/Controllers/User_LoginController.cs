using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/users/Login")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string UserName, string PasswordHASH, string SALT)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            BmobQuery UserNameQuery = new BmobQuery();
            UserNameQuery.WhereContainedIn("Username", UserName);
            try
            {
                var UsrNameResult = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UserTable, UserNameQuery);
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
}
