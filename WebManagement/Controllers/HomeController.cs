using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public class HomeController : ViewController
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
                    return _InternalError(ServerSideAction.Home_Index, ErrorType.UserGroupError, "用户未经过验证，UserID = " + user.objectId, user.UserName, ErrorRespCode.NotSet);
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
            AIUnknownUser();
            ViewData["where"] = ControllerName;
            return View();
        }

        public IActionResult requestResult(string req, string status, string callback)
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                AIKnownUser(user);
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
            return _InternalError(ServerSideAction.INTERNAL_ERROR, ErrorType.INTERNAL_ERROR, "未知原因异常：异常汇报程序未提供任何内容", LoginUsr: "SYSTEM");
        }

        public IActionResult WeChatLogin(string state, string code)
        {
            AIUnknownUser();
            ViewData["where"] = ControllerName;
            if (string.IsNullOrEmpty(Request.Cookies["WB_WXLoginOption"]) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(code))
                return _InternalError(ServerSideAction.WeChatLogin_PreExecute, ErrorType.RequestInvalid, "微信请求状态异常，请重试请求", "WECHAT_LOGIN", ErrorRespCode.RequestIllegal);
            else
            {
                string Session = Sessions.LoginOrCreateUser_Core(code, Request.Headers["User-Agent"], out object user);
                if (string.IsNullOrEmpty(Session))
                    return _InternalError(ServerSideAction.WeChatLogin_PostExecute, ErrorType.INTERNAL_ERROR, DetailedInfo: "未获取到 Session 信息，请重试", LoginUsr: "WECHAT_LOGIN", ResponseCode: ErrorRespCode.InternalError);
                else if (Session == "0")
                {
                    string token = JumpTokens.CreateToken();
                    JumpTokens.TryAdd(token, new JumpTokenInfo(JumpTokenUsage.WeChatLogin, Request.Headers["User-Agent"], (string)user));
                    return Redirect($"/Account/Register?token={token}&user={(string)user}&_action=register");
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
