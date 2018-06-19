using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;

using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;

using WBPlatform.StaticClasses;
using WBPlatform.DesktopClient.DelegateClasses;
using WBPlatform.DesktopClient.Properties;
using WBPlatform.DesktopClient.StaticClasses;
using WBPlatform.DesktopClient.Users;

using static WBPlatform.DesktopClient.StaticClasses.GlobalFunc;

namespace WBPlatform.DesktopClient.Views
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
            ApplicationExit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CurrentUser.UserGroup.IsParent &&
                !CurrentUser.UserGroup.IsAdmin &&
                !CurrentUser.UserGroup.IsClassTeacher &&
                !CurrentUser.UserGroup.IsBusManager)
            {
                MessageBox.Show("С���Windows�ͻ����ݲ�֧�ּҳ�ʹ�ã���л����֧�֡�\r\n��ʹ��΢�Ź�����ڣ�", "��Ǹ");
                return;
            }
            userRole.Text = "";
            if (!CurrentUser.UserGroup.IsAdmin && !CurrentUser.UserGroup.IsClassTeacher)
                UploadStuDataTile.Enabled = false;
            if (!CurrentUser.UserGroup.IsAdmin && !CurrentUser.UserGroup.IsBusManager)
                MyStudentDataInfo.Enabled = false;
            MgrLoginTile.Enabled = CurrentUser.UserGroup.IsAdmin;
            labelX2.Text =
                "<div align=\"right\"><font size=\"+4\">" +
                CurrentUser.RealName +
                "</font><br/>" +
                CurrentUser.objectId +
                "</div>";
            if (CurrentUser.HeadImagePath != "#")
                FileIO.DownloadFile("https://res.lhy0403.top/WBUserHeadImg/" + CurrentUser.HeadImagePath, Environment.CurrentDirectory + "//Temp//" + GlobalFunc.CurrentUser.objectId + "-HImg");

            if (CurrentUser.UserGroup.IsAdmin) userRole.Text += "����Ա;";
            if (CurrentUser.UserGroup.IsClassTeacher) userRole.Text += "������;";
            if (CurrentUser.UserGroup.IsBusManager) userRole.Text += "У����ʦ;";
            if (CurrentUser.UserGroup.IsParent) userRole.Text += "�ҳ�;";

        }
        public void DnFinished(FileIOEventArgs e)
        {
            if (e.isSucceed)
            {
                try
                {
                    Image p = FileIO.BytesToImage(FileIO.ReadFileBytes(e.LocalFilePath));
                    if (pictureBox1.InvokeRequired) Invoke(new Action(delegate { pictureBox1.BackgroundImage = p; }));
                }
                catch (Exception Ex)
                {
                    e.ErrDescription = Ex.Message;
                    e.isSucceed = false;
                }
            }
            if (!e.isSucceed)
            {
                if (pictureBox1.InvokeRequired) Invoke(new Action(delegate { pictureBox1.BackgroundImage = Resources.DefaultUserImage; }));
                MessageBox.Show("���Ի�ȡ�û�ͷ��ʧ�ܣ�" + e.ErrDescription);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            mainPanel.Location = new Point((Width - mainPanel.Width) / 2 + 10,
                ((Height - userLbl.Height - 10) - mainPanel.Height) / 2 + userLbl.Height);
            userLbl.Location = new Point((Width - mainPanel.Width) / 2,
                ((Height - userLbl.Height - 16) - mainPanel.Height) / 2 + userLbl.Height - 80);
        }

        private void LogOutUsrTile(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ��Ҫע����", "ע��", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            StudentUploadWindow.Default.Show();
            Hide();
        }

        private void appSettingsTile_Click(object sender, EventArgs e)
        {

        }

        private void helpTile_Click(object sender, EventArgs e)
        {
            LogWritter.DebugMessage("Clicked the Help Button, now navigating to the help page");
            Process.Start("https://www.lhy0403.top/wb-help/");
        }

        private void MgrLoginTile_Click(object sender, EventArgs e)
        {
            MGRLoginWindow.Default.ShowDialog(this);
        }

        private void MyStudentData_Click(object sender, EventArgs e)
        {
            CheckMyStudents.Default.Show();
            Hide();
        }

        private void myAccount_Click(object sender, EventArgs e)
        {
            UserSettings.Default.ShowDialog();
        }

        private void NotificationCenter_Click(object sender, EventArgs e)
        {
            Notifications.Default.Show();
            Hide();
        }
    }
}
