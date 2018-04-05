using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    public abstract class _Controller : Controller
    {
        public abstract IActionResult Index();

        protected IActionResult _LoginFailed(string ReDirectTo)
        {
            Response.Cookies.Delete("Session");
            Response.Cookies.Append("LoginRedirect", ReDirectTo, new CookieOptions() { Expires = DateTime.Now.AddMinutes(2) });
            return RedirectToAction("LoginFailed", AccountController.ControllerName);
        }

        protected IActionResult _OnInternalError(ErrorAt _Where, ErrorType _ErrorType, string DetailedInfo = "未提供详细错误信息", string LoginUsr = "用户未登录", ErrorRespCode ResponseCode = ErrorRespCode.NotSet)
        {
            string Page = Response.HttpContext.Request.Scheme + "://" + Response.HttpContext.Request.Host + ((Frame)((DefaultHttpContext)Response.HttpContext).Features).RawTarget;
            Exception ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex != null)
            {
                DetailedInfo = ex.Message;
                if (ex.InnerException != null)
                {
                    DetailedInfo = DetailedInfo + "\r\n" + ex.InnerException.Message;
                }
            }

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
                TextContent = "Error:" +
                "\r\n REQT: " + DateTime.Now.ToString() +
                "\r\n PURL: " + ViewData["RAWResp"] +
                "\r\n CODE: " + Response.StatusCode +
                "\r\n EMSG: " + ViewData["ErrorMessage"] +
                "\r\n LUSR: " + LoginUsr +
                "\r\n STCK: " + ViewData["ErrorAT"] +
                "\r\n DNFO: " + ViewData["DetailedInfo"]
                //"\r\n ErrThow: " + error.ToString() 
            };
            lock (WeChatMessageProc.MessageList)
            {
                WeChatMessageProc.MessageList.Add(_Message);
            }
            return View("Error");
        }
    }
}
