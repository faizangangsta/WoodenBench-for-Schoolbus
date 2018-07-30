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

                ViewData["cUser"] = CurrentUser.ToString();
                return View(CurrentUser);
            }
            else
            {

                return LoginFailed("/" + ControllerName);
            }
        }
        public IActionResult Register(string token, string user, string _action)
        {
            ViewData["where"] = ControllerName;
            if (token != null && ExecuteOnceTicket.OnAccessed(token, out TicketInfo info)
                && user == info.UserID
                && info.Usage == TicketUsage.UserRegister
                && (info.User_Agent == "JumpToken_FreeLogin" || info.User_Agent == Request.Headers["User-Agent"]))
            {
                ViewData["UserName"] = info.UserID;
                ViewData["mode"] = _action;
                return _action == "AddPassword"
                    ? info.Usage == TicketUsage.AddPassword
                        ? View()
                        : RequestIllegal(ServerAction.MyAccount_UserRegister, XConfig.Messages["TokenUsageInvalid"] + info.UserID)
                    : _action == "changePassword"
                        ? NotSupported(ServerAction.MyAccount_UserRegister, XConfig.Messages["NotSupportedOnlinePswdChange_GotoWinClient"])
                        : NotSupported(ServerAction.MyAccount_UserRegister, XConfig.Messages["NotSupportedUserRegister_ContactAdmin"]);
                //return _action == "register"
                //    ? View()
                //    : _InternalError(ServerSideAction.Home_UserRegister, "请求所带的参数无效", user + info?.UserID);

            }
            return RequestIllegal(ServerAction.MyAccount_UserRegister, XConfig.Messages["TokenTimeout"]);
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
                    UserChangeRequest request = new UserChangeRequest()
                    {
                        DetailTexts = reason,
                        SolverID = "",
                        NewContent = newVal,
                        Status = UCRProcessStatus.NotSolved,
                        RequestTypes = types,
                        UserID = CurrentUser.ObjectId
                    };

                    if (DataBaseOperation.CreateData(ref request) != DBQueryStatus.ONE_RESULT)
                    {
                        LW.E("AccountController->ProcessNewUCR: Create UCR Failed!");
                        return DatabaseError(ServerAction.MyAccount_CreateChangeRequest, XConfig.Messages["CreateUCR_Failed"]);
                    }

                    InternalMessage messageAdmin = new InternalMessage() { _Type = GlobalMessageTypes.UCR_Created_TO_ADMIN, DataObject = request, User = CurrentUser, ObjectId = request.ObjectId };
                    InternalMessage message_User = new InternalMessage() { _Type = GlobalMessageTypes.UCR_Created__TO_User, DataObject = request, User = CurrentUser, ObjectId = request.ObjectId };
                    MessagingSystem.AddMessageProcesses(messageAdmin, message_User);

                    return Redirect($"/{HomeController.ControllerName}/{nameof(HomeController.RequestResult)}?req=changereq&status=ok&callback=/Account/");
                }
                else
                {

                    ViewData["cUser"] = CurrentUser.ToString();
                    return View(new UserChangeRequest() { UserID = CurrentUser.ObjectId });
                }
            }
            else
            {

                return LoginFailed("/" + ControllerName + "/" + nameof(RequestChange));
            }
        }

        public IActionResult LoginFailed()
        {

            ViewData["where"] = HomeController.ControllerName;
            return View();
        }
    }
}
