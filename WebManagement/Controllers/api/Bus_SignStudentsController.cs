using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/SignStudents")]
    public class Bus_SignStudentsController : Controller
    {
        [HttpGet]
        public IEnumerable GET(string BusID, string SignData, string Data)
        {
            //THIS FUNCTION IS SHARED BY BUSTEACHER AND PARENTS
            if (!Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
                return WebAPIResponseErrors.SessionError;
            if (!(user.UserGroup.IsParent || user.UserGroup.IsBusManager || user.UserGroup.IsAdmin))
                return WebAPIResponseErrors.UserGroupError;
            string str = Encoding.UTF8.GetString(Convert.FromBase64String(Data));
            if (str.Contains(";") && str.Split(';').Length != 5) return WebAPIResponseErrors.RequestIllegal;
            string[] p = str.Split(';');
            string SType = p[0];
            string SValue = p[1];
            //P[2] = SALT
            string TeacherID = p[3];
            string StudentID = p[4];
            if (Crypto.SHA256Encrypt(SValue + p[2] + ";" + SType + BusID + TeacherID) != SignData) return WebAPIResponseErrors.RequestIllegal;

            DatabaseQuery busFindQuery = new DatabaseQuery();
            busFindQuery.WhereEqualTo("objectId", BusID);
            busFindQuery.WhereEqualTo("TeacherObjectID", TeacherID);
            switch (Database.QueryMultipleData(busFindQuery, out List<SchoolBusObject> BusList))
            {
                case DatabaseQueryResult.INTERNAL_ERROR: return WebAPIResponseErrors.InternalError;
                case DatabaseQueryResult.NO_RESULTS: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                default:
                    if (BusList.Count == 1 && BusList[0].objectId == BusID && BusList[0].TeacherID == TeacherID)
                    {
                        DatabaseQuery _stuQuery = new DatabaseQuery();
                        _stuQuery.WhereEqualTo("objectId", StudentID);
                        _stuQuery.WhereEqualTo("BusID", BusID);
                        switch (Database.QueryMultipleData(_stuQuery, out List<StudentObject> StuList))
                        {
                            case DatabaseQueryResult.INTERNAL_ERROR: return WebAPIResponseErrors.InternalError;
                            case DatabaseQueryResult.NO_RESULTS: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                            default:
                                if (!bool.TryParse(SValue, out bool Value)) return WebAPIResponseErrors.RequestIllegal;
                                StudentObject stu = StuList[0];
                                if (SType.ToLower() == "leave") stu.LSChecked = Value;
                                else if (SType.ToLower() == "pleave") stu.AHChecked = Value;
                                else if (SType.ToLower() == "come") stu.CSChecked = Value;
                                else return WebAPIResponseErrors.RequestIllegal;
                                if (Database.UpdateData(stu) == 0)
                                {
                                    Dictionary<string, string> dict = stu.ToDictionary();
                                    dict.Add("ErrCode", "0");
                                    dict.Add("ErrMessage", "null");
                                    dict.Add("SignMode", SType);
                                    dict.Add("SignResult", Value.ToString());
                                    dict.Add("Updated", DateTime.Now.ToString());
                                    return dict;
                                }
                                else return WebAPIResponseErrors.InternalError;
                        }
                    }
                    else return WebAPIResponseErrors.RequestIllegal;
            }
        }
    }
}
