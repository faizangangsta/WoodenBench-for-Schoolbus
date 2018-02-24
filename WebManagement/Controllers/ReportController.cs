using cn.bmob.response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/gen/NewReport")]
    public class NewReportController : Controller
    {
        [HttpGet]
        public IEnumerable GET(string BusID, string TeacherID, string ReportType, string Content)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                BusReport busReport = new BusReport
                {
                    BusID = BusID,
                    TeacherID = TeacherID,
                    ReportType = (BusReportTypeE)Convert.ToInt32(ReportType),
                    OtherData = Content
                };

                Task<CreateCallbackData> task = _Bmob.CreateTaskAsync(busReport);
                task.Wait();
                if (task.IsCompleted)
                {
                    dict.Add("CreatedAt", task.Result.createdAt);
                    dict.Add("ErrCode", "0");
                    dict.Add("ReportID", task.Result.objectId);
                    dict.Add("ErrMessage", "null");
                }

            }
            catch (Exception ex)
            {
                dict.Add("ErrCode", "999");
                dict.Add("ErrMessage", ex.Message);
            }
            return dict;
        }
    }
}
