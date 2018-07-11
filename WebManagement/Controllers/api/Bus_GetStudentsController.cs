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
    [Route("api/bus/GetStudents")]
    public class GetStudentsController : WebAPIController
    {
        [HttpGet]
        public IEnumerable Get(string BusID, string TeacherID, string Session, string STAMP)
        {
            if (!Sessions.OnSessionReceived(Session, Request.Headers["User-Agent"], out UserObject user)) return SessionError;
            if (!(user.objectId == TeacherID)) return UserGroupError;
            //user.UserGroup.BusID == BusID &&
            if (Cryptography.SHA256Encrypt(BusID + ";;" + Session + user.objectId + ";;" + Session) != STAMP) return RequestIllegal;
            DBQuery BusQuery = new DBQuery();
            BusQuery.WhereEqualTo("objectId", BusID);
            BusQuery.WhereEqualTo("TeacherObjectID", TeacherID);
            switch (DatabaseOperation.QueryMultipleData(BusQuery, out List<SchoolBusObject> BusList))
            {
                case DBQueryStatus.INTERNAL_ERROR: return InternalError;
                default:
                    {
                        if (BusList.Count == 0)
                        {
                            BusList.Add(new SchoolBusObject() { objectId = "0000000000", BusName = "未找到校车", TeacherID = user.objectId });
                        }
                        DBQuery StudentQuery = new DBQuery();
                        StudentQuery.WhereEqualTo("BusID", BusList[0].objectId);
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        switch (DatabaseOperation.QueryMultipleData(StudentQuery, out List<StudentObject> StudentList))
                        {
                            case DBQueryStatus.INTERNAL_ERROR: return DataBaseError;
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