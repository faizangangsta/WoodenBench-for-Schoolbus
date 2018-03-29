using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.WebManagement.Models;
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
        protected IActionResult _OnInternalError(MyError error, string errmsg = null)
        {
            switch (error)
            {
                case MyError.N01_InternalError:
                case MyError.N11_Server5xxError:
                case MyError.N99_UnknownError:
                    Response.StatusCode = 500;
                    break;
                case MyError.N03_ItemsNotFoundError:
                case MyError.N10_Normal404Error:
                    Response.StatusCode = 404;
                    break;
                case MyError.N05_PermissionDeniedError:
                case MyError.N04_RequestIllegalError:
                case MyError.N06_UserGroupError:
                    Response.StatusCode = 403;
                    break;
                case MyError.N07_NoDirectAccessError:
                    Response.StatusCode = 400;
                    break;
            }
            ViewData["where"] = HomeController.ControllerName;
            errmsg = errmsg == "" ? null : errmsg;
            ViewData["errmsg"] = errmsg;
            WeChatMessage errorMessage = new WeChatMessage();
            errorMessage.MessageType = WeChat.RcvdMessageType._DEVELOPER_ERROR_REPORT;
            errorMessage.TextContent = "Error:" +
                "\r\n Request: " + Request.Path + Request.QueryString.Value +
                "\r\n Session: " + Request.Cookies["Session"] +
                "\r\n ReqTime: " + DateTime.Now.ToString() + 
                "\r\n ReqUser: " + "NOT SUPPORT";
            lock (WeChatMessageProc.MessageList)
            {
                WeChatMessageProc.MessageList.Add(errorMessage);
            }
            return View("Error", new ErrorViewModel(Response, error).SetProperty((Activity.Current?.Id ?? "后台处理程序没有提供当前请求ID"), errmsg ?? "后台处理程序没有提供错误说明"));

        }
    }
}
