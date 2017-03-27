using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench_Desktop.Controls;

namespace WoodenBench_Desktop.Views
{
	public partial class MainWindow : Form
	{
		public UserController UsrCtrl;
		public MainWindow(UserController ValController)
		{
			UsrCtrl = ValController;
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			BtomNowUsrName.Text = UsrCtrl.UserName;
			BtomNowUsrID.Text = UsrCtrl.UserID;
			BtomNowUsrLoginTime.Text = UsrCtrl.LoginTime;
			BtomNowUserAct.Text = UsrCtrl.UserActAs.ToString();
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
