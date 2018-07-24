using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevComponents.DotNetBar.Metro;
using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.DesktopClient.Users;

using static WBPlatform.DesktopClient.StaticClasses.GlobalFunctions;

namespace WBPlatform.DesktopClient.Views
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
            DBQuery query = new DBQuery();
            if (DataBaseOperation.QueryMultipleData(query, out List<SchoolBusObject> list) >= 0)
            {
                foreach (SchoolBusObject item in list)
                {
                    schoolBusObjectBindingSource.Add(item);
                }
            }
            msgLabel.Text = "�ɹ���������";
        }

        private void BusesManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Default.Show();
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = busDataGrid.SelectedCells[0].OwningRow;
            if (Upload(row)) msgLabel.Text = "�ɹ�������Ŀ��" + row.Cells[1].Value.ToString();
        }

        private void ɾ��У����¼ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    msgLabel.Text = "�ɹ�ɾ����Ŀ��" + Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    msgLabel.Text = "ɾ��ʱ�������⣺" + ex.Message;
                }
            }
            else
            {

                switch (MessageBox.Show("�Ƿ��ڷ�������ɾ�����", "ɾ����Ŀ", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        if (DataBaseOperation.DeleteData(WBConsts.TABLE_Mgr_BusData, row.Cells[0].Value.ToString()) == 0)
                        {
                            busDataGrid.Rows.Remove(row);
                            msgLabel.Text = "�ɹ��ڷ�������ɾ����Ŀ��" + Name;
                        }
                        else
                        {
                            msgLabel.Text = "ɾ����Ŀ��" + Name + " ʱ�������⡣";
                        }
                        break;
                    case DialogResult.No:
                        busDataGrid.Rows.Remove(row);
                        msgLabel.Text = "�ɹ�ɾ����Ŀ��" + Name;
                        break;
                    default:
                        break;
                }
            }
        }

        private void UploadData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�ϴ��������ݣ������д��������", "ע��", MessageBoxButtons.OK);

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
                if (Upload(item)) msgLabel.Text = "�ɹ�������Ŀ��" + item.Cells[1].Value;
                Application.DoEvents();
            }
            msgLabel.Text = "�ɹ�����������Ŀ";
        }

        private static bool Upload(DataGridViewRow row)
        {
            SchoolBusObject busObject = new SchoolBusObject();
            if (row.Cells[0].Value == null && row.Cells[1].Value == null) return false;
            if (row.Cells[0].Value == "" && row.Cells[1].Value == "") return false;
            busObject.BusName = (string)row.Cells[1].Value;
            busObject.TeacherID = (string)row.Cells[3].Value ?? "";
            busObject.LSChecked = (bool)row.Cells[4].Value;
            busObject.AHChecked = (bool)row.Cells[5].Value;
            busObject.CSChecked = (bool)row.Cells[6].Value;


            if (row.Cells[0].Value == null || row.Cells[0].Value.ToString() == "")
            {
                return DataBaseOperation.CreateData(ref busObject) ==  DBQueryStatus.ONE_RESULT;
            }
            else
            {
                busObject.ObjectId = row.Cells[0].Value.ToString();
                return DataBaseOperation.UpdateData(busObject) == 0;
            }
        }

        private void busDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BusesManager_Shown(object sender, EventArgs e)
        {
            DBQuery query = new DBQuery();
            query.WhereEqualTo("isBusTeacher", true);
            if (DataBaseOperation.QueryMultipleData(query, out List<UserObject> list) >= 0)
            {
                foreach (UserObject item in list)
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