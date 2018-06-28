using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Database;
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
            if (!Sessions.OnSessionReceived(Session, Request.Headers["User-Agent"], out UserObject user)) return WebAPIResponseCollections.SessionError;
            if (!( user.objectId == TeacherID))//user.UserGroup.BusID == BusID &&
                return WebAPIResponseCollections.UserGroupError;
            if (Cryptography.SHA256Encrypt(BusID + ";;" + Session + user.objectId + ";;" + Session) != STAMP) return WebAPIResponseCollections.RequestIllegal;
            DBQuery BusQuery = new DBQuery();
            BusQuery.WhereEqualTo("objectId", BusID);
            BusQuery.WhereEqualTo("TeacherObjectID", TeacherID);
            switch (DBOperations.QueryMultipleData(BusQuery, out List<SchoolBusObject> BusList))
            {
                case DataBaseResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                case DataBaseResult.NO_RESULTS: return WebAPIResponseCollections.DataBaseError;
                default:
                    {
                        DBQuery StudentQuery = new DBQuery();
                        StudentQuery.WhereEqualTo("BusID", BusList[0].objectId);
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        switch (DBOperations.QueryMultipleData(StudentQuery, out List<StudentObject> StudentList))
                        {
                            case DataBaseResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                            case DataBaseResult.NO_RESULTS: return WebAPIResponseCollections.DataBaseError;
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