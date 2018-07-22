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
    [Route("api/gen/NewReport")]
    public class NewReportController : WebAPIController
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
                if (DataBaseOperation.CreateData(busReport, out BusReport _bus) == DBQueryStatus.ONE_RESULT)
                {
                    InternalMessage message_TC = new InternalMessage()
                    {
                        DataObject = _bus,
                        ObjectId = BusID,
                        User = user,
                        _Type = GlobalMessageTypes.Bus_Status_Report_TC
                    };
                    InternalMessage message_TP = new InternalMessage()
                    {
                        DataObject = _bus,
                        ObjectId = BusID,
                        User = user,
                        _Type = GlobalMessageTypes.Bus_Status_Report_TP
                    };
                    //Need to Process these messsages.....
                    MessagingSystem.AddMessageProcesses(message_TC, message_TP);
                    dict.Add("CreatedAt", _bus.CreatedAt.ToNormalString());
                    dict.Add("ErrCode", "0");
                    dict.Add("ReportID", _bus.ObjectId);
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
