using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WBServicePlatform.WebManagement.Models;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["WhereAmI"] = "index";
            ViewData["Message"] = "主页啊";
            return View();
        }

        public IActionResult WeekIssue()
        {
            ViewData["WhereAmI"] = "issuerpt";
            ViewData["Message"] = "反馈校车在运行时的问题，如 堵车，学生迟到等……";
            return View();
        }

        public IActionResult ReportBugs()
        {
            ViewData["WhereAmI"] = "bugrpt";
            ViewData["Message"] = "反馈本软件的Bug";
            return View();
        }

        public IActionResult UserManager()
        {
            ViewData["WhereAmI"] = "usrmgr";
            ViewData["Message"] = "查看当前用户的信息";
            return View();
        }
        
        public IActionResult SignStudent()
        {
            ViewData["WhereAmI"] = "";
            ViewData["Message"] = "签到";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
