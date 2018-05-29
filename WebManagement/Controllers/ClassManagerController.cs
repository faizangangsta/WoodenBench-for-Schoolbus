using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public class ClassManagerController : _Controller
    {
        public const string ControllerName = "ClassManager";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, user.GetIdentifiableCode());
                if (user.UserGroup.IsClassTeacher)
                {
                    switch (Database.QueryMultipleData(new DatabaseQuery().WhereEqualTo("objectId", user.ClassList[0]), out List<ClassObject> ClassList))
                    {
                        case DatabaseQueryResult.INTERNAL_ERROR: return _OnInternalError(ServerSideAction.MyClass_Index, ErrorType.DataBaseError, "Internal Error", user.UserName, ErrorRespCode.InternalError);
                        case DatabaseQueryResult.NO_RESULTS: return _OnInternalError(ServerSideAction.MyClass_Index, ErrorType.ItemsNotFound, "None of your class found", user.UserName);
                        default:
                            ViewData["ClassName"] = ClassList[0].CDepartment + " " + ClassList[0].CGrade + " " + ClassList[0].CNumber;
                            ViewData["ClassID"] = ClassList[0].objectId;
                            ViewData["cUser"] = user.ToString();
                            return View();
                    }
                }
                else return _OnInternalError(ServerSideAction.MyClass_Index, ErrorType.UserGroupError, "你现在不是班主任，暂时不能使用 “班级管理” 功能", user.UserName, ErrorRespCode.PermisstionDenied);
            }
            else
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
                return _LoginFailed("/ClassManager/Index/");
            }

        }
    }
}