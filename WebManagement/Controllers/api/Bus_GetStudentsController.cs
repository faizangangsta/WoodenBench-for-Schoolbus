using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/GetStudents")]
    public class GetStudentsController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string BusID, string TeacherID, string Session, string STAMP)
        {
            if (!Sessions.OnSessionReceived(Session, Request.Headers["User-Agent"], out UserObject user)) return WebAPIResponseErrors.SessionError;
            if (!(user.UserGroup.BusID == BusID && user.objectId == TeacherID))
                return WebAPIResponseErrors.UserGroupError;
            if (Crypto.SHA256Encrypt(user.UserGroup.BusID + ";;" + Session + user.objectId + ";;" + Session) != STAMP) return WebAPIResponseErrors.RequestIllegal;
            BmobQuery BusQuery = new BmobQuery();
            BusQuery.WhereEqualTo("objectId", BusID);
            BusQuery.WhereEqualTo("TeacherObjectID", TeacherID);
            switch (QueryHelper.BmobQueryData(BusQuery, out List<SchoolBusObject> BusList))
            {
                case -1: return WebAPIResponseErrors.InternalError;
                case 0: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                default:
                    {
                        BmobQuery StudentQuery = new BmobQuery();
                        StudentQuery.WhereEqualTo("BusID", BusList[0].objectId);
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        switch (QueryHelper.BmobQueryData(StudentQuery, out List<StudentObject> StudentList))
                        {
                            case -1: return WebAPIResponseErrors.InternalError;
                            case 0: return WebAPIResponseErrors.SpecialisedError("No Result Found");
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