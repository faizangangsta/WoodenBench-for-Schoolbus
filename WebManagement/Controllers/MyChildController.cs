using cn.bmob.io;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    public class MyChildController : _Controller
    {
        public const string ControllerName = "MyChild";
        public override IActionResult Index()
        {
            ViewData["where"] = HomeController.ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, user.GetIdentifiableCode());
                ViewData["cUser"] = user.ToString();
                //ViewData["ChildCount"] = user.ChildList.Count;

                return View();
            }
            else
            {
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
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
                Response.Cookies.Append(Constants.identifiedUID_CookieName, user.GetIdentifiableCode());
                if (ID == null) return _OnInternalError(ServerSideAction.MyChild_MarkAsArrived, ErrorType.RequestInvalid, "MyChild::ParentsCheck ==> Req_Error", user.UserName, ErrorRespCode.RequestIllegal);
                string[] IDSplit = ID.Split(";");
                if (IDSplit.Length != 2) return _OnInternalError(ServerSideAction.MyChild_MarkAsArrived, ErrorType.RequestInvalid, "MyChild::ParentsCheck ==> Req_Error", user.UserName, ErrorRespCode.RequestIllegal);
                if (!user.UserGroup.IsParent) return _OnInternalError(ServerSideAction.MyChild_MarkAsArrived, ErrorType.UserGroupError, "MyChild::ParentsCheck ==> UserGroup(NOT PARENT)", user.UserName, ErrorRespCode.PermisstionDenied);
                BusID = IDSplit[0];
                BusTeacherID = IDSplit[1];
                List<StudentObject> ToBeSignedStudents = new List<StudentObject>();
                switch (Database.QueryMultipleData(new DatabaseQuery().WhereEqualTo("BusID", BusID).WhereEqualTo("CHChecked", false), out List<StudentObject> StudentListInBus))
                {
                    case DatabaseQueryResult.INTERNAL_ERROR: return _OnInternalError(ServerSideAction.MyChild_MarkAsArrived, ErrorType.DataBaseError, "MyChild::ParentsCheck ==> FetchStudentListError", user.UserName, ErrorRespCode.InternalError);
                    case 0: //return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "MyChild::ParentsCheck ==> NoChildInBus???"));
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
                Response.Cookies.Append(Constants.identifiedUID_CookieName, Constants.UnknownUID);
                return _LoginFailed("/" + ControllerName + "/ParentCheck?ID=" + ID);
            }
        }
    }
}