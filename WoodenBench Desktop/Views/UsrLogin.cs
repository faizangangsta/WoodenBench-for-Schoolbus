using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.DelegateClasses;
using WoodenBench.GlobalEvents;
using WoodenBench.StaClasses;
using WoodenBench.TableObject;
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
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
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
            if (StaClasses.UserActivity.Login(UserNameTxt.Text, PswdTxt.Text, false))
            {
                MainWindow.Default.Show();
                Hide();
            }
            else
            {
                DebugMessage($"Login failed using username {UserNameTxt.Text} and password {PswdTxt.Text}");
                LoginResult.Text = "用户名或密码不正确";
            }
            DoLoginBtn.Enabled = true;
            CancelBtn.Enabled = true;
            DoLoginBtn.Text = "登陆(&L)";
        }

        private void CreateUsr(object sender, LinkLabelLinkClickedEventArgs e) { new CreateUserWindow().ShowDialog(); }

        private void ParentsLogin(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Parents Login
        }

        private void UsrLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Thread a = new Thread(P);
            a.Start();
        }
        private void P()
        {
            UserActivityEventArgs e = new UserActivityEventArgs(UserActivityEnum.UserLogin, null, null, ProcStatusEnum.Completed);
            AppEvents.onUserActivity(this, e);
        }

        public void EventRegister_Test(object sender, UserActivityEventArgs e)
        {
            SetTextBoxValue(Text, "");
        }

        private static void SetTextBoxValue(object obj, string s)
        {
            if (UsrLoginWindow.Default.InvokeRequired)
            {
                UsrLoginWindow.Default.Invoke(new onUserLoginDelegateVoid((e) =>
                {
                    UsrLoginWindow.Default.Text = e;
                }), obj.ToString());
            }
            else
            {

            }
        }
    }
}