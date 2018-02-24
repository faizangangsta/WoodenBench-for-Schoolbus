using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Controllers
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
            BmobQuery query = new BmobQuery();
            query.WhereEqualTo(ColName, Equals2Obj);

            var FindRst = _Bmob.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UserTable, query);
            FindRst.Wait();
            if (FindRst.IsCompleted)
            {
                dict.Add("ErrCode", "0");
                dict.Add("ErrMessage", "null");
                dict.Add("count", FindRst.Result.results.Count.ToString());
                foreach (AllUserObject userObj in FindRst.Result.results)
                {
                    Dictionary<string, string> tmpDict = ObjToDict.UsrInfo2Dict(userObj);
                    string UsrInfo = SimpleJson.SimpleJson.SerializeObject(tmpDict);
                    dict.Add("num_" + FindRst.Result.results.IndexOf(userObj).ToString() + "", UsrInfo);
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
