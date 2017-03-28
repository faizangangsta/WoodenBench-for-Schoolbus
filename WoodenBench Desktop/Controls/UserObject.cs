//Game表对应的模型类
using cn.bmob.io;
using System;

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

	//读字段信息
	public override void readFields(BmobInput input)
	{
		base.readFields(input);
		UserName = input.getString("Username");
		Password = input.getString("Password");
		UserActAs = input.getInt("UserActAs").Get();
		UserPartOfSchool = input.getInt("PartOfSchool").Get();
	}

	//写字段信息
	public override void write(BmobOutput output, bool all)
	{
		base.write(output, all);
		output.Put("Username", this.UserName);
		output.Put("Password", this.Password);
		output.Put("UserActAs", this.UserActAs);
		output.Put("PartOfSchool", UserPartOfSchool);
	}
}

namespace WoodenBench_Desktop.Controls
{
	public class UserController
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string UserID { get; set; }
		public UserGroup UserGroup { get; set; }
		public UserController() { }
		public string LoginTime { get; set; }
		public UserPartOS UserPartOfSchool { get; set; }
	}
	public enum UserGroup
	{
		管理组用户,
		班主任或一般老师,
		校车管理老师,
		家长
	}
	public enum UserPartOS
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