﻿using cn.bmob.io;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/bus/GetBuses")]
    public class Bus_GetBusController : Controller
    {
        [HttpGet]
        public IEnumerable Get(string UserID, string BusID, string Session)
        {
            if (SessionManager.OnSessionReceived(Session, Request.Headers["User-Agent"], out UserObject SessionUser))
            {
                if (SessionUser.objectId == UserID && SessionUser.UserGroup.IsBusManager && SessionUser.UserGroup.BusID == BusID)
                {
                    switch (QueryHelper.BmobQueryData(new BmobQuery().WhereEqualTo("TeacherObjectID", UserID).WhereEqualTo("objectId", BusID), out List<SchoolBusObject> BusList))
                    {
                        case -1: return WBConst.InternalError;
                        case 0: return WBConst.SpecialisedError("No Result Found");
                        default:
                            int LSChecked = 0, CSChecked = 0, AHChecked = 0;
                            switch (QueryHelper.BmobQueryData(new BmobQuery().WhereEqualTo("BusID", BusID), out List<StudentDataObject> StudentList))
                            {
                                case -1: return WBConst.InternalError;
                                case 0: return WBConst.SpecialisedError("No Result Found");
                                default:
                                    Dictionary<string, string> dict = BusList[0].ToDictionary();
                                    foreach (StudentDataObject item in StudentList)
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
                else return WBConst.RequestIllegal;
            }
            else return WBConst.SessionError;
        }
    }
}
