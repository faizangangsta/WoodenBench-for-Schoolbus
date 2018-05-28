using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DevComponents.DotNetBar.Metro;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WinClient.Users;
using WBPlatform.WinClient.Views;

using static WBPlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBPlatform.WinClient.Views
{
    public partial class ManagementWindow : MetroForm
    {
        public ManagementWindow() : base()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.BackColor = Color.White;
        }

        private void Btn_UpdateWinNoti_Click(object sender, EventArgs e)
        {

        }

        private void Btn_UpdateWebNoti_Click(object sender, EventArgs e)
        {

        }

        private void allUserObjectBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            bool IsGoing = true;
            int CurrNum = 0;
            allUserObjectBindingSource.Clear();
            DatabaseQuery query = new DatabaseQuery();


            if (ContentTxBox.Text.ToLower() == "true")
            {
                query.WhereEqualTo(ColNameTx.Text, true);

            }
            else if (ContentTxBox.Text.ToLower() == "false")
            {
                query.WhereEqualTo(ColNameTx.Text, false);
            }
            else
            {
                query.WhereEqualTo(ColNameTx.Text, ContentTxBox.Text != "" ? ContentTxBox.Text : null);
            }
            //query.Skip(CurrNum);
            if (Database.QueryMultipleData<UserObject>(query, out List<UserObject> result) < 0)
            {
                MessageBox.Show("Failed getting data");
                return;
            }
            else
            {
                foreach (UserObject item in result)
                {
                    allUserObjectBindingSource.Add(item);
                }
            }
        }

        private void radialMenu2_ItemClick(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
