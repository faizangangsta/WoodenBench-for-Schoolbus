using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DevComponents.DotNetBar.Metro;

using WBServicePlatform.Databases;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WinClient.Users;
using WBServicePlatform.WinClient.Views;

using static WBServicePlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBServicePlatform.WinClient.Views
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
                query.WhereContainedIn<bool>(ColNameTx.Text, true);

            }
            else if (ContentTxBox.Text.ToLower() == "false")
            {
                query.WhereContainedIn<bool>(ColNameTx.Text, false);
            }
            else
            {
                query.WhereContainedIn<string>(ColNameTx.Text, ContentTxBox.Text != "" ? ContentTxBox.Text : null);
            }
            //query.Skip(CurrNum);
            if (Database.QueryData<UserObject>(query, out List<UserObject> result) < 0)
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
