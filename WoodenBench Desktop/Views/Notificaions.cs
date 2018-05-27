using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Linq;
using DevComponents.DotNetBar.Metro;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WinClient.Users;

using static WBPlatform.WinClient.StaticClasses.GlobalFunc;

namespace WBPlatform.WinClient.Views
{
    public partial class Notifications : MetroForm
    {
        private List<NotificationObject> NotificationLists { get; set; } = new List<NotificationObject>();
        public Notifications()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static Notifications defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public static Notifications Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new Notifications();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion

        private void BusesManager_Load(object sender, EventArgs e)
        {

        }

        private void BusesManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Default.Show();
        }

        private void loadMessage_Click(object sender, EventArgs e)
        {
            if (Database.QueryMultipleData(new DatabaseQuery(), out List<NotificationObject> list) >= 0)
            {
                listView1.Items.Clear();
                NotificationLists.Clear();
                foreach (NotificationObject item in list)
                {
                    NotificationLists.Add(item);
                    listView1.Items.Add(new ListViewItem(new string[] { item.Sender, item.createdAt, new string(item.Content.Take(20).ToArray()) + "...." }));
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                NotificationObject @object = NotificationLists[listView1.SelectedItems[0].Index];
                msgTitle.Text = @object.Title;
                msgTime.Text = @object.createdAt;
                msgType.Text = @object.Type.ToString();
                msgSendID.Text = @object.Sender;
                msgRecvID.Text = @object.GetStringRecivers();
                msgContent.Text = @object.Content;
            }
        }

        private void copyMessage_Click(object sender, EventArgs e)
        {
            string clip = $"信息标题：{msgTitle.Text} \r\n发送者：{msgSendID.Text} \r\n接收者：{msgRecvID.Text}\r\n发送时间：{msgTime.Text}\r\n消息内容：{msgContent.Text}";
            Clipboard.SetText(clip);
        }
    }
}