using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;
namespace WBPlatform.WebManagement.Controllers
{
    public class ManageController : _Controller
    {
        public const string ControllerName = "Manage";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (!user.UserGroup.IsAdmin)
                {
                    LogWritter.ErrorMessage("Someone trying access illegal page!, Page: index, user:" + user.UserName + ", possible referer:" + Request.Headers["Referer"]);
                    return NotFound();
                }
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
        public IActionResult ChangeRequest(string arg, string reqId)
        {
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                AIKnownUser(user);
                if (!string.IsNullOrEmpty(arg))
                {
                    switch (arg)
                    {
                        case "my":
                            ViewData["mode"] = "my";
                            ViewData["where"] = AccountController.ControllerName;
                            if (string.IsNullOrEmpty(reqId))
                            {
                                // MY LIST
                                switch (Database.Database.QueryMultipleData(new DBQuery().WhereEqualTo("UserID", user.objectId), out List<UserChangeRequest> requests))
                                {
                                    case DatabaseOperationResult.INTERNAL_ERROR:
                                        return _OnInternalError(ServerSideAction.General_ViewChangeRequests, ErrorType.INTERNAL_ERROR, "服务器异常：数据库查询出错", user.UserName);
                                    default:
                                        ViewData["count"] = requests.Count;
                                        ViewData["list"] = requests.ToArray();
                                        return base.View();
                                }
                            }
                            else
                            {
                                // MY SINGLE Viewer
                                switch (Database.Database.QuerySingleData(new DBQuery().WhereEqualTo("UserID", user.objectId).WhereEqualTo("objectId", reqId), out UserChangeRequest requests))
                                {
                                    case DatabaseOperationResult.INTERNAL_ERROR:
                                    case DatabaseOperationResult.NO_RESULTS:
                                    case DatabaseOperationResult.MORE_RESULTS:
                                        return _OnInternalError(ServerSideAction.General_ViewChangeRequests, ErrorType.INTERNAL_ERROR, "服务器异常：数据库查询出错", user.UserName);
                                    default:
                                        return base.View(requests);
                                }
                            }
                        case "manage":
                            ViewData["where"] = ControllerName;
                            ViewData["mode"] = "manage";
                            if (!user.UserGroup.IsAdmin)
                            {
                                LogWritter.ErrorMessage("Someone trying access illegal page!, Page: changeRequest: arg=manage, user:" + user.UserName + ", possible referer:" + Request.Headers["Referer"]);
                                return NotFound();
                            }
                            if (string.IsNullOrEmpty(reqId))
                            {
                                switch (Database.Database.QueryMultipleData(new DBQuery().WhereEqualTo("objectId", null), out List<UserChangeRequest> requests))
                                {
                                    case DatabaseOperationResult.INTERNAL_ERROR:
                                        return _OnInternalError(ServerSideAction.General_ViewChangeRequests, ErrorType.INTERNAL_ERROR, "服务器异常：数据库查询出错", user.UserName);
                                    default:
                                        {
                                            ViewData["list"] = requests.ToArray();
                                            return base.View();
                                        }
                                }
                            }
                            else
                            {
                                switch (Database.Database.QuerySingleData(new DBQuery().WhereEqualTo("objectId", reqId), out UserChangeRequest requests))
                                {
                                    case DatabaseOperationResult.INTERNAL_ERROR:
                                    case DatabaseOperationResult.NO_RESULTS:
                                    case DatabaseOperationResult.MORE_RESULTS:
                                        return _OnInternalError(ServerSideAction.General_ViewChangeRequests, ErrorType.INTERNAL_ERROR, "服务器异常：数据库查询出错", user.UserName);
                                    default:
                                        return base.View(requests);
                                }
                            }
                        default:
                            return _OnInternalError(ServerSideAction.General_ViewChangeRequests, ErrorType.RequestInvalid, "请求异常：参数错误", user.UserName);
                    }
                }
                else
                {
                    return _OnInternalError(ServerSideAction.General_ViewChangeRequests, ErrorType.RequestInvalid, "请求异常：参数错误", user.UserName);
                }
            }
            else
            {
                AIUnknownUser();
                return _LoginFailed("/" + ControllerName + "/ChangeRequest?arg=" + arg + "&reqId=" + reqId);
            }
        }
    }
}
