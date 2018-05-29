using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/parent/getMyChild")]
    public class GetMyChildController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string parentId)
        {
            if (!Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user)) return WebAPIResponseErrors.SessionError;
            if (!(user.objectId == parentId && user.UserGroup.IsParent)) return WebAPIResponseErrors.UserGroupError;

            DatabaseQuery StudentQuery = new DatabaseQuery();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            switch (Database.QueryMultipleData(new DatabaseQuery().WhereContainedIn("objectId", user.ChildList.ToArray()), out List<StudentObject> StudentList))
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