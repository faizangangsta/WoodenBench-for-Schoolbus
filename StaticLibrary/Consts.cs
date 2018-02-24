using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBServicePlatform.StaticClasses
{
    /// <summary>
    /// Constaant Values...
    /// </summary>
    public static partial class Consts
    {
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
    public enum UsrActvtiE { UsrLogin, UserLogOff, UserChangePassword, UserUploadHImage, UserCompare, UserCreate }
    public enum LogLevel { Error, Infomation, Seperator }
    public enum ExcelOperationE { OpenApp, QuitApp, Open, Read, Write, Close }
    public enum BusReportTypeE { 堵车 = 0, 事故 = 1, 其他 = 9, }
    public struct UserGroup
    {
        public bool IsAdmin { get; private set; }
        public bool IsBusManager { get; private set; }
        public bool IsClassTeacher { get; private set; }
        public bool IsParents { get; private set; }

        public string[] ClassesIds { get; set; }
        public string[] ChildIds { get; set; }
        public string BusID { get; set; }

        public UserGroup(bool Teacher, bool BusManager, bool Parent)
        {
            IsAdmin = false;
            IsClassTeacher = Teacher;
            IsBusManager = BusManager;
            IsParents = Parent;

            ChildIds = IsParents ? new string[] { "1" } : new string[] { "0" };
            ClassesIds = IsClassTeacher ? new string[] { "1" } : new string[] { "0" };
            BusID = IsBusManager ? "1" : "0";
        }

        public UserGroup(string groupIdentifier)
        {
            string[] tmpA = groupIdentifier.Split(new char[] { ',' });
            IsAdmin = Convert.ToBoolean(Convert.ToInt32(tmpA[0].Substring(1)));

            ClassesIds = tmpA[1].Substring(1).Split(new char[] { '|' });
            ClassesIds = ClassesIds.Take(ClassesIds.Length - 1).ToArray();
            IsClassTeacher = !(ClassesIds[0] == "0");

            ChildIds = tmpA[2].Substring(1).Split(new char[] { '|' });
            ChildIds = ChildIds.Take(ChildIds.Length - 1).ToArray();
            IsParents = !(ChildIds[0] == "0");

            BusID = tmpA[3].Substring(1);
            IsBusManager = !(BusID == "0");
        }
        public override string ToString()
        {
            string toStr = "A" + (Convert.ToInt32(IsAdmin)).ToString() + ",T";
            foreach (string item in ClassesIds)
            {
                toStr = toStr + item + "|";
            }
            toStr = toStr + ",P";
            foreach (string item in ChildIds)
            {
                toStr = toStr + item + "|";
            }
            toStr = toStr + ",B" + BusID;
            return toStr;
        }
    }
}
