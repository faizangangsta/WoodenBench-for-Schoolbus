using cn.bmob.json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench_Desktop.staClass;
using WoodenBench_Desktop.TableObjects;

namespace WoodenBench_Desktop
{ 
	public partial class CreateUser : Form
	{
		private UserTableObj NewUserObj = new UserTableObj(Consts.TABLE_NAME_General_AllUser);
		public CreateUser()
		{
            InitializeComponent();
		}

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
				NewUserObj.Password = PasswordT2.Text;
				NewUserObj.CUserGroup = GroupT.SelectedIndex + 1;
				var future = BmobObject.Bmob.CreateTaskAsync(NewUserObj);
				Thread.Sleep(500);
                try
                {
                    ResultLabel.Text = JsonAdapter.JSON.ToDebugJsonString(future.Result);
                    MessageBox.Show("用户创建成功");
                    Close();
                    return;
                }
                catch (Exception Exc)
                {
                    MessageBox.Show($"用户创建失败，请稍后z再试 " +
                    //$"{Environment.NewLine + future.Status.ToString()}" +
                    //$"{Environment.NewLine + future.Result.ToString()}" +
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
