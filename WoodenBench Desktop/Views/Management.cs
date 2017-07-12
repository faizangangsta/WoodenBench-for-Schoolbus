using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench.View;
using static WoodenBench.staClass.UserActivity;
using static WoodenBench.staClass.GlobalFunc;

namespace WoodenBench.Views
{
    public partial class Management : Form
    {
        private static Management defaultInstance;
        public Management() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static Management Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new Management();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }

        private void Management_Load(object sender, EventArgs e)
        {

        }

        private void LoginMgrBtn_Click(object sender, EventArgs e)
        {
            if (CurrentUser.Password == PasswordTxt.Text && CurrentUser.UserName == UsrNameTxt.Text)
            {
                if (CurrentUser.RealName == RealNameTxt.Text)
                {
                    groupBox1.Visible = false;
                    switch (CurrentUser.UserGroup)
                    {
                        case 0:

                            break;
                        case 2:

                            break;
                        default:
                            MessageBox.Show("你不是管理组用户", "Sorry",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.ServiceNotification);
                            Close();
                            return;
                            break;
                    }
                }
            }
        }
    }
}
