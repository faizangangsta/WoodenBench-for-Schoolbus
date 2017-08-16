using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WoodenBench.StaClasses;
using WoodenBench.TableObject;
using WoodenBench.Users;
using WoodenBench.Views;
using static WoodenBench.StaClasses.GlobalFunc;
using static WoodenBench.Users.UserActivity;

namespace WoodenBench.Views
{
    public partial class MainWindow : DevComponents.DotNetBar.Metro.MetroForm
    {
        int Hiint = 0;
        private static MainWindow defaultInstance;
        string NotificationTitle, NotificationContent;
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public MainWindow() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        public static MainWindow Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new MainWindow();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            if ((int)CurrentUser.UserGroup == 0 || (int)CurrentUser.UserGroup == 2)
            {
                AdminManage.Visible = true;
                AdminManage.Enabled = true;
            }
            NotificationWorker.RunWorkerAsync();
            Text = Text + " - " + CurrentUser.RealName;
            TUsrWCIDL.Text = CurrentUser.WeChatID;
            BUsrNameL.Text = TUsrNameL.Text = CurrentUser.UserName;
            BUsrIDL.Text = TUsrIDL.Text = CurrentUser.objectId;
            BUsrGroupL.Text = TUsrGroupL.Text = ((UserGroupEnum)CurrentUser.UserGroup).ToString();
            BUsrRNameL.Text = TUsrRNameL.Text = CurrentUser.RealName;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplicationExit();
        }

        private void GetNotificationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var Resulta = _BmobWin.GetTaskAsync<NotificationObject>(Consts.TABLE_N_Gen_Notifi, Consts.OBJ_ID_Notifi);
            JObject JsonNowUsrResult = JObject.Parse(JsonAdapter.JSON.ToDebugJsonString(Resulta.Result));
            NotificationTitle = JsonNowUsrResult["NTitle"].ToString();
            string NotSplitedContent = JsonNowUsrResult["DataContent"].ToString();
            NotificationContent = NotSplitedContent.Replace("/NL", Environment.NewLine);
        }

        private void GetNotificationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            NotificationContentLabel.Text = NotificationContent;
            NotificationTitleLabel.Text = NotificationTitle;
        }

        private void 更改用户信息DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChangeUserDataWindow().ShowDialog();
        }

        private void 退出用户EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show($"确定要退出当前账户 {CurrentUser.UserName} 吗？", "询问", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    LogOut();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void StrangeBar(object sender, EventArgs e)
        {
            ///Something Strange??
            Hiint++;
            ///There isn't any Easter Eggs..
            if (Hiint == 5) Mysterious.ShowMys();
        }

        private void MainWindow_Click(object sender, EventArgs e)
        {
            Hiint = 0;
        }


        private void 管理员页面MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MGRLogin.Default.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Views.ExcelOperationWindow().ShowDialog(this);
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsrLoginWindow.Default.Show();
        }
    }
}
