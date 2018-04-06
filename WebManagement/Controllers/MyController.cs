using System;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

using WBServicePlatform.StaticClasses;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    public abstract class _Controller : Controller
    {
        public abstract IActionResult Index();

        protected IActionResult _LoginFailed(string RedirectPage)
        {
            Response.Cookies.Delete("Session");
            Response.Cookies.Append("LoginRedirect", RedirectPage, new CookieOptions() { Expires = DateTime.Now.AddMinutes(2) });
            return RedirectToAction("LoginFailed", AccountController.ControllerName);
        }

        protected IActionResult _OnInternalError(ErrorAt _Where, ErrorType _ErrorType, string DetailedInfo = "未提供详细错误信息", string LoginUsr = "用户未登录", ErrorRespCode ResponseCode = ErrorRespCode.NotSet)
        {
            string Page = Response.HttpContext.Request.Scheme + "://" + Response.HttpContext.Request.Host + ((Frame)((DefaultHttpContext)Response.HttpContext).Features).RawTarget;
            Exception ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex != null)
                DetailedInfo = ex.InnerException == null ? ex.Message : ex.Message + ":::" + ex.InnerException.Message;

            Response.StatusCode = ResponseCode != ErrorRespCode.NotSet ? (int)ResponseCode : Response.StatusCode;
            ViewData["where"] = HomeController.ControllerName;
            ViewData["ErrorMessage"] = Response.StatusCode == 404 ? ErrorType.ItemsNotFound.ToString() : _ErrorType.ToString();
            ViewData["ErrorAT"] = _Where.ToString();
            ViewData["RespCode"] = Response.StatusCode.ToString();
            ViewData["DetailedInfo"] = DetailedInfo;
            ViewData["RAWResp"] = Page;
            WeChatMessage _Message = new WeChatMessage
            {
                MessageType = WeChat.RcvdMessageType._DEVELOPER_ERROR_REPORT,
                TextContent = "ERROR!" +
                "\r\nREQT:" + DateTime.Now.ToString() + "\r\n" +
                "\r\nPURL:" + ViewData["RAWResp"] + "\r\n" +
                "\r\nCODE:" + Response.StatusCode + "\r\n" +
                "\r\nEMSG:" + ViewData["ErrorMessage"] + "\r\n" +
                "\r\nLUSR:" + LoginUsr + "\r\n" +
                "\r\nSTCK:" + ViewData["ErrorAT"] + "\r\n" +
                "\r\nDNFO:" + ViewData["DetailedInfo"]
            };
            lock (WeChatMessageProc.MessageList) WeChatMessageProc.MessageList.Add(_Message);
            return View("Error");
        }
    }
}
