using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WBServicePlatform.Databases;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/class/getStudents")]
    public class GetClassStudentsController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string ClassID, string TeacherID)
        {
            if (!Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user)) return WebAPIResponseErrors.SessionError;
            if (!(user.UserGroup.ClassesIds[0] == ClassID && user.objectId == TeacherID)) return WebAPIResponseErrors.UserGroupError;

            DatabaseQuery StudentQuery = new DatabaseQuery();
            StudentQuery.WhereEqualTo("ClassID", ClassID);
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