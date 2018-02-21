using cn.bmob.io;
using cn.bmob.response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.Users;
using static WBServicePlatform.WebAPIServices.GlobalApplication;

namespace WBServicePlatform.WebAPIServices.Controllers
{
    public class gen_NewReportController : ApiController
    {
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
