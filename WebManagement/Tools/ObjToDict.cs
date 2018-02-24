using System.Collections.Generic;
using WBServicePlatform.TableObject;

namespace WBServicePlatform.WebManagement.Controllers
{
    public class ObjToDict
    {
        public static Dictionary<string, string> UsrInfo2Dict(AllUserObject UserInfo)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "userID", UserInfo.objectId },
                { "CreatedAt", UserInfo.createdAt },
                { "HeadImagePath", UserInfo.HeadImagePath },
                { "Password", UserInfo.Password },
                { "RealName", UserInfo.RealName },
                { "UserGroup", UserInfo.UserGroup.ToString() },
                { "Username", UserInfo.UserName },
                { "FirstLogin", UserInfo.FirstLogin.ToString() },
                { "WebNotiSeen", UserInfo.WebNotiSeen.ToString() },
                { "WeChatID", UserInfo.WeChatID }
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
                { "ComingChecked", BusObject.CSChecked.ToString() },
                { "LeavingChecked", BusObject.LSChecked.ToString()},
                { "TeacherID", BusObject.TeacherID }
            };
            return dict;
        }
        public static Dictionary<string, string> StuInfo2Dict(StudentDataObject StuObject)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "StuID", StuObject.objectId },
                { "Name", StuObject.StudentName },
                { "BusID", StuObject.BusID },
                { "ClassID", StuObject.ClassID },
                { "ComingChecked", StuObject.CSChecked.ToString() },
                { "LeavingChecked", StuObject.LSChecked.ToString() },
                { "ParentLeavingChecked", StuObject.CHChecked.ToString() },
            };
            return dict;
        }
    }
}