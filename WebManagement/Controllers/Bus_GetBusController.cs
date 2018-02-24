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
    [Route("api/bus/GetBuses")]
    public class Bus_GetBusController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string UserID, string UserName, string PsWd, string SALT)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            BmobQuery query = new BmobQuery();
            query.WhereEqualTo("objectId", UserID);
            query.WhereEqualTo("Username", UserName);
            Task<QueryCallbackData<AllUserObject>> task;
            task = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UserTable, query);
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
}
