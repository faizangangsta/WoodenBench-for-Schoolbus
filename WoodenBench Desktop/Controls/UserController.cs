//Game表对应的模型类
using cn.bmob.io;
using System;
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