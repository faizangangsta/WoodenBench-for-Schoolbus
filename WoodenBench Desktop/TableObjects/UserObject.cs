//Game表对应的模型类
using cn.bmob.io;
using System;

namespace WoodenBench_Desktop.TableObjects
{
    public class UserTableObj : BmobTable
    {
        private string MyTable;

        public string UserID { get; set; }
        public UserGroupEnum UserGroup { get; set; }
        public string LoginTime { get; set; }
        //以下对应云端字段名称
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CUserGroup { get; set; }

        //构造函数
        public UserTableObj() { }

        //构造函数
        public UserTableObj(String TableName)
        {
            MyTable = TableName;
        }

        public override string table
        {
            get
            {
                if (MyTable != null) { return MyTable; }
                return base.table;
            }
        }
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            UserName = input.getString("Username");
            Password = input.getString("Password");
            CUserGroup = input.getInt("UsrGroup").Get();
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("Username", this.UserName);
            output.Put("Password", this.Password);
            output.Put("UsrGroup", this.CUserGroup);
        }
    }
    public enum UserGroupEnum
    {
        管理组用户,
        小学部_班主任,
        初中部_班主任,
        普通高中部_班主任,
        中加高中部_班主任,
        留学生部_班主任,
        剑桥高中部_班主任,
        校车管理老师,
        家长
    }
}