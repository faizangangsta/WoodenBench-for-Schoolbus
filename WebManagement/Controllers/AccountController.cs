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
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (Request.HasFormContentType)
                {
                    Microsoft.AspNetCore.Http.IFormCollection form = Request.Form;
                    string userID = Request.Cookies["userID"].Split('-')[1];
                    string userName = Request.Cookies["userID"].Split('-')[0];
                    UserChangeRequestTypes types = (UserChangeRequestTypes)Enum.Parse(typeof(UserChangeRequestTypes), form[nameof(UserChangeRequest.RequestTypes)][0]);
                    string reason = form[nameof(UserChangeRequest.DetailTexts)][0];
                    string newVal = form[nameof(UserChangeRequest.NewContent)][0];
                    UserChangeRequest request = new UserChangeRequest() { DetailTexts = reason, NewContent = newVal, IsSolved = false, RequestTypes = types, UserID = userID };
                    Databases.Database.CreateData(request);
                    MessagingSystem.onChangeRequest_Created();
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
