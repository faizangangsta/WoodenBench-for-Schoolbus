using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.Views;
using static WBServicePlatform.StaticClasses.GlobalFunc;

namespace WBServicePlatform.Views
{
    public partial class MGRLoginWindow : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static MGRLoginWindow defaultInstance;
        public MGRLoginWindow() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static MGRLoginWindow Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new MGRLoginWindow();
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
            if (CurrentUser.Password == Crypto.SHA256Encrypt(PasswordTxt.Text) && CurrentUser.UserName == UsrNameTxt.Text)
            {
                if (CurrentUser.RealName == RealNameTxt.Text)
                {
                    switch (CurrentUser.UserGroup)
                    {
                        case UserGroupEnum.高层管理:
                            //Administrator
                            new ManagementWindow(0).Show(MainForm.Default);
                            Close();
                            break;
                        case UserGroupEnum.管理组用户:
                            //Higher Management
                            new ManagementWindow(1).Show(MainForm.Default);
                            Close();
                            break;
                        default:
                            MessageBox.Show("你不是管理组用户", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                                MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            Close();
                            break;
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
