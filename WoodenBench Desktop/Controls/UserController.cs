using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoodenBench_Desktop.Controls
{
	public class UserController
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string UserID { get; set; }
		public Users UserActAs { get; set; }
		public UserController() { }
		public string LoginTime { get; set; }
	}
	public enum Users
	{
		User_Administrator,
		User_Tutor,
		User_SchoolBusTeacher,
		User_Parents
	}
}
