using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cn.bmob.io;
using cn.bmob.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Controllers;
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
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string str = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(Data));
            if (str.Contains(";") && str.Split(';').Length != 5)
            {
                dict.Add("ErrCode", "4");
                dict.Add("ErrMessage", "Request illegal");
            }
            else
            {
                string[] p = str.Split(';');
                string SType = p[0];
                string SValue = p[1];
                //P[2] = SALT
                string TeacherID = p[3];
                string StudentID = p[4];
                if (Crypto.SHA256Encrypt(SValue + p[2] + ";" + SType + BusID + TeacherID) != SignData)
                {
                    dict.Add("ErrCode", "4");
                    dict.Add("ErrMessage", "Request illegal");
                }
                else
                {
                    BmobQuery busFindQuery = new BmobQuery();
                    busFindQuery.WhereEqualTo("objectId", BusID);
                    busFindQuery.WhereEqualTo("TeacherObjectID", TeacherID);
                    var busFindTask = _Bmob.FindTaskAsync<SchoolBusObject>(Consts.TABLE_N_Mgr_BusData, busFindQuery);
                    busFindTask.Wait();
                    if (busFindTask.Result.results.Count == 1)
                    {
                        //BmobQuery _UserQuery = new BmobQuery();

                        BmobQuery _stuQuery = new BmobQuery();
                        _stuQuery.WhereEqualTo("objectId", StudentID);
                        _stuQuery.WhereEqualTo("BusID", BusID);
                        var _studentFindTask = _Bmob.FindTaskAsync<StudentDataObject>(Consts.TABLE_N_Mgr_StuData, _stuQuery);
                        _studentFindTask.Wait();
                        if (_studentFindTask.IsCompleted && _studentFindTask.Result.results.Count == 1)
                        {
                            if (!bool.TryParse(SValue, out bool Value))
                            {
                                dict.Add("ErrCode", "4");
                                dict.Add("ErrMessage", "Request illegal");
                            }
                            else
                            {
                                StudentDataObject stu = _studentFindTask.Result.results[0];
                                if (SType.ToLower() == "leave") stu.LSChecked = Value;
                                else if (SType.ToLower() == "pleave") stu.CHChecked = Value;
                                else if (SType.ToLower() == "come") stu.CSChecked = Value;
                                else
                                {
                                    dict.Add("ErrCode", "4");
                                    dict.Add("ErrMessage", "Request illegal");
                                    return dict;
                                }

                                Task<UpdateCallbackData> task3 = _Bmob.UpdateTaskAsync(stu);
                                task3.Wait();
                                if (task3.IsCompleted)
                                {
                                    dict = ObjToDict.StuInfo2Dict(stu);
                                    dict.Add("ErrCode", "0");
                                    dict.Add("ErrMessage", "null");
                                    dict.Add("SignMode", SType);
                                    dict.Add("SignResult", Value.ToString());
                                    dict.Add("Updated", task3.Result.updatedAt);
                                }
                            }
                        }
                        else
                        {
                            dict.Add("ErrCode", "4");
                            dict.Add("ErrMessage", "Request illegal");
                        }
                    }
                    else
                    {
                        dict.Add("ErrCode", "4");
                        dict.Add("ErrMessage", "Request illegal");
                    }
                }
            }
            return dict;
        }

    }
}
