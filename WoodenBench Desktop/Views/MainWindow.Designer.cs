namespace WoodenBench_Desktop.Views
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.BtomStaLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomNowUsrName = new System.Windows.Forms.ToolStripStatusLabel();
			this.Btom = new System.Windows.Forms.Timer(this.components);
			this.BtomStaLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomNowUsrID = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomStaLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomNowUserAct = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomStaLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomNowUsrLoginTime = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.关于ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(828, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 文件ToolStripMenuItem
			// 
			this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem});
			this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
			this.文件ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.文件ToolStripMenuItem.Text = "文件(&F)";
			// 
			// 退出EToolStripMenuItem
			// 
			this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
			this.退出EToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.退出EToolStripMenuItem.Text = "退出(&E)";
			this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
			// 
			// 关于ToolStripMenuItem
			// 
			this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			this.关于ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.关于ToolStripMenuItem.Text = "关于(&A)";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(12, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(165, 109);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtomStaLabel1,
            this.BtomNowUsrName,
            this.BtomStaLabel2,
            this.BtomNowUsrID,
            this.BtomStaLabel3,
            this.BtomNowUserAct,
            this.BtomStaLabel4,
            this.BtomNowUsrLoginTime});
			this.statusStrip1.Location = new System.Drawing.Point(0, 459);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(828, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// BtomStaLabel1
			// 
			this.BtomStaLabel1.Name = "BtomStaLabel1";
			this.BtomStaLabel1.Size = new System.Drawing.Size(91, 17);
			this.BtomStaLabel1.Text = "当前登陆用户：";
			// 
			// BtomNowUsrName
			// 
			this.BtomNowUsrName.Name = "BtomNowUsrName";
			this.BtomNowUsrName.Size = new System.Drawing.Size(61, 17);
			this.BtomNowUsrName.Text = "NowUser";
			// 
			// Btom
			// 
			this.Btom.Enabled = true;
			this.Btom.Interval = 1000;
			// 
			// BtomStaLabel2
			// 
			this.BtomStaLabel2.Name = "BtomStaLabel2";
			this.BtomStaLabel2.Size = new System.Drawing.Size(104, 17);
			this.BtomStaLabel2.Text = "      当前用户ID：";
			this.BtomStaLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// BtomNowUsrID
			// 
			this.BtomNowUsrID.Name = "BtomNowUsrID";
			this.BtomNowUsrID.Size = new System.Drawing.Size(74, 17);
			this.BtomNowUsrID.Text = "NowUserID";
			// 
			// BtomStaLabel3
			// 
			this.BtomStaLabel3.Name = "BtomStaLabel3";
			this.BtomStaLabel3.Size = new System.Drawing.Size(127, 17);
			this.BtomStaLabel3.Text = "         当前用户角色：";
			this.BtomStaLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// BtomNowUserAct
			// 
			this.BtomNowUserAct.Name = "BtomNowUserAct";
			this.BtomNowUserAct.Size = new System.Drawing.Size(79, 17);
			this.BtomNowUserAct.Text = "NowUserAct";
			// 
			// BtomStaLabel4
			// 
			this.BtomStaLabel4.Name = "BtomStaLabel4";
			this.BtomStaLabel4.Size = new System.Drawing.Size(131, 17);
			this.BtomStaLabel4.Text = "    当前用户登陆时间：";
			this.BtomStaLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// BtomNowUsrLoginTime
			// 
			this.BtomNowUsrLoginTime.Name = "BtomNowUsrLoginTime";
			this.BtomNowUsrLoginTime.Size = new System.Drawing.Size(125, 17);
			this.BtomNowUsrLoginTime.Text = "0000/00/00 00:00:00";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 481);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainWindow";
			this.Text = "MainWindow";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel1;
		private System.Windows.Forms.ToolStripStatusLabel BtomNowUsrName;
		private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel2;
		private System.Windows.Forms.ToolStripStatusLabel BtomNowUsrID;
		private System.Windows.Forms.Timer Btom;
		private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel3;
		private System.Windows.Forms.ToolStripStatusLabel BtomNowUserAct;
		private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel4;
		private System.Windows.Forms.ToolStripStatusLabel BtomNowUsrLoginTime;
	}
}