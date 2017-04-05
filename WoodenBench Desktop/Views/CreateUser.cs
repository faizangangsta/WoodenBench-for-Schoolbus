using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench_Desktop.Controls;
using WoodenBench_Desktop.Controls.Users;

namespace WoodenBench_Desktop.Views
{ 
	public partial class CreateUser : Form
	{
		private UserObject NewUserObj = new UserObject(Consts.TABLE_NAME_General_AllUser);
		public BmobWindows Bmob { get; }
		public CreateUser()
		{
			Bmob = new BmobWindows();
			Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
			InitializeComponent();
			BmobDebug.Register(Message =>
			{
				Debug.WriteLine(Message);
				//Console.WriteLine(Message);
			});
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
				ActT.SelectedIndex + 1 != 0 &&
				CheckT.Checked &&
				PasswordT.Text == PasswordT2.Text)
			{
				NewUserObj.UserName = UserNameT.Text;
				NewUserObj.Password = PasswordT2.Text;
				NewUserObj.UserActAs = ActT.SelectedIndex + 1;
				NewUserObj.UserPartOfSchool = GroupT.SelectedIndex + 1;
				var future = Bmob.CreateTaskAsync(NewUserObj);
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
					MessageBox.Show($"用户创建失败，请稍后再试 " +
					//$"	{Environment.NewLine + future.Status.ToString()}" +
					//$"	{Environment.NewLine + future.Result.ToString()}" +
					$"	{Environment.NewLine + Environment.NewLine + Exc.Message}");
				}
			}
			button1.Text = "用户已创建";
			Enabled = true;
		}

		private void CreateUser_FormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose(true);
		}
	}
}
