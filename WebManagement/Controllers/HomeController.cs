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
    public class HomeController : MyController
    {
        public const string ControllerName = "Home";
        public override IActionResult Index()
        {
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if ((user.UserGroup.IsBusManager || user.UserGroup.IsClassTeacher || user.UserGroup.IsParents || user.UserGroup.IsAdmin))
                {
                    if (Request.Cookies["LoginRedirect"] != null)
                    {
                        Response.Cookies.Delete("LoginRedirect");
                        return Redirect(Request.Cookies["LoginRedirect"]);
                    }
                    else return RedirectToAction("HomePage");
                }
                else
                {
                    return Redirect(Sessions.ErrorRedirectURL(MyError.N06_UserGroupError));
                }
            }
            else
            {
                string Stamp = DateTime.Now.TimeOfDay.TotalMilliseconds + ";WCLogin";
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?" +
                    "appid=" + WeChat.CorpID +
                    "&redirect_uri=" + Request.Scheme + "://" + Request.Host + "/Home/WeChatLogin" +
                    "&response_type=code&scope=snsapi_uerinfo&agentid=41" +
                    "&state=" + Stamp + "#wechat_redirect";
                Response.Cookies.Append("WB_WXLoginOption", Stamp, new CookieOptions() { Path = "/", Expires = DateTimeOffset.Now.AddMinutes(2) });
                return Redirect(url);
            }
        }

        public IActionResult ReportBugs()
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                ViewData["cUser"] = user.ToString();
                return View();
            }
            else return _LoginFailed("/" + ControllerName + "/ReportBugs");
        }

        public IActionResult HomePage()
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                return View();
            }
            else
            {
                return _LoginFailed("/" + ControllerName + "/HomePage");
            }
        }

        public IActionResult Register(string token)
        {
            ViewData["where"] = ControllerName;
            if (token == null) return Redirect(Sessions.ErrorRedirectURL(MyError.N07_NoDirectAccessError));
            string UA = "";
            lock (Sessions.JumpToken)
            {
                if (Sessions.JumpToken.ContainsKey(token))
                {
                    UA = Sessions.JumpToken[token];
                    Sessions.JumpToken.Remove(token);
                }
                else
                {
                    return Redirect(Sessions.ErrorRedirectURL(MyError.N07_NoDirectAccessError));
                }
            }

            if (UA != Request.Headers["User-Agent"].ToString()) return Redirect(Sessions.ErrorRedirectURL(MyError.N07_NoDirectAccessError));
            return View();
        }

        public IActionResult WeChatLogin(string state, string code)
        {
            ViewData["where"] = ControllerName;
            if (string.IsNullOrEmpty(Request.Cookies["WB_WXLoginOption"]) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(code))
                return Redirect(Sessions.ErrorRedirectURL(MyError.N08_WeChatLoginRequestError));
            else
            {
                string Session = Sessions.OnWeChatCodeRcvd_Login(code, Request.Headers["User-Agent"], out object user);
                UserObject User = (UserObject)user;
                if (string.IsNullOrEmpty(Session))
                    return Redirect(Sessions.ErrorRedirectURL(MyError.N09_WeChatLoginResponceError));
                else if (Session == "0")
                {
                    string token = Crypto.RandomString(10, false);
                    lock (Sessions.JumpToken)
                    {
                        Sessions.JumpToken.TryAdd(token, Request.Headers["User-Agent"]);
                    }
                    return RedirectToAction(nameof(Register), ControllerName, "token=" + token);
                }
                else
                {
                    Response.Cookies.Append("Session", Session, new CookieOptions() { Expires = DateTime.Now.AddHours(4) });
                    Response.Cookies.Delete("WB_WXLoginOption");
                    return RedirectToAction(nameof(HomeController.Index), ControllerName);
                }
            }
        }


        public IActionResult Error(int err, string errmsg)
        {
            ViewData["where"] = ControllerName;
            errmsg = errmsg == "" ? null : errmsg;
            try
            {
                MyError error = (MyError)err;
                ViewData["errmsg"] = errmsg;
                return View(new ErrorViewModel(Response, error).SetProperty((Activity.Current?.Id ?? "后台处理程序没有提供当前请求ID"), errmsg ?? "后台处理程序没有提供错误说明"));
            }
            catch (Exception ex)
            {
                Response.WriteAsync(ex.Message);
                return null;
            }
        }
    }
}