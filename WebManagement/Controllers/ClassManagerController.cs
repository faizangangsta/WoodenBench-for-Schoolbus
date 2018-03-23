using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Models;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class ClassManagerController : MyController
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
                        case -1: return Redirect(Sessions.ErrorRedirectURL(MyError.N01_InternalError, "Internal Error"));
                        case 0: return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "No your class found"));
                        default:
                            ViewData["ClassName"] = ClassList[0].CDepartment + " " + ClassList[0].CGrade + " " + ClassList[0].CNumber;
                            ViewData["ClassID"] = ClassList[0].objectId;
                            ViewData["cUser"] = user.ToString();
                            return View();
                    }
                }
                else return Redirect(Sessions.ErrorRedirectURL(MyError.N06_UserGroupError, "你现在不是班主任，暂时不能使用 “班级管理” 功能"));
            }
            else return _LoginFailed("/ClassManager/Index/");
        }
    }
}