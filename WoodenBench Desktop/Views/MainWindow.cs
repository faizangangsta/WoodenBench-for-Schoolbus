using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.staClass;
using WoodenBench.TableObjects;
using static WoodenBench.staClass.GlobalFunc;
using static WoodenBench.staClass.UserActivity;

namespace WoodenBench.View
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Office.Excel interface is to initialize an Excel.exe, and read excel files
        /// </summary>
        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook xWorkbook;
        /// <summary>
        /// This is something mysterious, you'll be able to see it later.
        /// </summary>
        int Hiint = 0;
        /// <summary>
        /// Default instance makes us easier to access a window and its components.
        /// </summary>
        private static MainWindow defaultInstance;
        /// <summary>
        /// Student data table, this is used when the user upload students data.
        /// </summary>
        EveryStudentData StudentObj = new EveryStudentData(TABLE_N_AllStuData);
        /// <summary>
        /// Some string variables used when we get notifications.
        /// </summary>
        string NotificationTitle, NotificationContent;
        /// <summary>
        /// Some string variables.
        /// </summary>
        string ExcelFilePath, NowClassProcess, NowPartOfSchool;
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public MainWindow() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        /// <summary>
        /// Default instance.
        /// </summary>
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
            ///Will be called when the window is loaded, some initialize occurs here.
            ///ASync get notifications.
            NotificationWorker.RunWorkerAsync();

            //Show user's realname on the title bar of the window
            Text = Text + " - " + CurrentUser.RealName;

            //User login time, shown in the bottom and on the right.
            TUsrLgnTimeL.Text = CurrentUser.LastLoginTime.iso;

            //Username, which is different from Realname. this is known as an ID
            BUsrNameL.Text = TUsrNameL.Text = CurrentUser.UserName;

            //The real ID, for BMOB storage use, shown as objectId
            BUsrIDL.Text = TUsrIDL.Text = CurrentUser.objectId;

            ///Usergroup. <see cref="UserGroupEnum"/>, this is the differece of every user. 
            BUsrGroupL.Text = TUsrGroupL.Text = ((UserGroupEnum)CurrentUser.UserGroup).ToString();

            //User's realname
            BUsrRNameL.Text = TUsrRNameL.Text = CurrentUser.RealName;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //First Exit the Excel Application
            ExcelApp.Quit();

            ///Then Exit whole App <see cref="ApplicationExit"/>
            ApplicationExit();
        }

        private void GetNotificationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Callthe when the "GetNotification" is doing job.
            //We use "var", for we don't know the type it returns..
            var Resulta = Bmob.GetTaskAsync<NotificationObject>(TABLE_N_Gen_Notifi, OBJ_ID_Notifi);

            ///Convert <see cref="Resulta"/> to JSON, for more information, JSON is a type.
            JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(Resulta.Result));

            //variable NotificationTitle, you should know what this is used for.
            NotificationTitle = JsonNowUsrResult["NTitle"].ToString();

            //RAW content of DataContent, you will know what is it by using 
            //"Console.Writeline(NotSplitedContent)"
            string NotSplitedContent = JsonNowUsrResult["DataContent"].ToString();

            //We store "newline" as "/NL", so we should replace "/NL" when we use them.
            NotificationContent = NotSplitedContent.Replace("/NL", Environment.NewLine);
        }

        private void GetNotificationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Once the application has finished getting Notifications, it will be shown.
            //Into the label with the Name(s) are
            //NotificationContentLabel And NotificationTitleLabel
            NotificationContentLabel.Text = NotificationContent;
            NotificationTitleLabel.Text = NotificationTitle;
        }

        private void 更改用户信息DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ChangeUserData is not a static window, so we should use "new"
            //ShowDialog() is different form Show()
            //You will know that later
            new ChangeUserData().ShowDialog();
        }

        private void 退出用户EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///switch is sometimes very useful, if you want to know, I'll show you.
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
            ///Something Strange??
            Hiint++;
            ///Something Strange??
            ///There isn't any Easter Eggs..
            if (Hiint == 5) Mysterious.ShowMys();
        }

        private void MainWindow_Click(object sender, EventArgs e)
        {
            //Clean Strange THING, there's no Easter Eggs...
            Hiint = 0;
        }

        /// <summary>
        /// This void is called once the <see cref="ExcelFileOpenBtn"/> is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenExcel(object sender, EventArgs e)
        {
            //First,reset the variable that used to store the Excel file path.
            OpenExcelFileDialog.FileName = "";
            //Second , show out a "choose file" dialog and that wil let user choose 
            //an exist excel file.
            OpenExcelFileDialog.ShowDialog();
            //if the user chose something....
            if (OpenExcelFileDialog.FileName != "")
            {
                //variable ExcelFilePath will be set to the file path, with full name.
                ExcelFilePath = OpenExcelFileDialog.FileName;
                //ExcelFilePathTxt, is a textbox, which shows out the
                //full path of the excel file.
                ExcelFilePathTxt.Text = ExcelFilePath;
                //This step may use more time cause this will let excel open the file.
                xWorkbook = ExcelApp.Workbooks._Open(ExcelFilePath);
                ///Here, we used a 'returnd value' of a function <see cref="GetLastLineOfExcel"/>
                ///We go to the <see cref="GetLastLineOfExcel"/>
                ///Before continue, Right click "GetLastLineOfExcel()" and select "速览定义"
                ///
                ///LastLine is the returned value.
                int LastLine = GetLastLineOfExcel();
                //Another loop to read the fields and store in a,b,c,d
                for (int LineNum = 4; LineNum <= (LastLine - 1); LineNum++)
                {
                    string a = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 2].Value);
                    string b = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 3].Value);
                    string c = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 4].Value);
                    string d = Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 5].Value);
                    //Redundant Data Field For Future Use
                    //Rows.Add can add these into "StudentData"
                    StudentData.Rows.Add(a, b, c, d);
                }
                //After the loop, Read the Department, Like "Cambridge" or,, "Canada"
                NowPartOfSchool = Convert.ToString(xWorkbook.Worksheets[1].Cells[2, 4].Value);
                //After the Department, this is the class name. like Y10-C
                NowClassProcess = Convert.ToString(xWorkbook.Worksheets[1].Cells[2, 2].Value);
                //Show out the Department and Class
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
                //StudentObj.StudentIsBWeek = StudentData.Rows[RowNum].Cells[2].Value.ToString();
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
                        MessageBox.Show("出现错误，错误代码:  401"
                            + Environment.NewLine
                            + "学生姓名有重复项"
                            + Environment.NewLine
                            + Inner.Substring(Inner.Length - (StudentObj.StudentName.Length + 5), StudentObj.StudentName.Length));
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
        /// <summary>
        /// Get the last line in an Excel file.
        /// </summary>
        /// <returns></returns>
        /// private int GetLastLineOfExcel()
        /// private: this function cannot be accessed outside this 'class'
        /// 
        ///             Class is like the group of the functions, you have known that 
        ///             Some classes are STATIC, some are not.
        ///             All the functions is in the class.
        ///             it is just like the "group"
        ///             
        /// int:     this function will return an 'int' value.
        ///          int is a number, a whole number. with size limit.
        /// GetLastLineOfExcel()
        ///          the nae of the function,,,, don't forget the breckets
        private int GetLastLineOfExcel()
        {
            ///Int Variable, its name is LineNum.
            int LineNum;
            ///for, is a loop, here we look at it closely
            ///
            ///  LineNum = 1 
            ///             Means the LineNum, which is a variable, 
            ///             Its value is set to 1 at the start.
            ///             
            //              LineNum <= 100
            ///             Means the loop will stop when LineNum == 100
            ///             
            ///                               LineNum++
            ///             Once one loop has finished, the LineNum will
            ///             increase 1, 
            ///                      "LineNum++" 
            ///                 can also written as 
            ///                      "LineNum = LineNum + 1"
            for (LineNum = 1; LineNum <= 100; LineNum++)
            {
                ///<see cref="Convert"/> is a static class, this 
                ///class gives us the possibility of convert a
                ///variable into many other types.

                ///xWorkbook.Worksheets[1].Cells[LineNum, 1].Value
                ///         will returnsthe text in the 
                ///         LineNum Row, 1st Column
                ///
                ///         if the value is null, then this line is the last line, 
                ///         if not, the loop will continue      
                if (Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 1].Value) == null)
                    return LineNum;
            }
            //if the loop did't finish when LinNum = 100,,
            //There must be an ERR..
            //for the Excel file should not be that long....
            //We Return 0 to let user know the error
            return 0;
            ///go back to where we came from
        }
    }
}

//var query = new BmobQuery();
//query.WhereContainedIn<string>("playerName", "123");
//var future = Bmob.FindTaskAsync<GameObject>(TABLE_NAME, query);
//FinishedCallback(future.Result, resultText);