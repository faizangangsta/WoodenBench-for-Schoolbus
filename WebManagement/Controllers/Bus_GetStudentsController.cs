using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/GetStudents")]
    public class GetStudentsController : Controller
    {
        [HttpGet]
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
                var task = _Bmob.FindTaskAsync<SchoolBusObject>(Consts.TABLE_N_Mgr_BusData, query);
                task.Wait();
                if (task.IsCompleted && task.Result.results.Count > 0)
                {
                    BmobQuery query2 = new BmobQuery();
                    query2.WhereEqualTo("BusID", task.Result.results[0].objectId);
                    var task2 = _Bmob.FindTaskAsync<StudentDataObject>(Consts.TABLE_N_Mgr_StuData, query2);
                    task2.Wait();
                    if (task2.IsCompleted && task2.Result.results.Count > 0)
                    {
                        dict.Add("count", task2.Result.results.Count.ToString());
                        for (int i = 0; i < task2.Result.results.Count; i++)
                        {
                            dict.Add("num_" + i.ToString(), SimpleJson.SimpleJson.SerializeObject(ObjToDict.StuInfo2Dict(task2.Result.results[i])));
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
}
