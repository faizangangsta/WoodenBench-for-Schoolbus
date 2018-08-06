using System.IO;
using System.Linq;
using System.Reflection;
using WBPlatform.StaticClasses.Properties;

namespace WBPlatform.StaticClasses
{

    public static partial class WBConsts
    {
        public static string CurrentCoreVersion => new FileInfo(new string(Assembly.GetExecutingAssembly().CodeBase.Skip(8).ToArray())).LastWriteTime.ToString();

        public static readonly string BmobAppKey = Resources.BmobDatabaseApplicationID;
        public static readonly string BmobRESTKey = Resources.BmobDatabaseREST;

        public const string TABLE_Mgr_StuData = "StudentsData";
        public const string TABLE_Mgr_Classes = "Classes";
        public const string TABLE_Mgr_BusData = "SchoolBuses";
        public const string TABLE_Mgr_WeekIssue = "WeeklyIssues";

        public const string TABLE_Gen_UserTable = "AllUsersTable";
        public const string TABLE_Gen_General = "GeneralData";
        public const string TABLE_Gen_Bugreport = "UserQuestions";

        public const string TABLE_Gen_Notification = "Notifications";
        public const string TABLE_Gen_UserRequest = "UserRequest";

    }
    public enum UserChangeRequestTypes
    {
        真实姓名 = 0,
        手机号码 = 1,
        班级 = 2,
        孩子 = 3,
        校车 = 4
    }

    public enum OperationStatus
    {
        Completed = 1,
        Failed = 0
    }
    public enum LogLevel
    {
        Dbg = 0,
        Info = 1,
        Warn = 2,
        Err = 3,
    }
    public enum NotificationType
    {
        WindowsClient = 1,
        WeChatC2C = 2,
        WeChatMultiCast = 3,
        WeChatBroadCast = 4
    }
    public enum BusReportTypeE
    {
        堵车 = 0,
        事故 = 1,
        学生迟到 = 2,
        到校 = 3,
        到家 = 4,
        其他 = 9,
    }

    public enum DBVerbs
    {
        Create = 0,
        QuerySingle = 1,
        QueryMulti = 2,
        Update = 3,
        Delete = 4
    }

    public enum DBQueryStatus
    {
        INJECTION_DETECTED = -3,
        NOT_CONNECTED = -2,
        INTERNAL_ERROR = -1,
        NO_RESULTS = 0,
        ONE_RESULT = 1,
        MORE_RESULTS
    }

    public enum GlobalMessageTypes
    {
        UCR_Created_TO_ADMIN = 0, UCR_Created__TO_User = 1,
        UCR_Procced_TO_ADMIN = 2, UCR_Procceed_TO_User = 3,
        User__Pending_Verify = 4, User__Finishd_Verify = 5,
        Bus_Status_Report_TC = 6, Bus_Status_Report_TP = 7
    }
    public enum UCRProcessStatus
    {
        NotSolved = -1, Accepted = 0, Refused = 1
    }
    public enum UCRRefusedReasons
    {
        理由不充分 = 0, 格式有误_请重新填写 = 1, 其他原因 = -1
    }
}
