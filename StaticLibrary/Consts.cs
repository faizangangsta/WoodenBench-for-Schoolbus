using System.IO;
using System.Linq;
using System.Reflection;

namespace WBServicePlatform.StaticClasses
{

    public static partial class WBConsts
    {
        public static string CurrentCoreVersion => new FileInfo(new string(Assembly.GetExecutingAssembly().CodeBase.Skip(8).ToArray())).LastWriteTime.ToString();

        public const string BmobAppKey = "b770100ff0051b0c313c1a0e975711e6";
        public const string BmobRESTKey = "281fb4c79c3a3391ae6764fa56d1468d";

        public const string TABLE_N_Mgr_StuData = "StudentsData";
        public const string TABLE_N_Mgr_Classes = "Classes";
        public const string TABLE_N_Mgr_BusData = "SchoolBuses";
        public const string TABLE_N_Mgr_WeekIssue = "WeeklyIssues";

        public const string TABLE_N_Gen_UserTable = "AllUsersTable";
        public const string TABLE_N_Gen_Notifi = "GeneralData";
        public const string TABLE_N_Gen_Bugreport = "UserQuestions";
        public const string TABLE_N_Gen_UserRequest  = "UserRequest";

        public const string OBJ_ID_Notifi = "H26yBBBi";
        public const string OBJ_ID_WinClientVer = "oRr7000l";

    }
    public enum UserChangeRequestTypes { Realname, PhoneNumber, ClassID, ChildID, BusID }
    public enum OperationStatus { Unknown, Completed, Failed }
    public enum UserActivityE { Login, Logout, ChangePassword, UploadHImage, Compare }
    public enum LogLevel { Error, Infomation, Seperator }
    public enum ExcelOperationE { OpenApp, QuitApp, Open, Read, Write, Close }
    public enum BusReportTypeE { 堵车 = 0, 事故 = 1, 其他 = 9, }
}
