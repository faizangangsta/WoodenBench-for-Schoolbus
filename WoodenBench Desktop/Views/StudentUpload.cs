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
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using static WBServicePlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBServicePlatform.WinClient.Views
{
    public partial class ExcelOperationWindow : MetroForm
    {
        string ExcelFilePath;
        ClassObject CurrentClass;
        bool IsReadOnly = true;
        Dictionary<string, string> BusDataPair = new Dictionary<string, string>();

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
            statusPanel.Visible = true;
            statusLabel.Text = "正在打开Excel....";
            Application.DoEvents();
            ExcelApplication Excel = new ExcelApplication();
            statusLabel.Text = "请选择Excel文档";
            Application.DoEvents();
            OpenExcelFileDialog.FileName = "";
            OpenExcelFileDialog.ShowDialog();
            if (OpenExcelFileDialog.FileName == "") return;
            ExcelFilePath = OpenExcelFileDialog.FileName;
            ExcelFilePathTxt.Text = ExcelFilePath;

            //Excel.OpenExcelApp();

            statusLabel.Text = "正在读取Excel文件，请稍等......";
            Application.DoEvents();
            Excel.OpenExcelFile(ExcelFilePath, true, false);

            statusLabel.Text = "获取文件长度......";
            Application.DoEvents();
            int LastLine = Excel.LastLine(StartFrom: 1, EndAt: 200, ifErrReturnVal: 0, WorkSheetNum: 1);
            string StuName, StuDirection;
            for (int LineNum = 4; LineNum <= (LastLine - 1); LineNum++)
            {
                bool IsUpdate = false;
                statusLabel.Text = $"处理数据，第{LineNum}项，共{(LastLine - 1)}项";
                Application.DoEvents();
                StuName = Excel.ReadContent<string>(LineNum, 1);
                StuDirection = Excel.ReadContent<string>(LineNum, 2);
                foreach (DataGridViewRow item in StudentData.Rows)
                {
                    statusLabel.Text = $"更新现有数据:{StuName}";
                    Application.DoEvents();
                    if (item.Cells[1].Value?.ToString() == StuName)
                    {
                        item.Cells[1].Value = StuName;
                        item.Cells[2].Value = StuDirection;
                        IsUpdate = true;
                        break;
                    }
                }
                if (!IsUpdate)
                {
                    statusLabel.Text = $"添加新数据:{StuName}";
                    Application.DoEvents();
                    StudentDataObject student = new StudentDataObject();
                    student.StudentName = StuName;
                    student.ClassID = CurrentClass.objectId;
                    student.BusID = BusDataPair[StuDirection];
                    studentDataBindSourc.Add(student);
                }
            }
            statusLabel.Text = $"正在释放Excel......";
            Application.DoEvents();
            Excel.QuitExcel();
            statusPanel.Visible = false;
        }

        private void ExcelOperationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Default.Show();
        }

        private void LoadExistStudents_Click(object sender, EventArgs e)
        {
            studentDataBindSourc.Clear();
            BmobQuery ClassQuery = new BmobQuery();

            ClassQuery.WhereEqualTo("ClassDepartment", ClassPartOS.Text);
            ClassQuery.WhereEqualTo("ClassGrade", ClassYear.Text);
            ClassQuery.WhereEqualTo("ClassNumber", ClassNum.Text);
            Task<QueryCallbackData<ClassObject>> ClassFindTask;
            ClassFindTask = _BmobWin.FindTaskAsync<ClassObject>(WBConst.TABLE_N_Mgr_Classes, ClassQuery);
            ClassFindTask.Wait();
            if (!ClassFindTask.IsCompleted || ClassFindTask.Result.results.Count == 0)
            {
                MessageBox.Show("没找到你想要的班级，这，，不应该吧。", "很失望？");
                return;
            }
            CurrentClass = ClassFindTask.Result.results[0];
            ClsID.Text = CurrentClass.objectId;
            ClsDpt.Text = CurrentClass.CDepartment;
            ClsGrade.Text = CurrentClass.CGrade;
            ClsNum.Text = CurrentClass.CNumber;
            ClsTID.Text = CurrentClass.TeacherID;
            if (CurrentClass.TeacherID == "")
            {
                MessageBox.Show("嗯，找到了匹配的班级，但好像没有老师绑定这个班。" +
                    "\r\n" +
                    "~快去叫他使用小板凳吧。" +
                    "\r\n\r\n" +
                    "如果你是这个班的老师的话，先去\"设置\"页绑定一下你的班级！", "没有老师的班级");
                ClsTName.Text = "";
                ClsTPhoneNum.Text = "";
            }
            else
            {
                BmobQuery TeacherDataQuery = new BmobQuery();
                TeacherDataQuery.WhereEqualTo("objectId", CurrentClass.TeacherID);
                Task<QueryCallbackData<UserObject>> TeacherDataFindTask;
                TeacherDataFindTask = _BmobWin.FindTaskAsync<UserObject>(WBConst.TABLE_N_Gen_UserTable, TeacherDataQuery);
                TeacherDataFindTask.Wait();
                if (!TeacherDataFindTask.IsCompleted || TeacherDataFindTask.Result.results.Count == 0)
                {
                    MessageBox.Show("这不应该，这个班级有老师管理，但是查不到老师的任何信息。", "班主任溜了？");
                    ClsTName.Text = "";
                    ClsTPhoneNum.Text = "";
                }
                else
                {
                    ClsTName.Text = TeacherDataFindTask.Result.results[0].RealName;
                    ClsTPhoneNum.Text = TeacherDataFindTask.Result.results[0].PhoneNumber;
                }
            }
            Application.DoEvents();
            //if (MessageBox.Show("找到了班级，是否继续列出班里坐校车的学生？", "要继续吗", MessageBoxButtons.YesNo) == DialogResult.No)
            //    return;

            BmobQuery StudentsQuery = new BmobQuery();
            StudentsQuery.WhereEqualTo("ClassID", CurrentClass.objectId);
            Task<QueryCallbackData<StudentDataObject>> StudentsFindTask;
            StudentsFindTask = _BmobWin.FindTaskAsync<StudentDataObject>(WBConst.TABLE_N_Mgr_StuData, StudentsQuery);
            StudentsFindTask.Wait();
            if (StudentsFindTask.Result.results.Count == 0)
            {
                MessageBox.Show("把数据库翻了个底朝天，还是没有这个班的学生", "学生去哪了？");
            }
            else
            {
                for (int i = 0; i < StudentsFindTask.Result.results.Count; i++)
                {
                    studentDataBindSourc.Add(StudentsFindTask.Result.results[i]);
                    if (!BusDataPair.ContainsValue(StudentsFindTask.Result.results[i].BusID))
                    {
                        MessageBox.Show("这就奇怪了，为啥校车列表里面没有这个学生的记录？？" +
                            $"\r\n 学生姓名：{ StudentsFindTask.Result.results[i].StudentName }" +
                            $" 奇怪的ID：{ StudentsFindTask.Result.results[i].BusID }");
                        StudentData.Rows[i].Cells[2].Value = "";
                    }
                    else
                    {
                        StudentData.Rows[i].Cells[2].Value = BusDataPair.ElementAt(BusDataPair.Values.ToList().IndexOf(StudentsFindTask.Result.results[i].BusID)).Key;
                    }
                }
            }
            ExDiscription.Text = $"成功加载了 { StudentsFindTask.Result.results.Count} 条数据";
            StudentData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        private void ExcelOperationWindow_Shown(object sender, EventArgs e)
        {
            schoolBusObjectBindingSource.Clear();
            ClassYear.SelectedIndex = 0;
            ClassPartOS.SelectedIndex = 0;
            ClassNum.SelectedIndex = 0;
            BmobQuery query = new BmobQuery();
            Task<QueryCallbackData<SchoolBusObject>> task;
            task = _BmobWin.FindTaskAsync<SchoolBusObject>(WBConst.TABLE_N_Mgr_BusData, query);
            task.Wait();
            if (task.IsCompleted)
            {
                List<SchoolBusObject> list = task.Result.results;
                foreach (SchoolBusObject item in list)
                {
                    schoolBusObjectBindingSource.Add(item);
                    BusDataPair.Add(item.BusName, item.objectId);
                }
            }
            BusDirection.Items.AddRange(BusDataPair.Keys.ToArray());
            BusDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void StuPartOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassYear.Items.Clear();
            switch (ClassPartOS.Text)
            {
                case "小学部":
                    ClassYear.Items.AddRange(new string[] { "一年级", "二年级", "三年级", "四年级", "五年级", "六年级" });
                    break;
                case "初中部":
                    ClassYear.Items.AddRange(new string[] { "初一", "初二", "初三" });
                    break;
                case "普通高中部":
                case "中加高中部":
                    ClassYear.Items.AddRange(new string[] { "高一", "高二", "高三" });
                    break;
                case "剑桥高中部":
                    ClassYear.Items.AddRange(new string[] { "Year 10", "Year 11", "Year 12", "Year 13" });
                    break;
                default:
                    ClassYear.Items.Add("请选择学部");
                    break;
            }
            ClassYear.SelectedIndex = 0;
        }

        public void onExcelFilePorcFinished(ExcelProcessEventArgs e)
        {

        }


        private void SureAndUpload(object sender, EventArgs e)
        {
            statusPanel.Visible = true;
            for (int index = 0; index < StudentData.Rows.Count - 1; index++)
            {
                statusLabel.Text = $"正在检测数据完整性......第{index}项，共{StudentData.Rows.Count - 2}项";
                Application.DoEvents();
                DataGridViewRow StuRow = StudentData.Rows[index];
                StuRow.DefaultCellStyle.BackColor = Color.White;
                StuRow.DefaultCellStyle.ForeColor = Color.Black;
                if (string.IsNullOrEmpty((string)StuRow.Cells[2].Value) &&
                     string.IsNullOrEmpty((string)StuRow.Cells[3].Value))
                {
                    MessageBox.Show("这一行：" + StuRow.Cells[1].Value.ToString() + "还没有填写完整！");
                    return;
                }
            }

            statusLabel.Text = $"正在确认上传";
            Application.DoEvents();
            switch (MessageBox.Show("上传会改写已经存在的项，是否继续？", "提示", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                default:
                    statusLabel.Text = $"上传数据已取消！";
                    Thread.Sleep(1000);
                    statusPanel.Visible = false;
                    return;
                    break;
            }
            foreach (DataGridViewRow StuRow in StudentData.Rows)
            {
                statusLabel.Text = $"正在处理校车ID";
                Application.DoEvents();
                //Combo Box is valueD, use the 2nd cell
                if (!string.IsNullOrEmpty((string)StuRow.Cells[2].Value))
                {
                    StuRow.Cells[3].Value = BusDataPair[(string)StuRow.Cells[2].Value];
                }
                else
                {
                    //Nothing to do
                }
            }
            statusLabel.Text = $"分配数据空间....";
            Application.DoEvents();

            StudentDataObject StudentObj = new StudentDataObject();
            StudentObj.CSChecked = false;
            StudentObj.LSChecked = false;
            StudentObj.AHChecked = false;
            this.Enabled = false;
            statusLabel.Text = $"开始上传....";
            this.SureAndUploadBtn.Text = "上传中...";
            Application.DoEvents();
            List<string> ErrDetail = new List<string>();
            for (int RowNum = 0; RowNum < (StudentData.RowCount - 1); RowNum++)
            {
                StudentObj.StudentName = (string)StudentData.Rows[RowNum].Cells[1].Value;
                StudentObj.BusID = (string)StudentData.Rows[RowNum].Cells[3].Value;
                StudentObj.ClassID = CurrentClass.objectId;

                statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项。";
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
                            statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项，完成！";
                            Application.DoEvents();
                            LogWritter.DebugMessage(CreateTask.Result.ToString());
                            StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.Green;
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项，出错！";
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
                            statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项，完成！";
                            LogWritter.DebugMessage(UpdateTask.Result.ToString());
                            StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.LawnGreen;
                            Application.DoEvents();
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项，出错！";
                        StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.Red;
                        StudentData.Rows[RowNum].DefaultCellStyle.ForeColor = Color.White;
                        LogWritter.ErrorMessage(ex.InnerException.Message);
                        ErrDetail.Add("\t" + StudentObj.StudentName + " : " + ex.InnerException.Message + ";" + "\r\n");
                    }
                }
            }
            statusLabel.Text = $"上传操作完成，正在处理后续工作。";
            Application.DoEvents();
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
            statusPanel.Visible = false;
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
                    task = _BmobWin.DeleteTaskAsync(WBConst.TABLE_N_Mgr_StuData, (string)StudentData.SelectedCells[0].OwningRow.Cells[0].Value);
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
