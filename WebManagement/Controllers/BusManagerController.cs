using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public class BusManagerController : _Controller
    {
        public const string ControllerName = "BusManager";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, user.GetIdentifyCode());
                ViewData["cUser"] = user.ToString();
                return View();
            }
            else
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
                return _LoginFailed("/" + ControllerName + "/");
            }
        }

        public IActionResult WeekIssue()
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, user.GetIdentifyCode());
                ViewData["cUser"] = user.ToString();
                return View();
            }
            else
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
                return _LoginFailed("/" + ControllerName + "/WeekIssue");
            }
        }

        public IActionResult SignStudent(string signmode)
        {
            ViewData["where"] = ControllerName;
            ViewData["SignMode"] = signmode;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, user.GetIdentifyCode());
                ViewData["cUser"] = user.ToString();
                if (Request.Cookies["SignMode"] == signmode)
                {
                    ViewData["cBus"] = user.UserGroup.BusID;
                    ViewData["mode"] = signmode;
                    return View();
                }
                else return _OnInternalError(ServerSideAction.BusManage_SignStudents, ErrorType.RequestInvalid, "_SignStudent::CookieExpire", LoginUsr: user.UserName);
            }
            else
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
                return _LoginFailed("/" + ControllerName + "/SignStudent?signmode=" + signmode);
            }
        }

        public IActionResult ArriveHomeScan()
        {
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, user.GetIdentifyCode());
                ViewData["cUser"] = user.ToString();
                if (user.UserGroup.IsBusManager && (!string.IsNullOrEmpty(user.UserGroup.BusID) || (user.UserGroup.BusID != "0")))
                {
                    ViewData["cBus"] = user.UserGroup.BusID;
                    ViewData["cTeacher"] = user.objectId;
                }
                else return _OnInternalError(ServerSideAction.BusManage_CodeGenerate, ErrorType.UserGroupError, "_ArriveHomeSigning::UserGroupInvalid", user.UserName, ErrorRespCode.PermisstionDenied);
            }
            else
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
                return _LoginFailed("/" + ControllerName + "/ArriveHomeScan");
            }
            return View();
        }

        private IActionResult CheckFlag(int flag, bool isSingleRequest, UserObject user, string info)
        {
            switch (flag)
            {
                case -1: return _OnInternalError(ServerSideAction.General_ViewStudent, ErrorType.DataBaseError, info + ":" + flag, user.UserName);
                case 0: return _OnInternalError(ServerSideAction.General_ViewStudent, ErrorType.ItemsNotFound, info + ":" + flag, user.UserName);
                case 1: return null;
                case 2: return isSingleRequest ? _OnInternalError(ServerSideAction.General_ViewStudent, ErrorType.MultipleRecordsFound_inSingleRequest, info + ":" + flag, user.UserName) : null;
                default: return null;
            }
        }
        public IActionResult ViewStudent(string StudentID, string ClassID, string BusID)
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, user.GetIdentifyCode());

                // User Group Check
                if (user.UserGroup.IsParents || user.UserGroup.IsClassTeacher || user.UserGroup.IsBusManager || user.UserGroup.IsAdmin)
                {
                    int flag = 0xff;
                    IActionResult result = null;

                    //Search student with spec ClassID and StudentID and BusID
                    flag = Database.QuerySingleData(new DatabaseQuery().WhereEqualTo("ClassID", ClassID).WhereEqualTo("objectId", StudentID).WhereEqualTo("BusID", BusID), out StudentObject Student);
                    result = CheckFlag(flag, true, user, "GetStudentBy_CID_BID_SID");
                    if (result != null) return result;

                    //Get Class information with ClassID
                    flag = Database.QuerySingleData(new DatabaseQuery().WhereEqualTo("objectId", Student.ClassID), out ClassObject Class);
                    result = CheckFlag(flag, true, user, "GetClassBy_CID");
                    if (result != null) return result;

                    //Get Class Teacher Information
                    flag = Database.QuerySingleData(new DatabaseQuery().WhereEqualTo("objectId", Class.TeacherID), out UserObject Teacher);
                    result = CheckFlag(flag, true, user, "GetStudentBy_CID_BID_SID");
                    if (result != null) return result;

                    //Get Parents
                    flag = Database.QueryMultipleData(new DatabaseQuery().WhereContainedIn("objectId", Student.ParentsID.Split(';')), out List<UserObject> Parents);
                    result = CheckFlag(flag, false, user, "GetParentsBy_UID");
                    if (result != null) return result;


                    // Get SchoolBus
                    flag = Database.QuerySingleData(new DatabaseQuery().WhereContainedIn("objectId", Student.BusID), out SchoolBusObject Bus);
                    result = CheckFlag(flag, true, user, "GetBusBy_BID");
                    if (result != null) return result;

                    // Get SchoolBus Teacher.
                    flag = Database.QuerySingleData(new DatabaseQuery().WhereContainedIn("objectId", Bus.TeacherID), out UserObject BusTeacher);
                    result = CheckFlag(flag, true, user, "GetBusTeacherBy_UID");
                    if (result != null) return result;


                    //  Is in user's class?                                     Is in user's Bus??                          Is user's child??                           I am the god...
                    if (user.UserGroup.ClassesIds.Contains(Student.ClassID) || user.UserGroup.BusID == Student.BusID || Student.ParentsID.Contains(user.objectId) || user.UserGroup.IsAdmin)
                        return View(new _DataCollection<StudentObject, ClassObject, UserObject, UserObject[], SchoolBusObject, UserObject>(Student, Class, Teacher, Parents.ToArray(), Bus, BusTeacher));
                    else return _OnInternalError(ServerSideAction.General_ViewStudent, ErrorType.PermisstionDenied, "ViewStudent::NoPermissionToViewStudent", user.UserName, ErrorRespCode.PermisstionDenied);
                }
                else return _OnInternalError(ServerSideAction.General_ViewStudent, ErrorType.UserGroupError, "ViewStudent::NoUserGroupProvided", user.UserName, ErrorRespCode.RequestIllegal);
            }

            //Return to Home because this is privacy-related function
            else
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
                return _LoginFailed("/");
            }
        }
    }
}
