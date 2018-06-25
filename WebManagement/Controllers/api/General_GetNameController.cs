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
    [Route("api/gen/GetName")]
    public class Gen_GetName : Controller
    {
        [HttpGet]
        public IEnumerable Get(string UserID)
        {
            if (Sessions.OnSessionReceived(Request.Cookies["Session"], Request.Headers["User-Agent"], out UserObject SessionUser))
            {
                if (string.IsNullOrEmpty(UserID))
                {
                    return WebAPIResponseCollections.RequestIllegal; 
                }
                else
                {
                    switch (DBOperations.QuerySingleData(new DBQuery().WhereEqualTo("objectId", UserID), out UserObject user))
                    {
                        case DatabaseResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                        case DatabaseResult.NO_RESULTS: return new Dictionary<string, string>() { { "ErrCode", "0" }, { "Value", $"未知用户({UserID})" } };
                        case DatabaseResult.MORE_RESULTS: return WebAPIResponseCollections.DataBaseError;
                        default: return new Dictionary<string, string>() { { "ErrCode", "0" }, { "Value", $"{user.RealName}({user.objectId})" } };
                    }
                }
            }
            else return WebAPIResponseCollections.SessionError;
        }
    }
}
