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
                    return WebAPIResponseErrors.RequestIllegal;
                }
                else
                {
                    switch (Database.QuerySingleData(new DatabaseQuery().WhereEqualTo("objectId", UserID), out UserObject user))
                    {
                        case DatabaseQueryResult.INTERNAL_ERROR: return WebAPIResponseErrors.InternalError;
                        case DatabaseQueryResult.NO_RESULTS: return new Dictionary<string, string>() { { "ErrCode", "0" }, { "Value", $"未知用户({UserID})" } };
                        case DatabaseQueryResult.MORE_RESULTS: return WebAPIResponseErrors.InternalError;
                        default: return new Dictionary<string, string>() { { "ErrCode", "0" }, { "Value", $"{user.RealName}({user.objectId})" } };
                    }
                }
            }
            else return WebAPIResponseErrors.SessionError;
        }
    }
}
