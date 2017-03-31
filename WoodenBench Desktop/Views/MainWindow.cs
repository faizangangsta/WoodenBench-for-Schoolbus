using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench_Desktop.Controls;

namespace WoodenBench_Desktop.Views
{
	public partial class MainWindow : Form
	{
		Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();

		Microsoft.Office.Interop.Excel.Workbook xWorkbook;

		UserController NowUser;
		int Hi = 0;
		EveryStudentData StudentObj = new EveryStudentData(Consts.TABLE_NAME_AllStudentsData);
		string NotificationTitle, NotificationContent, ExcelFilePath, NowClassProcess,NowPartOfSchool;
		public MainWindow(UserController ValController) : base()
		{
			Bmob = new BmobWindows();
			Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
			InitializeComponent();
			BmobDebug.Register(Message => { Debug.WriteLine(Message); });
			NowUser = ValController;
		}
		BmobWindows Bmob { get; }

		private void MainWindow_Load(object sender, EventArgs e)
		{
			BtomNowUsrName.Text = TopNowUserName.Text = NowUser.UserName;
			BtomNowUsrID.Text = TopNowUserID.Text = NowUser.UserID;
			TopNowUserLoginName.Text = NowUser.LoginTime;
			BtomNowUserAct.Text = TopNowUserGroup.Text = NowUser.UserGroup.ToString();
			NotificationWorker.RunWorkerAsync();
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			ExcelApp.Quit();
			Application.Exit();
		}

		private void GetNotificationWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var Resulta = Bmob.GetTaskAsync<NotificationObject>(Consts.TABLE_NAME_General_Notification, Consts.OBJECT_ID_Notification);
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
			switch (MessageBox.Show($"确定要退出当前账户 " +
				$"{NowUser.UserName} " +
				$"吗？", "询问", MessageBoxButtons.YesNo))
			{ case DialogResult.Yes: Application.Restart(); break; }
		}

		private void toolStripSeparator2_Click(object sender, EventArgs e)
		{
			Hi++;
			if (Hi == 5)
			{
				(new Mysterious()).ShowMys(NowUser);
			}
		}

		private void MainWindow_Click(object sender, EventArgs e)
		{
			Hi = 0;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			OpenExcelFileDialog.FileName = "";
			OpenExcelFileDialog.ShowDialog();
			if (OpenExcelFileDialog != null)
			{
				ExcelFilePath = OpenExcelFileDialog.FileName;
				ExcelFilePathTxt.Text = ExcelFilePath;
				// Solve File Missing 
				xWorkbook = ExcelApp.Workbooks._Open(ExcelFilePath);

				for (int LineNum = 4; LineNum <= (GetLastLineOfExcel() - 1); LineNum++)
				{
					string a = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 2].Value);
					string b = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 3].Value);
					string c = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 4].Value);
					string d = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 5].Value);
					StudentData.Rows.Add(a, b, c, d);
				}
				NowPartOfSchool = Convert.ToString(xWorkbook.Worksheets[1].Cells[2, 4].Value);
				NowClassProcess = Convert.ToString(xWorkbook.Worksheets[1].Cells[2, 2].Value);
				NowPartOSchoolLbl.Text = NowPartOfSchool;
				NowClassLbl.Text = NowClassProcess;
			}
		}

		private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void SureAndUpload(object sender, EventArgs e)
		{
			this.Enabled = false;
			this.SureAndUploadBtn.Text = "上传中……";
			Application.DoEvents();
			for (int RowNum = 0; RowNum <= (StudentData.RowCount - 2); RowNum++)
			{
				StudentObj.StudentName = StudentData.Rows[RowNum].Cells[0].Value.ToString();
				StudentObj.StudentDirection = StudentData.Rows[RowNum].Cells[1].Value.ToString();
				StudentObj.StudentIsBWeek = StudentData.Rows[RowNum].Cells[2].Value.ToString();
				StudentObj.StudentClass = NowClassProcess;
				StudentObj.StudentPartOfSchool = NowPartOfSchool;
				var future = Bmob.CreateTaskAsync(StudentObj);
				Thread.Sleep(50);
				try
				{
				}
				catch (Exception ex)
				{
					if (ex.InnerException.Message.Contains("401"))
					{
						string Inner = ex.InnerException.Message;
						MessageBox.Show("出现错误，错误代码:  401"+Environment.NewLine + "学生姓名有重复项" + Environment.NewLine + Inner.Substring(Inner.Length - (StudentObj.StudentName.Length + 5), StudentObj.StudentName.Length));
					}
				}
			}
			this.SureAndUploadBtn.Text = "确认并上传(&S)";
			this.Enabled = true;
		}
		private int GetLastLineOfExcel()
		{
			int LineNum;
			for (LineNum = 1; LineNum <= 100; LineNum++)
			{
				if (Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 1].Value) == null)
					return LineNum;
			}
			return 0;
		}
	}
}

//var query = new BmobQuery();
//query.WhereContainedIn<string>("playerName", "123");
//var future = Bmob.FindTaskAsync<GameObject>(TABLE_NAME, query);
//FinishedCallback(future.Result, resultText);