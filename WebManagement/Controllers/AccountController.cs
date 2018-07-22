using System;
using Microsoft.AspNetCore.Mvc;
using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;
namespace WBPlatform.WebManagement.Controllers
{
    public class AccountController : ViewController
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
            if (token != null && JumpTokens.OnAccessed(token, out JumpTokenInfo info) && user == info?.UserID && (info?.User_Agent == "JumpToken_FreeLogin" || info?.User_Agent == Request.Headers["User-Agent"]))
            {
                ViewData["UserName"] = info?.UserID;
                ViewData["mode"] = _action;
                if (_action == "AddPassword")
                {
                    return info.Usage == JumpTokenUsage.AddPassword
                        ? View()
                        : _InternalError(ServerAction.MyAccount_UserRegister, ErrorType.RequestInvalid, "Token用法不合法 " + info.UserID, info?.UserID, ErrorRespCode.RequestIllegal);
                }
                else
                {
                    return _action == "changePassword"
                        ? _InternalError(ServerAction.MyAccount_UserRegister, ErrorType.RequestInvalid, "小板凳微信平台现已不支持在线改密，请到Windows客户端更改密码", ResponseCode: ErrorRespCode.NotSet)
                        : _InternalError(ServerAction.MyAccount_UserRegister, ErrorType.RequestInvalid, "暂时不支持用户注册，请联系管理员进行操作", ResponseCode: ErrorRespCode.NotSet);
                }
                //return _action == "register"
                //    ? View()
                //    : _InternalError(ServerSideAction.Home_UserRegister, ErrorType.RequestInvalid, "请求所带的参数无效", user + info?.UserID);

            }
            return _InternalError(ServerAction.MyAccount_UserRegister, ErrorType.RequestInvalid, DetailedInfo: "Token 超时或不存在，请重试", LoginUsr: user, ResponseCode: ErrorRespCode.RequestIllegal);
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
                    UserChangeRequest request = new UserChangeRequest() { DetailTexts = reason, SolverID = "", NewContent = newVal, Status = UserChangeRequestProcessStatus.NotSolved, RequestTypes = types, UserID = user.ObjectId };
                    DataBaseOperation.CreateData(request, out UserChangeRequest _req);
                    request = _req;

                    InternalMessage messageAdmin = new InternalMessage() { _Type = GlobalMessageTypes.UCR_Created_TO_ADMIN, DataObject = request, User = user, ObjectId = request.ObjectId };
                    InternalMessage message_User = new InternalMessage() { _Type = GlobalMessageTypes.UCR_Created__TO_User, DataObject = request, User = user, ObjectId = request.ObjectId };
                    MessagingSystem.AddMessageProcesses(messageAdmin, message_User);

                    return Redirect($"/{HomeController.ControllerName}/{nameof(HomeController.requestResult)}?req=changereq&status=ok&callback=/Account/");
                }
                else
                {
                    AIKnownUser(user);
                    ViewData["cUser"] = user.ToString();
                    return View(new UserChangeRequest() { UserID = user.ObjectId });
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
