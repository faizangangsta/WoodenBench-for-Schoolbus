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
    [Route("api/class/getStudents")]
    public class GetClassStudentsController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string ClassID, string TeacherID)
        {
            if (!Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user)) return WebAPIResponseCollections.SessionError;
            if (!(user.ClassList.Contains(ClassID) && user.objectId == TeacherID)) return WebAPIResponseCollections.UserGroupError;

            DBQuery StudentQuery = new DBQuery();
            StudentQuery.WhereEqualTo("ClassID", ClassID);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            switch (Database.DBOperations.QueryMultipleData(StudentQuery, out List<StudentObject> StudentList))
            {
                case DatabaseOperationResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                case DatabaseOperationResult.NO_RESULTS: return WebAPIResponseCollections.DatabaseError;
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