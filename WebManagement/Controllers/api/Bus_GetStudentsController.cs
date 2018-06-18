﻿using System.Collections;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/GetStudents")]
    public class GetStudentsController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string BusID, string TeacherID, string Session, string STAMP)
        {
            if (!Sessions.OnSessionReceived(Session, Request.Headers["User-Agent"], out UserObject user)) return WebAPIResponseCollections.SessionError;
            if (!( user.objectId == TeacherID))//user.UserGroup.BusID == BusID &&
                return WebAPIResponseCollections.UserGroupError;
            if (Crypto.SHA256Encrypt(BusID + ";;" + Session + user.objectId + ";;" + Session) != STAMP) return WebAPIResponseCollections.RequestIllegal;
            DataBaseQuery BusQuery = new DataBaseQuery();
            BusQuery.WhereEqualTo("objectId", BusID);
            BusQuery.WhereEqualTo("TeacherObjectID", TeacherID);
            switch (Database.QueryMultipleData(BusQuery, out List<SchoolBusObject> BusList))
            {
                case DatabaseQueryResult.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                case DatabaseQueryResult.NO_RESULTS: return WebAPIResponseCollections.DatabaseError;
                default:
                    {
                        DataBaseQuery StudentQuery = new DataBaseQuery();
                        StudentQuery.WhereEqualTo("BusID", BusList[0].objectId);
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        switch (Database.QueryMultipleData(StudentQuery, out List<StudentObject> StudentList))
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
    }
}