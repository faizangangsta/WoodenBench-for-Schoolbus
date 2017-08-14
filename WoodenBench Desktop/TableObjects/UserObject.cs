using cn.bmob.io;
using System;
using WoodenBench.StaClasses;
using static WoodenBench.StaClasses.GlobalFunc;

namespace WoodenBench.TableObject
{
    /// <summary>
    /// DON'T CHANGE CLASS NAME  'AllUsersTable'
    /// </summary>
    public class AllUserObject : BmobTable
    {
        public override string table { get { return Consts.TABLE_N_Gen_UsrTable; } }
        public string objectId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealPassword { get; set; }
        public UserGroupEnum UserGroup { get; set; }
        public bool WebNotiSeen { get; set; }
        public string WeChatID { get; set; }
        public string RealName { get; set; }
        public BmobFile UserImage { get; set; }
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
            UserImage = input.Get<BmobFile>("HeadImage");
            RealPassword = input.getString("RealPassword");
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("WebNotiSeen", WebNotiSeen);
            output.Put("Username", this.UserName);
            output.Put("Password", this.Password);
            output.Put("WeChatID", this.WeChatID);
            output.Put("UsrGroup", (int)this.UserGroup);
            output.Put("RealName", this.RealName);
            output.Put("RealPassword", this.RealPassword);
            output.Put("HeadImage", this.UserImage);
        }
        public void SetEveryThingNull()
        {
            objectId = RandomString(10, true, CustomStr: RandomString(5, true));
            UserName = RandomString(10, true, CustomStr: RandomString(5, true));
            Password = RandomString(10, true, CustomStr: RandomString(5, true));
            WeChatID = RandomString(10, true, CustomStr: RandomString(5, true));
            RealName = RandomString(10, true, CustomStr: RandomString(5, true));
            UserGroup = UserGroupEnum.老师;
            WebNotiSeen = false;
        }
    }
}