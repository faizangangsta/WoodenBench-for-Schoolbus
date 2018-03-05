using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Models;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (SessionManager.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                Response.Redirect(Request.Scheme + "://" + Request.Host + "/Main/", false);
                return View();
            }
            else
            {
                string Stamp = DateTime.Now.TimeOfDay.TotalMilliseconds + ";WCLogin";
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?" +
                    "appid=wx68bec13e85ca6465" +
                    "&redirect_uri=" + Request.Scheme + "://" + Request.Host + "/Home/WeChatLogin" +
                    "&response_type=code" + "&scope=snsapi_uerinfo" + "&agentid=41" +
                    "&state=" + Stamp +
                    "#wechat_redirect";

                Response.Cookies.Append("WB_WXLoginOption", Stamp, new CookieOptions() { Path = "/", Expires = DateTimeOffset.Now.AddMinutes(2) });
                Response.Redirect(url, false);
                return View();
            }
        }
        public IActionResult WeChatLogin(string state, string code)
        {
            ViewData["result"] = false;
            if (string.IsNullOrEmpty(Request.Cookies["WB_WXLoginOption"]) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(code))
            {
                ViewData["Data"] = "Illegal Request";
                return View();
            }
            else
            {
                ViewData["code"] = code;
                string Session = SessionManager.OnWeChatCodeRcvd_Login(code, Request.Headers["User-Agent"], out object user);
                UserObject User = (UserObject)user;
                if (string.IsNullOrEmpty(Session))
                {
                    ViewData["Data"] = "Illegal Request";
                    return View();
                }
                else
                {
                    ViewData["result"] = true;
                    ViewData["Data"] = User.ToString();
                    Response.Cookies.Append("Session", Session, new CookieOptions() { Expires = DateTime.Now.AddDays(5) });
                    Response.Cookies.Append("WB_WXLoginOption", "", new CookieOptions() { Expires = DateTime.Now.AddSeconds(-1) });
                    ViewData["LogonUser"] = SimpleJson.SimpleJson.SerializeObject(User);
                    Response.Redirect(Request.Scheme + "://" + Request.Host + "/Main/");
                    return View();
                }
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}