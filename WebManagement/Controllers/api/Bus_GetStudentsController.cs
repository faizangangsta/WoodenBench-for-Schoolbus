using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
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
            switch (Database.QueryMultipleData(BusQuery, out List<SchoolBusObject> BusList))
            {
                case DatabaseQueryResult.INTERNAL_ERROR: return WebAPIResponseErrors.InternalError;
                case DatabaseQueryResult.NO_RESULTS: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                default:
                    {
                        DatabaseQuery StudentQuery = new DatabaseQuery();
                        StudentQuery.WhereEqualTo("BusID", BusList[0].objectId);
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        switch (Database.QueryMultipleData(StudentQuery, out List<StudentObject> StudentList))
                        {
                            case DatabaseQueryResult.INTERNAL_ERROR: return WebAPIResponseErrors.InternalError;
                            case DatabaseQueryResult.NO_RESULTS: return WebAPIResponseErrors.SpecialisedError("No Result Found");
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