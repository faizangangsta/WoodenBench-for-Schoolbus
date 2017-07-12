using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WoodenBench.staClass;
using WoodenBench.TableObjects;
using static WoodenBench.staClass.GlobalFunc;

namespace WoodenBench.View
{
    public partial class UsrLoginForm : Form
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
        public UsrLoginForm() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static UsrLoginForm defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static UsrLoginForm Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new UsrLoginForm();
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
            if (UserActivity.Login(UserNameTxt.Text, PswdTxt.Text, false))
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

        private void CreateUsr(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CreateUser().ShowDialog();
        }

        private void ParentsLogin(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Parents Login
        }
    }
}