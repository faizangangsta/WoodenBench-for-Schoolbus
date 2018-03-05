using cn.bmob.io;
using cn.bmob.response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/SignStudents")]
    public class Bus_SignStudentsController : Controller
    {
        [HttpGet]
        public IEnumerable GET(string BusID, string SignData, string Data)
        {
            string str = Encoding.UTF8.GetString(Convert.FromBase64String(Data));
            if (str.Contains(";") && str.Split(';').Length != 5) return WBConst.RequestIllegal;
            string[] p = str.Split(';');
            string SType = p[0];
            string SValue = p[1];
            //P[2] = SALT
            string TeacherID = p[3];
            string StudentID = p[4];
            if (Crypto.SHA256Encrypt(SValue + p[2] + ";" + SType + BusID + TeacherID) != SignData)
                return WBConst.RequestIllegal;

            BmobQuery busFindQuery = new BmobQuery();
            busFindQuery.WhereEqualTo("objectId", BusID);
            busFindQuery.WhereEqualTo("TeacherObjectID", TeacherID);
            switch (QueryHelper.BmobQueryData(busFindQuery, out List<SchoolBusObject> BusList))
            {
                case -1: return WBConst.InternalError;
                case 0: return WBConst.SpecialisedError("No Result Found");
                default:
                    if (BusList.Count == 1 && BusList[0].objectId == BusID && BusList[0].TeacherID == TeacherID)
                    {
                        BmobQuery _stuQuery = new BmobQuery();
                        _stuQuery.WhereEqualTo("objectId", StudentID);
                        _stuQuery.WhereEqualTo("BusID", BusID);
                        switch (QueryHelper.BmobQueryData(_stuQuery, out List<StudentDataObject> StuList))
                        {
                            case -1: return WBConst.InternalError;
                            case 0: return WBConst.SpecialisedError("No Result Found");
                            default:
                                if (!bool.TryParse(SValue, out bool Value)) return WBConst.RequestIllegal;
                                StudentDataObject stu = StuList[0];
                                if (SType.ToLower() == "leave") stu.LSChecked = Value;
                                else if (SType.ToLower() == "pleave") stu.AHChecked = Value;
                                else if (SType.ToLower() == "come") stu.CSChecked = Value;
                                else return WBConst.RequestIllegal;
                                Task<UpdateCallbackData> task3 = _Bmob.UpdateTaskAsync(stu);
                                task3.Wait();
                                Dictionary<string, string> dict = stu.ToDictionary();
                                dict.Add("ErrCode", "0");
                                dict.Add("ErrMessage", "null");
                                dict.Add("SignMode", SType);
                                dict.Add("SignResult", Value.ToString());
                                dict.Add("Updated", task3.Result.updatedAt);
                                return dict;
                        }
                    }
                    else return WBConst.RequestIllegal;
            }
        }
    }
}
