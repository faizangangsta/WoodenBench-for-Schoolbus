using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;
namespace WBPlatform.WebManagement.Controllers
{
    public class AccountController : _Controller
    {
        public const string ControllerName = "Account";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, user.GetIdentifyCode());
                return View(user);
            }
            else
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
                return _LoginFailed("/" + ControllerName);
            }
        }
        public IActionResult LoginFailed()
        {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
            ViewData["where"] = HomeController.ControllerName;
            ViewData["Message"] = "登陆失败";
            return View();
        }
    }
}
