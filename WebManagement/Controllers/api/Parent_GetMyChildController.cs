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
    [Route("api/parent/getMyChild")]
    public class GetMyChildController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string parentId)
        {
            if (!Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user)) return WebAPIResponseCollections.SessionError;
            if (!(user.objectId == parentId && user.UserGroup.IsParent)) return WebAPIResponseCollections.UserGroupError;

            DBQuery StudentQuery = new DBQuery();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            switch (DBOperations.QueryMultipleData(new DBQuery().WhereContainedInArray("objectId", user.ChildList.ToArray()), out List<StudentObject> StudentList))
            {
                case DatabaseResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                case DatabaseResult.NO_RESULTS: return WebAPIResponseCollections.DatabaseError;
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