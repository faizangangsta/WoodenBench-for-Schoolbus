using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;


using WBPlatform.DesktopClient.DelegateClasses;
using WBPlatform.DesktopClient.StaticClasses;
using WBPlatform.DesktopClient.Users;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

using static WBPlatform.DesktopClient.StaticClasses.GlobalFunctions;

namespace WBPlatform.DesktopClient.Views
{
    public partial class LoginWindow : DevComponents.DotNetBar.Metro.MetroForm
    {
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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
        public LoginWindow() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static LoginWindow defaultInstance { get; set; }
        public static LoginWindow Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new LoginWindow();
                    defaultInstance.FormClosed += new FormClosedEventHandler((obj, obj2) => { defaultInstance = null; });
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
            if (UserActivity.Login(UserNameTxt.Text, PswdTxt.Text, out UserObject user))
            {
                LogWritter.DebugMessage($"Login succeed using username {UserNameTxt.Text}");
                if (user.UserGroup.IsAdmin || user.UserGroup.IsBusManager || user.UserGroup.IsClassTeacher)
                {
                    DoLoginBtn.Enabled = true;
                    CancelBtn.Enabled = true;
                    UserNameTxt.Enabled = true;
                    PswdTxt.Enabled = true;
                    DoLoginBtn.Text = "登录(&L)";
                    CurrentUser = user;
                    MainForm.Default.Show();
                    Hide();
                }
                else if (user.UserGroup.IsParent)
                {
                    MessageBox.Show("暂时不支持家长使用小板凳 Windows 客户端哦！");
                }
                else
                {
                    MessageBox.Show("用户组配置无效，请联系管理员。");
                }
            }
            else
            {
                LogWritter.ErrorMessage($"Login failed using username {UserNameTxt.Text} and password {PswdTxt.Text}.");
                LoginResult.Text = "用户名或密码不正确";
                LoginResult.Visible = true;
                DoLoginBtn.Enabled = true;
                CancelBtn.Enabled = true;
                UserNameTxt.Enabled = true;
                PswdTxt.Enabled = true;
                DoLoginBtn.Text = "登录(&L)";
            }
        }

        private void CreateUsr(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("请使用微信登陆小板凳平台，进行用户注册过程");
        }

        private void ParentsLogin(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Parents Login
            MessageBox.Show("暂时不支持家长使用小板凳 Windows 客户端哦！");
        }

        private void UsrLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void UsrLoginWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            ApplicationExit();
        }
    }
}