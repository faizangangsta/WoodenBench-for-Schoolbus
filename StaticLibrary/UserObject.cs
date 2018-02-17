using cn.bmob.io;
using System.Drawing;
using WoodenBench.StaticClasses;
using static WoodenBench.StaticClasses.Crypto;

namespace WoodenBench.Users
{
    /// <summary>
    /// This is the class which for all users as one object
    /// </summary>
    public class AllUserObject : BmobTable
    {
        public override string table => Consts.TABLE_N_Gen_UsrTable;
        public string UserName { get; set; }
        public bool isFstLogin { get; set; }
        public string Password { get; set; }
        public UserGroupEnum UserGroup { get; set; }
        public bool WebNotiSeen { get; set; }
        public string WeChatID { get; set; }
        public string RealName { get; set; }
        public string HeadImgData { get; set; }
        public Image UserImage { get; set; }
        public bool IsBusTeacher { get; set; }
        public AllUserObject() { }
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            UserName = input.getString("Username");
            Password = input.getString("Password");
            WeChatID = input.getString("WeChatID");
            UserGroup = (UserGroupEnum)input.getInt("UsrGroup").Get();
            WebNotiSeen = input.getBoolean("WebNotiSeen").Get();
            RealName = input.getString("RealName");
            isFstLogin = input.getBoolean("IsFstLgn").Get();
            HeadImgData = input.getString("HeadImage");
            IsBusTeacher = input.getBoolean("isBusTeacher").Get();
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("WebNotiSeen", WebNotiSeen);
            output.Put("Username", UserName);
            output.Put("Password", Password);
            output.Put("WeChatID", WeChatID);
            output.Put("UsrGroup", (int)UserGroup);
            output.Put("RealName", RealName);
            output.Put("IsFstLgn", isFstLogin);
            output.Put("HeadImage", HeadImgData);
            output.Put("isBusTeacher", IsBusTeacher);
        }
        public void SetEveryThingNull()
        {
            objectId = RandomString(10, true, CustomStr: RandomString(5, true));
            UserName = RandomString(10, true, CustomStr: RandomString(5, true));
            Password = RandomString(10, true, CustomStr: RandomString(5, true));
            WeChatID = RandomString(10, true, CustomStr: RandomString(5, true));
            RealName = RandomString(10, true, CustomStr: RandomString(5, true));
            HeadImgData = RandomString(10, true, CustomStr: RandomString(5, true));
            UserGroup = UserGroupEnum.老师;
            WebNotiSeen = false;
        }
    }
}