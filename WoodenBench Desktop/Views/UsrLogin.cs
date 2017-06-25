
using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WoodenBench_Desktop.staClass;
using WoodenBench_Desktop.TableObjects;

namespace WoodenBench_Desktop
{
    public partial class UsrLoginForm : Form
    {
        private void button1_Click(object sender, EventArgs e) => Application.Exit();
        private void UserNameTxt_TextChanged(object sender, EventArgs e)
        {
            LoginResult.Text = "";
            PswdTxt.Clear();
        }
        private void PswdTxt_TextChanged(object sender, EventArgs e) => LoginResult.Text = "";
        public UsrLoginForm() : base()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        private static UsrLoginForm defaultInstance;
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static UsrLoginForm Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new UsrLoginForm();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        private void DoLogin(object sender, EventArgs e)
        {

            NewUserLabel.Visible = false;
            LoginResult.Text = "";
            DoLoginBtn.Enabled = false;
            CancelBtn.Enabled = false;
            DoLoginBtn.Text = "登陆中...";
            Application.DoEvents();
            UserActivity.Login(UserNameTxt.Text, PswdTxt.Text);
            (new MainWindow()).Show();
            Hide();
            DoLoginBtn.Enabled = true;
            CancelBtn.Enabled = true;
            DoLoginBtn.Text = "登陆(&L)";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CreateUser().ShowDialog();
        }
        
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void UsrLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}