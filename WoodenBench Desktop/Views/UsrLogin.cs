using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.DelegateClasses;
using WoodenBench.Events;
using WoodenBench.StaClasses;
using WoodenBench.TableObject;
using WoodenBench.Users;
using static WoodenBench.StaClasses.GlobalFunc;

namespace WoodenBench.Views
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
            NewUserLabel.Visible = false;
            LoginResult.Text = "";
            DoLoginBtn.Enabled = false;
            CancelBtn.Enabled = false;
            DoLoginBtn.Text = "登陆中...";
            Application.DoEvents();
            UserActivity.Login(UserNameTxt.Text, PswdTxt.Text, false);

        }

        private void CreateUsr(object sender, LinkLabelLinkClickedEventArgs e) { new CreateUserWindow().ShowDialog(); }

        private void ParentsLogin(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Parents Login
        }

        private void UsrLoginForm_Load(object sender, EventArgs e)
        {

        }

        public void onUsrLgn(UserActivityEventArgs e)
        {
            if (e.Activity == UserActivityEnum.UserLogin)
            {
                if (e.ProcessStatus == ProcStatusEnum.Completed)
                {
                    Invoke(new onUserLoginDelegateVoid(() =>
                    {
                        DoLoginBtn.Enabled = true;
                        CancelBtn.Enabled = true;
                        DoLoginBtn.Text = "登陆(&L)";
                        MainWindow.Default.Show();
                        Hide();
                    }));
                }
                else if (e.ProcessStatus == ProcStatusEnum.Failed || e.ProcessStatus == ProcStatusEnum.FailedWithErr)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new onUserLoginDelegateVoid(() =>
                        {
                            DebugMessage($"Login failed using username {UserNameTxt.Text} and password {PswdTxt.Text}");
                            LoginResult.Text = "用户名或密码不正确";
                            DoLoginBtn.Enabled = true;
                            CancelBtn.Enabled = true;
                            DoLoginBtn.Text = "登陆(&L)";
                        }));
                    }
                }
            }
        }
    }
}