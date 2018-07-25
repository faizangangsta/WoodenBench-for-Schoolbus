using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public class BusManagerController : ViewController
    {
        public const string ControllerName = "BusManager";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (ValidateSession())
            {
                if (CurrentUser.UserGroup.IsBusManager)
                {
                    AISetUser();
                    ViewData["cUser"] = CurrentUser.ToString();
                    return View();
                }
                else
                {
                    AISetUser();
                    return _InternalError(ServerAction.BusManage_Index, ErrorType.UserGroupError, "你不是校车老师，不能使用此功能.", CurrentUser.RealName, ErrorRespCode.NotSet);
                }
            }
            else
            {
                AISetUser();
                return _LoginFailed("/" + ControllerName + "/");
            }
        }

        public IActionResult WeekIssue()
        {
            ViewData["where"] = ControllerName;
            if (ValidateSession())
            {
                AISetUser();
                ViewData["cUser"] = CurrentUser.ToString();
                return View();
            }
            else
            {
                AISetUser();
                return _LoginFailed("/" + ControllerName + "/WeekIssue");
            }
        }

        public IActionResult SignStudent(string signmode)
        {
            ViewData["where"] = ControllerName;
            ViewData["SignMode"] = signmode;
            if (ValidateSession())
            {
                AISetUser();
                ViewData["cUser"] = CurrentUser.ToString();
                if (Request.Cookies["SignMode"] == signmode)
                {
                    DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("TeacherObjectID", CurrentUser.ObjectId), out SchoolBusObject busObject);
                    if (busObject == null)
                    {
                        busObject = new SchoolBusObject() { ObjectId = "0000000000", BusName = "未找到校车", TeacherID = CurrentUser.ObjectId };
                    }
                    ViewData["cBus"] = busObject.ObjectId;
                    ViewData["mode"] = signmode;
                    return View();
                }
                else return _InternalError(ServerAction.BusManage_SignStudents, ErrorType.RequestInvalid, "内部错误：Cookie已超时或不存在", LoginUsr: CurrentUser.UserName);
            }
            else
            {
                AISetUser();
                return _LoginFailed("/" + ControllerName + "/SignStudent?signmode=" + signmode);
            }
        }

        public IActionResult ArriveHomeScan()
        {
            ViewData["where"] = ControllerName;
            if (ValidateSession())
            {
                AISetUser();
                ViewData["cUser"] = CurrentUser.ToString();
                if (CurrentUser.UserGroup.IsBusManager)
                {
                    DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("TeacherObjectID", CurrentUser.ObjectId), out SchoolBusObject busObject);
                    ViewData["cBus"] = busObject.ObjectId;
                    ViewData["cTeacher"] = CurrentUser.ObjectId;
                }
                else return _InternalError(ServerAction.BusManage_CodeGenerate, ErrorType.UserGroupError, "用户组权限不足，无法执行此操作", CurrentUser.UserName, ErrorRespCode.PermisstionDenied);
            }
            else
            {
                AISetUser();
                return _LoginFailed("/" + ControllerName + "/ArriveHomeScan");
            }
            return View();
        }

        private IActionResult CheckFlag(DBQueryStatus flag, bool isSingleRequest, string info)
        {
            UserObject user = CurrentUser;
            switch (flag)
            {
                case DBQueryStatus.INTERNAL_ERROR: return _InternalError(ServerAction.General_ViewStudent, ErrorType.DataBaseError, info + ":" + flag, user.UserName);
                case DBQueryStatus.MORE_RESULTS:
                    if (isSingleRequest) _InternalError(ServerAction.General_ViewStudent, ErrorType.DataBaseError, info + ":" + flag, user.UserName);
                    return null;
                default: return null;
            }
        }
        /// <summary>
        /// TODO: If Parents Does not exist.. or Bus does not exist,, give a special warning instead of an functionless ERROR....
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="ClassID"></param>
        /// <param name="BusID"></param>
        /// <returns></returns>
        public IActionResult ViewStudent(string StudentID, string ClassID, string BusID, string from)
        {
            if (ValidateSession())
            {
                if (string.IsNullOrEmpty(from))
                {
                    return _InternalError(ServerAction.General_ViewStudent, ErrorType.RequestInvalid, "from 属性未设置", CurrentUser.UserName);
                }
                AISetUser();
                ViewData["where"] = from;
                // User Group Check
                if (CurrentUser.UserGroup.IsParent || CurrentUser.UserGroup.IsClassTeacher || CurrentUser.UserGroup.IsBusManager || CurrentUser.UserGroup.IsAdmin)
                {
                    DBQueryStatus flag;
                    IActionResult result = null;

                    ViewStudentInfo info = new ViewStudentInfo();

                    //Search student with spec ClassID and StudentID and BusID
                    flag = DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", StudentID).WhereEqualTo("ClassID", ClassID).WhereEqualTo("BusID", BusID), out StudentObject Student);
                    result = CheckFlag(flag, true, "GetStudentBy_CID_BID_SID");
                    if (result != null) return result;
                    if (Student != null)
                    {
                        info.StudentFound = true;
                        info._student = Student;

                        //Get Class information with ClassID
                        flag = DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", Student.ClassID), out ClassObject Class);
                        result = CheckFlag(flag, true, "GetClassBy_CID");
                        if (result != null) return result;
                        else
                        {
                            if (flag == DBQueryStatus.NO_RESULTS)
                            {
                                info.ClassFound = false;
                                info._class = null;
                            }
                            else
                            {
                                info.ClassFound = true;
                                info._class = Class;
                                //Get Class Teacher Information
                                flag = DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", Class.TeacherID), out UserObject Teacher);
                                result = CheckFlag(flag, true, "GetClassTeacherBy_CID_BID_SID");
                                if (result != null) return result;
                                else
                                {
                                    if (flag == DBQueryStatus.NO_RESULTS)
                                    {
                                        info.ClassTeacherFound = false;
                                        info._CTeacher = null;
                                    }
                                    else
                                    {
                                        info.ClassTeacherFound = true;
                                        info._CTeacher = Teacher;
                                    }
                                }
                            }
                        }

                        //Get Parents
                        flag = DataBaseOperation.QueryMultipleData(new DBQuery().WhereRecordContainsValue("ChildIDs", Student.ObjectId), out List<UserObject> Parents);
                        result = CheckFlag(flag, false, "GetParentsBy_UID");
                        if (result != null) return result;
                        else
                        {
                            if (flag == DBQueryStatus.NO_RESULTS)
                            {
                                info.ParentsCount = 0;
                                info._Parents = null;
                            }
                            else
                            {
                                info.ParentsCount = Parents.Count;
                                info._Parents = Parents.ToArray();
                            }
                        }


                        // Get SchoolBus
                        flag = DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", Student.BusID), out SchoolBusObject Bus);
                        result = CheckFlag(flag, true, "GetBusBy_BID");
                        if (result != null) return result;
                        else
                        {
                            if (flag == DBQueryStatus.NO_RESULTS)
                            {
                                info.BusFound = false;
                                info._schoolbus = null;
                            }
                            else
                            {
                                info.BusFound = true;
                                info._schoolbus = Bus;
                                // Get SchoolBus Teacher.
                                flag = DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", Bus.TeacherID), out UserObject BusTeacher);
                                result = CheckFlag(flag, true, "GetBusTeacherBy_UID");
                                if (result != null) return result;
                                else
                                {
                                    if (flag == DBQueryStatus.NO_RESULTS)
                                    {
                                        info.BusTeacherFound = false;
                                        info._BTeacher = null;
                                    }
                                    else
                                    {
                                        info.BusTeacherFound = true;
                                        info._BTeacher = BusTeacher;
                                    }
                                }
                            }
                        }

                        //        Is in user's class?                           Is in user's Bus??                      Is user's child??                Or the god...
                        if (CurrentUser.ClassList.Contains(Student.ClassID) || CurrentUser.ObjectId == Bus.TeacherID || CurrentUser.ChildList.Contains(Student.ObjectId) || CurrentUser.UserGroup.IsAdmin)
                        {
                            return View(info);
                        }
                        else return _InternalError(ServerAction.General_ViewStudent, ErrorType.PermisstionDenied, "没有权限查看当前学生信息", CurrentUser.UserName, ErrorRespCode.PermisstionDenied);
                    }
                    else return _InternalError(ServerAction.General_ViewStudent, ErrorType.DataBaseError, "数据库查询失败", CurrentUser.UserName, ErrorRespCode.RequestIllegal);
                }
                else return _InternalError(ServerAction.General_ViewStudent, ErrorType.UserGroupError, "用户组权限不足，无法执行此操作", CurrentUser.UserName, ErrorRespCode.RequestIllegal);
            }

            //Return to Home because this is privacy-related function
            else
            {
                AISetUser();
                return _LoginFailed("/");
            }
        }
    }
}
