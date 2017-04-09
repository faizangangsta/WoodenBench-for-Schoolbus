using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.json;
using cn.bmob.tools;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WoodenBench_Desktop.Controls;
using WoodenBench_Desktop.Controls.Users;

namespace WoodenBench_Desktop
{
	public partial class UsrLoginForm : Form
	{
		private string StrObjectID;
		private string Password;
		private int UserGroup;
		private int UserPartOfSchool;
		int CreateUsr = 0;
		private void button1_Click(object sender, EventArgs e) => Application.Exit();
		private void UserNameTxt_TextChanged(object sender, EventArgs e)
		{
			LoginResult.Text = "";
			PswdTxt.Clear();
		}
		private void PswdTxt_TextChanged(object sender, EventArgs e) => LoginResult.Text = "";
		public UsrLoginForm() : base()
		{
			Bmob = new BmobWindows();
			Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
			InitializeComponent();
			if (defaultInstance == null) defaultInstance = this;
			BmobDebug.Register(Message =>
			{
				Debug.WriteLine(Message);
				//Console.WriteLine(Message);
			});
		}
		private static UsrLoginForm defaultInstance;
		static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
		public static UsrLoginForm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new UsrLoginForm();
					defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
				}
				return defaultInstance;
			}
		}

		public BmobWindows Bmob { get; }

		private void DoLogin(object sender, EventArgs e)
		{
			NewUserLabel.Visible = false;
			LoginResult.Text = "";
			DoLoginBtn.Enabled = false;
			CancelBtn.Enabled = false;
			DoLoginBtn.Text = "登陆中...";
			Application.DoEvents();
			try
			{
				BmobQuery UserNameQuery = new BmobQuery();
				UserNameQuery.WhereContainedIn("Username", UserNameTxt.Text);
				var UsrNameResult = Bmob.FindTaskAsync<UserObject>(Consts.TABLE_NAME_General_AllUser, UserNameQuery);
				JObject JsonUserNameResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(UsrNameResult.Result));

				StrObjectID = (JsonUserNameResult.First.First.First.First.First).ToString();
				var NowUserResult = Bmob.GetTaskAsync<UserObject>(Consts.TABLE_NAME_General_AllUser, StrObjectID);
				JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(NowUserResult.Result));

				Password = JsonNowUsrResult["Password"].ToString();
				DoLoginBtn.Enabled = true;
				CancelBtn.Enabled = true;
				DoLoginBtn.Text = "登陆(&L)";
				UserGroup = Convert.ToInt32(JsonNowUsrResult["UserActAs"].ToString());
				UserPartOfSchool = Convert.ToInt32(JsonNowUsrResult["PartOfSchool"].ToString());
			}
			catch (Exception)
			{
				LoginResult.Text = "用户名或密码不正确";
				DoLoginBtn.Enabled = true;
				CancelBtn.Enabled = true;
				DoLoginBtn.Text = "登陆(&L)";
				return;
			}
			if (PswdTxt.Text == Password)
			{
				UserController UsrCtrl = new UserController()
				{
					Password = Password,
					UserID = StrObjectID,
					UserName = UserNameTxt.Text,
					UserGroup = (UserGroup)UserGroup,
					UserPartOfSchool = (UserPartOS)UserPartOfSchool,
					LoginTime = DateTime.Now.TimeOfDay.ToString()
				};
				(new Views.MainWindow(UsrCtrl)).Show();
				Hide();
			}
			else
			{
				LoginResult.Text = "用户名或密码不正确";
			}
			DoLoginBtn.Enabled = true;
			CancelBtn.Enabled = true;
			DoLoginBtn.Text = "登陆(&L)";
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			new Views.CreateUser().ShowDialog();
		}

		private void UsrLoginForm_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
		}
	}
}
