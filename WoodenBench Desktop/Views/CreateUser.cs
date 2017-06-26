using cn.bmob.json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.staClass;
using WoodenBench.TableObjects;
using static WoodenBench.staClass.GlobalFunc;

namespace WoodenBench.View
{ 
	public partial class CreateUser : Form
	{
        /// <summary>
        /// <see cref="NewUserObj"/> is a new variable,
        /// its type is <seealso cref="AllUsersTable"/>
        /// the <see cref="AllUsersTable"/> is not static, so use "new"
        /// </summary>
		private AllUsersTable NewUserObj = new AllUsersTable();
		public CreateUser()
		{
            //Auto generated, initialize the objects inside the window
            InitializeComponent();
		}

		private void CreateUser_Load(object sender, EventArgs e)
		{			
            ///Generate the <see cref="Random"/> number
            ///we use 'new' because this <see cref="Random"/> is not static
			randomlabel.Text = (new Random()).Next(10000, 99999).ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			button1.Text = "正在提交请求";
			Enabled = false;
			Application.DoEvents();

            ///if
            /// <see cref="UserNameT"/> has not a empty value
            /// <seealso cref="PasswordT"/> and <seealso cref="PasswordT2"/> aren't empty, 
            /// the <see cref="KeyT"/> equals to the randpm number in <see cref="randomlabel"/>
            /// the user has already chosen a <see cref="GroupT"/>
            /// and the user has accepted the use policy <see cref="CheckT"/>
            /// <see cref="PasswordT"/> and <see cref="PasswordT2"/> are same.

			if (UserNameT.Text != "" &&
				PasswordT.Text != "" &&
				PasswordT2.Text != "" &&
				KeyT.Text == randomlabel.Text &&
				GroupT.SelectedIndex + 1 != 0 &&
				CheckT.Checked &&
				PasswordT.Text == PasswordT2.Text)
			{
                ///<see cref="NewUserObj"/>
				NewUserObj.UserName = UserNameT.Text;
                NewUserObj.RealName = RealNameT.Text;
                NewUserObj.WebNotiSeen = false;
                NewUserObj.WeChatID = "";
				NewUserObj.Password = PasswordT2.Text;
				NewUserObj.UserGroup = GroupT.SelectedIndex + 1;
                ///Give values to the new user object
                ///Then <see cref="Bmob"/> will create a record
                ///in <see cref="TABLE_N_AllStuData"/> table.
				var future = Bmob.CreateTaskAsync(NewUserObj);
                ///Wait for the BMOB to be finished
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
                    ///Failed, write to debug log
                    DebugMessage($"Failed create user, " +
                        $"name is {NewUserObj.UserName}, " +
                        $"password is {NewUserObj.Password}" +
                        $"usergroup number is {NewUserObj.UserGroup}" +
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
