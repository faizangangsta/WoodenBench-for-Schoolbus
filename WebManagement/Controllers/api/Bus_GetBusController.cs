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
    [Route("api/bus/GetBuses")]
    public class Bus_GetBusController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string UserID, string Session)
        {
            if (Sessions.OnSessionReceived(Session, Request.Headers["User-Agent"], out UserObject SessionUser))
            {
                if (SessionUser.objectId == UserID && SessionUser.UserGroup.IsBusManager)//&& SessionUser.UserGroup.BusID == BusID
                {
                    switch (DatabaseOperation.QueryMultipleData(new DBQuery().WhereEqualTo("TeacherObjectID", UserID), out List<SchoolBusObject> BusList))
                    {
                        case DBQueryStatus.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
                        default:
                            if (BusList.Count == 0)
                            {
                                BusList.Add(new SchoolBusObject() { objectId = "0000000000", BusName = "未找到校车", TeacherID = SessionUser.objectId });
                            }
                            int LSChecked = 0, CSChecked = 0, AHChecked = 0;
                            switch (DatabaseOperation.QueryMultipleData(new DBQuery().WhereEqualTo("BusID", BusList[0].objectId), out List<StudentObject> StudentList))
                            {
                                case DBQueryStatus.INTERNAL_ERROR: return WebAPIResponseCollections.InternalError;
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
                else return WebAPIResponseCollections.RequestIllegal;
            }
            else return WebAPIResponseCollections.SessionError;
        }
    }
}
