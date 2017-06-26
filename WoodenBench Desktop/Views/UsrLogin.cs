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
            /// on cancel button click, call <see cref="ApplicationExit()"/>
            /// Which is in <see cref="GlobalFunc"/>
            ApplicationExit();
        }
        private void UserNameTxt_TextChanged(object sender, EventArgs e)
        {
            //Reset Login result label, back to nothing.
            LoginResult.Text = "";
            //once UserName textbox changes, clear the password textbox
            PswdTxt.Clear();
        }
        private void PswdTxt_TextChanged(object sender, EventArgs e)
        {
            //Reset Login result label, back to nothing.
            LoginResult.Text = "";
        }
        public UsrLoginForm() : base()
        {
            ///Auto generated code, <see cref="InitializeComponent()"/>
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        /// <summary>
        /// Make the non-static class <see cref="UsrLoginForm"/>
        /// static <see cref="Default"/> and <see cref="defaultInstance"/>
        /// </summary>
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
            //Above is the UI changes
            Application.DoEvents();
            ///<see cref="Application.DoEvents()"/> is to apply the UI changes immediately
            
            ///<see cref="UserActivity.Login(string, string)"/>
            ///Returns a bool that indicate if the user is succeed in login progress
            ///The strings are Username  and Password
            if (UserActivity.Login(UserNameTxt.Text, PswdTxt.Text))
            {
                ///if <see cref="UserActivity.Login(string, string)"/>
                ///returns 'true'
                (new MainWindow()).Show();
                Hide();
            }
            else
            {
                ///if <see cref="UserActivity.Login(string, string)"/>
                ///returns 'false'
                DebugMessage($"Login failed using username {UserNameTxt.Text} and password {PswdTxt.Text}");
                LoginResult.Text = "用户名或密码不正确";
            }

            DoLoginBtn.Enabled = true;
            CancelBtn.Enabled = true;
            DoLoginBtn.Text = "登陆(&L)";
            //Above is the UI changes
        }

        private void CreateUsr(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ///we need to use "new" syntax to show the new window,
            ///because the <see cref="CreateUser"/>, is not a static class.
            new CreateUser().ShowDialog();
            //Show Create user window
        }
        
        private void ParentsLogin(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Parents Login
        }

        private void UsrLoginForm_Load(object sender, EventArgs e)
        {
            ///nothing, for future use when <see cref="UsrLoginForm"/> is loaded
        }
    }
}