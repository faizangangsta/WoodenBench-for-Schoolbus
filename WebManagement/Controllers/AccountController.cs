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
            if (ValidateSession())
            {
                AISetUser();
                ViewData["cUser"] = CurrentUser.ToString();
                return View(CurrentUser);
            }
            else
            {
                AISetUser();
                return _LoginFailed("/" + ControllerName);
            }
        }
        public IActionResult Register(string token, string user, string _action)
        {
            AISetUser();
            ViewData["where"] = ControllerName;
            if (token != null && JumpTokens.OnAccessed(token, out JumpTokenInfo info)
                && user == info.UserID 
                && (info.User_Agent == "JumpToken_FreeLogin" || info.User_Agent == Request.Headers["User-Agent"]))
            {
                ViewData["UserName"] = info.UserID;
                ViewData["mode"] = _action;
                return _action == "AddPassword"
                    ? info.Usage == JumpTokenUsage.AddPassword
                        ? View()
                        : _InternalError(ServerAction.MyAccount_UserRegister, ErrorType.RequestInvalid, "Token用法不合法 " + info.UserID, info.UserID, ErrorRespCode.RequestIllegal)
                    : _action == "changePassword"
                        ? _InternalError(ServerAction.MyAccount_UserRegister, ErrorType.RequestInvalid, "小板凳微信平台现已不支持在线改密，请到Windows客户端更改密码", ResponseCode: ErrorRespCode.NotSet)
                        : _InternalError(ServerAction.MyAccount_UserRegister, ErrorType.RequestInvalid, "暂时不支持用户注册，请联系管理员进行操作", ResponseCode: ErrorRespCode.NotSet);
                //return _action == "register"
                //    ? View()
                //    : _InternalError(ServerSideAction.Home_UserRegister, ErrorType.RequestInvalid, "请求所带的参数无效", user + info?.UserID);

            }
            return _InternalError(ServerAction.MyAccount_UserRegister, ErrorType.RequestInvalid, DetailedInfo: "Token 超时或不存在，请重试", LoginUsr: user, ResponseCode: ErrorRespCode.RequestIllegal);
        }
        public IActionResult RequestChange()
        {
            ViewData["where"] = ControllerName;
            if (ValidateSession())
            {
                if (Request.HasFormContentType)
                {
                    Microsoft.AspNetCore.Http.IFormCollection form = Request.Form;
                    UserChangeRequestTypes types = (UserChangeRequestTypes)Enum.Parse(typeof(UserChangeRequestTypes), form[nameof(UserChangeRequest.RequestTypes)][0]);
                    string reason = form[nameof(UserChangeRequest.DetailTexts)][0];
                    string newVal = form[nameof(UserChangeRequest.NewContent)][0];
                    UserChangeRequest request = new UserChangeRequest() { DetailTexts = reason, SolverID = "", NewContent = newVal, Status = UCRProcessStatus.NotSolved, RequestTypes = types, UserID = CurrentUser.ObjectId };
                    if (DataBaseOperation.CreateData(ref request) != DBQueryStatus.ONE_RESULT)
                    {
                        LW.E("AccountController->ProcessNewUCR: Create UCR Failed!");
                    }

                    InternalMessage messageAdmin = new InternalMessage() { _Type = GlobalMessageTypes.UCR_Created_TO_ADMIN, DataObject = request, User = CurrentUser, ObjectId = request.ObjectId };
                    InternalMessage message_User = new InternalMessage() { _Type = GlobalMessageTypes.UCR_Created__TO_User, DataObject = request, User = CurrentUser, ObjectId = request.ObjectId };
                    MessagingSystem.AddMessageProcesses(messageAdmin, message_User);

                    return Redirect($"/{HomeController.ControllerName}/{nameof(HomeController.requestResult)}?req=changereq&status=ok&callback=/Account/");
                }
                else
                {
                    AISetUser();
                    ViewData["cUser"] = CurrentUser.ToString();
                    return View(new UserChangeRequest() { UserID = CurrentUser.ObjectId });
                }
            }
            else
            {
                AISetUser();
                return _LoginFailed("/" + ControllerName + "/RequestChange");
            }
        }

        public IActionResult LoginFailed()
        {
            AISetUser();
            ViewData["where"] = HomeController.ControllerName;
            return View();
        }
    }
}
