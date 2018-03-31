using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;
namespace WBServicePlatform.WebManagement.Controllers
{
    public class AccountController : _Controller
    {
        public const string ControllerName = "Account";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                return View(user);
            }
            else return _LoginFailed("/" + ControllerName);
        }
        public IActionResult LoginFailed()
        {
            ViewData["where"] = HomeController.ControllerName;
            ViewData["Message"] = "登陆失败";
            return View();
        }
    }
}
