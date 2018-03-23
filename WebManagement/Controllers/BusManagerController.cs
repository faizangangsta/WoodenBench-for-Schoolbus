using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using cn.bmob.io;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Models;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class BusManagerController : MyController
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
                else return Redirect(Sessions.ErrorRedirectURL(MyError.N04_RequestIllegalError, "_SignStudent::CookieExpire"));
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
                else return Redirect(Sessions.ErrorRedirectURL(MyError.N06_UserGroupError, "_ArriveHomeSigning::UserGroupInvalid"));
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
                    switch (QueryHelper.BmobQueryData(new BmobQuery().WhereEqualTo("ClassID", ClassID).WhereEqualTo("objectId", StudentID), out List<StudentObject> StudentList))
                    {
                        case -1: return Redirect(Sessions.ErrorRedirectURL(MyError.N01_InternalError, "_GetStudentByID::-1"));
                        case 0: return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "_GetStudentByID::0 :: StudentID = " + StudentID));
                    }
                    switch (QueryHelper.BmobQueryData(new BmobQuery().WhereEqualTo("objectId", StudentList[0].ClassID), out List<ClassObject> ClassList))
                    {
                        case -1: return Redirect(Sessions.ErrorRedirectURL(MyError.N01_InternalError, "_GetClassByID::-1"));
                        case 0: return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "_GetClassByID::0"));
                    }
                    switch (QueryHelper.BmobQueryData(new BmobQuery().WhereEqualTo("objectId", ClassList[0].TeacherID), out List<UserObject> TeacherList))
                    {
                        case -1: return Redirect(Sessions.ErrorRedirectURL(MyError.N01_InternalError, "_GetTeacherByID::-1"));
                        case 0: return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "_GetTeacherByID::0"));
                    }
                    switch (QueryHelper.BmobQueryData(new BmobQuery().WhereContainedIn("objectId", StudentList[0].ParentsID.Split(';')), out List<UserObject> Parents))
                    {
                        case -1: return Redirect(Sessions.ErrorRedirectURL(MyError.N01_InternalError, "_GetParentsByGroup::-1"));
                        case 0: return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "_GetParentsByGroup::0"));
                    }
                    switch (QueryHelper.BmobQueryData(new BmobQuery().WhereContainedIn("objectId", StudentList[0].BusID), out List<SchoolBusObject> BusList))
                    {
                        case -1: return Redirect(Sessions.ErrorRedirectURL(MyError.N01_InternalError, "_GetBusByGroup::-1"));
                        case 0: return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "_GetBusByGroup::0"));
                    }
                    switch (QueryHelper.BmobQueryData(new BmobQuery().WhereContainedIn("objectId", BusList[0].TeacherID), out List<UserObject> BusTeacherList))
                    {
                        case -1: return Redirect(Sessions.ErrorRedirectURL(MyError.N01_InternalError, "_GetBusTeacherByGroup::-1"));
                        case 0: return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "_GetBusTeacherByGroup::0"));
                    }
                    if (StudentList[0].ClassID == ClassID && StudentList[0].BusID == BusID)
                    {
                        return View(new _DataCollection<StudentObject, ClassObject, UserObject, UserObject[], SchoolBusObject, UserObject>(StudentList[0], ClassList[0], TeacherList[0], Parents.ToArray(), BusList[0], BusTeacherList[0]));
                    }
                    else return Redirect(Sessions.ErrorRedirectURL(MyError.N04_RequestIllegalError));
                }
                else return Redirect(Sessions.ErrorRedirectURL(MyError.N06_UserGroupError, "ViewStudent_Request::UserGroup_PermissionDenied"));
            }
            //Return to Home because this is privacy-related function
            else return _LoginFailed("/");
        }
    }
}
