using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoodenBench.StaClasses
{
    public static partial class Consts
    {
        /// <summary>
        /// All students Table
        /// </summary>
        public const string TABLE_N_Mgr_StuData = "AllStudentsBData";

        /// <summary>
        /// All Users Table
        /// </summary>
        public const string TABLE_N_Gen_UsrTable = "AllUsersTable";

        /// <summary>
        /// General used data Table
        /// </summary>
        public const string TABLE_N_Gen_Notifi = "GeneralData";

        /// <summary>
        /// Weekly Issues are gathered here...
        /// </summary>
        public const string TABLE_N_Mgr_WeekIssue = "WeeklyIssues";

        /// <summary>
        /// User maybe report their BUGs.
        /// </summary>
        public const string TABLE_N_Gen_Bugreport = "UserQuestions";

        /// <summary>
        /// Notification objectID in the <see cref="TABLE_N_Gen_Notifi"/> Table
        /// </summary>
        public const string OBJ_ID_Notifi = "H26yBBBi";

        /// <summary>
        /// Windows Client Version String
        /// </summary>
        public const string OBJ_ID_WinClientVer = "oRr7000l";

        /// <summary>
        /// The User Group Enum
        /// </summary>
    }
    public enum UserGroupEnum
    {
        管理组用户,
        老师,
        高层管理,
        家长
    }

    public enum ProcStatE
    {
        Unknown,
        Completed,
        Failed,
        FailedWithErr
    }

    public enum UsrActvtiE
    {
        UsrLogin,
        UserLogOff,
        UserChangePassword,
        UserUploadHImage,
        UserCompare
    }
}
