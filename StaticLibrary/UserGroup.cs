using System;
using System.Linq;

namespace WBServicePlatform.StaticClasses
{
    public struct UserGroup
    {
        public bool IsAdmin { get; private set; }
        public bool IsBusManager { get; private set; }
        public bool IsClassTeacher { get; private set; }
        public bool IsParents { get; private set; }

        public string[] ClassesIds { get; set; }
        public string BusID { get; set; }

        public UserGroup(bool Teacher, bool BusManager, bool Parent)
        {
            IsAdmin = false;
            IsClassTeacher = Teacher;
            IsBusManager = BusManager;
            IsParents = Parent;

            ClassesIds = IsClassTeacher ? new string[] { "1" } : new string[] { "0" };
            BusID = IsBusManager ? "1" : "0";
        }

        public UserGroup(string groupIdentifier)
        {
            string[] tmpA = groupIdentifier.Split(new char[] { ',' });
            IsAdmin = Convert.ToBoolean(Convert.ToInt32(tmpA[0].Substring(1)));

            ClassesIds = tmpA[1].Substring(1).Split(new char[] { '|' }).Take(1).ToArray();
            //ClassesIds = ClassesIds.Take(ClassesIds.Length - 1).ToArray();
            IsClassTeacher = !(ClassesIds[0] == "0");

            IsParents = !(tmpA[2].Substring(1) == "0");

            BusID = tmpA[3].Substring(1);
            IsBusManager = !(BusID == "0");
        }

        public string GetClassIdString(char Splitter)
        {
            string result = "";
            foreach (string item in ClassesIds)
            {
                result = result + item + Splitter.ToString();
            }
            return result;
        }

        public override string ToString()
        {
            if (BusID == null || ClassesIds == null)
            {
                return null;
            }
            string toStr = "A" + (Convert.ToInt32(IsAdmin)).ToString() + ",T";
            foreach (string item in ClassesIds)
            {
                toStr = toStr + item + "|";
            }
            toStr = toStr + ",P" + (IsParents ? "1" : "0");
            toStr = toStr + ",B" + BusID;
            return toStr;
        }
    }
}
