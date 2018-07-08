using WBPlatform.TableObject;

namespace WBPlatform.WebManagement.Tools
{
    public class ViewStudentInfo
    {
        public ViewStudentInfo() { }
        public ViewStudentInfo(int parentsCount, bool classFound, bool classTeacherFound, bool busFound, bool busTeacherFound, StudentObject student, ClassObject @class, UserObject CTeacher, UserObject[] Parents, SchoolBusObject schoolbus, UserObject BTeacher, bool StudentFound)
        {
            ParentsCount = parentsCount;
            ClassFound = classFound;
            ClassTeacherFound = classTeacherFound;
            BusFound = busFound;
            BusTeacherFound = busTeacherFound;
            _student = student;
            _class = @class;
            _CTeacher = CTeacher;
            _Parents = Parents;
            _schoolbus = schoolbus;
            _BTeacher = BTeacher;
            this.StudentFound = StudentFound;
        }

        public bool StudentFound { get; set; }
        public int ParentsCount { get; set; }
        public bool ClassFound { get; set; }
        public bool ClassTeacherFound { get; set; }
        public bool BusFound { get; set; }
        public bool BusTeacherFound { get; set; }

        public StudentObject _student { get; set; }
        public ClassObject _class { get; set; }
        public UserObject _CTeacher { get; set; }
        public UserObject[] _Parents { get; set; }
        public SchoolBusObject _schoolbus { get; set; }
        public UserObject _BTeacher { get; set; }
    }
}
