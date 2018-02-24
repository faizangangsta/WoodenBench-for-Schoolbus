using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WinClient.DelegateClasses;
using WBServicePlatform.WinClient.Users;
using static WBServicePlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBServicePlatform.WinClient.Views
{
    public partial class UsrLoginWindow : DevComponents.DotNetBar.Metro.MetroForm
    {
        private void button1_Click(object sender, EventArgs e)
        {
            ApplicationExit();
        }
        private void UserNameTxt_TextChanged(object sender, EventArgs e)
        {
            LoginResult.Text = "";
            PswdTxt.Clear();
        }
        private void PswdTxt_TextChanged(object sender, EventArgs e)
        {
            LoginResult.Text = "";
        }
        public UsrLoginWindow() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static UsrLoginWindow defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public static UsrLoginWindow Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new UsrLoginWindow();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion
        private void DoLogin(object sender, EventArgs e)
        {
            //Login the user
            UserNameTxt.Enabled = false;
            PswdTxt.Enabled = false;
            NewUserLabel.Visible = false;
            LoginResult.Text = "";
            DoLoginBtn.Enabled = false;
            CancelBtn.Enabled = false;
            DoLoginBtn.Text = "登录中...";
            Application.DoEvents();
            UserActivity.Login(UserNameTxt.Text, PswdTxt.Text, false);
        }

        private void CreateUsr(object sender, LinkLabelLinkClickedEventArgs e) { CreateUserWindow.Default.ShowDialog(); }

        private void ParentsLogin(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Parents Login
        }

        private void UsrLoginForm_Load(object sender, EventArgs e)
        {

        }

        public void onUsrLgn(UserActivityEventArgs e)
        {
            if (e.Activity == UsrActvtiE.UsrLogin)
            {
                if (e.ProcessStatus == OperationStatus.Completed)
                {
                    Invoke(new NullArgDelegate(() =>
                    {
                        LogWritter.DebugMessage($"Login succeed using username {UserNameTxt.Text} and password {PswdTxt.Text}");
                        DoLoginBtn.Enabled = true;
                        CancelBtn.Enabled = true;
                        UserNameTxt.Enabled = true;
                        PswdTxt.Enabled = true;
                        DoLoginBtn.Text = "登录(&L)";
                        MainForm.Default.Show();
                        Hide();
                    }));
                }
                else if (e.ProcessStatus == OperationStatus.Failed)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new NullArgDelegate(() =>
                        {
                            LogWritter.ErrorMessage($"Login failed using username {UserNameTxt.Text} and password {PswdTxt.Text}.");
                            LoginResult.Text = "用户名或密码不正确";
                            LoginResult.Visible = true;
                            DoLoginBtn.Enabled = true;
                            CancelBtn.Enabled = true;
                            UserNameTxt.Enabled = true;
                            PswdTxt.Enabled = true;
                            DoLoginBtn.Text = "登录(&L)";
                        }));
                    }
                }
            }
        }

        private void UsrLoginWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticClasses.GlobalFunc.ApplicationExit();
        }
    }
}