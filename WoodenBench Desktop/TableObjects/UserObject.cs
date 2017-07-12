using cn.bmob.io;
using System;
using WoodenBench.staClass;

namespace WoodenBench.TableObjects
{
    /// <summary>
    /// DON'T CHANGE CLASS NAME  'AllUsersTable'
    /// </summary>
    public class AllUsersTable : BmobTable
    {
        public enum UserGroupEnum { 管理组用户, 班主任, 高层管理, 家长 }
        public override string table { get { return GlobalFunc.TABLE_N_Gen_UsrTable; } }
        public string objectId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserGroup { get; set; }
        public bool WebNotiSeen { get; set; }
        public string WeChatID { get; set; }
        public string RealName { get; set; }
        public AllUsersTable() { }
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            UserName = input.getString("Username");
            Password = input.getString("Password");
            WeChatID = input.getString("WeChatID");
            UserGroup = input.getInt("UsrGroup").Get();
            WebNotiSeen = input.getBoolean("WebNotiSeen").Get();
            RealName = input.getString("RealName");
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("WebNotiSeen", WebNotiSeen);
            output.Put("Username", this.UserName);
            output.Put("Password", this.Password);
            output.Put("WeChatID", this.WeChatID);
            output.Put("UsrGroup", this.UserGroup);
            output.Put("RealName", this.RealName);
        }
    }
}