using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;

using WBPlatform.DesktopClient.Users;
using WBPlatform.StaticClasses;

using static WBPlatform.DesktopClient.StaticClasses.GlobalFunctions;

namespace WBPlatform.DesktopClient.Views
{
    public partial class ChangePasswordForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            userIDLabel.Text = CurrentUser.objectId;
            UserLogonNamelabel.Text = CurrentUser.UserName;
            SexLabel.Text = CurrentUser.Sex.ToLower() == "m" ? "��" : "Ů";
            realnameLabel.Text = CurrentUser.RealName;
            PhoneNumLAbel.Text = CurrentUser.PhoneNumber;
        }

        private void ClearPassword_Click(object sender, EventArgs e)
        {
            prePassword.Clear();
            prePassword.ClearUndo();
            NewPassword1.Clear();
            NewPassword1.ClearUndo();
            NewPassword2.Clear();
            NewPassword2.ClearUndo();
        }

        private void prePassword_TextChanged(object sender, EventArgs e)
        {
            DochangePassword.Enabled = true;
            DochangePassword.Text = "ȷ��(&C)";
            NewPassword1.Clear();
            NewPassword1.ClearUndo();
            NewPassword2.Clear();
            NewPassword2.ClearUndo();
        }

        private void NewPassword1_TextChanged(object sender, EventArgs e)
        {
            DochangePassword.Text = "ȷ��(&C)";
            NewPassword2.Clear();
            NewPassword2.ClearUndo();
        }

        private void DochangePassword_Click(object sender, EventArgs e)
        {
            if (prePassword.Text == "" || Cryptography.SHA256Encrypt(prePassword.Text) == CurrentUser.Password)
            {
                if (NewPassword1.Text == NewPassword2.Text)
                {
                    if (NewPassword1.Text != "")
                    {
                        if (UserActivity.ChangePassWord(CurrentUser, prePassword.Text, NewPassword1.Text))
                        {
                            MessageBox.Show($"�ɹ��޸����룡");
                            //UserActivity.LogOut();
                        }
                        else
                        {
                            MessageBox.Show("�޸�����ʧ�ܣ�");
                        }
                    }
                    else MessageBox.Show("���������ÿ�����", "ע��");
                }
                else DochangePassword.Text = "�����벻ƥ��";
            }
            else DochangePassword.Text = "ԭ���벻��ȷ";
        }
    }
}