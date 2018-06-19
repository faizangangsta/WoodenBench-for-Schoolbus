using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/QueryStudents")]
    public class QueryStudentsController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string BusID, string Column, string Content, string STAMP, string SALT)
        {
            if (Crypto.SHA256Encrypt(BusID + ";;" + SALT + Column + ";" + Content + ";;" + SALT) != STAMP) return WebAPIResponseCollections.RequestIllegal;

            DBQuery query = new DBQuery();
            query.WhereEqualTo("objectId", BusID);
            switch (Database.Database.QueryMultipleData(query, out List<SchoolBusObject> BusList))
            {
                case DatabaseOperationResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                case DatabaseOperationResult.NO_RESULTS: return WebAPIResponseCollections.DatabaseError;
                default:
                    {
                        object Equals2Obj = Content;
                        if (int.TryParse((string)Equals2Obj, out int EqInt)) Equals2Obj = EqInt;
                        else if (((string)Equals2Obj).ToLower() == "true") Equals2Obj = true;
                        else if (((string)Equals2Obj).ToLower() == "false") Equals2Obj = false;
                        DBQuery query2 = new DBQuery();
                        query2.WhereEqualTo("BusID", BusList[0].objectId);
                        query2.WhereEqualTo(Column, Equals2Obj);
                        switch (Database.Database.QueryMultipleData(query2, out List<StudentObject> StudentList))
                        {
                            case DatabaseOperationResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                            case DatabaseOperationResult.NO_RESULTS: return WebAPIResponseCollections.DatabaseError;
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
