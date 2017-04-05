//Game表对应的模型类
using cn.bmob.io;
using System;

namespace WoodenBench_Desktop.Controls.Users
{
	class UserObject : BmobTable
	{
		private string PriTable;
		//以下对应云端字段名称
		public string UserName { get; set; }
		public string Password { get; set; }
		public int UserActAs { get; set; }
		public int UserPartOfSchool { get; set; }

		//构造函数
		public UserObject() { }

		//构造函数
		public UserObject(String TableName)
		{
			PriTable = TableName;
		}

		public override string table
		{
			get
			{
				if (PriTable != null) { return PriTable; }
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
	}
}