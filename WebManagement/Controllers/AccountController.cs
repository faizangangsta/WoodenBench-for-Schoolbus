using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WBServicePlatform.WebManagement.Models;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["WhereAmI"] = "index";
            ViewData["Message"] = "主页";
            return View();
        }

        public IActionResult LoginFailed()
        {
            ViewData["WhereAmI"] = "loginfailed";
            ViewData["Message"] = "登陆失败";
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
