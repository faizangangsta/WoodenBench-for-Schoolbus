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

using static WBPlatform.DesktopClient.StaticClasses.GlobalFunc;

namespace WBPlatform.DesktopClient.Views
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
                DBQuery query = new DBQuery();
                query.WhereEqualTo("TeacherObjectID", CurrentUser.objectId);
                DatabaseOperationResult resultX = Database.DBOperations.QueryMultipleData<SchoolBusObject>(query, out List<SchoolBusObject> result);

                if (resultX == DatabaseOperationResult.NO_RESULTS) MessageBox.Show("�Ҳ����κ�������У��");
                else if (resultX == DatabaseOperationResult.ONE_RESULT) busObject = result[0];
                else if (resultX == DatabaseOperationResult.MORE_RESULTS)
                {
                    MessageBox.Show("�ҵ��˶������󶨵�У��(�ⲻ���ܡ���)��Ŀǰֻ����ʾ���е�һ��");
                    busObject = result[0];
                }

                myID.Text = busObject.objectId;
                myDirection.Text = busObject.BusName;
                LeavingChecked.Text = busObject.LSChecked.ToString();
                ExpNumber.Text = "��δ����";
                BackNumber.Text = "��δ����";
                ExDescription.Text = "�������";
                Application.DoEvents();
                StudentDataGrid.AutoResizeColumns();
            }
            else if (CurrentUser.UserGroup.IsAdmin)
                MessageBox.Show("����Ա�û��뵽����ҳ����в�ѯ���޸ļ�¼", "����Ա֪ͨ", MessageBoxButtons.OK);
            else
            {
                MessageBox.Show("�㲻��У����ʦ��ֻ��У����ʦ�͹���Ա�ܱ༭����", "ֻ��ģʽ", MessageBoxButtons.OK);
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
            DatabaseOperationResult resultX = DBOperations.QueryMultipleData<StudentObject>(query, out List<StudentObject> result);
            if (resultX < 0)
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
                if (Database.DBOperations.UpdateData(item) == 0)
                {
                    ExDescription.Text = "�ɹ������" + item.StudentName;
                }
                else
                {
                    ExDescription.Text = "�������⣺" + item.StudentName;
                }
                Application.DoEvents();
            }
        }
    }
}