using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/QueryStudents")]
    public class QueryStudentsController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string BusID, string Column, string Content, string STAMP, string SALT)
        {
            if (Crypto.SHA256Encrypt(BusID + ";;" + SALT + Column + ";" + Content + ";;" + SALT) != STAMP) return WebAPIResponseErrors.RequestIllegal;

            BmobQuery query = new BmobQuery();
            query.WhereEqualTo("objectId", BusID);
            switch (QueryHelper.BmobQueryData(query, out List<SchoolBusObject> BusList))
            {
                case -1: return WebAPIResponseErrors.InternalError;
                case 0: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                default:
                    {
                        object Equals2Obj = Content;
                        if (Int32.TryParse((string)Equals2Obj, out int EqInt)) Equals2Obj = EqInt;
                        else if (((string)Equals2Obj).ToLower() == "true") Equals2Obj = true;
                        else if (((string)Equals2Obj).ToLower() == "false") Equals2Obj = false;
                        BmobQuery query2 = new BmobQuery();
                        query2.WhereEqualTo("BusID", BusList[0].objectId);
                        query2.WhereEqualTo(Column, Equals2Obj);
                        switch (QueryHelper.BmobQueryData(query2, out List<StudentObject> StudentList))
                        {
                            case -1: return WebAPIResponseErrors.InternalError;
                            case 0: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                            default:

                                Dictionary<string, string> dict = new Dictionary<string, string> { { "count", StudentList.Count.ToString() } };
                                for (int i = 0; i < StudentList.Count; i++)
                                {
                                    dict.Add("num_" + i.ToString(), StudentList[i].ToString());
                                }
                                dict.Add("ErrCode", "0");
                                dict.Add("ErrMsg", "null");
                                return dict;
                        }
                    }
            }
        }
    }
}
