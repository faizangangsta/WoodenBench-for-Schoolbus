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
using WoodenBench_Desktop.Operation;
using static WoodenBench_Desktop.Controls.Users.UserTableElements;

namespace WoodenBench_Desktop.Views
{
	public partial class ChangeUserData : Form
	{
		static UserTableElements NowUser;
		public ChangeUserData(UserTableElements ValController)
		{
			Bmob = new BmobWindows();
			Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
			InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
            BmobDebug.Register(Message =>
			{
				Debug.WriteLine(Message);
				//Console.WriteLine(Message);
			});
			NowUser = ValController;
		}
		public BmobWindows Bmob { get; }

        private static ChangeUserData defaultInstance;
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static ChangeUserData Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new ChangeUserData(NowUser);
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        private void SureChangeUserData(object sender, EventArgs e)
		{
				UserTableElements Obj = new UserTableElements(Consts.TABLE_NAME_General_AllUser)
				{
					objectId = NowUser.UserID,
					CUserGroup = UsrGroupDrop.SelectedIndex + 1,
					Password = NowUser.Password,
					UserName = NowUser.UserName
				};
				Bmob.UpdateTaskAsync(Obj);
				MessageBox.Show("为重新载入用户配置，应用将会重启");
				Application.Restart();
			
		}

		private void ChangeUserData_Load(object sender, EventArgs e)
		{
			if (NowUser.UserGroup == UserGroupEnum.管理组用户)
			{
				SuperuserRefuse.Visible = true;
				ChangePartOfSchool.Enabled = false;
				ChangePartOfSchool.Visible = false;
			}
			UsrNameLbl.Text = NowUser.UserName;
			UsrIDLbl.Text = NowUser.UserID;
			UsrGroup.Text = NowUser.UserGroup.ToString();
		}

		private void ChangePartOfSchool_Click(object sender, EventArgs e)
		{
			ChangePartOfSchool.Visible = false;
			UsrGroupDrop.Visible = true;
			UserActChangeBtn.Visible = true;
		}
        private void DoChange(object sender, EventArgs e)
		{
			if (FPasswordTxt.Text == null || FPasswordTxt.Text == NowUser.Password)
			{
				if (NPasswrodTxt1.Text == NPasswrodTxt2.Text)
				{
					if (NPasswrodTxt1.Text != "")
					{
                        UserActivity.ChangePassWord(NowUser, FPasswordTxt.Text, NPasswrodTxt1.Text);
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
