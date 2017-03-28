using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using WoodenBench_Desktop.Controls;

namespace WoodenBench_Desktop.Views
{
	public partial class MainWindow : Form
	{
		static string NOTI_TABLE_NAME = "YHNotifications";
		public UserController NowUser;
		string NotificationTitle, NotificationContent;
		public MainWindow(UserController ValController) : base()
		{
			Bmob = new BmobWindows();
			Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
			InitializeComponent();
			BmobDebug.Register(Message =>
			{
				Debug.WriteLine(Message);
				//Console.WriteLine(Message);
			});
			NowUser = ValController;
		}
		public BmobWindows Bmob { get; }

		private void MainWindow_Load(object sender, EventArgs e)
		{
			BtomNowUsrName.Text = TopNowUserName.Text = NowUser.UserName;
			BtomNowUsrID.Text = TopNowUserID.Text = NowUser.UserID;
			BtomNowUsrLoginTime.Text = TopNowUserLoginName.Text = NowUser.LoginTime;
			BtomNowUserAct.Text = TopNowUserGroup.Text = NowUser.UserGroup.ToString();
			NotificationWorker.RunWorkerAsync();
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		private void GetNotificationWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var Resulta = Bmob.GetTaskAsync<NotificationObject>(NOTI_TABLE_NAME, "DVMoSSS3");
			JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(Resulta.Result));
			NotificationTitle = JsonNowUsrResult["NTitle"].ToString();
			string NotSplitedContent = JsonNowUsrResult["NContent"].ToString();
			NotificationContent = NotSplitedContent.Replace("/NL", Environment.NewLine);
		}

		private void GetNotificationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			NotificationContentLabel.Text = NotificationContent;
			NotificationTitleLabel.Text = NotificationTitle;
		}

		private void 更改用户信息DToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new ChangeUserData(NowUser).ShowDialog();
		}

		private void 退出用户EToolStripMenuItem_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show($"确定要退出当前账户 {NowUser.UserName} 吗？", "询问", MessageBoxButtons.YesNo))
			{
				case DialogResult.Yes:
					Application.Restart();
					break;
				case DialogResult.No:
					break;
				default:
					break;
			}

		}

		private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
