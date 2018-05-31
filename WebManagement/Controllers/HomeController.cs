using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public class HomeController : _Controller
    {
        public const string ControllerName = "Home";
        public override IActionResult Index()
        {
            ViewData["where"] = "Home";
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                AIKnownUser(user);
                if ((user.UserGroup.IsBusManager || user.UserGroup.IsClassTeacher || user.UserGroup.IsParent || user.UserGroup.IsAdmin))
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
                    return _OnInternalError(ServerSideAction.Home_Index, ErrorType.UserGroupError, "Home_MainMenu::UserGroupInvalid", user.UserName, ErrorRespCode.PermisstionDenied);
                }
            }
            else
            {
                AIUnknownUser();
                string Stamp = DateTime.Now.TimeOfDay.TotalMilliseconds + ";WCLogin";
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?" +
                    "appid=" + WeChat.CorpID +
                    "&redirect_uri=" + Request.Scheme + "://" + Request.Host + "/Home/WeChatLogin" +
                    "&response_type=code&scope=snsapi_uerinfo&agentid=41" +
                    "&state=" + Stamp + "#wechat_redirect";
                Response.Cookies.Append("WB_WXLoginOption", Stamp, new CookieOptions() { Path = "/", Expires = DateTimeOffset.Now.AddMinutes(2) });
                //procRespCookies(Response, "unlogonUser", null);
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

        public IActionResult requestResult(string req, string status, string callback)
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                ViewData["req"] = req;
                ViewData["status"] = status;
                ViewData["callback"] = callback;
                return View();
            }
            else
            {
                AIUnknownUser();
                return _LoginFailed(callback);
            }
        }

        public IActionResult Error()
        {
            return _OnInternalError(ServerSideAction.INTERNAL_ERROR, ErrorType.INTERNAL_ERROR, LoginUsr: "SYSTEM");
        }

        public IActionResult Register(string token, string user, string action)
        {
            AIUnknownUser();
            ViewData["where"] = ControllerName;
            if (token == null || Request.Cookies["Token"] == null) return _OnInternalError(ServerSideAction.Home_UserRegister, ErrorType.RequestInvalid, "TokenInvalid", "REGISTER", ErrorRespCode.RequestIllegal);
            if (JumpTokens.OnAccessed(token, out JumpTokens.TokenInfo? info) && (info?.User_Agent == Request.Headers["User-Agent"]))
            {
                ViewData["UserName"] = info?.WeChatUserName;
                return View();
            }
            return _OnInternalError(ServerSideAction.Home_UserRegister, ErrorType.RequestInvalid, "TokenInvalid", "REGISTER", ErrorRespCode.RequestIllegal);
        }

        public IActionResult WeChatLogin(string state, string code)
        {
            AIUnknownUser();
            ViewData["where"] = ControllerName;
            if (string.IsNullOrEmpty(Request.Cookies["WB_WXLoginOption"]) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(code))
                return _OnInternalError(ServerSideAction.WeChatLogin_PreExecute, ErrorType.RequestInvalid, "Login State Seems Strange", "WECHAT_LOGIN", ErrorRespCode.RequestIllegal);
            else
            {
                string Session = Sessions.OnWeChatCodeRcvd_Login(code, Request.Headers["User-Agent"], out object user);
                if (string.IsNullOrEmpty(Session))
                    return _OnInternalError(ServerSideAction.WeChatLogin_PostExecute, ErrorType.INTERNAL_ERROR, DetailedInfo: "UNKNOWN ERROR", LoginUsr: "WECHAT_LOGIN", ResponseCode: ErrorRespCode.InternalError);
                else if (Session == "0")
                {
                    string token = JumpTokens.CreateToken(); 
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