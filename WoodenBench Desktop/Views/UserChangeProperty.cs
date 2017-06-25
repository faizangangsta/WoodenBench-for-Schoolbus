using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench_Desktop.staClass;
using WoodenBench_Desktop.TableObjects;

namespace WoodenBench_Desktop
{
	public partial class ChangeUserData : Form
	{
		public ChangeUserData()
		{
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
		}

        private static ChangeUserData defaultInstance;
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static ChangeUserData Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new ChangeUserData();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        private void SureChangeUserData(object sender, EventArgs e)
		{
				UserTableObj Obj = new UserTableObj(Consts.TABLE_NAME_General_AllUser)
				{
					objectId = UserActivity.NowUser.UserID,
					CUserGroup = UsrGroupDrop.SelectedIndex + 1,
					Password = UserActivity.NowUser.Password,
					UserName = UserActivity.NowUser.UserName
				};
				BmobObject.Bmob.UpdateTaskAsync(Obj);
				MessageBox.Show("为重新载入用户配置，应用将会重启");
				Application.Restart();			
		}

		private void ChangeUserData_Load(object sender, EventArgs e)
		{
			if (UserActivity.NowUser.UserGroup == UserGroupEnum.管理组用户)
			{
				SuperuserRefuse.Visible = true;
				ChangePartOfSchool.Enabled = false;
				ChangePartOfSchool.Visible = false;
			}
			UsrNameLbl.Text = UserActivity.NowUser.UserName;
			UsrIDLbl.Text = UserActivity.NowUser.UserID;
			UsrGroup.Text = UserActivity.NowUser.UserGroup.ToString();
		}

		private void ChangePartOfSchool_Click(object sender, EventArgs e)
		{
			ChangePartOfSchool.Visible = false;
			UsrGroupDrop.Visible = true;
			UserActChangeBtn.Visible = true;
		}
        private void DoChange(object sender, EventArgs e)
		{
			if (FPasswordTxt.Text == null || FPasswordTxt.Text == UserActivity.NowUser.Password)
			{
				if (NPasswrodTxt1.Text == NPasswrodTxt2.Text)
				{
					if (NPasswrodTxt1.Text != "")
					{
                        UserActivity.ChangePassWord(staClass.UserActivity.NowUser, FPasswordTxt.Text, NPasswrodTxt1.Text);
						MessageBox.Show($"为重载用户配置，当前用户 {UserActivity.NowUser.UserName} 将被注销，请重新登陆");
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
