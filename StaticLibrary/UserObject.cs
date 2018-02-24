using cn.bmob.io;
using System.Drawing;
using WBServicePlatform.StaticClasses;
using static WBServicePlatform.StaticClasses.Crypto;

namespace WBServicePlatform.TableObject
{
    /// <summary>
    /// This is the class which for all users as one object
    /// </summary>
    public class AllUserObject : BmobTable
    {
        public override string table => Consts.TABLE_N_Mgr_Classes;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }

        public UserGroup UserGroup;

        public bool FirstLogin { get; set; }
        public bool WebNotiSeen { get; set; }

        public string WeChatID { get; set; }
        public string HeadImagePath { get; set; }
        public string PhoneNumber { get; set; }

        public AllUserObject() { }
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            UserName = input.getString("Username");
            Password = input.getString("Password");
            WeChatID = input.getString("WeChatID");
            UserGroup = new UserGroup(input.getString("UserGroup"));
            WebNotiSeen = input.getBoolean("WebNotiSeen").Get();
            RealName = input.getString("RealName");
            FirstLogin = input.getBoolean("IsFstLgn").Get();
            HeadImagePath = input.getString("HeadImage");
            PhoneNumber = input.getString("PhoneNumber");
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("WebNotiSeen", WebNotiSeen);
            output.Put("Username", UserName);
            output.Put("Password", Password);
            output.Put("WeChatID", WeChatID);
            output.Put("UserGroup", UserGroup.ToString());
            output.Put("RealName", RealName);
            output.Put("IsFstLgn", FirstLogin);
            output.Put("HeadImage", HeadImagePath);
            output.Put("PhoneNumber", PhoneNumber);

        }

        public void SetEveryThingNull()
        {
            objectId = RandomString(10, true, CustomStr: RandomString(5, true));
            UserName = RandomString(10, true, CustomStr: RandomString(5, true));
            Password = RandomString(10, true, CustomStr: RandomString(5, true));
            WeChatID = RandomString(10, true, CustomStr: RandomString(5, true));
            RealName = RandomString(10, true, CustomStr: RandomString(5, true));
            HeadImagePath = RandomString(10, true, CustomStr: RandomString(5, true));
            UserGroup = new UserGroup("A0,T0;,P0;,B0");
            WebNotiSeen = false;
            FirstLogin = false;
        }
    }
}