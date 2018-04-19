using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBServicePlatform.Databases;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class BusManagerController : _Controller
    {
        public const string ControllerName = "BusManager";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                ViewData["cUser"] = user.ToString();
                return View();
            }
            else return _LoginFailed("/" + ControllerName + "/");
        }

        public IActionResult WeekIssue()
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                ViewData["cUser"] = user.ToString();
                return View();
            }
            else return _LoginFailed("/" + ControllerName + "/WeekIssue");
        }

        public IActionResult SignStudent(string signmode)
        {
            ViewData["where"] = ControllerName;
            ViewData["SignMode"] = signmode;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                ViewData["cUser"] = user.ToString();
                if (Request.Cookies["SignMode"] == signmode)
                {
                    ViewData["cBus"] = user.UserGroup.BusID;
                    ViewData["mode"] = signmode;
                    return View();
                }
                else return _OnInternalError(ErrorAt.BusManage_SignStudents, ErrorType.RequestInvalid, "_SignStudent::CookieExpire", LoginUsr: user.WeChatID);
            }
            else return _LoginFailed("/" + ControllerName + "/SignStudent?signmode=" + signmode);
        }

        public IActionResult ArriveHomeScan()
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                ViewData["cUser"] = user.ToString();
                if (user.UserGroup.IsBusManager && (!string.IsNullOrEmpty(user.UserGroup.BusID) || (user.UserGroup.BusID != "0")))
                {
                    ViewData["cBus"] = user.UserGroup.BusID;
                    ViewData["cTeacher"] = user.objectId;
                }
                else return _OnInternalError(ErrorAt.BusManage_CodeGenerate, ErrorType.UserGroupError, "_ArriveHomeSigning::UserGroupInvalid", user.WeChatID, ErrorRespCode.PermisstionDenied);
            }
            else return _LoginFailed("/" + ControllerName + "/ArriveHomeScan");
            return View();
        }

        public IActionResult ViewStudent(string StudentID, string ClassID, string BusID)
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (user.UserGroup.IsParents ||
                    (user.UserGroup.IsClassTeacher && user.UserGroup.ClassesIds.Contains(ClassID)) ||
                    (user.UserGroup.IsBusManager))
                {
                    switch (Database.QueryData(new DatabaseQuery().WhereEqualTo("ClassID", ClassID).WhereEqualTo("objectId", StudentID), out List<StudentObject> StudentList))
                    {
                        case -1: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.DataBaseError, "_GetStudentByID::-1", user.WeChatID);
                        case 0: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.ItemsNotFound, "_GetStudentByID::0 :: StudentID = " + StudentID, user.WeChatID);
                    }
                    switch (Database.QueryData(new DatabaseQuery().WhereEqualTo("objectId", StudentList[0].ClassID), out List<ClassObject> ClassList))
                    {
                        case -1: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.DataBaseError, "_GetClassByID::-1", user.WeChatID);
                        case 0: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.ItemsNotFound, "_GetClassByID::0", user.WeChatID);
                    }
                    switch (Database.QueryData(new DatabaseQuery().WhereEqualTo("objectId", ClassList[0].TeacherID), out List<UserObject> TeacherList))
                    {
                        case -1: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.DataBaseError, "_GetTeacherByID::-1", user.WeChatID);
                        case 0: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.ItemsNotFound, "_GetTeacherByID::0", user.WeChatID);
                    }
                    switch (Database.QueryData(new DatabaseQuery().WhereContainedIn("objectId", StudentList[0].ParentsID.Split(';')), out List<UserObject> Parents))
                    {
                        case -1: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.DataBaseError, "_GetParentsByGroup::-1", user.WeChatID);
                        case 0: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.ItemsNotFound, "_GetParentsByGroup::0", user.WeChatID);
                    }
                    switch (Database.QueryData(new DatabaseQuery().WhereContainedIn("objectId", StudentList[0].BusID), out List<SchoolBusObject> BusList))
                    {
                        case -1: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.DataBaseError, "_GetBusByGroup::-1", user.WeChatID);
                        case 0: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.ItemsNotFound, "_GetBusByGroup::0", user.WeChatID);
                    }
                    switch (Database.QueryData(new DatabaseQuery().WhereContainedIn("objectId", BusList[0].TeacherID), out List<UserObject> BusTeacherList))
                    {
                        case -1: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.DataBaseError, "_GetBusTeacherByGroup::-1", user.WeChatID);
                        case 0: return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.ItemsNotFound, "_GetBusTeacherByGroup::0", user.WeChatID);
                    }
                    if (StudentList[0].ClassID == ClassID && StudentList[0].BusID == BusID)
                    {
                        return View(new _DataCollection<StudentObject, ClassObject, UserObject, UserObject[], SchoolBusObject, UserObject>(StudentList[0], ClassList[0], TeacherList[0], Parents.ToArray(), BusList[0], BusTeacherList[0]));
                    }
                    else return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.RequestInvalid, "Students::ClassID & BusID !Match", user.WeChatID);
                }
                else return _OnInternalError(ErrorAt.General_ViewStudent, ErrorType.UserGroupError, "ViewStudent_Request::UserGroup_PermissionDenied", user.WeChatID, ErrorRespCode.PermisstionDenied);
            }
            //Return to Home because this is privacy-related function
            else return _LoginFailed("/");
        }
    }
}
