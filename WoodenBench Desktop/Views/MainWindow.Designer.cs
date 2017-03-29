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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.TopMenu = new System.Windows.Forms.MenuStrip();
			this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.用户UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.更改用户信息DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.退出用户EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NowUsrDataGroup = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.TopNowUserLoginName = new System.Windows.Forms.Label();
			this.TopNowUserGroup = new System.Windows.Forms.Label();
			this.TopNowUserID = new System.Windows.Forms.Label();
			this.TopNowUserName = new System.Windows.Forms.Label();
			this.MainStatusGroup = new System.Windows.Forms.StatusStrip();
			this.BtomStaLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomNowUsrName = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomStaLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomNowUsrID = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomStaLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomNowUserAct = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomStaLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtomNowUsrLoginTime = new System.Windows.Forms.ToolStripStatusLabel();
			this.SysNotiGroup = new System.Windows.Forms.GroupBox();
			this.NotificationContentLabel = new System.Windows.Forms.Label();
			this.NotificationTitleLabel = new System.Windows.Forms.Label();
			this.NotificationWorker = new System.ComponentModel.BackgroundWorker();
			this.ProcessExcelGroup = new System.Windows.Forms.GroupBox();
			this.OpenExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ExcelFileOpenBtn = new System.Windows.Forms.Button();
			this.ExcelFilePathTxt = new System.Windows.Forms.TextBox();
			this.TopMenu.SuspendLayout();
			this.NowUsrDataGroup.SuspendLayout();
			this.MainStatusGroup.SuspendLayout();
			this.SysNotiGroup.SuspendLayout();
			this.ProcessExcelGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// TopMenu
			// 
			this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.用户UToolStripMenuItem,
            this.关于ToolStripMenuItem});
			this.TopMenu.Location = new System.Drawing.Point(0, 0);
			this.TopMenu.Name = "TopMenu";
			this.TopMenu.Size = new System.Drawing.Size(870, 25);
			this.TopMenu.TabIndex = 3;
			this.TopMenu.Text = "menuStrip1";
			// 
			// 文件ToolStripMenuItem
			// 
			this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem});
			this.文件ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
			this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
			this.文件ToolStripMenuItem.Text = "文件(&F)";
			// 
			// 退出EToolStripMenuItem
			// 
			this.退出EToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
			this.退出EToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.退出EToolStripMenuItem.Text = "退出(&E)";
			this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
			// 
			// 用户UToolStripMenuItem
			// 
			this.用户UToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更改用户信息DToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出用户EToolStripMenuItem});
			this.用户UToolStripMenuItem.Name = "用户UToolStripMenuItem";
			this.用户UToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
			this.用户UToolStripMenuItem.Text = "用户(&U)";
			// 
			// 更改用户信息DToolStripMenuItem
			// 
			this.更改用户信息DToolStripMenuItem.Name = "更改用户信息DToolStripMenuItem";
			this.更改用户信息DToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.更改用户信息DToolStripMenuItem.Text = "更改用户信息(&D)";
			this.更改用户信息DToolStripMenuItem.Click += new System.EventHandler(this.更改用户信息DToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
			// 
			// 退出用户EToolStripMenuItem
			// 
			this.退出用户EToolStripMenuItem.Name = "退出用户EToolStripMenuItem";
			this.退出用户EToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.退出用户EToolStripMenuItem.Text = "退出用户(&E)";
			this.退出用户EToolStripMenuItem.Click += new System.EventHandler(this.退出用户EToolStripMenuItem_Click);
			// 
			// 关于ToolStripMenuItem
			// 
			this.关于ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			this.关于ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
			this.关于ToolStripMenuItem.Text = "关于(&A)";
			// 
			// NowUsrDataGroup
			// 
			this.NowUsrDataGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NowUsrDataGroup.Controls.Add(this.label4);
			this.NowUsrDataGroup.Controls.Add(this.label3);
			this.NowUsrDataGroup.Controls.Add(this.label2);
			this.NowUsrDataGroup.Controls.Add(this.label1);
			this.NowUsrDataGroup.Controls.Add(this.TopNowUserLoginName);
			this.NowUsrDataGroup.Controls.Add(this.TopNowUserGroup);
			this.NowUsrDataGroup.Controls.Add(this.TopNowUserID);
			this.NowUsrDataGroup.Controls.Add(this.TopNowUserName);
			this.NowUsrDataGroup.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.NowUsrDataGroup.Location = new System.Drawing.Point(650, 27);
			this.NowUsrDataGroup.Name = "NowUsrDataGroup";
			this.NowUsrDataGroup.Size = new System.Drawing.Size(208, 104);
			this.NowUsrDataGroup.TabIndex = 4;
			this.NowUsrDataGroup.TabStop = false;
			this.NowUsrDataGroup.Text = "当前用户信息";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "登陆时间";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "当前用户组";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "当前用户ID";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "当前用户名";
			// 
			// TopNowUserLoginName
			// 
			this.TopNowUserLoginName.AutoSize = true;
			this.TopNowUserLoginName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TopNowUserLoginName.Location = new System.Drawing.Point(80, 81);
			this.TopNowUserLoginName.Name = "TopNowUserLoginName";
			this.TopNowUserLoginName.Size = new System.Drawing.Size(72, 17);
			this.TopNowUserLoginName.TabIndex = 3;
			this.TopNowUserLoginName.Text = "Login Time";
			// 
			// TopNowUserGroup
			// 
			this.TopNowUserGroup.AutoSize = true;
			this.TopNowUserGroup.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TopNowUserGroup.Location = new System.Drawing.Point(80, 61);
			this.TopNowUserGroup.Name = "TopNowUserGroup";
			this.TopNowUserGroup.Size = new System.Drawing.Size(76, 17);
			this.TopNowUserGroup.TabIndex = 2;
			this.TopNowUserGroup.Text = "User Group";
			// 
			// TopNowUserID
			// 
			this.TopNowUserID.AutoSize = true;
			this.TopNowUserID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TopNowUserID.Location = new System.Drawing.Point(80, 40);
			this.TopNowUserID.Name = "TopNowUserID";
			this.TopNowUserID.Size = new System.Drawing.Size(48, 17);
			this.TopNowUserID.TabIndex = 1;
			this.TopNowUserID.Text = "UserID";
			// 
			// TopNowUserName
			// 
			this.TopNowUserName.AutoSize = true;
			this.TopNowUserName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TopNowUserName.Location = new System.Drawing.Point(80, 19);
			this.TopNowUserName.Name = "TopNowUserName";
			this.TopNowUserName.Size = new System.Drawing.Size(70, 17);
			this.TopNowUserName.TabIndex = 0;
			this.TopNowUserName.Text = "UserName";
			// 
			// MainStatusGroup
			// 
			this.MainStatusGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtomStaLabel1,
            this.BtomNowUsrName,
            this.BtomStaLabel2,
            this.BtomNowUsrID,
            this.BtomStaLabel3,
            this.BtomNowUserAct,
            this.BtomStaLabel4,
            this.BtomNowUsrLoginTime});
			this.MainStatusGroup.Location = new System.Drawing.Point(0, 506);
			this.MainStatusGroup.Name = "MainStatusGroup";
			this.MainStatusGroup.Size = new System.Drawing.Size(870, 22);
			this.MainStatusGroup.TabIndex = 5;
			this.MainStatusGroup.Text = "statusStrip1";
			// 
			// BtomStaLabel1
			// 
			this.BtomStaLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomStaLabel1.Name = "BtomStaLabel1";
			this.BtomStaLabel1.Size = new System.Drawing.Size(92, 17);
			this.BtomStaLabel1.Text = "当前登陆用户：";
			// 
			// BtomNowUsrName
			// 
			this.BtomNowUsrName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomNowUsrName.Name = "BtomNowUsrName";
			this.BtomNowUsrName.Size = new System.Drawing.Size(62, 17);
			this.BtomNowUsrName.Text = "NowUser";
			// 
			// BtomStaLabel2
			// 
			this.BtomStaLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomStaLabel2.Name = "BtomStaLabel2";
			this.BtomStaLabel2.Size = new System.Drawing.Size(93, 17);
			this.BtomStaLabel2.Text = "   当前用户ID：";
			this.BtomStaLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// BtomNowUsrID
			// 
			this.BtomNowUsrID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomNowUsrID.Name = "BtomNowUsrID";
			this.BtomNowUsrID.Size = new System.Drawing.Size(75, 17);
			this.BtomNowUsrID.Text = "NowUserID";
			// 
			// BtomStaLabel3
			// 
			this.BtomStaLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomStaLabel3.Name = "BtomStaLabel3";
			this.BtomStaLabel3.Size = new System.Drawing.Size(92, 17);
			this.BtomStaLabel3.Text = "   当前用户组：";
			this.BtomStaLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// BtomNowUserAct
			// 
			this.BtomNowUserAct.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomNowUserAct.Name = "BtomNowUserAct";
			this.BtomNowUserAct.Size = new System.Drawing.Size(80, 17);
			this.BtomNowUserAct.Text = "NowUserAct";
			// 
			// BtomStaLabel4
			// 
			this.BtomStaLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomStaLabel4.Name = "BtomStaLabel4";
			this.BtomStaLabel4.Size = new System.Drawing.Size(128, 17);
			this.BtomStaLabel4.Text = "   当前用户登陆时间：";
			this.BtomStaLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// BtomNowUsrLoginTime
			// 
			this.BtomNowUsrLoginTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomNowUsrLoginTime.Name = "BtomNowUsrLoginTime";
			this.BtomNowUsrLoginTime.Size = new System.Drawing.Size(126, 17);
			this.BtomNowUsrLoginTime.Text = "0000/00/00 00:00:00";
			// 
			// SysNotiGroup
			// 
			this.SysNotiGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SysNotiGroup.Controls.Add(this.NotificationContentLabel);
			this.SysNotiGroup.Controls.Add(this.NotificationTitleLabel);
			this.SysNotiGroup.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.SysNotiGroup.Location = new System.Drawing.Point(650, 137);
			this.SysNotiGroup.Name = "SysNotiGroup";
			this.SysNotiGroup.Size = new System.Drawing.Size(208, 366);
			this.SysNotiGroup.TabIndex = 6;
			this.SysNotiGroup.TabStop = false;
			this.SysNotiGroup.Text = "通知区域";
			// 
			// NotificationContentLabel
			// 
			this.NotificationContentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NotificationContentLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.NotificationContentLabel.Location = new System.Drawing.Point(14, 68);
			this.NotificationContentLabel.Name = "NotificationContentLabel";
			this.NotificationContentLabel.Size = new System.Drawing.Size(177, 295);
			this.NotificationContentLabel.TabIndex = 1;
			this.NotificationContentLabel.Text = "内容";
			// 
			// NotificationTitleLabel
			// 
			this.NotificationTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NotificationTitleLabel.Font = new System.Drawing.Font("微软雅黑", 12F);
			this.NotificationTitleLabel.Location = new System.Drawing.Point(9, 17);
			this.NotificationTitleLabel.Name = "NotificationTitleLabel";
			this.NotificationTitleLabel.Size = new System.Drawing.Size(193, 51);
			this.NotificationTitleLabel.TabIndex = 0;
			this.NotificationTitleLabel.Text = "标题";
			this.NotificationTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NotificationWorker
			// 
			this.NotificationWorker.WorkerReportsProgress = true;
			this.NotificationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GetNotificationWorker_DoWork);
			this.NotificationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.GetNotificationWorker_RunWorkerCompleted);
			// 
			// ProcessExcelGroup
			// 
			this.ProcessExcelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProcessExcelGroup.Controls.Add(this.ExcelFilePathTxt);
			this.ProcessExcelGroup.Controls.Add(this.ExcelFileOpenBtn);
			this.ProcessExcelGroup.Location = new System.Drawing.Point(12, 28);
			this.ProcessExcelGroup.Name = "ProcessExcelGroup";
			this.ProcessExcelGroup.Size = new System.Drawing.Size(632, 210);
			this.ProcessExcelGroup.TabIndex = 7;
			this.ProcessExcelGroup.TabStop = false;
			this.ProcessExcelGroup.Text = "从 Excel 导入信息";
			// 
			// OpenExcelFileDialog
			// 
			this.OpenExcelFileDialog.DefaultExt = "*.xls;*.xlsx";
			this.OpenExcelFileDialog.Filter = "Excel 表格(2007)|*.xlsx|Excel 表格(2003)|*.xls";
			this.OpenExcelFileDialog.Title = "打开一个 Excel 文件";
			// 
			// ExcelFileOpenBtn
			// 
			this.ExcelFileOpenBtn.Location = new System.Drawing.Point(7, 21);
			this.ExcelFileOpenBtn.Name = "ExcelFileOpenBtn";
			this.ExcelFileOpenBtn.Size = new System.Drawing.Size(118, 23);
			this.ExcelFileOpenBtn.TabIndex = 0;
			this.ExcelFileOpenBtn.Text = "打开一个文件(&O)";
			this.ExcelFileOpenBtn.UseVisualStyleBackColor = true;
			this.ExcelFileOpenBtn.Click += new System.EventHandler(this.Button1_Click);
			// 
			// ExcelFilePathTxt
			// 
			this.ExcelFilePathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ExcelFilePathTxt.Location = new System.Drawing.Point(131, 21);
			this.ExcelFilePathTxt.Name = "ExcelFilePathTxt";
			this.ExcelFilePathTxt.ReadOnly = true;
			this.ExcelFilePathTxt.Size = new System.Drawing.Size(495, 21);
			this.ExcelFilePathTxt.TabIndex = 1;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(870, 528);
			this.Controls.Add(this.ProcessExcelGroup);
			this.Controls.Add(this.SysNotiGroup);
			this.Controls.Add(this.MainStatusGroup);
			this.Controls.Add(this.NowUsrDataGroup);
			this.Controls.Add(this.TopMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.TopMenu;
			this.Name = "MainWindow";
			this.Text = "管理小板凳";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.TopMenu.ResumeLayout(false);
			this.TopMenu.PerformLayout();
			this.NowUsrDataGroup.ResumeLayout(false);
			this.NowUsrDataGroup.PerformLayout();
			this.MainStatusGroup.ResumeLayout(false);
			this.MainStatusGroup.PerformLayout();
			this.SysNotiGroup.ResumeLayout(false);
			this.ProcessExcelGroup.ResumeLayout(false);
			this.ProcessExcelGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip TopMenu;
		private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
		private System.Windows.Forms.GroupBox NowUsrDataGroup;
		private System.Windows.Forms.StatusStrip MainStatusGroup;
		private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel1;
		private System.Windows.Forms.ToolStripStatusLabel BtomNowUsrName;
		private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel2;
		private System.Windows.Forms.ToolStripStatusLabel BtomNowUsrID;
		private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel3;
		private System.Windows.Forms.ToolStripStatusLabel BtomNowUserAct;
		private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel4;
		private System.Windows.Forms.ToolStripStatusLabel BtomNowUsrLoginTime;
		private System.Windows.Forms.Label TopNowUserLoginName;
		private System.Windows.Forms.Label TopNowUserGroup;
		private System.Windows.Forms.Label TopNowUserID;
		private System.Windows.Forms.Label TopNowUserName;
		private System.Windows.Forms.GroupBox SysNotiGroup;
		private System.ComponentModel.BackgroundWorker NotificationWorker;
		private System.Windows.Forms.Label NotificationContentLabel;
		private System.Windows.Forms.Label NotificationTitleLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem 用户UToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 更改用户信息DToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem 退出用户EToolStripMenuItem;
		private System.Windows.Forms.GroupBox ProcessExcelGroup;
		private System.Windows.Forms.OpenFileDialog OpenExcelFileDialog;
		private System.Windows.Forms.TextBox ExcelFilePathTxt;
		private System.Windows.Forms.Button ExcelFileOpenBtn;
	}
}