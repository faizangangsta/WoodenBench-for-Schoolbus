using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench_Desktop.staClass;
using WoodenBench_Desktop.TableObjects;
using static WoodenBench_Desktop.staClass.GlobalFunc;
using static WoodenBench_Desktop.staClass.UserActivity;

namespace WoodenBench_Desktop.View
{
    public partial class MainWindow : Form
    {
        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook xWorkbook;
        int Hiint = 0;
        private static MainWindow defaultInstance;
        EveryStudentData StudentObj = new EveryStudentData(TABLE_N_AllStuData);
        string NotificationTitle, NotificationContent;
            string ExcelFilePath, NowClassProcess, NowPartOfSchool;
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public MainWindow() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        public static MainWindow Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new MainWindow();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            NotificationWorker.RunWorkerAsync();
            Text = Text + " - " + CurrentUser.RealName;
            TUsrLgnTimeL.Text = CurrentUser.LastLoginTime.iso;
            BUsrNameL.Text = TUsrNameL.Text = CurrentUser.UserName;
            BUsrIDL.Text = TUsrIDL.Text = CurrentUser.objectId;
            BUsrGroupL.Text = TUsrGroupL.Text = ((UserGroupEnum)CurrentUser.UserGroup).ToString();
            BUsrRNameL.Text = TUsrRNameL.Text = CurrentUser.RealName;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExcelApp.Quit();
            
        }

        private void GetNotificationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var Resulta = Bmob.GetTaskAsync<NotificationObject>(TABLE_N_Gen_Notifi, OBJ_ID_Notifi);
            JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(Resulta.Result));
            NotificationTitle = JsonNowUsrResult["NTitle"].ToString();
            string NotSplitedContent = JsonNowUsrResult["DataContent"].ToString();
            NotificationContent = NotSplitedContent.Replace("/NL", Environment.NewLine);
        }

        private void GetNotificationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            NotificationContentLabel.Text = NotificationContent;
            NotificationTitleLabel.Text = NotificationTitle;
        }

        private void 更改用户信息DToolStripMenuItem_Click(object sender, EventArgs e)
        { new ChangeUserData().ShowDialog(); }

        private void 退出用户EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show($"确定要退出当前账户 {CurrentUser.UserName} 吗？", "询问", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    LogOut();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void StrangeBar(object sender, EventArgs e)
        {
            Hiint++;
            if (Hiint == 5) Mysterious.ShowMys();
        }

        private void MainWindow_Click(object sender, EventArgs e)
        {
            Hiint = 0; //Clean Strange THING
        }

        private void OpenExcel(object sender, EventArgs e)
        {
            OpenExcelFileDialog.FileName = "";
            OpenExcelFileDialog.ShowDialog();
            if (OpenExcelFileDialog.FileName != "")
            {
                ExcelFilePath = OpenExcelFileDialog.FileName;
                ExcelFilePathTxt.Text = ExcelFilePath;
                // Solve File Missing 
                xWorkbook = ExcelApp.Workbooks._Open(ExcelFilePath);
                int LastLine = GetLastLineOfExcel();
                for (int LineNum = 4; LineNum <= (LastLine - 1); LineNum++)
                {
                    string a = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 2].Value);
                    string b = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 3].Value);
                    string c = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 4].Value);
                    string d = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 5].Value);
                    //Redundant Data Field For Future Use
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
            ApplicationExit();
        }

        private void SureAndUpload(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.SureAndUploadBtn.Text = "上传中...";
            Application.DoEvents();
            for (int RowNum = 0; RowNum <= (StudentData.RowCount - 2); RowNum++)
            {
                StudentObj.StudentName = StudentData.Rows[RowNum].Cells[0].Value.ToString();
                StudentObj.StudentDirection = StudentData.Rows[RowNum].Cells[1].Value.ToString();
                StudentObj.StudentIsBWeek = StudentData.Rows[RowNum].Cells[2].Value.ToString();
                StudentObj.StudentClass = NowClassProcess;
                StudentObj.StudentPartOfSchool = NowPartOfSchool;
                var future = Bmob.CreateTaskAsync(StudentObj);
                future.Wait();
                try { future.Result.ToString(); }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("401"))
                    {
                        string Inner = ex.InnerException.Message;
                        MessageBox.Show("出现错误，错误代码:  401" + Environment.NewLine + "学生姓名有重复项" + Environment.NewLine + Inner.Substring(Inner.Length - (StudentObj.StudentName.Length + 5), StudentObj.StudentName.Length));
                    }
                    else
                    {
                        MessageBox.Show($"出现其它错误 {ex.Message}");

                    }
                }
            }
            MessageBox.Show("所有项目已上传!");
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