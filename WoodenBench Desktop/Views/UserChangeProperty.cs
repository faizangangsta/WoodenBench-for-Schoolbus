using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench.TableObjects;
using static WoodenBench.staClass.GlobalFunc;
using static WoodenBench.staClass.UserActivity;

namespace WoodenBench.View
{
    public partial class ChangeUserData : Form
    {
        public ChangeUserData()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }

        private static ChangeUserData defaultInstance;
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static ChangeUserData Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new ChangeUserData();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }

        private void ChangeUserData_Load(object sender, EventArgs e)
        {
            UsrNameLbl.Text = CurrentUser.UserName;
            UsrIDLbl.Text = CurrentUser.objectId;
            UsrGroup.Text = CurrentUser.UserGroup.ToString();
            UsrWCID.Text = CurrentUser.WeChatID;
        }

        private void DoChange(object sender, EventArgs e)
        {
            if (FPasswordTxt.Text == null || FPasswordTxt.Text == CurrentUser.Password)
            {
                if (NPasswrodTxt1.Text == NPasswrodTxt2.Text)
                {
                    if (NPasswrodTxt1.Text != "")
                    {
                        ChangePassWord(CurrentUser, FPasswordTxt.Text, NPasswrodTxt1.Text);
                        LogOut();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("不允许设置空密码", "注意");
                        return;
                    }
                }
                else
                {
                    SureChangeBtn.Text = "新密码不匹配";
                    return;
                }
            }
            else
            {
                SureChangeBtn.Text = "原密码不正确";
                return;
            }
        }

        private void FPasswordTxt_TextChanged(object sender, EventArgs e)
        {
            SureChangeBtn.Enabled = true;
            SureChangeBtn.Text = "确定(&C)";
            NPasswrodTxt1.Clear();
            NPasswrodTxt1.ClearUndo();
            NPasswrodTxt2.Clear();
            NPasswrodTxt2.ClearUndo();
        }

        private void NPasswrodTxt1_TextChanged(object sender, EventArgs e)
        {
            SureChangeBtn.Text = "确定(&C)";
            NPasswrodTxt2.Clear();
            NPasswrodTxt2.ClearUndo();
        }
    }
}
