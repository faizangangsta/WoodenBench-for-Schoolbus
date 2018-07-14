using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public class MyChildController : ViewController
    {
        public const string ControllerName = "MyChild";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                AIKnownUser(user);
                if (user.ChildList.Count > 0)
                {
                    ViewData["cUser"] = user.ToString();
                    return View();
                }
                else return _InternalError(ServerSideAction.MyChild_Index, ErrorType.UserGroupError, "你不是家长，不能使用此功能.请确认是否被注册为家长。", user.RealName, ErrorRespCode.NotSet);
            }
            else
            {
                AIUnknownUser();
                return _LoginFailed("/" + ControllerName);
            }

            //throw new NotImplementedException("This method is not ready.......", new InvalidOperationException("This Method IS Still Under Developing"));
        }

        public IActionResult ParentCheck(string ID) //ID = BusID;UserID
        {
            string BusID, BusTeacherID;
            //CHECK => Student Bus is TeacherID
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                AIKnownUser(user);
                if (ID == null) return _InternalError(ServerSideAction.MyChild_MarkAsArrived, ErrorType.RequestInvalid, "请求必需的 ChildID 不存在", user.UserName, ErrorRespCode.RequestIllegal);
                string[] IDSplit = ID.Split(";");
                if (IDSplit.Length != 2) return _InternalError(ServerSideAction.MyChild_MarkAsArrived, ErrorType.RequestInvalid, "非法请求", user.UserName, ErrorRespCode.RequestIllegal);
                if (!user.UserGroup.IsParent) return _InternalError(ServerSideAction.MyChild_MarkAsArrived, ErrorType.UserGroupError, "你不是家长，没有权限使用此功能", user.UserName, ErrorRespCode.PermisstionDenied);
                BusID = IDSplit[0];
                BusTeacherID = IDSplit[1];
                List<StudentObject> ToBeSignedStudents = new List<StudentObject>();
                switch (DataBaseOperation.QueryMultipleData(new DBQuery().WhereEqualTo("BusID", BusID).WhereEqualTo("CHChecked", false), out List<StudentObject> StudentListInBus))
                {
                    case DBQueryStatus.INTERNAL_ERROR: return _InternalError(ServerSideAction.MyChild_MarkAsArrived, ErrorType.DataBaseError, "内部错误，数据库查询出错", user.UserName, ErrorRespCode.InternalError);
                    case DBQueryStatus.NO_RESULTS: //return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "MyChild::ParentsCheck ==> NoChildInBus???"));
                    default:
                        foreach (StudentObject item in StudentListInBus)
                        {
                            if (user.ChildList.Contains(item.objectId))
                            {
                                ToBeSignedStudents.Add(item);
                            }
                        }
                        break;
                }
                //if (ToBeSignedStudents.Count == 0)
                //return Redirect(Sessions.ErrorRedirectURL(WBConst.MyError.N03_ItemsNotFoundError, "MyChild::ParentsCheck ==> NoChildFoundInSpec.Bus"));
                ViewData["ChildCount"] = ToBeSignedStudents.Count;
                for (int i = 0; i < ToBeSignedStudents.Count; i++)
                {
                    ViewData["ChildNum_" + (i.ToString())] = ToBeSignedStudents[i].ToString();
                }
                ViewData["cUser"] = user.ToString();
                ViewData["cBusID"] = BusID;
                ViewData["cTeacherID"] = BusTeacherID;
                return View();
            }
            else
            {
                AIUnknownUser();
                return _LoginFailed("/" + ControllerName + "/ParentCheck?ID=" + ID);
            }
        }
    }
}