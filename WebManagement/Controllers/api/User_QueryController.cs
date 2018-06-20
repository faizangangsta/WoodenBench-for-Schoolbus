using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using WBPlatform.Database;
using WBPlatform.TableObject;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/users/Query")]
    public class User_QueryController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string ColName, string EqualsTo)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            object Equals2Obj = EqualsTo;
            if (Int32.TryParse((string)Equals2Obj, out int EqInt)) Equals2Obj = EqInt;
            else if (((string)Equals2Obj).ToLower() == "true") Equals2Obj = true;
            else if (((string)Equals2Obj).ToLower() == "false") Equals2Obj = false;
            DBQuery query = new DBQuery();
            query.WhereEqualTo(ColName, Equals2Obj);
            
            if (Database.DBOperations.QueryMultipleData(query, out List<UserObject> list) >= 0)
            {
                dict.Add("ErrCode", "0");
                dict.Add("ErrMessage", "null");
                dict.Add("count", list.Count.ToString());
                foreach (UserObject userObj in list)
                {
                    dict.Add("num_" + list.IndexOf(userObj).ToString() + "", userObj.ToString());
                }
            }
            else
            {
                dict.Add("ErrCode", "999");
                dict.Add("ErrMessage", "Something went wrong...");
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return dict;
        }
    }
}
