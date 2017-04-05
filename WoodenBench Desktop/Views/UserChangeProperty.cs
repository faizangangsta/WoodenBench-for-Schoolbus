using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench_Desktop.Controls;
using WoodenBench_Desktop.Controls.Users;

namespace WoodenBench_Desktop.Views
{
	public partial class ChangeUserData : Form
	{
		UserController NowUser;
		public ChangeUserData(UserController ValController)
		{
			Bmob = new BmobWindows();
			Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
			InitializeComponent();
			BmobDebug.Register(Message =>
			{
				Debug.WriteLine(Message);
				//Console.WriteLine(Message);
			});
			NowUser = ValController;
		}
		public BmobWindows Bmob { get; }

		private void SureChangeUserData(object sender, EventArgs e)
		{
			if (UserGroupChangeDrop.SelectedIndex + 1 != 0 && PartOfSchoolDrop.SelectedIndex + 1 != 0)
			{
				UserObject Obj = new UserObject(Consts.TABLE_NAME_General_AllUser)
				{
					objectId = NowUser.UserID,
					UserActAs = UserGroupChangeDrop.SelectedIndex + 1,
					UserPartOfSchool = PartOfSchoolDrop.SelectedIndex + 1,
					Password = NowUser.Password,
					UserName = NowUser.UserName
				};
				Bmob.UpdateTaskAsync(Obj);
				MessageBox.Show("为重新载入用户配置，应用将会重启");
				Application.Restart();
			}
			else
			{
				MessageBox.Show("请重新选择用户组");
				return;
			}
		}

		private void ChangeUserData_Load(object sender, EventArgs e)
		{
			if (NowUser.UserGroup == UserGroup.管理组用户)
			{
				SuperuserRefuse.Visible = true;
				ChangePartOfSchool.Enabled = false;
				ChangePartOfSchool.Visible = false;
			}
			UsrNameLbl.Text = NowUser.UserName;
			UsrIDLbl.Text = NowUser.UserID;
			UsrPartLbl.Text = NowUser.UserPartOfSchool.ToString();
			UsrGroup.Text = NowUser.UserGroup.ToString();
		}

		private void ChangePartOfSchool_Click(object sender, EventArgs e)
		{
			ChangePartOfSchool.Visible = false;
			PartOfSchoolDrop.Visible = true;
			UserActChangeBtn.Visible = true;
			UserGroupChangeDrop.Visible = true;
		}

		private void PartOfSchoolDrop_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void DoChange(object sender, EventArgs e)
		{
			if (FPasswordTxt.Text == null || FPasswordTxt.Text == NowUser.Password)
			{
				if (NPasswrodTxt1.Text == NPasswrodTxt2.Text)
				{
					if (NPasswrodTxt1.Text != "")
					{
						UserObject Obj = new UserObject(Consts.TABLE_NAME_General_AllUser)
						{
							objectId = NowUser.UserID,
							UserActAs = (int)NowUser.UserGroup,
							UserPartOfSchool = (int)NowUser.UserGroup,
							Password = NPasswrodTxt2.Text,
							UserName = NowUser.UserName
						};
						Bmob.UpdateTaskAsync(Obj);
						MessageBox.Show($"为重载用户配置，当前用户 {NowUser.UserName} 将被注销，请重新登陆");
						Application.Restart();
						return;
					}
					else
					{
						MessageBox.Show("不允许设置空密码", "注意");
					}
				}
				else
				{
					button2.Text = "新密码不匹配";
					return;
				}
			}
			else
			{
				button2.Text = "原密码不正确";
				return;
			}
		}

		private void FPasswordTxt_TextChanged(object sender, EventArgs e)
		{
			button2.Enabled = true;
			button2.Text = "确定(&C)";
			NPasswrodTxt1.Clear();
			NPasswrodTxt1.ClearUndo();
			NPasswrodTxt2.Clear();
			NPasswrodTxt2.ClearUndo();
		}

		private void NPasswrodTxt1_TextChanged(object sender, EventArgs e)
		{
			button2.Text = "确定(&C)";
			NPasswrodTxt2.Clear();
			NPasswrodTxt2.ClearUndo();
		}
	}
}
