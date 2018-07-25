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
            if (!ValidateSession()) return SessionError;
            if (!(CurrentUser.ObjectId == TeacherID)) return UserGroupError;
            //user.UserGroup.BusID == BusID &&
            if (Cryptography.SHA256Encrypt(BusID + ";;" + Session + CurrentUser.ObjectId + ";;" + Session) != STAMP) return RequestIllegal;
            DBQuery BusQuery = new DBQuery();
            BusQuery.WhereEqualTo("objectId", BusID);
            BusQuery.WhereEqualTo("TeacherObjectID", TeacherID);
            switch (DataBaseOperation.QueryMultipleData(BusQuery, out List<SchoolBusObject> BusList))
            {
                case DBQueryStatus.INTERNAL_ERROR: return InternalError;
                default:
                    {
                        if (BusList.Count == 0)
                        {
                            BusList.Add(new SchoolBusObject() { ObjectId = "0000000000", BusName = "未找到校车", TeacherID = CurrentUser.ObjectId });
                        }
                        DBQuery StudentQuery = new DBQuery();
                        StudentQuery.WhereEqualTo("BusID", BusList[0].ObjectId);
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        switch (DataBaseOperation.QueryMultipleData(StudentQuery, out List<StudentObject> StudentList))
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