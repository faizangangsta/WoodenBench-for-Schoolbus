using System;
using System.Linq;

namespace WBPlatform.StaticClasses
{
    public struct UserGroup
    {
        public bool IsAdmin { get; private set; }
        public bool IsBusManager { get; private set; }
        public bool IsClassTeacher { get; private set; }
        public bool IsParent { get; private set; }

        //public int ChildCounts { get; private set; }
        //public int ClassCounts { get; private set; }
        public string BusID { get; set; }

        //public UserGroup(bool Teacher, bool BusManager, int ChildIDs)
        //{
        //    IsAdmin = false;
        //    IsClassTeacher = Teacher;
        //    IsBusManager = BusManager;
        //    IsParents = !(ChildIDs == 0);
        //    ChildCounts = ChildIDs;
        //    ClassesIds = IsClassTeacher ? new string[] { "1" } : new string[] { "0" };
        //    BusID = IsBusManager ? "1" : "0";
        //}

        public UserGroup(string groupIdentifier)
        {
            string[] tmpA = groupIdentifier.Split(new char[] { ',' });
            IsAdmin = tmpA[0].Substring(1) == "1";

            IsClassTeacher = tmpA[1].Substring(1) != "0";

            IsParent = tmpA[2].Substring(1) != "0";

            BusID = tmpA[3].Substring(1);
            IsBusManager = BusID != "0";
        }

        public override string ToString() => (BusID == null) ? null : "A" + (IsAdmin ? "1" : "0") + ",T" + (IsClassTeacher ? "1" : "0") + ",P" + (IsParent ? "1" : "0") + ",B" + BusID;
    }
}
