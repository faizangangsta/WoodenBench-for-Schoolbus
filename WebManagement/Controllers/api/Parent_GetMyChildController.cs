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
    [Route("api/parent/getMyChild")]
    public class GetMyChildController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string parentId)
        {
            if (!Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject user)) return WebAPIResponseCollections.SessionError;
            if (!(user.objectId == parentId && user.UserGroup.IsParent)) return WebAPIResponseCollections.UserGroupError;

            DataBaseQuery StudentQuery = new DataBaseQuery();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            switch (Database.QueryMultipleData(new DataBaseQuery().WhereExistsInArray("objectId", user.ChildList.ToArray()), out List<StudentObject> StudentList))
            {
                case DatabaseQueryResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                case DatabaseQueryResult.NO_RESULTS: return WebAPIResponseCollections.DatabaseError;
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