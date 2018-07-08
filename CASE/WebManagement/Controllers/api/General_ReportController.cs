using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace WBPlatform.WebManagement.Controllers
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
                if (DatabaseOperation.CreateData(busReport, out BusReport _bus) == DBQueryStatus.ONE_RESULT)
                {
                    dict.Add("CreatedAt", DateTime.Now.ToString());
                    dict.Add("ErrCode", "0");
                    dict.Add("ReportID", "");
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
