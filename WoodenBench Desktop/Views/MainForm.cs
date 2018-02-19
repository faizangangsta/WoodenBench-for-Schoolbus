using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Security;
using System.Text;
using System.Windows.Forms;
using WoodenBench.DelegateClasses;
using WoodenBench.Properties;
using WoodenBench.StaticClasses;
using WoodenBench.Users;
using static WoodenBench.StaticClasses.GlobalFunc;


namespace WoodenBench.Views
{
    public partial class MainForm : MetroForm
    {

        int intX = 0;
        public MainForm()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static MainForm defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static MainForm Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new MainForm();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion                

        private void MainForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            GlobalFunc.ApplicationExit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelX2.Text = "<div align=\"right\"><font size=\"+4\">"
                + GlobalFunc.CurrentUser.RealName + "</font><br/>" + GlobalFunc.CurrentUser.objectId + "</div>";
            FileIO.DownloadFile("https://res.lhy0403.top/WBUserHeadImg/" + GlobalFunc.CurrentUser.HeadImgData, Environment.CurrentDirectory + "//Temp//" + GlobalFunc.CurrentUser.objectId + "-HImg", DownloadType.SingleUserHeadImage);
        }
        public void DnFinished(FileIOEventArgs e)
        {
            if (e.ProcessStatus == ProcStatE.Completed)
            {
                if (e.DownloadType == DownloadType.SingleUserHeadImage)
                {
                    if (pictureBox1.InvokeRequired)
                    {
                        Invoke(new nullArgDelegate(delegate { pictureBox1.BackgroundImage = FileIO.BytesToImage(FileIO.ReadFileBytes(e.LocalFilePath)); }));
                    }
                }
            }
            else if (e.ProcessStatus == ProcStatE.FailedWithErr)
            {
                if (pictureBox1.InvokeRequired)
                {
                    Invoke(new nullArgDelegate(delegate { pictureBox1.BackgroundImage = Resources.User1; }));
                }
                //MessageBox.Show("尝试获取用户头像失败，请联系网络信息中心。");
            }
        }

        protected override void OnResize(EventArgs e)
        {
            itemPanel1.Location = new Point((Width - itemPanel1.Width) / 2 + 10, ((Height - labelX1.Height - 16) - itemPanel1.Height) / 2 + labelX1.Height + 16);
            labelX1.Location = new Point((Width - itemPanel1.Width) / 2, ((Height - labelX1.Height - 16) - itemPanel1.Height) / 2 + labelX1.Height - 80);
            base.OnResize(e);
        }

        private void LogOutUsrTile(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要注销吗？", "注销", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UserActivity.LogOut();
                UsrLoginWindow.Default.Show();
                Hide();
            }
        }

        private void labelX2_Click(object sender, EventArgs e)
        {
            intX++;
            if (intX == 25) Mysterious.ShowMys();
        }

        private void UploadStuDataTile_Click(object sender, EventArgs e)
        {
            ExcelOperationWindow.Default.Show();
            Hide();
        }

        private void appSettingsTile_Click(object sender, EventArgs e)
        {

        }

        private void helpTile_Click(object sender, EventArgs e)
        {
            LogWritter.DebugMessage("Clicked the Help Button, now navigating to the help page");
            Process.Start("explorer.exe", " https://schoolbus.lhy0403.top/Help");
        }

        private void MgrLoginTile_Click(object sender, EventArgs e)
        {
            MGRLoginWindow.Default.ShowDialog(this);
        }

        private void newClientTile_Click(object sender, EventArgs e)
        {
            BusesManager.Default.Show();
            Hide();
        }

        private void MyStudentData_Click(object sender, EventArgs e)
        {
            CheckMyStudents.Default.Show();
            Hide();
        }
    }
}
