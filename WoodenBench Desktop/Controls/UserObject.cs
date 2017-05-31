//Game表对应的模型类
using cn.bmob.io;
using System;

namespace WoodenBench_Desktop.Controls.Users
{
	public class UserTableElements : BmobTable
	{
		private string MyTable;
        
        public string UserID { get; set; }
        public UserGroupEnum UserGroup { get; set; }
        public string LoginTime { get; set; }
        public UserPartOSEnum _UserPartOfSchool { get; set; }
        //以下对应云端字段名称
        public string UserName { get; set; }
		public string Password { get; set; }
		public int UserActAs { get; set; }
		public int UserPartOfSchool { get; set; }

        //构造函数
        public UserTableElements() { }

        //构造函数
        public UserTableElements(String TableName)
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
			UserActAs = input.getInt("UserActAs").Get();
			UserPartOfSchool = input.getInt("PartOfSchool").Get();
		}

		public override void write(BmobOutput output, bool all)
		{
			base.write(output, all);
			output.Put("Username", this.UserName);
			output.Put("Password", this.Password);
			output.Put("UserActAs", this.UserActAs);
			output.Put("PartOfSchool", UserPartOfSchool);
		}
        public enum UserGroupEnum
        {
            管理组用户,
            班主任或一般老师,
            校车管理老师,
            家长
        }
        public enum UserPartOSEnum
        {
            管理组用户,
            小学部,
            初中部,
            普通高中部,
            中加高中部,
            留学生部,
            剑桥高中部,
            家长
        }
    }
}