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
    public enum LogType
    {
        Err = 3,
        Info = 1,
        LongChain = 0
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
        其他 = 9,
    }

    public enum DBOperation
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
    /// <summary>
    /// Message Types -->   0b + MessageType + (int)isSentToUser
    /// </summary>
    public enum GlobalMessageTypes
    {
        UCR_Created_TO_ADMIN = 0b00000010, UCR_Created_TO_User = 0b00000011,
        UCR_Procced_TO_ADMIN = 0b00000100, UCR_Procced_TO_User = 0b00000101,
        User__Pending_Verify = 0b00001000, User__Finish_Verify = 0b00001001
    }
    public enum UserChangeRequestProcessStatus
    {
        NotSolved = -1, Accepted = 0, Refused = 1
    }
    public enum UserChangeRequestRefusedReasons
    {
        理由不充分 = 0, 格式有误_请重新填写 = 1, 其他原因 = -1
    }
}
