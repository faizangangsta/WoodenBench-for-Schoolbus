using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Models;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            ViewData["WhereAmI"] = "index";
            ViewData["Message"] = "主页";
            if (SessionManager.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user) == false)
            {
                Response.Redirect(Request.Scheme + "://" + Request.Host + "/" + "Account/LoginFailed");
                Response.Cookies.Append("Session", "", new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddSeconds(-1) });
                ViewData["cUser"] = new UserObject().SetEveryThingNull().ToString();
                LoginFailed();
            }
            else ViewData["cUser"] = user.ToString();
            return View();
        }

        public IActionResult WeekIssue()
        {
            ViewData["WhereAmI"] = "issuerpt";
            ViewData["Message"] = "反馈校车在运行时的问题，如 堵车，学生迟到等……";
            if (SessionManager.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user) == false)
            {
                Response.Redirect(Request.Scheme + "://" + Request.Host + "/" + "Account/LoginFailed");
                Response.Cookies.Append("Session", "", new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddSeconds(-1) });
                ViewData["cUser"] = new UserObject().SetEveryThingNull().ToString();
            }
            else ViewData["cUser"] = user.ToString();
            return View();
        }

        public IActionResult ReportBugs()
        {
            ViewData["WhereAmI"] = "bugrpt";
            ViewData["Message"] = "反馈本软件的Bug";
            if (SessionManager.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user) == false)
            {
                Response.Redirect(Request.Scheme + "://" + Request.Host + "/" + "Account/LoginFailed");
                Response.Cookies.Append("Session", "", new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddSeconds(-1) });
                ViewData["cUser"] = new UserObject().SetEveryThingNull().ToString();
                LoginFailed();
            }
            else ViewData["cUser"] = user.ToString();
            return View();
        }

        public IActionResult SignStudent(string signmode)
        {
            Request.Headers["User-Agent"].ToString();
            ViewData["Message"] = "签到";
            ViewData["SignMode"] = signmode;
            if (SessionManager.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                ViewData["cUser"] = user.ToString();
                if ((Request.Cookies.ContainsKey("CBusID") && Request.Cookies["CBusID"] == user.UserGroup.BusID) &&
                    (Request.Cookies.ContainsKey("SignMode") && Request.Cookies["SignMode"] == signmode))
                {
                    ViewData["cBus"] = user.UserGroup.BusID;
                    ViewData["mode"] = signmode;
                }
                else
                {
                    ViewData["cBus"] = "0000000000";
                    ViewData["mode"] = "null";
                    LoginFailed();
                }
            }
            else LoginFailed();
            return View();
        }



        public IActionResult ArriveHomeScan()
        {
            Request.Headers["User-Agent"].ToString();
            ViewData["Message"] = "签到";
            if (SessionManager.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                ViewData["cUser"] = user.ToString();
                if (user.UserGroup.IsBusManager)
                {
                    ViewData["cBus"] = user.UserGroup.BusID;
                    ViewData["cTeacher"] = user.objectId;
                }
                else
                {
                    ViewData["cBus"] = "0000000000";
                    ViewData["mode"] = "null";
                    LoginFailed();
                }
            }
            else LoginFailed();
            return View();
        }

        private void LoginFailed()
        {
            Response.Redirect(Request.Scheme + "://" + Request.Host + "/" + "Account/LoginFailed");
            Response.Cookies.Append("Session", "", new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddSeconds(-1) });
            ViewData["cUser"] = new UserObject().SetEveryThingNull().ToString();
        }

        public IActionResult ViewStudent(string ID)
        {
            if (SessionManager.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                ViewData["cUser"] = user.ToString();

            }
            else LoginFailed();
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
