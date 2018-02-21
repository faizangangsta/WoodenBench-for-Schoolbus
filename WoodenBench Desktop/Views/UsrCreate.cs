using cn.bmob.json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WBServicePlatform.DelegateClasses;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.Users;
using static WBServicePlatform.StaticClasses.GlobalFunc;

namespace WBServicePlatform.Views
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


        private void CreateUser_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonX1.Text = "正在提交请求";
            Enabled = false;
            if (UserNameT.Text != "" && PasswordT.Text != "" && PasswordT2.Text != "" &&
                GroupT.SelectedIndex + 1 != 0 &&
                CheckT.Checked && PasswordT.Text == PasswordT2.Text)
            {
                UserActivity.CreateUser(UserNameT.Text, RealNameT.Text, PasswordT.Text, GroupT.SelectedIndex + 1, isBusTeacher.Checked);
            }
            else
            {
                buttonX1.Text = "请检查各项填写情况";
                Enabled = true;
            }
            Enabled = true;
            Application.DoEvents();
        }

        public void onUserActivity(UserActivityEventArgs e)
        {
            if (e.ProcessStatus == ProcStatE.Completed && e.Activity == UsrActvtiE.UserCreate)
            {
                if (e.ProcessStatus == ProcStatE.Completed)
                {
                    Invoke(new nullArgDelegate(() =>
                    {
                        ResultLabel.Text = "用户创建成功，你可以使用新用户名和密码登录了";
                        Enabled = true;
                    }));
                }
                else if (e.ProcessStatus == ProcStatE.Failed || e.ProcessStatus == ProcStatE.FailedWithErr)
                {
                    Invoke(new nullArgDelegate(() =>
                    {
                        ResultLabel.Text = "在创建用户时出现了一些问题，过会再试试？？";
                        Enabled = true; 
                    }));
                }
            }
        }

        private void CreateUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose(true);
            GC.Collect();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
