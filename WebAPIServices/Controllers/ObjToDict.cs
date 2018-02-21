using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WBServicePlatform.TableObject;
using WBServicePlatform.Users;

namespace WBServicePlatform.WebAPIServices.Controllers
{
    public class ObjToDict
    {
        public static Dictionary<string, string> UsrInfo2Dict(AllUserObject UserInfo)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "userID", UserInfo.objectId },
                { "CreatedAt", UserInfo.createdAt },
                { "HeadImagePath", UserInfo.HeadImgData },
                { "Password", UserInfo.Password },
                { "RealName", UserInfo.RealName },
                { "UserGroup", ((int)UserInfo.UserGroup).ToString() },
                { "Username", UserInfo.UserName },
                { "FirstLogin", UserInfo.isFstLogin.ToString() },
                { "WebNotiSeen", UserInfo.WebNotiSeen.ToString() },
                { "WeChatID", UserInfo.WeChatID },
                { "IsBusTeacher", UserInfo.IsBusTeacher.ToString() }
            };
            return dict;
        }

        public static Dictionary<string, string> BusInfo2Dict(SchoolBusObject BusObject)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "busID", BusObject.objectId },
                { "CreatedAt", BusObject.createdAt },
                { "Name", BusObject.BusName },
                { "ComingChecked", BusObject.ComingChecked ?? "" },
                { "LeavingChecked", BusObject.LeavingChecked ?? "" },
                { "TeacherID", BusObject.TeacherID },
                { "TeacherName", BusObject.TeacherName }
            };
            return dict;
        }
        public static Dictionary<string, string> StuInfo2Dict(StudentDataObject StuObject)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "StuID", StuObject.objectId },
                { "Name", StuObject.StudentName },
                { "Direction", StuObject.StudentDirection },
                { "BusID", StuObject.BusID },
                { "PartOfSchool", StuObject.StudentPartOfSchool },
                { "Year", StuObject.StudentYear },
                { "Class", StuObject.StudentClass },
                { "ComingChecked", StuObject.ComeChecked.ToString() },
                { "LeavingChecked", StuObject.LeaveChecked.ToString() },
                { "ParentComingChecked", StuObject.ParentComeChecked.ToString() },
                { "ParentLeavingChecked", StuObject.ParentLeaveChecked.ToString() },
            };
            return dict;
        }
    }
}