using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using System;
using System.Collections.Generic;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public class WebAPIController : Controller
    {
        public static Dictionary<string, string> SpecialisedInfo(string Message) => new Dictionary<string, string> { { "ErrCode", "0" }, { "ErrMessage", Message } };
        public static Dictionary<string, string> SessionError { get; } = new Dictionary<string, string> { { "ErrCode", "1" }, { "ErrMessage", "Session Invalid" } };
        public static Dictionary<string, string> DataBaseError { get; } = new Dictionary<string, string> { { "ErrCode", "995" }, { "ErrMessage", "Database Error" } };
        public static Dictionary<string, string> UserGroupError { get; } = new Dictionary<string, string> { { "ErrCode", "996" }, { "ErrMessage", "UserGroupError" } };
        public static Dictionary<string, string> InternalError { get; } = new Dictionary<string, string> { { "ErrCode", "997" }, { "ErrMessage", "Internal Error" } };
        public static Dictionary<string, string> SpecialisedError(string Message) => new Dictionary<string, string> { { "ErrCode", "998" }, { "ErrMessage", Message } };
        public static Dictionary<string, string> RequestIllegal { get; } = new Dictionary<string, string> { { "ErrCode", "999" }, { "ErrMessage", "Request Illegal" } };
    }

    public abstract class ViewController : Controller
    {
        private TelemetryClient telemetry = new TelemetryClient();
        public abstract IActionResult Index();
        protected IActionResult _LoginFailed(string RedirectPage)
        {
            AIUnknownUser();
            Response.Cookies.Delete("Session");
            Response.Cookies.Append("LoginRedirect", RedirectPage, new CookieOptions() { Expires = DateTime.Now.AddMinutes(2) });
            return RedirectToAction("Index", HomeController.ControllerName);
        }

        public static readonly string UID_CookieName = "identifiedUID";
        public static readonly string UnknownUID = "unknownUser";

        public void AIKnownUser(UserObject user)
        {
            telemetry.Context.User.AccountId = user.UserName;
            telemetry.Context.User.Id = user.UserName;
            ViewData[UID_CookieName] = user.GetIdentifiableCode();
        }

        public void AIUnknownUser()
        {
            ViewData[UID_CookieName] = UnknownUID;
        }

        protected IActionResult _InternalError(ServerSideAction _Where, ErrorType _ErrorType, string DetailedInfo = "未提供错误信息", string LoginUsr = "用户未登录", ErrorRespCode ResponseCode = ErrorRespCode.NotSet)
        {
            string Page = "";//Response.HttpContext.Request.Scheme + "://" + Response.HttpContext.Request.Host + Response.HttpContext.Request.Path;
            Exception ex = HttpContext.Features.Get<ExceptionHandlerFeature>()?.Error;
            Page = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Path;
            if (ex != null) DetailedInfo = ex.InnerException == null ? ex.Message : (ex.Message + ":::" + ex.InnerException.Message);

            Response.StatusCode = ResponseCode != ErrorRespCode.NotSet ? (int)ResponseCode : Response.StatusCode;
            ViewData["where"] = HomeController.ControllerName;
            ViewData["DetailedInfo"] = Response.StatusCode == 404 ? ErrorType.ItemsNotFound.ToString() : _ErrorType.ToString();
            ViewData["ErrorAT"] = _Where.ToString();
            ViewData["RespCode"] = Response.StatusCode.ToString();
            ViewData["ErrorMessage"] = DetailedInfo;
            ViewData["RAWResp"] = Page;
            WeChatSentMessage message = BuildWeChatPacket(LoginUsr, ViewData, Response);
            LW.E(message.Content.Replace("\r\n", " -- "));
            if (Response.StatusCode != 200)
            {
                WeChatMessageSystem.AddToSendList(message);
            }
            return View("Error");
        }

        private static WeChatSentMessage BuildWeChatPacket(string LoginUsr, ViewDataDictionary ViewData, HttpResponse Response)
        {
            WeChatSentMessage _Message = new WeChatSentMessage(WeChat.SentMessageType.text, null,
                "ERROR!" +
                "\r\nRQT:" + DateTime.Now.ToString() +
                "\r\nURL:" + ViewData["RAWResp"] +
                "\r\nCOE:" + Response.StatusCode +
                "\r\nMSG:" + ViewData["ErrorMessage"] +
                "\r\nUSR:" + LoginUsr +
                "\r\nSTK:" + ViewData["ErrorAT"] +
                "\r\nNFO:" + ViewData["DetailedInfo"], null, "liuhaoyu");
            return _Message;
        }
    }
}
