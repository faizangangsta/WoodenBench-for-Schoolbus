using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WBPlatform.StaticClasses;
using WBPlatform.DesktopClient.Views;
using static WBPlatform.DesktopClient.StaticClasses.GlobalFunctions;

namespace WBPlatform.DesktopClient.Views
{
    public partial class AdminLoginForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static AdminLoginForm defaultInstance;
        public AdminLoginForm() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static AdminLoginForm Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new AdminLoginForm();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }

        private void MGRLogin_Load(object sender, EventArgs e)
        {

        }

        private void LoginMgrBtn_Click(object sender, EventArgs e)
        {
            if (CurrentUser.Password == Cryptography.SHA256Encrypt(PasswordTxt.Text) && CurrentUser.UserName == UsrNameTxt.Text)
            {
                if (CurrentUser.RealName == RealNameTxt.Text)
                {
                    if (CurrentUser.UserGroup.IsAdmin)
                    {
                        Close();
                        new ManagementWindow().Show(MainForm.Default);
                    }
                    else
                    {
                        MessageBox.Show("你不是管理组用户", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                            MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("个人信息不正确");
                }
            }
            else
            {
                MessageBox.Show("用户名或密码不正确");
            }
        }
    }
}
