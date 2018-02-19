using cn.bmob.io;
using cn.bmob.response;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoodenBench.TableObject;
using WoodenBench.StaticClasses;
using static WoodenBench.StaticClasses.GlobalFunc;
using WoodenBench.Users;

namespace WoodenBench.Views
{
    public partial class BusesManager : MetroForm
    {
        public BusesManager()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static BusesManager defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public static BusesManager Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new BusesManager();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion

        private void BusesManager_Load(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            schoolBusObjectBindingSource.Clear();
            BmobQuery query = new BmobQuery();
            Task<QueryCallbackData<SchoolBusObject>> task;
            task = _BmobWin.FindTaskAsync<SchoolBusObject>(Consts.TABLE_N_Mgr_BusData, query);
            task.Wait();
            if (task.IsCompleted)
            {
                List<SchoolBusObject> result = task.Result.results;
                foreach (SchoolBusObject item in result)
                {
                    schoolBusObjectBindingSource.Add(item);
                }
            }
            msgLabel.Text = "成功加载数据";
        }

        private void BusesManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Default.Show();
        }

        private void 更新这条数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = busDataGrid.SelectedCells[0].OwningRow;
            if (Upload(row)) msgLabel.Text = "成功更新项目：" + row.Cells[1].Value.ToString();
        }

        private void 删除校车记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = busDataGrid.SelectedCells[0].OwningRow;

            if (row.Cells[0].Value == null) row.Cells[0].Value = "";
            if (row.Cells[1].Value == null) row.Cells[1].Value = "";
            string Name = row.Cells[1].Value.ToString();
            if (row.Cells[0].Value.ToString() == "")
            {
                try
                {
                    busDataGrid.Rows.Remove(row);
                    msgLabel.Text = "成功删除项目：" + Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    msgLabel.Text = "删除时出现问题：" + ex.Message;
                }
            }
            else
            {

                switch (MessageBox.Show("是否在服务器上删除此项？", "删除项目", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        Task<DeleteCallbackData> task;
                        task = _BmobWin.DeleteTaskAsync(Consts.TABLE_N_Mgr_BusData, row.Cells[0].Value.ToString());
                        task.Wait();
                        busDataGrid.Rows.Remove(row);
                        msgLabel.Text = "成功在服务器上删除项目：" + Name;
                        break;
                    case DialogResult.No:
                        busDataGrid.Rows.Remove(row);
                        msgLabel.Text = "成功删除项目：" + Name;
                        break;
                    default:
                        break;
                }
            }
        }

        private void UploadData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("上传所有数据，将会改写现有数据", "注意", MessageBoxButtons.OK);

            foreach (DataGridViewRow BusDataRow in busDataGrid.Rows)
            {
                if (string.IsNullOrEmpty((string)BusDataRow.Cells[2].Value))
                {
                    BusDataRow.Cells[3].Value = "";
                }
                else
                {
                    foreach (DataGridViewRow TeacherDataRow in teacherData.Rows)
                    {
                        if (!string.IsNullOrEmpty((string)TeacherDataRow.Cells[2].Value))
                        {
                            if (BusDataRow.Cells[2].Value.ToString() == TeacherDataRow.Cells[2].Value.ToString())
                            {
                                BusDataRow.Cells[3].Value = TeacherDataRow.Cells[0].Value.ToString();
                                Application.DoEvents();
                                break;
                            }
                        }
                    }
                }
            }

            Application.DoEvents();

            foreach (DataGridViewRow item in busDataGrid.Rows)
            {
                if (Upload(item)) msgLabel.Text = "成功更新项目：" + item.Cells[1].Value;
                Application.DoEvents();
            }
            msgLabel.Text = "成功更新所有项目";
        }
        private static bool Upload(DataGridViewRow row)
        {
            SchoolBusObject busObject = new SchoolBusObject();
            if (row.Cells[0].Value == null && row.Cells[1].Value == null) return false;
            if (row.Cells[0].Value == "" && row.Cells[1].Value == "") return false;
            busObject.BusName = (string)row.Cells[1].Value;
            busObject.TeacherName = (string)row.Cells[2].Value ?? "";
            busObject.TeacherID = (string)row.Cells[3].Value ?? "";
            busObject.LeavingChecked = (string)row.Cells[4].Value;
            busObject.ComingChecked = (string)row.Cells[5].Value;


            if (row.Cells[0].Value == null || row.Cells[0].Value.ToString() == "")
            {
                Task<CreateCallbackData> task = _BmobWin.CreateTaskAsync<SchoolBusObject>(busObject);
                task.Wait();
                return task.IsCompleted;
            }
            else
            {
                busObject.objectId = row.Cells[0].Value.ToString();
                Task<UpdateCallbackData> task = _BmobWin.UpdateTaskAsync<SchoolBusObject>(busObject);
                task.Wait();
                return task.IsCompleted;
            }
        }

        private void busDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BusesManager_Shown(object sender, EventArgs e)
        {
            Task<QueryCallbackData<AllUserObject>> task;
            BmobQuery query = new BmobQuery();
            query.WhereEqualTo("isBusTeacher", true);
            task = _BmobWin.FindTaskAsync<AllUserObject>(Consts.TABLE_N_Gen_UsrTable, query);
            task.Wait();
            if (task.IsCompleted)
            {
                foreach (AllUserObject item in task.Result.results)
                {
                    allUserObjectBindingSource.Add(item);
                }
            }
        }

        private void busDataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 2) busDataGrid.SelectedCells[0].OwningRow.Cells[3].Value = "";
        }
    }
}