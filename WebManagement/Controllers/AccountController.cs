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
        
        public IActionResult RequestChange()
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (Request.HasFormContentType)
                {
                    Microsoft.AspNetCore.Http.IFormCollection form = Request.Form;
                    string userID = Request.Cookies["userID"].Split('-')[1];
                    string userName = Request.Cookies["userID"].Split('-')[0];
                    if (user.objectId != userID && userName != user.UserName)
                    {
                        return _OnInternalError(ServerSideAction.MyAccount_CreateChangeRequest, ErrorType.RequestInvalid, "你的Cookie信息包含异常内容", user.UserName, ErrorRespCode.NotSet);
                    }
                    UserChangeRequestTypes types = (UserChangeRequestTypes)Enum.Parse(typeof(UserChangeRequestTypes), form[nameof(UserChangeRequest.RequestTypes)][0]);
                    string reason = form[nameof(UserChangeRequest.DetailTexts)][0];
                    string newVal = form[nameof(UserChangeRequest.NewContent)][0];
                    UserChangeRequest request = new UserChangeRequest() { DetailTexts = reason, SolverID = "", NewContent = newVal, HasProcessed = false, RequestTypes = types, UserID = userID };
                    Databases.Database.CreateData(request, out string objectId);
                    request.objectId = objectId;
                    MessagingSystem.onChangeRequest_Created(request, user);
                    return Redirect($"/{HomeController.ControllerName}/{nameof(HomeController.requestResult)}?req=changereq&status=ok&callback=/Account/");
                }
                else
                {
                    AIKnownUser(user);
                    ViewData["cUser"] = user.ToString();
                    Response.Cookies.Append("userID", user.GetIdentifiableCode());
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
            ViewData["Message"] = "登陆失败";
            return View();
        }
    }
}
