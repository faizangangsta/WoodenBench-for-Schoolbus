using System.Collections.Generic;

using cn.bmob.io;

using WBPlatform.StaticClasses;

using static WBPlatform.StaticClasses.Crypto;

namespace WBPlatform.TableObject
{
    public class UserObject : DataTable
    {
        public override string table => WBConsts.TABLE_Gen_UserTable;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string Sex { get; set; }

        public UserGroup UserGroup;
        
        public string HeadImagePath { get; set; }
        public string PhoneNumber { get; set; }

        public List<string> ChildList { get; set; } = new List<string>();
        public List<string> ClassList { get; set; } = new List<string>();

        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            UserName = input.getString("Username");
            Password = input.getString("Password");
            Sex = input.getString("Sex");

            UserGroup = new UserGroup(
                isAdmin: input.getBoolean("isAdmin").Get(), 
                isTeacher: input.getBoolean("isClassTeacher").Get(), 
                isBusManager: input.getBoolean("isBusTeacher").Get(), 
                isParent: input.getBoolean("isParent").Get());

            
            RealName = input.getString("RealName");
            HeadImagePath = input.getString("HeadImage");
            PhoneNumber = input.getString("PhoneNumber");

            ClassList = input.getList<string>("ClassIDs");
            ChildList = input.getList<string>("ChildIDs");
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("Username", UserName);
            output.Put("Password", Password);
            output.Put("Sex", Sex);

            //output.Put("isAdmin", UserGroup.IsAdmin);  DISABLED DUE TO SECURTY ISSUE....
            output.Put("isClassTeacher", UserGroup.IsClassTeacher);
            output.Put("isBusTeacher", UserGroup.IsBusManager);
            output.Put("isParent", UserGroup.IsParent);

            output.Put("RealName", RealName);
            output.Put("HeadImage", HeadImagePath);
            output.Put("PhoneNumber", PhoneNumber);

            output.Put("ClassIDs", ClassList);
            output.Put("ChildIDs", ChildList);
        }

        public UserObject SetEveryThingNull()
        {
            objectId = RandomString(10, true, CustomStr: RandomString(5, true));
            UserName = RandomString(10, true, CustomStr: RandomString(5, true));
            Password = RandomString(10, true, CustomStr: RandomString(5, true));
            RealName = RandomString(10, true, CustomStr: RandomString(5, true));
            HeadImagePath = RandomString(10, true, CustomStr: RandomString(5, true));
            UserGroup = new UserGroup(false, false, false, false);
            return this;
        }
        public string GetIdentifiableCode()
        {
            return UserName + "-" + objectId;
        }

        public static UserObject RandomValue => new UserObject().SetEveryThingNull();

        public override string ToString() => SimpleJson.SimpleJson.SerializeObject(ToDictionary());

        public string GetClassIdString(char Splitter)
        {
            string result = "";
            foreach (string item in ClassList)
            {
                result = result + item + Splitter.ToString();
            }
            return result;
        }

        public string GetChildIdString(char Splitter)
        {
            string result = "";
            foreach (string item in ChildList)
            {
                result = result + item + Splitter.ToString();
            }
            return result;
        }


        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>
            {
                { "userID", objectId },
                { "RealName", RealName },
                { "Username", UserName },
                { "CreatedAt", createdAt },
                { "HeadImagePath", HeadImagePath },
                { "PhoneNumber", PhoneNumber },
                { "hasPassword", (!string.IsNullOrEmpty(Password)).ToString() },
                //UserGroup
                { "IsBusTeacher", UserGroup.IsBusManager.ToString().ToLower() },
                { "IsParent" ,UserGroup.IsParent.ToString().ToLower()},
                { "IsClassTeacher" , UserGroup.IsClassTeacher.ToString().ToLower() },
                //{ "BusID", UserGroup.BusID },
                { "ClassIDs", GetClassIdString(';') }
            };
        }
    }
}