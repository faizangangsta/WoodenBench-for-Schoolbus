using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

using static WBPlatform.DesktopClient.StaticClasses.GlobalFunctions;

namespace WBPlatform.DesktopClient.Views
{
    public partial class BusCheckForm : MetroForm
    {
        public BusCheckForm()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static BusCheckForm defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public static BusCheckForm Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new BusCheckForm();
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
                DBQueryStatus resultX = DataBaseOperation.QueryMultipleData<SchoolBusObject>(new DBQuery().WhereEqualTo("TeacherObjectID", CurrentUser.objectId), out List<SchoolBusObject> result);

                switch (resultX)
                {
                    case DBQueryStatus.NO_RESULTS:
                        MessageBox.Show("没有找到你管理的校车");
                        return;
                    case DBQueryStatus.ONE_RESULT:
                        break;
                    case DBQueryStatus.MORE_RESULTS:
                        MessageBox.Show("找到了多个和你绑定的校车(这不可能……)，目前只会显示其中第一项");
                        break;
                    default: { MessageBox.Show("出现内部错误：" + resultX.ToString()); return; }
                }
                busObject = result[0];
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
            DBQuery query = new DBQuery();
            query.WhereEqualTo("BusID", myID.Text);
            DBQueryStatus resultX = DataBaseOperation.QueryMultipleData<StudentObject>(query, out List<StudentObject> result);
            if (resultX >= 0)
            {
                foreach (StudentObject item in result)
                {
                    studentDataObjectBindingSource.Add(item);
                }
                ExpNumber.Text = result.Count.ToString();
                LeaveNumber.Text = CountTicks(4).ToString();
                LeavingChecked.Text = CountTicks(5).ToString();
                BackNumber.Text = CountTicks(6).ToString();
            }
            StudentDataGrid.AutoResizeColumns();
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
                if (Database.DataBaseOperation.UpdateData(item) == DBQueryStatus.ONE_RESULT)
                {
                    ExDescription.Text = "成功更新项：" + item.StudentName;
                }
                else
                {
                    ExDescription.Text = "出现问题：" + item.StudentName;
                }
                Application.DoEvents();
            }
        }
    }
}