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
    public enum UserChangeRequestTypes { 真实姓名, 手机号码, 班级, 孩子, 校车 }
    public enum OperationStatus { Completed, Failed }
    public enum LogType { Err, Info, LongChain }
    public enum NotificationType { WindowsClient, WeChatC2C, WeChatMultiCast, WeChatBroadCast }
    public enum BusReportTypeE { 堵车 = 0, 事故 = 1, 其他 = 9, }
    public enum DatabaseQueryResult { INTERNAL_ERROR = -1, NO_RESULTS = 0, ONE_RESULT = 1, MORE_RESULTS }
    public enum GlobalMessageTypes
    {
        UCR_Created, UCR_Solved
    }
}
