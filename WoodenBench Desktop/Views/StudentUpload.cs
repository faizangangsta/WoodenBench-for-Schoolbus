using cn.bmob.io;
using cn.bmob.response;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoodenBench.StaticClasses;
using WoodenBench.TableObject;
using static WoodenBench.StaticClasses.GlobalFunc;

namespace WoodenBench.Views
{
    public partial class ExcelOperationWindow : MetroForm
    {
        string ExcelFilePath;
        public ExcelOperationWindow()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static ExcelOperationWindow defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public static ExcelOperationWindow Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new ExcelOperationWindow();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion

        private void ExcelOperationWindow_Load(object sender, EventArgs e)
        {

        }


        private void OpenExcel(object sender, EventArgs e)
        {
            OpenExcelFileDialog.FileName = "";
            OpenExcelFileDialog.ShowDialog();
            if (OpenExcelFileDialog.FileName == "") return;
            ExcelFilePath = OpenExcelFileDialog.FileName;
            ExcelFilePathTxt.Text = ExcelFilePath;

            ExcelApplication Excel = new ExcelApplication();
            //Excel.OpenExcelApp();

            Excel.OpenExcelFile(ExcelFilePath, true, false);

            int LastLine = Excel.LastLine(StartFrom: 1, EndAt: 200, ifErrReturnVal: 0, WorkSheetNum: 1);

            for (int LineNum = 4; LineNum <= (LastLine - 1); LineNum++)
            {
                bool IsUpdate = false;
                string StuName = Excel.ReadContent<string>(LineNum, 1);
                string StuDirection = Excel.ReadContent<string>(LineNum, 2);
                foreach (DataGridViewRow item in StudentData.Rows)
                {
                    if (item.Cells[1].Value?.ToString() == StuName)
                    {
                        item.Cells[1].Value = StuName;
                        item.Cells[5].Value = StuDirection;
                        IsUpdate = true;
                        break;
                    }
                }
                if (!IsUpdate)
                {
                    StudentDataObject student = new StudentDataObject();
                    student.StudentName = StuName;
                    student.StudentPartOfSchool = StuPartOS.Text;
                    student.StudentYear = StuYear.Text;
                    student.StudentClass = StuClass.Text;
                    student.StudentDirection = StuDirection;

                    studentDataObjectBindingSource.Add(student);
                }
            }
            Excel.QuitExcel();
        }

        private void ExcelOperationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Default.Show();
        }

