using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBServicePlatform.Databases;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/GetStudents")]
    public class GetStudentsController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string BusID, string TeacherID, string Session, string STAMP)
        {
            if (!Sessions.OnSessionReceived(Session, Request.Headers["User-Agent"], out UserObject user)) return WebAPIResponseErrors.SessionError;
            if (!(user.UserGroup.BusID == BusID && user.objectId == TeacherID))
                return WebAPIResponseErrors.UserGroupError;
            if (Crypto.SHA256Encrypt(user.UserGroup.BusID + ";;" + Session + user.objectId + ";;" + Session) != STAMP) return WebAPIResponseErrors.RequestIllegal;
            DatabaseQuery BusQuery = new DatabaseQuery();
            BusQuery.WhereEqualTo("objectId", BusID);
            BusQuery.WhereEqualTo("TeacherObjectID", TeacherID);
            switch (Database.QueryData(BusQuery, out List<SchoolBusObject> BusList))
            {
                case -1: return WebAPIResponseErrors.InternalError;
                case 0: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                default:
                    {
                        DatabaseQuery StudentQuery = new DatabaseQuery();
                        StudentQuery.WhereEqualTo("BusID", BusList[0].objectId);
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        switch (Database.QueryData(StudentQuery, out List<StudentObject> StudentList))
                        {
                            case -1: return WebAPIResponseErrors.InternalError;
                            case 0: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                            default:
                                dict.Add("count", StudentList.Count.ToString());
                                for (int i = 0; i < StudentList.Count; i++)
                                    dict.Add("num_" + i.ToString(), StudentList[i].ToString());
                                dict.Add("ErrCode", "0");
                                dict.Add("ErrMessage", "null");
                                return dict;
                        }
                    }
            }
        }
    }
}