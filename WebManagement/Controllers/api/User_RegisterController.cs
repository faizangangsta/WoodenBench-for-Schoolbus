using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/users/Register")]
    public class User_RegisterController : WebAPIController
    {
        [HttpPost]
        public IEnumerable POST()
        {
            FormCollection myform = (FormCollection)Request.Form;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var item in myform)
            {
                dict.Add(item.Key, item.Value[0]);
            }
            if (!string.IsNullOrEmpty(dict["UserName"]))
            {
                if (dict.ContainsKey("Password"))
                {
                    if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject _cpUser))
                    {
                        string password = Cryptography.SHA256Encrypt(dict["Password"]);
                        if (_cpUser.UserName == dict["UserName"])
                        {
                            _cpUser.Password = password;
                            if (DataBaseOperation.UpdateData(_cpUser) == DBQueryStatus.ONE_RESULT)
                            {
                                Response.Redirect("/Home");
                                Response.Cookies.Delete("Session");
                                return "OK";
                            }
                            else return DataBaseError;
                        }
                        else return RequestIllegal;
                    }
                    else return SessionError;
                }
                else
                {
                    UserObject user = new UserObject()
                    {
                        UserName = dict["UserName"],
                        RealName = dict["RealName"],
                        Sex = dict["Sex"],
                        PhoneNumber = dict["PhoneNumber"]
                    };
                    if (DataBaseOperation.CreateData(user, out user) == DBQueryStatus.ONE_RESULT)
                    {
                        MessagingSystem.AddMessageProcesses(new InternalMessage() { User = user, _Type = GlobalMessageTypes.User__Pending_Verify, DataObject = dict["table"] });
                        Response.Redirect("/Home");
                        return "OK";
                    }
                    else
                    {
                        Response.Redirect("/Home/Error");
                        return InternalError;
                    }
                }
            }
            else return RequestIllegal;
        }

        [HttpGet]
        public IEnumerable GET(string userId, string mode)
        {
            //Response.Redirect("/Error");
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(mode)) return RequestIllegal;
                if (userId != user.ObjectId) return RequestIllegal;
                switch (mode)
                {
                    case "true":
                        //Create Password
                        if (!string.IsNullOrWhiteSpace(user.Password))
                        {
                            return RequestIllegal;
                        }
                        else
                        {
                            string token = JumpTokens.CreateToken();
                            JumpTokens.TryAdd(token, new JumpTokenInfo(JumpTokenUsage.AddPassword, Request.Headers["User-Agent"], user.UserName, 600));
                            return SpecialisedInfo(token);
                        }
                    case "false":
                        //Register User....
                        if (string.IsNullOrEmpty(user.Password))
                        {
                            return RequestIllegal;
                        }
                        else
                        {
                            string token = JumpTokens.CreateToken();
                            JumpTokens.TryAdd(token, new JumpTokenInfo(JumpTokenUsage.UserRegister, Request.Headers["User-Agent"], user.UserName, 600));
                            return SpecialisedInfo(token);
                        }
                    default: return RequestIllegal;
                }
            }
            else return SessionError;
        }
    }
}
