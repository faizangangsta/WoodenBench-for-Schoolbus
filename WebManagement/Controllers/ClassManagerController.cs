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
    public class ClassManagerController : ViewController
    {
        public const string ControllerName = "ClassManager";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (ValidateSession())
            {
                AISetUser();
                if (CurrentUser.UserGroup.IsClassTeacher && CurrentUser.ClassList.Count > 0)
                {
                    switch (DataBaseOperation.QueryMultipleData(new DBQuery().WhereEqualTo("objectId", CurrentUser.ClassList[0]), out List<ClassObject> ClassList))
                    {
                        case DBQueryStatus.INTERNAL_ERROR: return _InternalError(ServerAction.MyClass_Index, ErrorType.DataBaseError, "数据库查询出错", CurrentUser.UserName, ErrorRespCode.InternalError);
                        case DBQueryStatus.NO_RESULTS: return _InternalError(ServerAction.MyClass_Index, ErrorType.ItemsNotFound, "未找到任何你管理的班级", CurrentUser.UserName);
                        default:
                            ViewData["ClassName"] = ClassList[0].CDepartment + " " + ClassList[0].CGrade + " " + ClassList[0].CNumber;
                            ViewData["ClassID"] = ClassList[0].ObjectId;
                            ViewData["cUser"] = CurrentUser.ToString();
                            return base.View();
                    }
                }
                else return _InternalError(ServerAction.MyClass_Index, ErrorType.UserGroupError, "你不是班主任，不能使用此功能.", CurrentUser.UserName, ErrorRespCode.NotSet);
            }
            else
            {
                AISetUser();
                return _LoginFailed("/ClassManager/Index/");
            }

        }
    }
}