using System.Collections.Generic;
using System.Linq;
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
            if (ValidateSession())
            {

                if (CurrentUser.ChildList.Count > 0)
                {
                    ViewData["cUser"] = CurrentUser.ToString();
                    return View();
                }
                else return PermissionDenied(ServerAction.MyChild_Index, XConfig.Messages["NotParent"], ResponceCode.Default);
            }
            else
            {

                return LoginFailed("/" + ControllerName);
            }

            //throw new NotImplementedException("This method is not ready.......", new InvalidOperationException("This Method IS Still Under Developing"));
        }

        public IActionResult ParentCheck(string ID) //ID = BusID;UserID
        {
            string BusID, BusTeacherID;
            //CHECK => Student Bus is TeacherID
            ViewData["where"] = ControllerName;
            if (ValidateSession())
            {
                if (ID == null) return RequestIllegal(ServerAction.MyChild_MarkAsArrived, XConfig.Messages.ParameterUnexpected);
                string[] IDSplit = ID.Split(";");
                if (IDSplit.Length != 2) return RequestIllegal(ServerAction.MyChild_MarkAsArrived, XConfig.Messages.RequestIllegal);
                if (!CurrentUser.UserGroup.IsParent) return PermissionDenied(ServerAction.MyChild_MarkAsArrived, XConfig.Messages["NotParent"], ResponceCode.PermisstionDenied);
                BusID = IDSplit[0];
                BusTeacherID = IDSplit[1];
                List<StudentObject> ToBeSignedStudents = new List<StudentObject>();
                switch (DataBaseOperation.QueryMultipleData(new DBQuery().WhereEqualTo("BusID", BusID).WhereEqualTo("CHChecked", false), out List<StudentObject> StudentListInBus))
                {
                    case DBQueryStatus.INTERNAL_ERROR: return DatabaseError(ServerAction.MyChild_MarkAsArrived, XConfig.Messages.InternalDataBaseError);
                    case DBQueryStatus.NO_RESULTS: //return Redirect(Sessions.ErrorRedirectURL(MyError.N03_ItemsNotFoundError, "MyChild::ParentsCheck ==> NoChildInBus???"));
                    default:
                        ToBeSignedStudents.AddRange(from _stu in StudentListInBus where CurrentUser.ChildList.Contains(_stu.ObjectId) select _stu);
                        break;
                }
                //if (ToBeSignedStudents.Count == 0)
                //return Redirect(Sessions.ErrorRedirectURL(WBConst.MyError.N03_ItemsNotFoundError, "MyChild::ParentsCheck ==> NoChildFoundInSpec.Bus"));
                ViewData["ChildCount"] = ToBeSignedStudents.Count;
                for (int i = 0; i < ToBeSignedStudents.Count; i++)
                {
                    ViewData["ChildNum_" + i.ToString()] = ToBeSignedStudents[i].ToString();
                }
                ViewData["cUser"] = CurrentUser.ToString();
                ViewData["cBusID"] = BusID;
                ViewData["cTeacherID"] = BusTeacherID;
                return View();
            }
            else
            {

                return LoginFailed("/" + ControllerName + "/ParentCheck?ID=" + ID);
            }
        }
    }
}