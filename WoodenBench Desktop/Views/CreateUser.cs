using cn.bmob.json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.StaClasses;
using WoodenBench.TableObject;
using static WoodenBench.StaClasses.GlobalFunc;
using static WoodenBench.TableObject.AllUserObject;

namespace WoodenBench.Views
{
    public partial class CreateUserWindow : Form
    {
        public CreateUserWindow() { InitializeComponent(); }

        private void CreateUser_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "正在提交请求";
            Enabled = false;
            Application.DoEvents();
            if (UserNameT.Text != "" && PasswordT.Text != "" && PasswordT2.Text != "" &&
                GroupT.SelectedIndex + 1 != 0 &&
                CheckT.Checked && PasswordT.Text == PasswordT2.Text)
            {
                AllUserObject NewUserObj = new AllUserObject
                {
                    UserName = UserNameT.Text,
                    RealName = RealNameT.Text,
                    WebNotiSeen = false,
                    WeChatID = "####",
                    Password = PasswordT2.Text,
                    UserGroup = (UserGroupEnum)(GroupT.SelectedIndex + 1)
                };
                var future = _BmobWin.CreateTaskAsync(NewUserObj);
                future.Wait();
                //try to read the Callback data
                ResultLabel.Text = JsonAdapter.JSON.ToDebugJsonString(future.Result);
                Application.DoEvents();
                MessageBox.Show("用户创建成功");
                Close();
                return;
                try
                {

                }
                catch (Exception Exc)
                {
                    DebugMessage(
                        $"Failed create user, " + Environment.NewLine +
                        $"name is {NewUserObj.UserName}, " + Environment.NewLine +
                        $"password is {NewUserObj.Password}" + Environment.NewLine +
                        $"usergroup number is {NewUserObj.UserGroup}" + Environment.NewLine +
                        $"realname is {NewUserObj.RealName}");
                    MessageBox.Show(
                        $"用户创建失败，请稍后再试 " +
                        $"{Environment.NewLine + Environment.NewLine + Exc.Message}");
                }
            }
            else
            {
                button1.Text = "请检查各项填写情况";
                Enabled = true;
                Application.DoEvents();
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
