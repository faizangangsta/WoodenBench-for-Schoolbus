using cn.bmob.api;
using cn.bmob.tools;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WoodenBench_Desktop.Views
{
	public partial class CreateUser : Form
	{		
		public const String TABLE_NAME = "AllUsersTable";
		private UserObject NewUserObj = new UserObject(TABLE_NAME);
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
			;
			randomlabel.Text = (new Random()).Next(10000, 99999).ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (UserNameT.Text != "" && PasswordT.Text != "" && PasswordT2.Text != "")
			{
				if (KeyT.Text == randomlabel.Text)
				{
					if (GroupT.SelectedIndex + 1 != 0 && ActT.SelectedIndex + 1 != 0)
					{
						if (CheckT.Checked)
						{
							if (PasswordT.Text == PasswordT2.Text)
							{
								NewUserObj.UserName = UserNameT.Text;
								NewUserObj.Password = PasswordT2.Text;
								NewUserObj.UserActAs = ActT.SelectedIndex + 1;
								NewUserObj.UserPartOfSchool = GroupT.SelectedIndex + 1;
								var future = Bmob.CreateTaskAsync(NewUserObj);
								MessageBox.Show(future.Status.ToString());
								MessageBox.Show("用户创建成功");
								Close();
							}
						}
					}
				}
			}
		}
	}
}
