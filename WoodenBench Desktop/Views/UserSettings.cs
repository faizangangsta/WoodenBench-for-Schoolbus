using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

using WBServicePlatform.StaticClasses;
using WBServicePlatform.WinClient.StaticClasses;
using WBServicePlatform.WinClient.Users;

using static WBServicePlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBServicePlatform.WinClient.Views
{
    public partial class UserSettings : MetroForm
    {
        public UserSettings()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static UserSettings defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static UserSettings Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new UserSettings();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion

        private void UserSettings_Load(object sender, EventArgs e)
        {
            userIDLabel.Text = CurrentUser.objectId;
            UserLogonNamelabel.Text = CurrentUser.UserName;
            SexLabel.Text = CurrentUser.Sex.ToLower() == "m" ? "男" : "女";
            realnameLabel.Text = CurrentUser.RealName;
            PhoneNumLAbel.Text = CurrentUser.PhoneNumber;
            AdminLabel.Text = CurrentUser.UserGroup.IsAdmin ? "是" : "否";
        }

        private void realnameLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void prePassword_TextChanged(object sender, EventArgs e)
        {
            DochangePassword.Enabled = true;
            DochangePassword.Text = "确定(&C)";
            NewPassword1.Clear();
            NewPassword1.ClearUndo();
            NewPassword2.Clear();
            NewPassword2.ClearUndo();
        }

        private void NewPassword1_TextChanged(object sender, EventArgs e)
        {
            DochangePassword.Text = "确定(&C)";
            NewPassword2.Clear();
            NewPassword2.ClearUndo();
        }

        private void DochangePassword_Click(object sender, EventArgs e)
        {
            if (prePassword.Text == "" || Crypto.SHA256Encrypt(prePassword.Text) == CurrentUser.Password)
            {
                if (NewPassword1.Text == NewPassword2.Text)
                {
                    if (NewPassword1.Text != "")
                    {
                        if (UserActivity.ChangePassWord(CurrentUser, prePassword.Text, NewPassword1.Text))
                        {
                            MessageBox.Show($"你在成功修改密码，现在将要重新登陆");
                            UserActivity.LogOut();
                        }
                        else
                        {
                            MessageBox.Show("修改密码失败！");
                        }
                    }
                    else MessageBox.Show("不允许设置空密码", "注意");
                }
                else DochangePassword.Text = "新密码不匹配";
            }
            else DochangePassword.Text = "原密码不正确";
        }
    }
}