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
    public class User_RegisterController : Controller
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
                UserObject user = new UserObject()
                {
                    UserName = dict["UserName"],
                    RealName = dict["RealName"],
                    Sex = dict["Sex"],
                    PhoneNumber = dict["PhoneNumber"]
                };
                if (DatabaseOperation.CreateData(user, out user) == DBQueryStatus.ONE_RESULT)
                {
                    MessagingSystem.AddMessageProcesses(new GlobalMessage() { user = user, type = GlobalMessageTypes.User__Pending_Verify, dataObject = dict["table"] });
                    Response.Redirect("/Home");
                }
                else
                {
                    Response.Redirect("/Error");
                }
            }
            return "";
        }

        [HttpGet]
        public IEnumerable GET(string userId, string mode)
        {
            Response.Redirect("/Error");
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(mode)) return WebAPIResponseCollections.RequestIllegal;
                if (userId != user.objectId) return WebAPIResponseCollections.RequestIllegal;
                switch (mode)
                {
                    case "true":
                        //Create Password
                        if (!string.IsNullOrEmpty(user.Password))
                        {
                            return WebAPIResponseCollections.RequestIllegal;
                        }
                        else
                        {
                            string token = JumpTokens.CreateToken();
                            JumpTokens.TryAdd(token, new JumpTokenInfo(JumpTokenUsage.AddPassword, Request.Headers["User-Agent"], user.UserName, 600));
                            return WebAPIResponseCollections.SpecialisedInfo(token);
                        }
                    case "false":
                        //Register User....
                        if (string.IsNullOrEmpty(user.Password))
                        {
                            return WebAPIResponseCollections.RequestIllegal;
                        }
                        else
                        {
                            string token = JumpTokens.CreateToken();
                            JumpTokens.TryAdd(token, new JumpTokenInfo(JumpTokenUsage.UserRegister, Request.Headers["User-Agent"], user.UserName, 600));
                            return WebAPIResponseCollections.SpecialisedInfo(token);
                        }
                    default: return WebAPIResponseCollections.RequestIllegal;
                }
            }
            else return WebAPIResponseCollections.SessionError;
        }
    }
}
