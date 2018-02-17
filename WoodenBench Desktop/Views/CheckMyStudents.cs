using System;
using cn.bmob.response;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using static WoodenBench.StaticClasses.GlobalFunc;
using WoodenBench.StaticClasses;
using System.Threading.Tasks;
using WoodenBench.TableObject;
using cn.bmob.io;

namespace WoodenBench.Views
{
    public partial class CheckMyStudents : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CheckMyStudents()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static CheckMyStudents defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public static CheckMyStudents Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new CheckMyStudents();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion

        private void CheckMyStudents_Shown(object sender, EventArgs e)
        {
            if (!CurrentUser.IsBusTeacher &&
                CurrentUser.UserGroup != UserGroupEnum.管理组用户 &&
                CurrentUser.UserGroup != UserGroupEnum.高层管理)
            {
                MessageBox.Show("你不是校车老师，只有校车老师和管理员能编辑数据", "只读模式", MessageBoxButtons.OK);
                Text = Text + " - 只读模式";
            }
            else
            {
                Text = Text + " - 已经启用编辑";
            }

            if (CurrentUser.IsBusTeacher)
            {
                SchoolBusObject busObject = new SchoolBusObject();
                BmobQuery query = new BmobQuery();
                query.WhereEqualTo("TeacherObjectID", CurrentUser.objectId);
                Task<QueryCallbackData<SchoolBusObject>> task;
                task = _BmobWin.FindTaskAsync<SchoolBusObject>(Consts.TABLE_N_Mgr_BusData, query);
                task.Wait();
                if (task.Result.results.Count <= 0)
                {
                    MessageBox.Show("找不到任何你管理的校车");
                }
                else if (task.Result.results.Count == 1)
                {
                    busObject = task.Result.results[0];
                }
                else
                {
                    MessageBox.Show("找到了多个和你绑定的校车，目前只会显示其中第一项");
                    busObject = task.Result.results[0];
                }
                myID.Text = busObject.objectId;
                myDirection.Text = busObject.BusName;
                LeavingChecked.Text = busObject.LeavingChecked;
                BackChecked.Text = busObject.ComingChecked;
                ExpNumber.Text = "尚未加载";
                BackNumber.Text = "尚未加载";
                ExDescription.Text = "加载完成";
                Application.DoEvents();
                StudentDataGrid.AutoResizeColumns();
            }
            else
            {
                switch (CurrentUser.UserGroup)
                {
                    case UserGroupEnum.高层管理:

                        break;
                    case UserGroupEnum.管理组用户:

                        break;
                }
            }
        }

        private void CheckMyStudents_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Default.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void teacherBasicData_Enter(object sender, EventArgs e)
        {

        }

        private void LoadAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("加载全部数据可能需要一段时间，这将取决于你的网络速度", "长耗时任务提醒",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                BmobQuery query = new BmobQuery();
                query.WhereEqualTo("BusID", myID.Text);
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
                    ExpNumber.Text = list.Count.ToString();
                    LeaveNumber.Text = CountTicks(4).ToString();
                    LeavingChecked.Text = CountTicks(5).ToString();
                    BackNumber.Text = CountTicks(6).ToString();
                    BackChecked.Text = CountTicks(7).ToString();
                }
            }
            else
            {
                return;
            }
        }

        private void CheckMyStudents_Load(object sender, EventArgs e)
        {

        }

        private void StudentDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            LeaveNumber.Text = CountTicks(4).ToString();
            LeavingChecked.Text = CountTicks(5).ToString();
            BackNumber.Text = CountTicks(6).ToString();
            BackChecked.Text = CountTicks(7).ToString();
        }

        private int CountTicks(int ColNum)
        {
            int Val = 0;
            foreach (DataGridViewRow row in StudentDataGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells[ColNum].Value)) Val++;
            }
            return Val;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            foreach (StudentDataObject item in studentDataObjectBindingSource)
            {
                Task<UpdateCallbackData> task = _BmobWin.UpdateTaskAsync<StudentDataObject>(item);
                task.Wait();
                ExDescription.Text = "成功更新项：" + item.StudentName;
                Application.DoEvents();
            }
        }
    }
}