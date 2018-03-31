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

        protected IActionResult _OnInternalError(string _where, string ErrorMessage = "未知的异常", string DetailedInfo = "未提供详细错误信息", string LoginUsr = "用户未登录", ErrorRespCode ResponseCode = ErrorRespCode.NotSet)
        {
            string Page = Response.HttpContext.Request.Scheme + "://" + Response.HttpContext.Request.Host + ((Frame)((DefaultHttpContext)Response.HttpContext).Features).RawTarget;
            Exception ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            _where = _where ?? "未知调用栈";
            if (ex != null)
            {
                ErrorMessage = ex.Message;
                //_where = ex.StackTrace.Split('\r')[0];
                if (ex.InnerException != null)
                {
                    DetailedInfo = ex.InnerException.Message;
                }
            }

            Response.StatusCode = ResponseCode != ErrorRespCode.NotSet ? (int)ResponseCode : Response.StatusCode;
            ViewData["where"] = HomeController.ControllerName;
            ViewData["ErrorMessage"] = Response.StatusCode == 404 ? "系统找不到指定的文件" : ErrorMessage;
            ViewData["ErrorAT"] = _where;
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
        //protected IActionResult _OnInternalError() { return View("Error"); }
    }
}
