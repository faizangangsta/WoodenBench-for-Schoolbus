using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Models;
using WBServicePlatform.WebManagement.Tools;
namespace WBServicePlatform.WebManagement.Controllers
{
    public class AccountController : MyController
    {
        public const string ControllerName = "Account";
        public override IActionResult Index()
        {
            ViewData["where"] = "Home";
            ViewData["Message"] = "主页";
            return View();
        }
        public IActionResult LoginFailed()
        {
            ViewData["WhereAmI"] = "loginfailed";
            ViewData["Message"] = "登陆失败";
            return View();
        }
    }
}
