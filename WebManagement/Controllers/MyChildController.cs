using cn.bmob.io;
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
    public class MyChildController : MyController
    {
        public const string ControllerName = "MyChild";
        public override IActionResult Index()
        {
            return View();
        }

        public IActionResult ParentCheck(string ID) //ID = BusID;UserID
        {
            string BusID, BusTeacherID;
            //CHECK => Student Bus is TeacherID
            ViewData["where"] = ControllerName;
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (ID == null)
                    return Redirect(Sessions.ErrorRedirectURL(MyError.N04_RequestIllegalError, "MyChild::ParentsCheck ==> Req_Error"));
                string[] IDSplit = ID.Split(";");
                if (IDSplit.Length != 2)
                    return Redirect(Sessions.ErrorRedirectURL(MyError.N04_RequestIllegalError, "MyChild::ParentsCheck ==> Req_Error"));
                if (!user.UserGroup.IsParents)
                    return Redirect(Sessions.ErrorRedirectURL(MyError.N06_UserGroupError, "MyChild::ParentsCheck ==> UserGroup(NOT PARENT)"));
                BusID = IDSplit[0];
                BusTeacherID = IDSplit[1];
            }
            else
            {
                return _LoginFailed("/" + ControllerName + "/ParentCheck?ID=" + ID);
            }
            List<StudentObject> ToBeSignedStudents = new List<StudentObject>();
            switch (QueryHelper.BmobQueryData(new BmobQuery().WhereEqualTo("BusID", BusID).WhereEqualTo("CHChecked", false), out List<StudentObject> StudentListInBus))
            {
                case -1: return Redirect(Sessions.ErrorRedirectURL(MyError.N01_InternalError, "MyChild::ParentsCheck ==> FetchStudentListError"));
                case 0: //return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "MyChild::ParentsCheck ==> NoChildInBus???"));
                default:
                    foreach (StudentObject item in StudentListInBus)
                    {
                        if (item.ParentsID.Contains(user.objectId))
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
                ViewData["ChildNum_" + (i).ToString()] = ToBeSignedStudents[i].ToString();
            }
            ViewData["cUser"] = user.ToString();
            ViewData["cBusID"] = BusID;
            ViewData["cTeacherID"] = BusTeacherID;
            return View();
        }
    }
}