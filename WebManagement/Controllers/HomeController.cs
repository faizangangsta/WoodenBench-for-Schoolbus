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
                    return RequestIllegal(ServerAction.Home_Index, XConfig.Messages["UserAccoutNotVerified_With_UserID"] + CurrentUser.ObjectId, ResponceCode.Default);
                }
            }
            else
            {
                string ticket = ExecuteOnceTicket.CreateTicket();
                string Stamp = ticket + ";WCLogin";
                string url = string.Join("", "https://open.weixin.qq.com/connect/oauth2/authorize?",
                    "appid=", XConfig.Current.WeChat.CorpID,
                    "&redirect_uri=", Request.Scheme, "://" + Request.Host, "/Home/WeChatLogin",
                    "&response_type=code" +
                    "&scope=snsapi_uerinfo" +
                    "&agentid=", XConfig.Current.WeChat.AgentId,
                    "&state=", Stamp, "#wechat_redirect");
                Response.Cookies.Append("WB_WXLoginOption", Stamp, new CookieOptions() { Path = "/", Expires = DateTimeOffset.Now.AddMinutes(2) });
                ExecuteOnceTicket.TryAdd(ticket, new TicketInfo(TicketUsage.WeChatLogin, Request.Headers["User-Agent"], "WeChat_Login"));
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
                return RequestIllegal(ServerAction.WeChatLogin_PreExecute, XConfig.Messages["WeChatRequestStatusUnexcepted"]);
            else
            {
                WeChatHelper.ReNewWCCodes();
                //object LogonUser = null;
                Dictionary<string, string> JSON = PublicTools.HTTPGet("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + WeChatHelper.AccessToken + "&code=" + code);
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
                        return DatabaseError(ServerAction.WeChatLogin_PostExecute, XConfig.Messages["InternalDataBaseError"]);

                    case DBQueryStatus.NO_RESULTS:
                        string token = ExecuteOnceTicket.CreateTicket();
                        ExecuteOnceTicket.TryAdd(token, new TicketInfo(TicketUsage.UserRegister, Request.Headers["User-Agent"], WeiXinID));
                        return Redirect($"/Account/Register?token={token}&user={WeiXinID}&_action=register");

                    case DBQueryStatus.ONE_RESULT:
                        UpdateUser(User);
                        Response.Cookies.Delete("WB_WXLoginOption");
                        return Redirect("/Home/Index/");

                    default:
                        LW.E("HomeController: Unexpected Database Query Result for WeChatLogin...");
                        return DatabaseError(ServerAction.WeChatLogin_PostExecute, XConfig.Messages["WrongDataReturnedFromDatabase"]);
                }
            }
        }
    }
}

