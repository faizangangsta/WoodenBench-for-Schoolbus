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

        protected IActionResult NotFoundError(ServerAction action, string item, ResponceCode respCode = ResponceCode.NotFound) => _InternalError(action, XConfig.Messages.NotFound + item, respCode);
        protected IActionResult PermissionDenied(ServerAction action, string Reason, ResponceCode respCode = ResponceCode.PermisstionDenied)
            => _InternalError(action, XConfig.Messages.UserPermissionDenied + Reason, respCode);

        protected IActionResult DatabaseError(ServerAction action, string Reason, ResponceCode respCode = ResponceCode.InternalServerError)
            => _InternalError(action, XConfig.Messages.DataBaseError + Reason, respCode);

        protected IActionResult RequestIllegal(ServerAction action, string Reason, ResponceCode respCode = ResponceCode.RequestIllegal)
            => _InternalError(action, XConfig.Messages.RequestIllegal + Reason, respCode);

        protected IActionResult NotSupported(ServerAction action, string Reason, ResponceCode respCode = ResponceCode.NotSupported)
            => _InternalError(action, XConfig.Messages.NotSupported + Reason, respCode);

        protected IActionResult Unknown_Error(ServerAction action) => _InternalError(action, XConfig.Messages.UnknownInternalException, ResponceCode.InternalServerError);

        protected enum ResponceCode { RequestIllegal = 400, PermisstionDenied = 403, NotFound = 404, InternalServerError = 500, NotSupported = 501, Default = 200 }

        private IActionResult _InternalError(ServerAction action, string info, ResponceCode respCode)
        {
            Exception ex = HttpContext.Features.Get<ExceptionHandlerFeature>()?.Error;
            string Page = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Path;

            info = info + "\r\n" + ex?.ToString();

            Response.StatusCode = Response.StatusCode == 404 ? 404 : (int)respCode;

            ViewData["where"] = HomeController.ControllerName;
            ViewData["DetailedInfo"] = respCode.ToString();
            ViewData["ErrorAT"] = action.ToString();
            ViewData["RespCode"] = Response.StatusCode.ToString();
            ViewData["ErrorMessage"] = info;
            ViewData["RAWResp"] = Page;

            string content = string.Join("\r\n",
                "Error Report:",
                DateTime.Now.ToNormalString(),
                CurrentUser.GetFullIdentity(),
                Response.StatusCode,
                ViewData["RAWResp"],
                ViewData["ErrorMessage"],
                ViewData["ErrorAT"],
                ViewData["DetailedInfo"]);

            WeChatSentMessage _Message = new WeChatSentMessage(WeChatSMsg.text, null, content, null, "liuhaoyu");

            LW.E(content.Replace("\r\n", " -- "));

            if (respCode != ResponceCode.Default)
                WeChatMessageSystem.AddToSendList(_Message);
            return View("Error");
        }
    }
}
