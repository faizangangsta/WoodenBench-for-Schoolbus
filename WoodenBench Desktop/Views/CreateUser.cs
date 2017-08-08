﻿using cn.bmob.json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.staClass;
using WoodenBench.TableObject;
using static WoodenBench.staClass.GlobalFunc;
using static WoodenBench.TableObject.AllUsersTable;

namespace WoodenBench.View
{
    public partial class CreateUser : Form
    {
        private AllUsersTable NewUserObj = new AllUsersTable();
        public CreateUser() { InitializeComponent(); }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            randomlabel.Text = (new Random()).Next(10000, 99999).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "正在提交请求";
            Enabled = false;
            Application.DoEvents();
            if (UserNameT.Text != "" &&
                PasswordT.Text != "" &&
                PasswordT2.Text != "" &&
                KeyT.Text == randomlabel.Text &&
                GroupT.SelectedIndex + 1 != 0 &&
                CheckT.Checked &&
                PasswordT.Text == PasswordT2.Text)
            {
                NewUserObj.UserName = UserNameT.Text;
                NewUserObj.RealName = RealNameT.Text;
                NewUserObj.WebNotiSeen = false;
                NewUserObj.WeChatID = "####";
                NewUserObj.Password = PasswordT2.Text;
                NewUserObj.UserGroup = (UserGroupEnum)(GroupT.SelectedIndex + 1);
                var future = Bmob.CreateTaskAsync(NewUserObj);
                future.Wait();
                try
                {
                    //try to read the Callback data
                    ResultLabel.Text = JsonAdapter.JSON.ToDebugJsonString(future.Result);
                    Application.DoEvents();
                    MessageBox.Show("用户创建成功");
                    Close();
                    return;
                }
                catch (Exception Exc)
                {
                    DebugMessage($"Failed create user, " + Environment.NewLine +
                        $"name is {NewUserObj.UserName}, " + Environment.NewLine +
                        $"password is {NewUserObj.Password}" + Environment.NewLine +
                        $"usergroup number is {NewUserObj.UserGroup}" + Environment.NewLine +
                        $"realname is {NewUserObj.RealName}");
                    MessageBox.Show($"用户创建失败，请稍后再试 " +
                    $"{Environment.NewLine + Environment.NewLine + Exc.Message}");
                }
            }
            button1.Text = "用户已创建";
            Enabled = true;
            Application.DoEvents();
        }

        private void CreateUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose(true);
            GC.Collect();
        }
    }
}
