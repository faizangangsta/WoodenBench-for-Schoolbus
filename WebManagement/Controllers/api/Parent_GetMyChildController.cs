using Microsoft.AspNetCore.Mvc;

using System.Collections;
using System.Collections.Generic;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/parent/getMyChild")]
    public class GetMyChildController : APIController
    {
        [HttpGet]
        public JsonResult Get(string parentId)
        {
            if (!ValidateSession()) return SessionError;
            if (!(CurrentUser.ObjectId == parentId && CurrentUser.UserGroup.IsParent)) return UserGroupError;


            Dictionary<string, string> dict = new Dictionary<string, string>();
            switch (DataBaseOperation.QueryMultipleData(new DBQuery().WhereValueContainedInArray("objectId", CurrentUser.ChildList.ToArray()), out List<StudentObject> StudentList))
            {
                case DBQueryStatus.INTERNAL_ERROR: return InternalError;
                default:
                    dict.Add("count", StudentList.Count.ToString());
                    for (int i = 0; i < StudentList.Count; i++)
                        dict.Add("num_" + i.ToString(), StudentList[i].ToString());
                    dict.Add("ErrCode", "0");
                    dict.Add("ErrMessage", "null");
                    return Json(dict);
            }
        }
    }
}