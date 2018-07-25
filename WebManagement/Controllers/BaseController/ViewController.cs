using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using System;

using WBPlatform.StaticClasses;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public abstract class ViewController : BaseController
    {
        public abstract IActionResult Index();
        protected IActionResult _LoginFailed(string RedirectPage)
        {
            AISetUser();
            Response.Cookies.Delete("Session");
            Response.Cookies.Append("LoginRedirect", RedirectPage, new CookieOptions() { Expires = DateTime.Now.AddMinutes(2) });
            return RedirectToAction("Index", HomeController.ControllerName);
        }

        protected IActionResult _InternalError(ServerAction _Where, ErrorType _ErrorType, string DetailedInfo = "未提供错误信息", string LoginUsr = "用户未登录", ErrorRespCode ResponseCode = ErrorRespCode.NotSet)
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

            WeChatSentMessage _Message = new WeChatSentMessage(WeChat.SentMessageType.text, null,
                "ERROR!" +
                "\r\nRQT:" + DateTime.Now.ToString() +
                "\r\nURL:" + ViewData["RAWResp"] +
                "\r\nCOE:" + Response.StatusCode +
                "\r\nMSG:" + ViewData["ErrorMessage"] +
                "\r\nUSR:" + LoginUsr +
                "\r\nSTK:" + ViewData["ErrorAT"] +
                "\r\nNFO:" + ViewData["DetailedInfo"], null, "liuhaoyu");

            LW.E(_Message.Content.Replace("\r\n", " -- "));

            if (Response.StatusCode != 200)
            {
                WeChatMessageSystem.AddToSendList(_Message);
            }
            return View("Error");
        }
    }
}
