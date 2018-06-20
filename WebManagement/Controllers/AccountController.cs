using System;
using Microsoft.AspNetCore.Mvc;

using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;
namespace WBPlatform.WebManagement.Controllers
{
    public class AccountController : _Controller
    {
        public const string ControllerName = "Account";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                AIKnownUser(user);
                ViewData["cUser"] = user.ToString();
                return View(user);
            }
            else
            {
                AIUnknownUser();
                return _LoginFailed("/" + ControllerName);
            }
        }
        public IActionResult Register(string token, string user, string _action)
        {
            AIUnknownUser();
            ViewData["where"] = ControllerName;
            if (token != null && JumpTokens.OnAccessed(token, out JumpTokens.TokenInfo? info) && user == info?.WeChatUserName && (info?.User_Agent == "JumpToken_FreeLogin" || info?.User_Agent == Request.Headers["User-Agent"]))
            {
                ViewData["UserName"] = info?.WeChatUserName;
                ViewData["mode"] = _action;
                if (_action == "AddPassword")
                {

                    return View();
                }
                else if (_action == "changePassword")
                {
                    throw new NotImplementedException("Not Supported ChangePassword.... Go to Windows Client...");
                }
                else if (_action == "register")
                {

                    return View();
                }
                else
                {
                    return _OnInternalError(ServerSideAction.Home_UserRegister, ErrorType.RequestInvalid, "请求所带的参数无效", user + ":" + info?.WeChatUserName);
                }
            }
            return _OnInternalError(ServerSideAction.Home_UserRegister, ErrorType.RequestInvalid, DetailedInfo: "Token 超时或不存在，请重试", LoginUsr: user, ResponseCode: ErrorRespCode.RequestIllegal);
        }
        public IActionResult RequestChange()
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (Request.HasFormContentType)
                {
                    Microsoft.AspNetCore.Http.IFormCollection form = Request.Form;
                    UserChangeRequestTypes types = (UserChangeRequestTypes)Enum.Parse(typeof(UserChangeRequestTypes), form[nameof(UserChangeRequest.RequestTypes)][0]);
                    string reason = form[nameof(UserChangeRequest.DetailTexts)][0];
                    string newVal = form[nameof(UserChangeRequest.NewContent)][0];
                    UserChangeRequest request = new UserChangeRequest() { DetailTexts = reason, SolverID = "", NewContent = newVal, Status = UserChangeRequestProcessStatus.NotSolved, RequestTypes = types, UserID = user.objectId };
                    Database.DBOperations.CreateData(request, out string objectId);
                    request.objectId = objectId;
                    MessagingSystem.onChangeRequest_Created(request, user);
                    return Redirect($"/{HomeController.ControllerName}/{nameof(HomeController.requestResult)}?req=changereq&status=ok&callback=/Account/");
                }
                else
                {
                    AIKnownUser(user);
                    ViewData["cUser"] = user.ToString();
                    return View(new UserChangeRequest() { UserID = user.objectId });
                }
            }
            else
            {
                AIUnknownUser();
                return _LoginFailed("/" + ControllerName + "/RequestChange");
            }
        }

        public IActionResult LoginFailed()
        {
            AIUnknownUser();
            ViewData["where"] = HomeController.ControllerName;
            return View();
        }
    }
}
