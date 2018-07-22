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
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                AIKnownUser(user);
                if (user.UserGroup.IsClassTeacher && user.ClassList.Count > 0)
                {
                    switch (DataBaseOperation.QueryMultipleData(new DBQuery().WhereEqualTo("objectId", user.ClassList[0]), out List<ClassObject> ClassList))
                    {
                        case DBQueryStatus.INTERNAL_ERROR: return _InternalError(ServerAction.MyClass_Index, ErrorType.DataBaseError, "数据库查询出错", user.UserName, ErrorRespCode.InternalError);
                        case DBQueryStatus.NO_RESULTS: return _InternalError(ServerAction.MyClass_Index, ErrorType.ItemsNotFound, "未找到任何你管理的班级", user.UserName);
                        default:
                            ViewData["ClassName"] = ClassList[0].CDepartment + " " + ClassList[0].CGrade + " " + ClassList[0].CNumber;
                            ViewData["ClassID"] = ClassList[0].ObjectId;
                            ViewData["cUser"] = user.ToString();
                            return base.View();
                    }
                }
                else return _InternalError(ServerAction.MyClass_Index, ErrorType.UserGroupError, "你不是班主任，不能使用此功能.", user.UserName, ErrorRespCode.NotSet);
            }
            else
            {
                AIUnknownUser();
                return _LoginFailed("/ClassManager/Index/");
            }

        }
    }
}