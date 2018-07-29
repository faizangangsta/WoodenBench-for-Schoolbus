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
                if (CurrentUser.UserGroup.AnyThing)
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
                    return RequestIllegal(ServerAction.Home_Index, "用户未经过验证，用户ID = " + CurrentUser.ObjectId, ResponceCode.Default);
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

        public IActionResult RequestResult(string req, string status, string callback)
        {
            ViewData["where"] = ControllerName;
            if (ValidateSession())
            {

                ViewData["req"] = req;
                ViewData["status"] = status;
                ViewData["callback"] = callback;
                return View();
            }
            else
            {

                return LoginFailed(callback);
            }
        }

        public IActionResult Error()
        {
            return Unknown_Error(ServerAction.INTERNAL_ERROR);
        }

        public IActionResult WeChatLogin(string state, string code)
        {

            ViewData["where"] = ControllerName;
            if (string.IsNullOrEmpty(Request.Cookies["WB_WXLoginOption"]) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(code))
                return RequestIllegal(ServerAction.WeChatLogin_PreExecute, "微信请求状态异常，请重试请求");
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
                        return DatabaseError(ServerAction.WeChatLogin_PostExecute, "数据库内部异常", ResponceCode.InternalServerError);

                    case DBQueryStatus.NO_RESULTS:
                        string token = ExecuteOnceTicket.CreateToken();
                        ExecuteOnceTicket.TryAdd(token, new TicketInfo(TicketUsage.UserRegister, Request.Headers["User-Agent"], WeiXinID));
                        return Redirect($"/Account/Register?token={token}&user={WeiXinID}&_action=register");

                    case DBQueryStatus.ONE_RESULT:
                        UpdateUser(User);
                        Response.Cookies.Delete("WB_WXLoginOption");
                        return Redirect("/Home/Index/");

                    default:
                        LW.E("HomeController: Unexpected Database Query Result for WeChatLogin...");
                        return DatabaseError(ServerAction.WeChatLogin_PostExecute, "数据库返回了错误信息");
                }
            }
        }
    }
}

