using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cn.bmob.io;
using cn.bmob.response;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;

using static WBServicePlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBServicePlatform.WinClient.Views
{
    public partial class CheckMyStudents : MetroForm
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
            if (CurrentUser.UserGroup.IsBusManager)
            {                
                SchoolBusObject busObject = new SchoolBusObject();
                BmobQuery query = new BmobQuery();
                query.WhereEqualTo("TeacherObjectID", CurrentUser.objectId);
                var task = _BmobWin.FindTaskAsync<SchoolBusObject>(WBConsts.TABLE_N_Mgr_BusData, query);
                task.Wait();
                if (task.Result.results.Count <= 0)
                    MessageBox.Show("找不到任何你管理的校车");
                else if (task.Result.results.Count == 1)
                    busObject = task.Result.results[0];
                else
                {
                    MessageBox.Show("找到了多个和你绑定的校车(这不可能……)，目前只会显示其中第一项");
                    busObject = task.Result.results[0];
                }
                myID.Text = busObject.objectId;
                myDirection.Text = busObject.BusName;
                LeavingChecked.Text = busObject.LSChecked.ToString();
                ExpNumber.Text = "尚未加载";
                BackNumber.Text = "尚未加载";
                ExDescription.Text = "加载完成";
                Application.DoEvents();
                StudentDataGrid.AutoResizeColumns();
            }
            else if (CurrentUser.UserGroup.IsAdmin)
                MessageBox.Show("管理员用户请到管理页面进行查询和修改记录", "管理员通知", MessageBoxButtons.OK);
            else
            {
                MessageBox.Show("你不是校车老师，只有校车老师和管理员能编辑数据", "只读模式", MessageBoxButtons.OK);
                Close();
            }
        }

        private void CheckMyStudents_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Default.Show();
        }


        private void LoadAll_Click(object sender, EventArgs e)
        {
            studentDataObjectBindingSource.Clear();
            BmobQuery query = new BmobQuery();
            query.WhereEqualTo("BusID", myID.Text);
            var task = _BmobWin.FindTaskAsync<StudentObject>(WBConsts.TABLE_N_Mgr_StuData, query);
            task.Wait();
            if (task.IsCompleted)
            {
                List<StudentObject> list = task.Result.results;
                foreach (StudentObject item in list)
                {
                    studentDataObjectBindingSource.Add(item);
                }
                ExpNumber.Text = list.Count.ToString();
                LeaveNumber.Text = CountTicks(4).ToString();
                LeavingChecked.Text = CountTicks(5).ToString();
                BackNumber.Text = CountTicks(6).ToString();
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
            foreach (StudentObject item in studentDataObjectBindingSource)
            {
                Task<UpdateCallbackData> task = _BmobWin.UpdateTaskAsync<StudentObject>(item);
                task.Wait();
                ExDescription.Text = "成功更新项：" + item.StudentName;
                Application.DoEvents();
            }
        }
    }
}