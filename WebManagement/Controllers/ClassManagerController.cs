using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WBPlatform.Database;
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
                AIKnownUser(user);
                if (user.UserGroup.IsClassTeacher)
                {
                    switch (DBOperations.QueryMultipleData(new DBQuery().WhereEqualTo("objectId", user.ClassList[0]), out List<ClassObject> ClassList))
                    {
                        case DatabaseResult.INTERNAL_ERROR: return _OnInternalError(ServerSideAction.MyClass_Index, ErrorType.DataBaseError, "数据库查询出错", user.UserName, ErrorRespCode.InternalError);
                        case DatabaseResult.NO_RESULTS: return _OnInternalError(ServerSideAction.MyClass_Index, ErrorType.ItemsNotFound, "未找到任何你管理的班级", user.UserName);
                        default:
                            ViewData["ClassName"] = ClassList[0].CDepartment + " " + ClassList[0].CGrade + " " + ClassList[0].CNumber;
                            ViewData["ClassID"] = ClassList[0].objectId;
                            ViewData["cUser"] = user.ToString();
                            return base.View();
                    }
                }
                else return _OnInternalError(ServerSideAction.MyClass_Index, ErrorType.UserGroupError, "你现在不是班主任，暂时不能使用 “班级管理” 功能", user.UserName, ErrorRespCode.PermisstionDenied);
            }
            else
            {
                AIKnownUser(user);
                return _LoginFailed("/ClassManager/Index/");
            }

        }
    }
}