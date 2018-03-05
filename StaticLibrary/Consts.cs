using System;
using System.Collections.Generic;
using System.Text;

namespace WBServicePlatform.StaticClasses
{

    public static partial class WBConst
    {
        public static class WeChat
        {
            public const string CorpID = "wx68bec13e85ca6465";
            public const string CorpSecret = "DatZ0P349SEAS-yDiqpHbb_3VR-kAnKtSaZj39KuWmhJqiiIjmW83LDpIvE49-Gt";

            public static string AccessTicket { get; set; }
            public static DateTime AvailableTime_Ticket { get; set; }


            public static string AccessToken { get; set; }
            public static DateTime AvailableTime_Token { get; set; }

            public const string AccessToken_Url =
                "https://qyapi.weixin.qq.com/cgi-bin/gettoken?" + "corpid=" + CorpID + "&corpsecret=" + CorpSecret;

        }
        public static readonly Dictionary<string, string> RequestIllegal = new Dictionary<string, string> { { "ErrCode", "999" }, { "ErrMessage", "Request Illegal" } };
        public static readonly Dictionary<string, string> SessionError = new Dictionary<string, string> { { "ErrCode", "1" }, { "ErrMessage", "Session Invalid" } };
        public static readonly Dictionary<string, string> InternalError = new Dictionary<string, string> { { "ErrCode", "997" }, { "ErrMessage", "Internal Error" } };


        public static Dictionary<string, string> SpecialisedError(string ErrorMessage) => new Dictionary<string, string> { { "ErrCode", "998" }, { "ErrMessage", ErrorMessage } };

        public const string BmobAppKey = "b770100ff0051b0c313c1a0e975711e6";
        public const string BmobRESTKey = "281fb4c79c3a3391ae6764fa56d1468d";

        public const string TABLE_N_Mgr_StuData = "StudentsData";
        public const string TABLE_N_Mgr_Classes = "Classes";
        public const string TABLE_N_Mgr_BusData = "SchoolBuses";
        public const string TABLE_N_Mgr_WeekIssue = "WeeklyIssues";

        public const string TABLE_N_Gen_UserTable = "AllUsersTable";
        public const string TABLE_N_Gen_Notifi = "GeneralData";
        public const string TABLE_N_Gen_Bugreport = "UserQuestions";

        public const string OBJ_ID_Notifi = "H26yBBBi";
        public const string OBJ_ID_WinClientVer = "oRr7000l";

    }
    public enum OperationStatus { Unknown, Completed, Failed }
    public enum UserActivityE { Login, LogOff, ChangePassword, UploadHImage, Compare, Create }
    public enum LogLevel { Error, Infomation, Seperator }
    public enum ExcelOperationE { OpenApp, QuitApp, Open, Read, Write, Close }
    public enum BusReportTypeE { 堵车 = 0, 事故 = 1, 其他 = 9, }
}
