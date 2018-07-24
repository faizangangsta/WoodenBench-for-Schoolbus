using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/NewIssueReport")]
    public class Bus_ReportController : WebAPIController
    {
        [HttpGet]
        public IEnumerable GET(string BusID, string TeacherID, string ReportType, string Content)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user))
            {
                if (TeacherID != user.ObjectId) return RequestIllegal;
                if (DataBaseOperation.QuerySingleData(
                    new DBQuery()
                    .WhereEqualTo("objectId", BusID)
                    .WhereEqualTo("TeacherObjectID", TeacherID)
                    , out SchoolBusObject bus) != DBQueryStatus.ONE_RESULT)
                {
                    return RequestIllegal;
                }
                BusReport busReport = new BusReport
                {
                    BusID = BusID,
                    TeacherID = TeacherID,
                    ReportType = (BusReportTypeE)Convert.ToInt32(ReportType),
                    OtherData = Content
                };
                if (DataBaseOperation.CreateData(ref busReport) == DBQueryStatus.ONE_RESULT)
                {
                    InternalMessage message_TC = new InternalMessage()
                    {
                        DataObject = busReport,
                        ObjectId = BusID,
                        User = user,
                        _Type = GlobalMessageTypes.Bus_Status_Report_TC
                    };
                    InternalMessage message_TP = new InternalMessage()
                    {
                        DataObject = busReport,
                        ObjectId = BusID,
                        User = user,
                        _Type = GlobalMessageTypes.Bus_Status_Report_TP
                    };
                    //Need to Process these messsages.....
                    MessagingSystem.AddMessageProcesses(message_TC, message_TP);
                    dict.Add("CreatedAt", busReport.CreatedAt.ToNormalString());
                    dict.Add("ErrCode", "0");
                    dict.Add("ReportID", busReport.ObjectId);
                    dict.Add("ErrMessage", "null");
                }
                else
                {
                    return DataBaseError;
                }
            }
            return dict;
        }
    }
}
