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
using System.Windows;
using System.Windows.Forms;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

using static WBPlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBPlatform.WinClient.Views
{
    public partial class StudentUploadWindow : MetroForm
    {
        string ExcelFilePath;
        ClassObject CurrentClass;
        bool IsReadOnly = true;
        Dictionary<string, string> BusDataPair = new Dictionary<string, string>();

        public StudentUploadWindow()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static StudentUploadWindow defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public static StudentUploadWindow Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new StudentUploadWindow();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion

        private void ExcelOperationWindow_Load(object sender, EventArgs e)
        {
            if (!CurrentUser.UserGroup.IsClassTeacher)
            {
                MessageBox.Show("你不是班主任，不能执行这项操作", "操作有问题", MessageBoxButtons.OK);
                Close();
            }
            StudentData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            ExDiscription.Items.Clear();
        }

        private void DoLog(string log)
        {
            bool scroll = false;
            if (ExDiscription.TopIndex == ExDiscription.Items.Count - ExDiscription.Height / ExDiscription.ItemHeight) scroll = true;
            ExDiscription.Items.Add(log);
            if (scroll) ExDiscription.TopIndex = ExDiscription.Items.Count - (ExDiscription.Height / ExDiscription.ItemHeight);
        }

        private void OpenExcel(object sender, EventArgs e)
        {
            if (CurrentClass == null)
            {
                MessageBox.Show("请先加载一个班级~", "操作不对……");
                return;
            }
            statusPanel.Visible = true;
            statusLabel.Text = "正在打开Excel....";
            DoLog(statusLabel.Text);
            Application.DoEvents();
            ExcelApplication _Excel = new ExcelApplication();
            statusLabel.Text = "请选择Excel文档";
            DoLog(statusLabel.Text);
            Application.DoEvents();
            OpenExcelFileDialog.FileName = "";
            OpenExcelFileDialog.ShowDialog();
            if (OpenExcelFileDialog.FileName == "")
            {
                statusPanel.Visible = false;
                return;
            }
            ExcelFilePath = OpenExcelFileDialog.FileName;
            ExcelFilePathTxt.Text = ExcelFilePath;

            //Excel.OpenExcelApp();

            statusLabel.Text = "正在读取Excel文件，请稍等......";
            DoLog(statusLabel.Text);
            Application.DoEvents();
            if (!_Excel.OpenExcelFile(ExcelFilePath, true, false))
            {
                MessageBox.Show("打开Excel文件失败！请查看Log文件！");
                return;
            }

            statusLabel.Text = "获取文件长度......";
            DoLog(statusLabel.Text);
            Application.DoEvents();
            int LastLine = _Excel.LastLine(1, 100);
            if (LastLine == -1)
            {
                MessageBox.Show("读取Excel文件出现问题：无法获取文件长度");
                return;
            }
            string StuName, StuDirection;
            for (int LineNum = 4; LineNum <= (LastLine - 1); LineNum++)
            {
                bool IsUpdate = false;
                StuName = _Excel.ReadContent<string>(LineNum, 1);
                StuDirection = _Excel.ReadContent<string>(LineNum, 2);
                foreach (DataGridViewRow item in StudentData.Rows)
                {
                    statusLabel.Text = $"更新现有数据:{StuName}";
                    DoLog(statusLabel.Text);
                    Application.DoEvents();

                    List<StudentObject> students = ((List<StudentObject>)studentDataBindSourc.List).TakeWhile(new Func<StudentObject, int, bool>((stu, num) => { return stu.StudentName == StuName; })).ToList();
                    //UNKNOWN CHANGE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    if (string.IsNullOrEmpty((string)item.Cells[1].Value) && (string)item.Cells[1].Value == StuName)
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
                    DoLog(statusLabel.Text);
                    Application.DoEvents();
                    StudentObject student = new StudentObject();
                    student.StudentName = StuName;
                    student.ClassID = CurrentClass.objectId;
                    student.BusID = BusDataPair[StuDirection];
                    studentDataBindSourc.Add(student);
                }
            }
            statusLabel.Text = $"正在释放Excel......";
            DoLog(statusLabel.Text);
            Application.DoEvents();
            GC.Collect();
            _Excel.QuitExcel();
            statusPanel.Visible = false;
        }

        private void ExcelOperationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Default.Show();
        }

        private void LoadExistStudents_Click(object sender, EventArgs e)
        {
            studentDataBindSourc.Clear();
            DatabaseQuery ClassQuery = new DatabaseQuery();

            ClassQuery.WhereEqualTo("objectId", CurrentUser.ClassList[0]);
            DatabaseQueryResult resultCode = Database.QueryMultipleData<ClassObject>(ClassQuery, out List<ClassObject> result);
            if (resultCode == DatabaseQueryResult.NO_RESULTS)
            {
                MessageBox.Show("没找到你想要的班级，这，，不应该吧。", "很失望？");
                return;
            }
            CurrentClass = result[0];
            ClsID.Text = CurrentClass.objectId;
            ClsDpt.Text = CurrentClass.CDepartment;
            ClsGrade.Text = CurrentClass.CGrade;
            ClsNum.Text = CurrentClass.CNumber;
            ClsTID.Text = CurrentClass.TeacherID;
            if (string.IsNullOrEmpty(CurrentClass.TeacherID))
            {
                MessageBox.Show("嗯，找到了匹配的班级，但好像没有老师绑定这个班。" +
                    "\r\n" +
                    "~快去叫他使用小板凳吧。" +
                    "\r\n\r\n" +
                    "如果你是这个班的老师的话，先去\"设置\"页绑定一下你的班级！", "孤儿班级");
                ClsTName.Text = "";
                ClsTPhoneNum.Text = "";
            }
            else
            {
                DatabaseQuery TeacherDataQuery = new DatabaseQuery();
                TeacherDataQuery.WhereEqualTo("objectId", CurrentClass.TeacherID);
                if (Database.QueryMultipleData(TeacherDataQuery, out List<UserObject> teacherresult) <= 0)
                {
                    MessageBox.Show("这不应该，这个班级有老师管理，但是查不到老师的任何信息。", "班主任溜了？");
                    ClsTName.Text = "";
                    ClsTPhoneNum.Text = "";
                }
                else
                {
                    ClsTName.Text = teacherresult[0].RealName;
                    ClsTPhoneNum.Text = teacherresult[0].PhoneNumber;
                }
            }
            Application.DoEvents();

            //if (MessageBox.Show("找到了班级，是否继续列出班里坐校车的学生？", "要继续吗", MessageBoxButtons.YesNo) == DialogResult.No)
            //    return;
            DatabaseQuery StudentsQuery = new DatabaseQuery();
            StudentsQuery.WhereEqualTo("ClassID", CurrentClass.objectId);
            if (Database.QueryMultipleData(StudentsQuery, out List<StudentObject> results) == 0)
                MessageBox.Show("把数据库翻了个底朝天，还是没有这个班的学生", "学生去哪了？");
            else
            {
                for (int i = 0; i < results.Count; i++)
                {
                    studentDataBindSourc.Add(results[i]);
                    if (!BusDataPair.ContainsValue(results[i].BusID))
                    {
                        MessageBox.Show("这就奇怪了，为啥校车列表里面没有这个学生的记录？？" +
                            $"\r\n 学生姓名：{results[i].StudentName }" +
                            $" 奇怪的ID：{ results[i].BusID }");
                        StudentData.Rows[i].Cells[2].Value = "";
                    }
                    else
                    {
                        StudentData.Rows[i].Cells[2].Value = BusDataPair.ElementAt(BusDataPair.Values.ToList().IndexOf(results[i].BusID)).Key;
                    }
                }
            }
            DoLog($"成功加载了 {results.Count} 条数据");
            StudentData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        private void ExcelOperationWindow_Shown(object sender, EventArgs e)
        {
            schoolBusObjectBindingSource.Clear();
            DatabaseQuery query = new DatabaseQuery();
            if (Database.QueryMultipleData(query, out List<SchoolBusObject> list) <= 0)
            {
                MessageBox.Show("出现了一些错误");
            }
            else
            {
                foreach (SchoolBusObject item in list)
                {
                    schoolBusObjectBindingSource.Add(item);
                    BusDataPair.Add(item.BusName, item.objectId);
                }
                BusDirection.Items.AddRange(BusDataPair.Keys.ToArray());
                BusDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                LoadExistStudents_Click(sender, e);
            }
        }
        #region UseLess
        //private void StuPartOS_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ClassYear.Items.Clear();
        //    switch (ClassPartOS.Text)
        //    {
        //        case "小学部":
        //            ClassYear.Items.AddRange(new string[] { "一年级", "二年级", "三年级", "四年级", "五年级", "六年级" });
        //            break;
        //        case "初中部":
        //            ClassYear.Items.AddRange(new string[] { "初一", "初二", "初三" });
        //            break;
        //        case "普通高中部":
        //        case "中加高中部":
        //            ClassYear.Items.AddRange(new string[] { "高一", "高二", "高三" });
        //            break;
        //        case "剑桥高中部":
        //            ClassYear.Items.AddRange(new string[] { "Year 10", "Year 11", "Year 12", "Year 13" });
        //            break;
        //        default:
        //            ClassYear.Items.Add("请选择学部");
        //            break;
        //    }
        //    ClassYear.SelectedIndex = 0;
        //}
        #endregion

        private void SureAndUpload(object sender, EventArgs e)
        {
            statusPanel.Visible = true;
            for (int index = 0; index < StudentData.Rows.Count - 1; index++)
            {
                DoLog("正在校验数据完整性");
                statusLabel.Text = $"正在检测数据完整性......第{index}项，共{StudentData.Rows.Count - 2}项";
                DoLog("数据完整性校验完成");
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
            switch (MessageBox.Show("上传会改写已经存在的项，并且将重置学生签到信息，是否继续？", "提示", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                default:
                    statusLabel.Text = $"上传数据已取消！";
                    DoLog(statusLabel.Text);
                    Thread.Sleep(1000);
                    statusPanel.Visible = false;
                    return;
                    break;
            }
            foreach (DataGridViewRow StuRow in StudentData.Rows)
            {
                statusLabel.Text = $"正在处理校车ID";
                DoLog(statusLabel.Text);
                Application.DoEvents();
                //Combo Box is valueD, use the 2nd cell
                if (!string.IsNullOrEmpty((string)StuRow.Cells[2].Value))
                {
                    if (BusDataPair.ContainsKey((string)StuRow.Cells[2].Value))
                        StuRow.Cells[3].Value = BusDataPair[(string)StuRow.Cells[2].Value];
                    else
                    {
                        MessageBox.Show($"在数据库中找不到匹配的校车信息: {(string)StuRow.Cells[2].Value}");
                    }
                }
                else
                {
                    //Nothing to do for NOT GIVEN student Bus Direction
                }
            }
            statusLabel.Text = $"分配数据空间....";
            DoLog(statusLabel.Text);
            Application.DoEvents();

            StudentObject StudentObj = new StudentObject();
            StudentObj.CSChecked = false;
            StudentObj.LSChecked = false;
            StudentObj.AHChecked = false;
            this.Enabled = false;
            statusLabel.Text = $"开始上传....";
            DoLog(statusLabel.Text);
            this.SureAndUploadBtn.Text = "上传中...";
            Application.DoEvents();
            List<string> ErrDetail = new List<string>();
            for (int RowNum = 0; RowNum < (StudentData.RowCount - 1); RowNum++)
            {
                StudentObj.StudentName = (string)StudentData.Rows[RowNum].Cells[1].Value;
                StudentObj.BusID = (string)StudentData.Rows[RowNum].Cells[3].Value;
                StudentObj.ClassID = CurrentClass.objectId;

                statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项。";
                DoLog("学生姓名：" + StudentObj.StudentName);
                Application.DoEvents();
                //If Record is NOT in the Server Database, SHOWN AS NO  "OBJECT ID" GIVEN
                if (string.IsNullOrEmpty((string)StudentData.Rows[RowNum].Cells[0].Value))
                {
                    if (Database.CreateData(StudentObj, out string objectId) == 0)
                    {
                        statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项，完成！";
                        Application.DoEvents();
                        StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.Green;
                        continue;
                    }
                    else
                    {
                        statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项，出错！";
                        StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.Red;
                        StudentData.Rows[RowNum].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
                //Record is in the Database, only update needed
                else
                {
                    StudentObj.objectId = (string)StudentData.Rows[RowNum].Cells[0].Value;
                    if (Database.UpdateData(StudentObj) == 0)
                    {
                        statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项，完成！";
                        StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.LawnGreen;
                        Application.DoEvents();
                        continue;
                    }
                    else
                    {
                        statusLabel.Text = $"正在上传第{RowNum}项，共{StudentData.RowCount - 2}项，出错！";
                        StudentData.Rows[RowNum].DefaultCellStyle.BackColor = Color.Red;
                        StudentData.Rows[RowNum].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            statusLabel.Text = $"上传操作完成，正在处理后续工作。";
            Application.DoEvents();
            if (ErrDetail.Count == 0)
            {
                DoLog("成功完成操作！已经上传 " + (StudentData.RowCount - 1).ToString() + " 条数据");
                MessageBox.Show("所有项目已经成功上传！");
            }
            else
            {
                DoLog("上传部分失败！共 " + ErrDetail.Count.ToString() + " 条失败");
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

        private void radialMenu1_ItemClick(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(RadialMenuItem))
            {
                string Name = (string)StudentData.SelectedCells[0].OwningRow.Cells[1].Value;
                switch (((RadialMenuItem)sender).Text)
                {
                    case "编辑":
                        if (StudentData.SelectedCells.Count > 0)
                        {
                            DataGridViewCell cell = StudentData.SelectedCells[0];
                            StudentData.BeginEdit(true);
                        }
                        break;
                    case "彻底删除":
                        if (MessageBox.Show("确定要在服务器上删除这条数据吗？该操作不可撤销！", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (Database.DeleteData(WBConsts.TABLE_Mgr_StuData, (string)StudentData.SelectedCells[0].OwningRow.Cells[0].Value) == 0) ;
                            StudentData.Rows.Remove(StudentData.SelectedCells[0].OwningRow);
                            DoLog("成功在服务器上删除:" + Name);
                        }
                        else
                        {
                            DoLog("删除 " + Name + " 时出现问题");
                        }
                        break;
                    case "移除":
                        StudentData.Rows.Remove(StudentData.SelectedCells[0].OwningRow);
                        DoLog("成功删除:" + Name);
                        break;
                    case "重输":
                        foreach (DataGridViewCell item in StudentData.SelectedCells)
                        {
                            if (item.OwningColumn.ReadOnly)
                            {

                            }
                            else
                            {
                                item.Value = null;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void StudentData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex >= 0)
            {
                StudentData.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                Point p = PointToClient(MousePosition);
                p.X = p.X + 70;
                p.Y = p.Y + 20;
                radialMenu1.Location = p;
                radialMenu1.IsOpen = true;
                radialMenu1.Visible = true;
            }
            else
            {
                radialMenu1.IsOpen = false;
                radialMenu1.Visible = false;
            }
        }

        private void radialMenu1_MenuClosed(object sender, EventArgs e)
        {
            radialMenu1.Visible = false;
        }
    }
}
