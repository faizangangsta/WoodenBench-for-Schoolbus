using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
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
            if (!Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user)) return WebAPIErrors.SessionError;
            if (!(user.UserGroup.ClassesIds[0] == ClassID && user.objectId == TeacherID)) return WebAPIErrors.UserGroupError;

            BmobQuery StudentQuery = new BmobQuery();
            StudentQuery.WhereEqualTo("ClassID", ClassID);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            switch (QueryHelper.BmobQueryData(StudentQuery, out List<StudentObject> StudentList))
            {
                case -1: return WebAPIErrors.InternalError;
                case 0: return WebAPIErrors.SpecialisedError("No Result Found");
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