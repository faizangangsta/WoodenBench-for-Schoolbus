using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/GetBuses")]
    public class Bus_GetBusController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string UserID, string BusID, string Session)
        {
            if (Tools.Sessions.OnSessionReceived(Session, Request.Headers["User-Agent"], out UserObject SessionUser))
            {
                if (SessionUser.objectId == UserID && SessionUser.UserGroup.IsBusManager && SessionUser.UserGroup.BusID == BusID)
                {
                    switch (Database.QueryMultipleData(new DatabaseQuery().WhereEqualTo("TeacherObjectID", UserID).WhereEqualTo("objectId", BusID), out List<SchoolBusObject> BusList))
                    {
                        case -1: return WebAPIResponseErrors.InternalError;
                        case 0: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                        default:
                            int LSChecked = 0, CSChecked = 0, AHChecked = 0;
                            switch (Database.QueryMultipleData(new DatabaseQuery().WhereEqualTo("BusID", BusID), out List<StudentObject> StudentList))
                            {
                                case -1: return WebAPIResponseErrors.InternalError;
                                case 0: return WebAPIResponseErrors.SpecialisedError("No Result Found");
                                default:
                                    Dictionary<string, string> dict = BusList[0].ToDictionary();
                                    foreach (StudentObject item in StudentList)
                                    {
                                        LSChecked = item.LSChecked ? LSChecked + 1 : LSChecked;
                                        CSChecked = item.CSChecked ? CSChecked + 1 : CSChecked;
                                        AHChecked = item.AHChecked ? AHChecked + 1 : AHChecked;
                                    }
                                    dict.Add("AHChecked", AHChecked.ToString());
                                    dict.Add("LSChecked", LSChecked.ToString());
                                    dict.Add("CSChecked", CSChecked.ToString());
                                    dict.Add("Total", StudentList.Count.ToString());
                                    dict.Add("ErrCode", "0");
                                    dict.Add("ErrMessage", "null");
                                    return dict;
                            }
                    }
                }
                else return WebAPIResponseErrors.RequestIllegal;
            }
            else return WebAPIResponseErrors.SessionError;
        }
    }
}
