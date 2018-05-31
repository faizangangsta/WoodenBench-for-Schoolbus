using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

using System;
using System.Collections.Generic;

using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public abstract class _Controller : Controller, IInternalController
    {
        public abstract IActionResult Index();
        public HttpResponse procRespCookies(HttpResponse resp, string user, Dictionary<string, string> cookiePair)
        {
            if (cookiePair == null || cookiePair.Count == 0)
            {

            }
            else
            {
                foreach (KeyValuePair<string, string> item in cookiePair)
                {
                    resp.Cookies.Append(item.Key, item.Value);
                }
            }
            resp.Cookies.Append("identifiedUID", user);
            return resp;
        }

        protected IActionResult _LoginFailed(string RedirectPage)
        {
            AIUnknownUser();
            Response.Cookies.Delete("Session");
            Response.Cookies.Append("LoginRedirect", RedirectPage, new CookieOptions() { Expires = DateTime.Now.AddMinutes(2) });
            return RedirectToAction("LoginFailed", AccountController.ControllerName);
        }

        private static readonly string identifiedUID_CookieName = "identifiedUID";
        private static readonly string UnknownUID = "unknownUser";
        public void AIKnownUser(UserObject user) => Response.Cookies.Append(identifiedUID_CookieName, user.GetIdentifiableCode());
        public void AIUnknownUser() => Response.Cookies.Append(identifiedUID_CookieName, UnknownUID);

        protected IActionResult _OnInternalError(ServerSideAction _Where, ErrorType _ErrorType, string DetailedInfo = "未提供详细错误信息", string LoginUsr = "用户未登录", ErrorRespCode ResponseCode = ErrorRespCode.NotSet)
        {
            string Page = Response.HttpContext.Request.Scheme + "://" + Response.HttpContext.Request.Host + ((Frame)((DefaultHttpContext)Response.HttpContext).Features).RawTarget;
            Exception ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex != null) DetailedInfo = ex.InnerException == null ? ex.Message : ex.Message + ":::" + ex.InnerException.Message;

            Response.StatusCode = ResponseCode != ErrorRespCode.NotSet ? (int)ResponseCode : Response.StatusCode;
            ViewData["where"] = HomeController.ControllerName;
            ViewData["ErrorMessage"] = Response.StatusCode == 404 ? ErrorType.ItemsNotFound.ToString() : _ErrorType.ToString();
            ViewData["ErrorAT"] = _Where.ToString();
            ViewData["RespCode"] = Response.StatusCode.ToString();
            ViewData["DetailedInfo"] = DetailedInfo;
            ViewData["RAWResp"] = Page;
            BuildWeChatPacket(LoginUsr, ViewData, Response);
            return View("Error");
        }

        private static void BuildWeChatPacket(string LoginUsr, ViewDataDictionary ViewData, HttpResponse Response)
        {
            WeChatSentMessage _Message = new WeChatSentMessage(WeChat.SentMessageType.text, null,
                "ERROR!" +
                "\r\nREQT:" + DateTime.Now.ToString() + "\r\n" +
                "\r\nPURL:" + ViewData["RAWResp"] + "\r\n" +
                "\r\nCODE:" + Response.StatusCode + "\r\n" +
                "\r\nEMSG:" + ViewData["ErrorMessage"] + "\r\n" +
                "\r\nLUSR:" + LoginUsr + "\r\n" +
                "\r\nSTCK:" + ViewData["ErrorAT"] + "\r\n" +
                "\r\nDNFO:" + ViewData["DetailedInfo"], null, "liuhaoyu");
            WeChatMessageSystem.AddToSendList(_Message);
        }
    }
    public interface IInternalController
    {
        IActionResult Index();
    }
}
