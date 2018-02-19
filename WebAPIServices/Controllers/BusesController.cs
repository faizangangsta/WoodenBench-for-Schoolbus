using cn.bmob.io;
using cn.bmob.response;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Web.Http;
using WoodenBench.StaticClasses;
using WoodenBench.TableObject;
using WoodenBench.Users;
using static WoodenBench.WebAPIServices.GlobalApplication;

namespace WoodenBench.WebAPIServices.Controllers
{
    public class bus_GetMgmtBusController : ApiController
    {
        public IEnumerable Get(string UserID, string UserName, string PsWd, string SALT)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            BmobQuery query = new BmobQuery();
            query.WhereEqualTo("objectId", UserID);
            query.WhereEqualTo("Username", UserName);
            Task<QueryCallbackData<AllUserObject>> task;
            task = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UsrTable, query);
            task.Wait();
            if (task.IsCompleted && task.Result.results.Count > 0)
            {
                string Check1 = Crypto.SHA256Encrypt(task.Result.results[0].Password + SALT);
                if (Check1 == PsWd)
                {
                    BmobQuery query2 = new BmobQuery();
                    query2.WhereEqualTo("TeacherObjectID", task.Result.results[0].objectId);
                    Task<QueryCallbackData<SchoolBusObject>> task2;
                    task2 = _Bmob.FindTaskAsync<SchoolBusObject>(Consts.TABLE_N_Mgr_BusData, query2);
                    task2.Wait();
                    if (task2.IsCompleted && task2.Result.results.Count > 0)
                    {
                        dict = ObjToDict.BusInfo2Dict(task2.Result.results[0]);
                        dict.Add("ErrCode", "0");
                        dict.Add("ErrMessage", "null");
                    }
                    else
                    {
                        dict.Add("ErrCode", "3");
                        dict.Add("ErrMessage", "No Bus Found");
                    }
                }
                else
                {
                    dict.Add("ErrCode", "1");
                    dict.Add("ErrMessage", "UserName or Password Not Correct");
                }
            }
            else
            {
                dict.Add("ErrCode", "1");
                dict.Add("ErrMessage", "UserName or Password Not Correct");
            }
            return dict;
        }
    }

    public class bus_GetStudentsController : ApiController
    {
        public IEnumerable Get(string BusID, string TeacherID, string STAMP, string SALT)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (Crypto.SHA256Encrypt(BusID + ";;" + SALT + TeacherID + ";;" + SALT) != STAMP)
            {
                dict.Add("ErrCode", "4");
                dict.Add("ErrMessage", "Request illegal");
            }
            else
            {
                BmobQuery query = new BmobQuery();
                query.WhereEqualTo("objectId", BusID);
                query.WhereEqualTo("TeacherObjectID", TeacherID);
                Task<QueryCallbackData<SchoolBusObject>> task;
                task = _Bmob.FindTaskAsync<SchoolBusObject>(Consts.TABLE_N_Mgr_BusData, query);
                task.Wait();
                if (task.IsCompleted && task.Result.results.Count > 0)
                {
                    BmobQuery query2 = new BmobQuery();
                    query2.WhereEqualTo("BusID", task.Result.results[0].objectId);
                    Task<QueryCallbackData<StudentDataObject>> task2;
                    task2 = _Bmob.FindTaskAsync<StudentDataObject>(Consts.TABLE_N_Mgr_StuData, query2);
                    task2.Wait();
                    if (task2.IsCompleted && task2.Result.results.Count > 0)
                    {
                        List<StudentDataObject> list = task2.Result.results;
                        dict.Add("count", list.Count.ToString());
                        for (int i = 0; i < list.Count; i++)
                        {
                            dict.Add("num_" + i.ToString(), SimpleJson.SimpleJson.SerializeObject(ObjToDict.StuInfo2Dict(list[i])));
                        }
                        dict.Add("ErrCode", "0");
                        dict.Add("ErrMsg", "null");
                    }
                    else
                    {
                        dict.Add("ErrCode", "5");
                        dict.Add("ErrMessage", "No Student Found or Bus Data Corrupt");
                    }
                }
                else
                {
                    dict.Add("ErrCode", "4");
                    dict.Add("ErrMessage", "Request illegal");
                }
            }
            return dict;
        }
    }



    public class bus_QueryStudentsController : ApiController
    {
        public IEnumerable Get(string BusID, string Column, string Content, string STAMP, string SALT)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (Crypto.SHA256Encrypt(BusID + ";;" + SALT + Column + ";" + Content + ";;" + SALT) != STAMP)
            {
                dict.Add("ErrCode", "4");
                dict.Add("ErrMessage", "Request illegal");
            }
            else
            {
                BmobQuery query = new BmobQuery();
                query.WhereEqualTo("objectId", BusID);
                Task<QueryCallbackData<SchoolBusObject>> task;
                task = _Bmob.FindTaskAsync<SchoolBusObject>(Consts.TABLE_N_Mgr_BusData, query);
                task.Wait();
                if (task.IsCompleted && task.Result.results.Count > 0)
                {
                    BmobQuery query2 = new BmobQuery();
                    query2.WhereEqualTo("BusID", task.Result.results[0].objectId);


                    object Equals2Obj = Content;
                    if (Int32.TryParse((string)Equals2Obj, out int EqInt)) Equals2Obj = EqInt;
                    else if (((string)Equals2Obj).ToLower() == "true") Equals2Obj = true;
                    else if (((string)Equals2Obj).ToLower() == "false") Equals2Obj = false;

                    query2.WhereEqualTo(Column, Equals2Obj);
                    Task<QueryCallbackData<StudentDataObject>> task2;
                    task2 = _Bmob.FindTaskAsync<StudentDataObject>(Consts.TABLE_N_Mgr_StuData, query2);
                    task2.Wait();
                    if (task2.IsCompleted && task2.Result.results.Count > 0)
                    {
                        List<StudentDataObject> list = task2.Result.results;
                        dict.Add("count", list.Count.ToString());
                        for (int i = 0; i < list.Count; i++)
                        {
                            dict.Add("num_" + i.ToString(), SimpleJson.SimpleJson.SerializeObject(ObjToDict.StuInfo2Dict(list[i])));
                        }
                        dict.Add("ErrCode", "0");
                        dict.Add("ErrMsg", "null");
                    }
                    else
                    {
                        dict.Add("ErrCode", "5");
                        dict.Add("ErrMessage", "No Student Found or Bus Data Corrupt");
                    }
                }
                else
                {
                    dict.Add("ErrCode", "4");
                    dict.Add("ErrMessage", "Request illegal");
                }
            }
            return dict;
        }
    }
    public class bus_SignStudentsController : ApiController
    {
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
                    BmobQuery query = new BmobQuery();
                    query.WhereEqualTo("objectId", BusID);
                    query.WhereEqualTo("TeacherObjectID", TeacherID);
                    Task<QueryCallbackData<SchoolBusObject>> task;
                    task = _Bmob.FindTaskAsync<SchoolBusObject>(Consts.TABLE_N_Mgr_BusData, query);
                    task.Wait();
                    if (task.Result.results.Count == 1)
                    {
                        BmobQuery query2 = new BmobQuery();
                        query2.WhereEqualTo("objectId", StudentID);
                        query2.WhereEqualTo("BusID", BusID);
                        Task<QueryCallbackData<StudentDataObject>> task2;
                        task2 = _Bmob.FindTaskAsync<StudentDataObject>(Consts.TABLE_N_Mgr_StuData, query2);
                        task2.Wait();
                        if (task2.IsCompleted && task2.Result.results.Count == 1)
                        {
                            if (!bool.TryParse(SValue, out bool Value))
                            {
                                dict.Add("ErrCode", "4");
                                dict.Add("ErrMessage", "Request illegal");
                            }
                            else
                            {
                                StudentDataObject stu = task2.Result.results[0];
                                if (SType.ToLower() == "leave") stu.LeaveChecked = Value;
                                else if (SType.ToLower() == "pleave") stu.ParentLeaveChecked = Value;
                                else if (SType.ToLower() == "come") stu.ComeChecked = Value;
                                else if (SType.ToLower() == "pcome") stu.ParentComeChecked = Value;
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
