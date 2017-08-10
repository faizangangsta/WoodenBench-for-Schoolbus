using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.StaClasses;
using WoodenBench.TableObject;
using static WoodenBench.StaClasses.GlobalFunc;

namespace WoodenBench.Views
{
    public partial class ExcelOperationWindow : Form
    {
        string ExcelFilePath, NowClassProcess, NowPartOfSchool;
        public ExcelOperationWindow() { InitializeComponent(); }

        private void ExcelOperation_Load(object sender, EventArgs e)
        {

        }
        private void OpenExcel(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xWorkbook;

            OpenExcelFileDialog.FileName = "";
            OpenExcelFileDialog.ShowDialog();
            if (OpenExcelFileDialog.FileName == "") return;
            ExcelFilePath = OpenExcelFileDialog.FileName;
            ExcelFilePathTxt.Text = ExcelFilePath;
            xWorkbook = ExcelApp.Workbooks._Open(ExcelFilePath, ReadOnly: true, Editable: false);
            int LastLine = ExcelApplication.GetLastLineOfExcel(xWorkbook);
            for (int LineNum = 4; LineNum <= (LastLine - 1); LineNum++)
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
            ExcelApp.Quit();
        }

        private void SureAndUpload(object sender, EventArgs e)
        {
            string LastErrPerson = "";
            StudentDataObject StudentObj = new StudentDataObject();
            this.Enabled = false;
            bool IsSucceed = false;
            this.SureAndUploadBtn.Text = "上传中...";
            Application.DoEvents();
            for (int RowNum = 0; RowNum <= (StudentData.RowCount - 2); RowNum++)
            {
                StudentObj.StudentName = StudentData.Rows[RowNum].Cells[0].Value.ToString();
                StudentObj.StudentDirection = StudentData.Rows[RowNum].Cells[1].Value.ToString();
                StudentObj.StudentClass = NowClassProcess;
                StudentObj.StudentPartOfSchool = NowPartOfSchool;
                StudentObj.StudentNamePinYin = PinYin.GetPinyin(StudentObj.StudentName);
                StudentObj.StuIdentity = StudentObj.StudentNamePinYin + PinYin.GetPinyin(NowPartOfSchool);
                StatusBar.Text = "正在处理第" + (RowNum + 1).ToString() + "条数据，学生姓名 " + StudentObj.StudentName;
                Application.DoEvents();
                var future = _BmobWin.CreateTaskAsync(StudentObj);
                try
                {
                    future.Wait();
                    future.Result.ToString();
                    IsSucceed = true;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("401"))
                    {
                        IsSucceed = false;
                        string Inner = ex.InnerException.Message;
                        LastErrPerson = Inner.Substring(Inner.Length - (StudentObj.StudentName.Length + 5), StudentObj.StudentName.Length);
                        MessageBox.Show(
                            "出现错误，错误代码: 401 \r\n"
                            + "学生姓名有重复项\r\n"
                            + LastErrPerson
                            + "\r\n操作将要停止，已经上传的学生数据将不会显示");
                        StatusBar.Text = "出现了错误，请检查 " + LastErrPerson + "的记录";
                    }
                }
            }
            if (IsSucceed)
            {
                StatusBar.Text = "成功完成操作！已经上传" + StudentData.RowCount.ToString() + "条数据";
                MessageBox.Show("所有项目已经成功上传！");
            }
            else
            {
                MessageBox.Show($"出现错误");
            }
            this.SureAndUploadBtn.Text = "确认并上传(&S)";
            this.Enabled = true;
        }
    }
}
