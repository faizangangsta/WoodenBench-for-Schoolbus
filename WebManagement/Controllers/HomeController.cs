using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBPlatform.Database;
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
            if (ValidateSession())
            {
                AISetUser();
                if (CurrentUser.UserGroup.IsBusManager || CurrentUser.UserGroup.IsClassTeacher || CurrentUser.UserGroup.IsParent || CurrentUser.UserGroup.IsAdmin)
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
                    return _InternalError(ServerAction.Home_Index, ErrorType.UserGroupError, "用户未经过验证，UserID = " + CurrentUser.ObjectId, CurrentUser.UserName, ErrorRespCode.NotSet);
                }
            }
            else
            {
                AISetUser();
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
            AISetUser();
            ViewData["where"] = ControllerName;
            return View();
        }

        public IActionResult requestResult(string req, string status, string callback)
        {
            ViewData["where"] = ControllerName;
            if (ValidateSession())
            {
                AISetUser();
                ViewData["req"] = req;
                ViewData["status"] = status;
                ViewData["callback"] = callback;
                return View();
            }
            else
            {
                AISetUser();
                return _LoginFailed(callback);
            }
        }

        public IActionResult Error()
        {
            AISetUser();
            return _InternalError(ServerAction.INTERNAL_ERROR, ErrorType.INTERNAL_ERROR, "未知原因异常：异常汇报程序未提供任何内容", LoginUsr: "SYSTEM");
        }

        public IActionResult WeChatLogin(string state, string code)
        {
            AISetUser();
            ViewData["where"] = ControllerName;
            if (string.IsNullOrEmpty(Request.Cookies["WB_WXLoginOption"]) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(code))
                return _InternalError(ServerAction.WeChatLogin_PreExecute, ErrorType.RequestInvalid, "微信请求状态异常，请重试请求", "WECHAT_LOGIN", ErrorRespCode.RequestIllegal);
            else
            {
                WeChat.ReNewWCCodes();
                //object LogonUser = null;
                Dictionary<string, string> JSON = PublicTools.HTTPGet("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + WeChat.AccessToken + "&code=" + code);
                if (!JSON.ContainsKey("UserId"))
                {
                    LW.E("WeChat JSON doesnot Contain: UserID, " + JSON.ToParsedString());
                    return null;
                }
                string WeiXinID = JSON["UserId"];
                switch (DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("Username", WeiXinID), out UserObject User))
                {
                    case DBQueryStatus.INTERNAL_ERROR:
                        LW.E("SessionManager: Failed to get User by its UserName --> DataBase Inernal Error....");
                        return _InternalError(ServerAction.WeChatLogin_PostExecute, ErrorType.INTERNAL_ERROR, DetailedInfo: "未获取到 Session 信息，请重试", LoginUsr: "WECHAT_LOGIN", ResponseCode: ErrorRespCode.InternalError);

                    case DBQueryStatus.NO_RESULTS:
                        string token = JumpTokens.CreateToken();
                        JumpTokens.TryAdd(token, new JumpTokenInfo(JumpTokenUsage.WeChatLogin, Request.Headers["User-Agent"], WeiXinID));
                        return Redirect($"/Account/Register?token={token}&user={WeiXinID}&_action=register");

                    case DBQueryStatus.ONE_RESULT:
                        UpdateUser(User);
                        Response.Cookies.Delete("WB_WXLoginOption");
                        return Redirect("/Home/Index/");

                    default:
                        LW.E("HomeController: Unexpected Database Query Result for WeChatLogin...");
                        return _InternalError(ServerAction.WeChatLogin_PostExecute, ErrorType.DataBaseError, "数据库返回了错误信息", ResponseCode: ErrorRespCode.InternalError);
                }
            }
        }
    }
}

