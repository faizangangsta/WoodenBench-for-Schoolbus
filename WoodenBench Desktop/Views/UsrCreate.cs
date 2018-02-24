using cn.bmob.json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WBServicePlatform.WinClient.DelegateClasses;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WinClient.Users;
using static WBServicePlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBServicePlatform.WinClient.Views
{
    public partial class CreateUserWindow : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CreateUserWindow()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static CreateUserWindow defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public static CreateUserWindow Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new CreateUserWindow();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            buttonX1.Text = "正在提交请求";
            Enabled = false;
            if (UserNameT.Text != "" && PasswordT1.Text != "" && PasswordT2.Text != "" && CheckT.Checked && PasswordT1.Text == PasswordT2.Text)
            {
                UserGroup ug = new UserGroup(isTeacherChk.Checked, isBusManagerChk.Checked, isParentChk.Checked);
                UserActivity.CreateUser(UserNameT.Text, RealNameT.Text, PasswordT1.Text, ug, phoneNumberTx.Text);
            }
            else
            {
                buttonX1.Text = "请检查各项填写情况";
                Enabled = true;
            }
            Enabled = true;
        }

        public void onUserActivity(UserActivityEventArgs e)
        {
            if (e.Activity == UsrActvtiE.UserCreate)
            {
                if (e.ProcessStatus == OperationStatus.Completed)
                {
                    Invoke(new NullArgDelegate(() =>
                    {
                        ResultLabel.Text = "用户创建成功，你可以使用新用户名和密码登录了";
                        MessageBox.Show("用户创建成功，你可以使用新用户名和密码登录了");
                        Enabled = false;
                        UsrLoginWindow.Default.UserNameTxt.Text = UserNameT.Text;
                        Close();
                    }));
                }
                else if (e.ProcessStatus == OperationStatus.Failed)
                {
                    Invoke(new NullArgDelegate(() =>
                    {
                        ResultLabel.Text = "在创建用户时出现了一些问题，过会再试试？？\r\n" + e.ToString();
                        buttonX1.Text = "OK，创建账户";
                        MessageBox.Show("在创建用户时出现了一些问题");
                        Enabled = true;
                    }));
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "https://schoolbus.lhy0403.top/eula.docx");
        }
    }
}