        private void LoadExistStudents_Click(object sender, EventArgs e)
        {
            studentDataObjectBindingSource.Clear();
            BmobQuery query = new BmobQuery();

            query.WhereEqualTo("StuPartOfSchool", StuPartOS.Text);
            query.WhereEqualTo("StuYear", StuYear.Text);
            query.WhereEqualTo("StuClass", StuClass.Text);
            Task<QueryCallbackData<StudentDataObject>> task;
            task = _BmobWin.FindTaskAsync<StudentDataObject>(Consts.TABLE_N_Mgr_StuData, query);
            task.Wait();
            if (task.IsCompleted)
            {
                List<StudentDataObject> list = task.Result.results;
                foreach (StudentDataObject item in list)
                {
                    studentDataObjectBindingSource.Add(item);
                }
                ExDiscription.Text = $"成功加载了 { task.Result.results.Count} 条数据";
            }
            StudentData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExcelOperationWindow_Shown(object sender, EventArgs e)
        {
            StuYear.SelectedIndex = 0;
            StuPartOS.SelectedIndex = 0;
            StuClass.SelectedIndex = 0;
            BmobQuery query = new BmobQuery();
            query.Limit(100);
            Task<QueryCallbackData<SchoolBusObject>> task;
            task = _BmobWin.FindTaskAsync<SchoolBusObject>(Consts.TABLE_N_Mgr_BusData, query);
            task.Wait();
            if (task.IsCompleted)
            {
                List<SchoolBusObject> list = task.Result.results;
                foreach (SchoolBusObject item in list)
                {
                    schoolBusObjectBindingSource.Add(item);
                }
            }
            BusDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void StuPartOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            StuYear.Items.Clear();
            switch (StuPartOS.Text)
            {
                case "小学部":
                    StuYear.Items.AddRange(new string[] { "一年级", "二年级", "三年级", "四年级", "五年级", "六年级" });
                    break;
                case "初中部":
                    StuYear.Items.AddRange(new string[] { "初一", "初二", "初三" });
                    break;
                case "普通高中部":
                case "中加高中部":
                    StuYear.Items.AddRange(new string[] { "高一", "高二", "高三" });
                    break;
                case "剑桥高中部":
                    StuYear.Items.AddRange(new string[] { "Year 10", "Year 11", "Year 12", "Year 13" });
                    break;
                default:
                    StuYear.Items.Add("请选择学部");
                    break;
            }
            StuYear.SelectedIndex = 0;
        }

        public void onExcelFilePorcFinished(ExcelProcessEventArgs e)
        {
            switch (e.ProcessStatus)
            {
                case ProcStatE.Unknown:
                    break;
                case ProcStatE.Completed:
                    break;
                case ProcStatE.Failed:
                    break;
                case ProcStatE.FailedWithErr:
                    break;
                default:
                    break;
            }

            switch (e.ExcelProcType)
            {
                case ExcelFileProcE.StartExcelApp:
                    break;
                case ExcelFileProcE.QuitExcelApp:
                    break;
                case ExcelFileProcE.Open:
                    break;
                case ExcelFileProcE.Read:
                    break;
                case ExcelFileProcE.Close:
                    break;
                case ExcelFileProcE.Write:
                    break;
                default:
                    break;
            }
        }


        private void SureAndUpload(object sender, EventArgs e)
        {
            switch (MessageBox.Show("上传会改写已经存在的项，是否继续？", "提示", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                default:
                    return;
                    break;
            }

            foreach (DataGridViewRow item in StudentData.Rows)
            {
                item.DefaultCellStyle.BackColor = Color.White;
                item.DefaultCellStyle.ForeColor = Color.Black;
                if (item.Cells[5].Value != null)
                {
                    foreach (DataGridViewRow subItem in BusDataGrid.Rows)
                    {
                        if (subItem.Cells[1].Value != null || subItem.Cells[1].Value.ToString() != "")
                        {
                            if (item.Cells[5].Value.ToString().Contains(subItem.Cells[1].Value.ToString()))
                            {
                                item.Cells[6].Value = subItem.Cells[0].Value.ToString();
                                Application.DoEvents();
                                break;
                            }
                        }
                    }
                }
            }

            Application.DoEvents();

            StudentDataObject StudentObj = new StudentDataObject();
            StudentObj.ComeChecked = false;
            StudentObj.LeaveChecked = false;
            StudentObj.ParentComeChecked = false;
            StudentObj.ParentLeaveChecked = false;
            StudentObj.OtherStuData = "";
            this.Enabled = false;
            this.SureAndUploadBtn.Text = "上传中...";
            Application.DoEvents();
            List<string> ErrDetail = new List<string>();
            for (int RowNum = 0; RowNum < (StudentData.RowCount - 1); RowNum++)
            {
                StudentObj.StudentName = (string)StudentData.Rows[RowNum].Cells[1].Value;
                StudentObj.StudentDirection = (string)StudentData.Rows[RowNum].Cells[5].Value;

                StudentObj.BusID = (string)StudentData.Rows[RowNum].Cells[6].Value;
                StudentObj.StudentPartOfSchool = StuPartOS.Text;
                StudentObj.StudentYear = StuYear.Text;
                StudentObj.StudentClass = StuClass.Text;

                ExDiscription.Text = "学生姓名：" + StudentObj.StudentName;
                Application.DoEvents();
                //If Record is NOT in the Server Database
                if (string.IsNullOrEmpty((string)StudentData.Rows[RowNum].Cells[0].Value))
                {
                    Task<CreateCallbackData> CreateTask = _BmobWin.CreateTaskAsync(StudentObj);
                    try
                    {
                        CreateTask.Wait();
                        if (CreateTask.IsCompleted)
                        {
                            Application.DoEvents();
                            LogWritter.DebugMessage(CreateTask.Result.ToString());
                            StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.Green;
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.Red;
                        StudentData.Rows[RowNum].DefaultCellStyle.ForeColor = Color.White;
                        LogWritter.ErrorMessage(ex.InnerException.Message);
                        ErrDetail.Add("\t" + StudentObj.StudentName + " : " + ex.InnerException.Message + ";" + "\r\n");
                    }
                }
                //Record is in the Database, only update needed
                else
                {
                    StudentObj.objectId = (string)StudentData.Rows[RowNum].Cells[0].Value;
                    Task<UpdateCallbackData> UpdateTask = _BmobWin.UpdateTaskAsync(StudentObj);
                    try
                    {
                        UpdateTask.Wait();
                        if (UpdateTask.IsCompleted)
                        {
                            Application.DoEvents();
                            LogWritter.DebugMessage(UpdateTask.Result.ToString());
                            StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.LawnGreen;
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.Red;
                        StudentData.Rows[RowNum].DefaultCellStyle.ForeColor = Color.White;
                        LogWritter.ErrorMessage(ex.InnerException.Message);
                        ErrDetail.Add("\t" + StudentObj.StudentName + " : " + ex.InnerException.Message + ";" + "\r\n");
                    }
                }
            }
            if (ErrDetail.Count == 0)
            {
                ExDiscription.Text = "成功完成操作！已经上传 " + (StudentData.RowCount - 1).ToString() + " 条数据";
                MessageBox.Show("所有项目已经成功上传！");
            }
            else
            {
                ExDiscription.Text = "上传部分失败！共 " + ErrDetail.Count.ToString() + " 条失败";
                string ErrMsg = "\r\n";
                foreach (string item in ErrDetail)
                {
                    ErrMsg = ErrMsg + item;
                }
                LogWritter.ErrorMessage("Error when updating these students data: " + ErrMsg);
                MessageBox.Show("有部分内容上传失败，它们是：" + ErrMsg + "请尝试重新上传");
            }
            this.SureAndUploadBtn.Text = "确认并上传(&S)";
            this.Enabled = true;
        }

        private void 删除当前行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Name = (string)StudentData.SelectedCells[0].OwningRow.Cells[1].Value;
            if (StudentData.SelectedCells.Count >= 1 && MessageBox.Show("是否要在服务器上删除此条记录？", "删除记录", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Task<DeleteCallbackData> task;
                    task = _BmobWin.DeleteTaskAsync(Consts.TABLE_N_Mgr_StuData, (string)StudentData.SelectedCells[0].OwningRow.Cells[0].Value);
                    task.Wait();
                    StudentData.Rows.Remove(StudentData.SelectedCells[0].OwningRow);
                    ExDiscription.Text = "成功在服务器上删除:" + Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    LogWritter.ErrorMessage(ex.Message);
                    ExDiscription.Text = "删除 " + Name + " 时出现问题";
                }
            }
            else
            {
                StudentData.Rows.Remove(StudentData.SelectedCells[0].OwningRow);
                ExDiscription.Text = "成功删除:" + Name;
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell item in StudentData.SelectedCells)
            {
                item.Value = "";
            }
        }
    }
}
