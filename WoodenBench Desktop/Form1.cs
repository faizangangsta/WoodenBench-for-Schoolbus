using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.json;
using cn.bmob.tools;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WoodenBench_Desktop.Controls;

namespace WoodenBench_Desktop
{
	public partial class UsrLoginForm : Form
	{
		private string StrObjectID;
		private string Password;
		private int UserActAs;

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
			BmobDebug.Register(Message => { Debug.WriteLine(Message); });
		}

		public BmobWindows Bmob { get; }
		public const String TABLE_NAME = "AllUsersTable";

		private void DoLogin(object sender, EventArgs e)
		{
			LoginResult.Text = "";
			DoLoginBtn.Enabled = false;
			CancelBtn.Enabled = false;
			DoLoginBtn.Text = "登陆中...";
			Application.DoEvents();
			try
			{
				BmobQuery UserNameQuery = new BmobQuery();
				UserNameQuery.WhereContainedIn("Username", UserNameTxt.Text);
				var UsrNameResult = Bmob.FindTaskAsync<BmobObject>(TABLE_NAME, UserNameQuery);
				JObject JsonUserNameResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(UsrNameResult.Result));

				StrObjectID = (JsonUserNameResult.First.First.First.First.First).ToString();
				var NowUserResult = Bmob.GetTaskAsync<BmobObject>(TABLE_NAME, StrObjectID);
				JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(NowUserResult.Result));

				Password = JsonNowUsrResult["Password"].ToString();
				DoLoginBtn.Enabled = true;
				CancelBtn.Enabled = true;
				DoLoginBtn.Text = "登陆(&L)";
				UserActAs = Convert.ToInt32(JsonNowUsrResult["UserActAs"].ToString());
			}
			catch (Exception)
			{
				LoginResult.Text = "用户名不存在";
			}
			if (PswdTxt.Text == Password)
			{
				UserController UsrCtrl = new UserController()
				{
					Password = Password,
					UserID = StrObjectID,
					UserName = UserNameTxt.Text,
					UserActAs = (Users)UserActAs,
					LoginTime = DateTime.Now.ToString()
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
	}
}
