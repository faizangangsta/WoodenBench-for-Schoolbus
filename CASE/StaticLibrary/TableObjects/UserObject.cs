using System.Collections.Generic;
using Newtonsoft.Json;
using WBPlatform.Database;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.StaticClasses;

using static WBPlatform.StaticClasses.Cryptography;

namespace WBPlatform.TableObject
{
    public class UserObject : DataTableObject
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

        public override void readFields(DBInput input)
        {
            base.readFields(input);
            UserName = input.GetString("Username");
            Password = input.GetString("Password");
            Sex = input.GetString("Sex");

            UserGroup = new UserGroup(
                isAdmin: input.GetBool("isAdmin"), 
                isTeacher: input.GetBool("isClassTeacher"), 
                isBusManager: input.GetBool("isBusTeacher"), 
                isParent: input.GetBool("isParent"));

            
            RealName = input.GetString("RealName");
            HeadImagePath = input.GetString("HeadImage");
            PhoneNumber = input.GetString("PhoneNumber");

            ClassList = input.GetList("ClassIDs");
            ChildList = input.GetList("ChildIDs");
        }

        public override void write(DBOutput output, bool all)
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

        public override string ToString() => JsonConvert.SerializeObject(ToDictionary());

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
                { "CreatedAt", createdAt.ToString("yyyy-MM-dd HH:mm:ss") },
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