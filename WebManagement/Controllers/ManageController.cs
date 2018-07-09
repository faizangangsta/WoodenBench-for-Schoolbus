using System;
using System.Collections.Generic;
using System.Text;
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
                    LW.E("Someone trying access illegal page!, Page: index, user:" + user.UserName + ", possible referer:" + Request.Headers["Referer"]);
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
        public IActionResult UserManage(string mode, string from, string uid, string msg)
        {
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (!user.UserGroup.IsAdmin)
                {
                    LW.E("Someone trying access illegal page!, Page: UserManage, user:" + user.UserName + ", possible referer:" + Request.Headers["Referer"]);
                    return NotFound();
                }
                ViewData["mode"] = mode;
                if (mode == "edit")
                {
                    ViewData["from"] = from;
                    string targetId = uid;
                    string message = Encoding.UTF8.GetString(Convert.FromBase64String(msg ?? ""));
                    if (DatabaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", uid), out UserObject _user) == DBQueryStatus.ONE_RESULT)
                    {
                        return View(_user);
                    }
                    else return _OnInternalError(ServerSideAction.INTERNAL_ERROR, ErrorType.DataBaseError, "暂时找不到URL中指定的用户", user.RealName, ErrorRespCode.NotSet);
                }
                else if (mode == "query")
                {
                    return View();
                }
                else
                {
                    throw new NotSupportedException("mode not supported!");
                }
            }
            else
            {
                return _LoginFailed($"/Manage/UserManage?mode={mode}&from={from}&uid={uid}&msg={msg}");
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
                                switch (DatabaseOperation.QueryMultipleData(new DBQuery().WhereEqualTo("UserID", user.objectId), out List<UserChangeRequest> requests))
                                {
                                    case DBQueryStatus.INTERNAL_ERROR:
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
                                switch (DatabaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("UserID", user.objectId).WhereEqualTo("objectId", reqId), out UserChangeRequest requests))
                                {
                                    case DBQueryStatus.INTERNAL_ERROR:
                                    case DBQueryStatus.NO_RESULTS:
                                    case DBQueryStatus.MORE_RESULTS:
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
                                LW.E("Someone trying access illegal page!, Page: changeRequest: arg=manage, user:" + user.UserName + ", possible referer:" + Request.Headers["Referer"]);
                                return NotFound();
                            }
                            if (string.IsNullOrEmpty(reqId))
                            {
                                switch (DatabaseOperation.QueryMultipleData(new DBQuery(), out List<UserChangeRequest> requests))
                                {
                                    case DBQueryStatus.INTERNAL_ERROR:
                                        return _OnInternalError(ServerSideAction.Manage_VerifyChangeRequest, ErrorType.INTERNAL_ERROR, "服务器异常：数据库查询出错", user.UserName);
                                    default:
                                        ViewData["list"] = requests.ToArray();
                                        return base.View();
                                }
                            }
                            else
                            {
                                switch (DatabaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", reqId), out UserChangeRequest requests))
                                {
                                    case DBQueryStatus.INTERNAL_ERROR:
                                    case DBQueryStatus.NO_RESULTS:
                                    case DBQueryStatus.MORE_RESULTS:
                                        return _OnInternalError(ServerSideAction.Manage_VerifyChangeRequest, ErrorType.INTERNAL_ERROR, "服务器异常：数据库查询出错", user.UserName);
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
