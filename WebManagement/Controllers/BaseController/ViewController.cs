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
        protected IActionResult LoginFailed(string RedirectPage)
        {

            Response.Cookies.Delete("Session");
            Response.Cookies.Append("LoginRedirect", RedirectPage, new CookieOptions() { Expires = DateTime.Now.AddMinutes(2) });
            return RedirectToAction("Index", HomeController.ControllerName);
        }

        protected IActionResult NotFoundError(ServerAction action, string item, ResponceCode respCode = ResponceCode.NotFound) => _InternalError(action, "未找到所需内容:\r\n" + item, respCode);
        protected IActionResult PermissionDenied(ServerAction action, string Reason, ResponceCode respCode = ResponceCode.PermisstionDenied) => _InternalError(action, "用户权限不足:\r\n" + Reason, respCode);
        protected IActionResult DatabaseError(ServerAction action, string Reason, ResponceCode respCode = ResponceCode.InternalServerError) => _InternalError(action, "数据库错误: \r\n" + Reason, respCode);
        protected IActionResult RequestIllegal(ServerAction action, string Reason, ResponceCode respCode = ResponceCode.RequestIllegal) => _InternalError(action, "请求不合法: \r\n" + Reason, respCode);
        protected IActionResult NotSupported(ServerAction action, string Reason, ResponceCode respCode = ResponceCode.NotSupported) => _InternalError(action, "不支持所选的操作: \r\n" + Reason, respCode);

        protected IActionResult Unknown_Error(ServerAction action) => _InternalError(action, "未知异常……", ResponceCode.InternalServerError);

        protected enum ResponceCode { RequestIllegal = 400, PermisstionDenied = 403, NotFound = 404, InternalServerError = 500, NotSupported = 501, Default = 200 }
        private IActionResult _InternalError(ServerAction action, string info, ResponceCode respCode)
        {
            string Page = "";//Response.HttpContext.Request.Scheme + "://" + Response.HttpContext.Request.Host + Response.HttpContext.Request.Path;
            Exception ex = HttpContext.Features.Get<ExceptionHandlerFeature>()?.Error;
            Page = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Path;

            info = info + "\r\n" + ex?.ToString();

            Response.StatusCode = (int)respCode;

            ViewData["where"] = HomeController.ControllerName;
            ViewData["DetailedInfo"] = respCode.ToString();
            ViewData["ErrorAT"] = action.ToString();
            ViewData["RespCode"] = Response.StatusCode.ToString();
            ViewData["ErrorMessage"] = info;
            ViewData["RAWResp"] = Page;

            WeChatSentMessage _Message = new WeChatSentMessage(WeChat.SentMessageType.text, null,
                "ERROR!" +
                "\r\nRQT:" + DateTime.Now.ToString() +
                "\r\nURL:" + ViewData["RAWResp"] +
                "\r\nCOE:" + Response.StatusCode +
                "\r\nMSG:" + ViewData["ErrorMessage"] +
                "\r\nUSR:" + CurrentUser.GetFullIdentity() +
                "\r\nSTK:" + ViewData["ErrorAT"] +
                "\r\nNFO:" + ViewData["DetailedInfo"], null, "liuhaoyu");

            LW.E(_Message.Content.Replace("\r\n", " -- "));

            if (respCode != ResponceCode.Default)
            {
                WeChatMessageSystem.AddToSendList(_Message);
            }
            return View("Error");
        }
    }
}
