using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class ClassManagerController : _Controller
    {
        public const string ControllerName = "ClassManager";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (user.UserGroup.IsClassTeacher)
                {
                    switch (QueryHelper.BmobQueryData(new cn.bmob.io.BmobQuery().WhereEqualTo("objectId", user.UserGroup.ClassesIds[0]), out List<ClassObject> ClassList))
                    {
                        case -1: return _OnInternalError(ErrorAt.MyClass_Index, ErrorType.DataBaseError, "Internal Error", user.WeChatID, ErrorRespCode.InternalError);
                        case 0: return _OnInternalError(ErrorAt.MyClass_Index, ErrorType.ItemsNotFound, "None of your class found", user.WeChatID);
                        default:
                            ViewData["ClassName"] = ClassList[0].CDepartment + " " + ClassList[0].CGrade + " " + ClassList[0].CNumber;
                            ViewData["ClassID"] = ClassList[0].objectId;
                            ViewData["cUser"] = user.ToString();
                            return View();
                    }
                }
                else return _OnInternalError(ErrorAt.MyClass_Index, ErrorType.UserGroupError, "你现在不是班主任，暂时不能使用 “班级管理” 功能", user.WeChatID, ErrorRespCode.PermisstionDenied);
            }
            else return _LoginFailed("/ClassManager/Index/");
        }
    }
}