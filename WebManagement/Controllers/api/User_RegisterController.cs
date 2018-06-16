using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Controllers;
using WBPlatform.WebManagement.Tools;
using static WBPlatform.WebManagement.Program;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/users/Register")]
    public class User_RegisterController : Controller
    {
        [HttpPost]
        public IEnumerable POST()
        {
            Request.Form[""].ToArray();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            return dict;
        }

        [HttpGet]
        public IEnumerable GET(string userId, string mode)
        {
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
                            JumpTokens.TryAdd(token, new JumpTokens.TokenInfo() { User_Agent = Request.Headers["User-Agent"], WeChatUserName = user.UserName });
                            return WebAPIResponseCollections.SpecialisedInfo(token);
                        }
                    case "false":
                        if (string.IsNullOrEmpty(user.Password))
                        {
                            return WebAPIResponseCollections.RequestIllegal;
                        }
                        else
                        {
                            string token = JumpTokens.CreateToken();
                            JumpTokens.TryAdd(token, new JumpTokens.TokenInfo() { User_Agent = Request.Headers["User-Agent"], WeChatUserName = user.UserName });
                            return WebAPIResponseCollections.SpecialisedInfo(token);
                        }
                    default: return WebAPIResponseCollections.RequestIllegal;
                }
            }
            else return WebAPIResponseCollections.SessionError;
        }
    }
}
