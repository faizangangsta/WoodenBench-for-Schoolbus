using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class HomeController : _Controller
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
                    else return View();
                }
                else
                {
                    Response.Cookies.Delete("Session");
                    return _OnInternalError("Home/Index", "用户组权限异常", "Home_MainMenu::UserGroupInvalid", user.WeChatID, ErrorRespCode.PermisstionDenied);
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

        /// <summary>
        /// Don't Check Login in BugReport
        /// the user may experience LOGIN ERROR.......
        /// </summary>
        /// <returns>Bug Report Form </returns> 
        public IActionResult ReportBugs()
        {
            ViewData["where"] = ControllerName;
            return View();
        }

        public IActionResult Error()
        {
            return _OnInternalError(null);
        }

        public IActionResult Register(string token, string user, string action)
        {
            ViewData["where"] = ControllerName;
            if (token == null || Request.Cookies["Token"] == null) return _OnInternalError("Register", "请求非法", "TokenInvalid", "REGISTER", ErrorRespCode.RequestIllegal);
            if (JumpTokens.OnAccessed(token, out JumpTokens.TokenInfo? info) && (info?.User_Agent == Request.Headers["User-Agent"]))
            {
                ViewData["wechatID"] = info?.WeChatUserName;
                return View();
            }
            return _OnInternalError("Register", "请求非法", "TokenInvalid", "REGISTER", ErrorRespCode.RequestIllegal);
        }

        public IActionResult WeChatLogin(string state, string code)
        {
            ViewData["where"] = ControllerName;
            if (string.IsNullOrEmpty(Request.Cookies["WB_WXLoginOption"]) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(code))
                return _OnInternalError("WeChatLogin", "微信登陆请求非法", "Login State Seems Strange", "WECHAT_LOGIN", ErrorRespCode.RequestIllegal);
            else
            {
                string Session = Sessions.OnWeChatCodeRcvd_Login(code, Request.Headers["User-Agent"], out object user);
                if (string.IsNullOrEmpty(Session))
                    return _OnInternalError("WeChatLogin", "微信登陆请求出现未知异常", "UNKNOWN ERROR", "WECHAT_LOGIN", ErrorRespCode.InternalError);
                else if (Session == "0")
                {
                    string token = Crypto.SHA512Encrypt(Crypto.RandomString(20, true));
                    JumpTokens.TryAdd(token, new JumpTokens.TokenInfo() { User_Agent = Request.Headers["User-Agent"], WeChatUserName = (string)user });
                    Response.Cookies.Append("Token", token);
                    return Redirect($"/Home/Register?token={token}&user=&action=register");
                }
                else
                {
                    Response.Cookies.Append("Session", Session, new CookieOptions() { Expires = DateTime.Now.AddHours(4) });
                    Response.Cookies.Delete("WB_WXLoginOption");
                    return Redirect("/Home/Index/");
                }
            }
        }
    }
}