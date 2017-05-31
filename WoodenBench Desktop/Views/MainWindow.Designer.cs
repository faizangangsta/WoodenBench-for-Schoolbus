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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.TopMenu = new System.Windows.Forms.MenuStrip();
			this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
			this.SysNotiGroup = new System.Windows.Forms.GroupBox();
			this.NotificationContentLabel = new System.Windows.Forms.Label();
			this.NotificationTitleLabel = new System.Windows.Forms.Label();
			this.NotificationWorker = new System.ComponentModel.BackgroundWorker();
			this.TutorProcessExcelGroup = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.NowPartOSchoolLbl = new System.Windows.Forms.Label();
			this.NowClassLbl = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.StudentData = new System.Windows.Forms.DataGridView();
			this.SureAndUploadBtn = new System.Windows.Forms.Button();
			this.ExcelFilePathTxt = new System.Windows.Forms.TextBox();
			this.ExcelFileOpenBtn = new System.Windows.Forms.Button();
			this.OpenExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.DataStuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataStuDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataStuIsBWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TopMenu.SuspendLayout();
			this.NowUsrDataGroup.SuspendLayout();
			this.MainStatusGroup.SuspendLayout();
			this.SysNotiGroup.SuspendLayout();
			this.TutorProcessExcelGroup.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.StudentData)).BeginInit();
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
			this.TopMenu.Size = new System.Drawing.Size(848, 25);
			this.TopMenu.TabIndex = 3;
			this.TopMenu.Text = "menuStrip1";
			// 
			// 文件ToolStripMenuItem
			// 
			this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem,
            this.toolStripSeparator2});
			this.文件ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
			this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
			this.文件ToolStripMenuItem.Text = "文件(&F)";
			// 
			// 退出EToolStripMenuItem
			// 
			this.退出EToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
			this.退出EToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.退出EToolStripMenuItem.Text = "退出(&E)";
			this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			this.toolStripSeparator2.Click += new System.EventHandler(this.StrangeBar);
			// 
			// 用户UToolStripMenuItem
			// 
			this.用户UToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更改用户信息DToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出用户EToolStripMenuItem});
			this.用户UToolStripMenuItem.Name = "用户UToolStripMenuItem";
			this.用户UToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
			this.用户UToolStripMenuItem.Text = "用户(&U)";
			// 
			// 更改用户信息DToolStripMenuItem
			// 
			this.更改用户信息DToolStripMenuItem.Name = "更改用户信息DToolStripMenuItem";
			this.更改用户信息DToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.更改用户信息DToolStripMenuItem.Text = "更改用户信息(&D)";
			this.更改用户信息DToolStripMenuItem.Click += new System.EventHandler(this.更改用户信息DToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
			// 
			// 退出用户EToolStripMenuItem
			// 
			this.退出用户EToolStripMenuItem.Name = "退出用户EToolStripMenuItem";
			this.退出用户EToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
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
			this.NowUsrDataGroup.Location = new System.Drawing.Point(628, 27);
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
            this.BtomNowUserAct});
			this.MainStatusGroup.Location = new System.Drawing.Point(0, 604);
			this.MainStatusGroup.Name = "MainStatusGroup";
			this.MainStatusGroup.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.MainStatusGroup.Size = new System.Drawing.Size(848, 22);
			this.MainStatusGroup.TabIndex = 5;
			this.MainStatusGroup.Text = "statusStrip1";
			// 
			// BtomStaLabel1
			// 
			this.BtomStaLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomStaLabel1.Name = "BtomStaLabel1";
			this.BtomStaLabel1.Size = new System.Drawing.Size(104, 17);
			this.BtomStaLabel1.Text = "   当前登陆用户：";
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
			this.BtomNowUserAct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.BtomNowUserAct.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtomNowUserAct.Name = "BtomNowUserAct";
			this.BtomNowUserAct.Size = new System.Drawing.Size(80, 17);
			this.BtomNowUserAct.Text = "NowUserAct";
			// 
			// SysNotiGroup
			// 
			this.SysNotiGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SysNotiGroup.Controls.Add(this.NotificationContentLabel);
			this.SysNotiGroup.Controls.Add(this.NotificationTitleLabel);
			this.SysNotiGroup.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.SysNotiGroup.Location = new System.Drawing.Point(628, 137);
			this.SysNotiGroup.Name = "SysNotiGroup";
			this.SysNotiGroup.Size = new System.Drawing.Size(208, 464);
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
			this.NotificationContentLabel.Size = new System.Drawing.Size(177, 393);
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
			// TutorProcessExcelGroup
			// 
			this.TutorProcessExcelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TutorProcessExcelGroup.Controls.Add(this.groupBox1);
			this.TutorProcessExcelGroup.Controls.Add(this.StudentData);
			this.TutorProcessExcelGroup.Controls.Add(this.SureAndUploadBtn);
			this.TutorProcessExcelGroup.Controls.Add(this.ExcelFilePathTxt);
			this.TutorProcessExcelGroup.Controls.Add(this.ExcelFileOpenBtn);
			this.TutorProcessExcelGroup.Location = new System.Drawing.Point(12, 28);
			this.TutorProcessExcelGroup.Name = "TutorProcessExcelGroup";
			this.TutorProcessExcelGroup.Size = new System.Drawing.Size(610, 250);
			this.TutorProcessExcelGroup.TabIndex = 7;
			this.TutorProcessExcelGroup.TabStop = false;
			this.TutorProcessExcelGroup.Text = "从 Excel 导入信息";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.NowPartOSchoolLbl);
			this.groupBox1.Controls.Add(this.NowClassLbl);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(498, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(106, 134);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "班级和学部";
			// 
			// NowPartOSchoolLbl
			// 
			this.NowPartOSchoolLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NowPartOSchoolLbl.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.NowPartOSchoolLbl.Location = new System.Drawing.Point(6, 86);
			this.NowPartOSchoolLbl.Name = "NowPartOSchoolLbl";
			this.NowPartOSchoolLbl.Size = new System.Drawing.Size(94, 45);
			this.NowPartOSchoolLbl.TabIndex = 2;
			this.NowPartOSchoolLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NowClassLbl
			// 
			this.NowClassLbl.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.NowClassLbl.Location = new System.Drawing.Point(6, 35);
			this.NowClassLbl.Name = "NowClassLbl";
			this.NowClassLbl.Size = new System.Drawing.Size(94, 39);
			this.NowClassLbl.TabIndex = 2;
			this.NowClassLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 74);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 12);
			this.label7.TabIndex = 1;
			this.label7.Text = "学部";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 12);
			this.label6.TabIndex = 0;
			this.label6.Text = "班级";
			// 
			// StudentData
			// 
			this.StudentData.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.StudentData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.StudentData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StudentData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataStuName,
            this.DataStuDirection,
            this.DataStuIsBWeek});
			this.StudentData.Location = new System.Drawing.Point(6, 56);
			this.StudentData.Name = "StudentData";
			this.StudentData.RowTemplate.Height = 23;
			this.StudentData.Size = new System.Drawing.Size(486, 184);
			this.StudentData.TabIndex = 4;
			// 
			// SureAndUploadBtn
			// 
			this.SureAndUploadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SureAndUploadBtn.Location = new System.Drawing.Point(498, 196);
			this.SureAndUploadBtn.Name = "SureAndUploadBtn";
			this.SureAndUploadBtn.Size = new System.Drawing.Size(106, 44);
			this.SureAndUploadBtn.TabIndex = 3;
			this.SureAndUploadBtn.Text = "确认并上传(&S)";
			this.SureAndUploadBtn.UseVisualStyleBackColor = true;
			this.SureAndUploadBtn.Click += new System.EventHandler(this.SureAndUpload);
			// 
			// ExcelFilePathTxt
			// 
			this.ExcelFilePathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ExcelFilePathTxt.Location = new System.Drawing.Point(131, 22);
			this.ExcelFilePathTxt.Name = "ExcelFilePathTxt";
			this.ExcelFilePathTxt.ReadOnly = true;
			this.ExcelFilePathTxt.Size = new System.Drawing.Size(473, 21);
			this.ExcelFilePathTxt.TabIndex = 1;
			// 
			// ExcelFileOpenBtn
			// 
			this.ExcelFileOpenBtn.Location = new System.Drawing.Point(7, 21);
			this.ExcelFileOpenBtn.Name = "ExcelFileOpenBtn";
			this.ExcelFileOpenBtn.Size = new System.Drawing.Size(118, 23);
			this.ExcelFileOpenBtn.TabIndex = 0;
			this.ExcelFileOpenBtn.Text = "打开一个文件(&O)";
			this.ExcelFileOpenBtn.UseVisualStyleBackColor = true;
			this.ExcelFileOpenBtn.Click += new System.EventHandler(this.OpenExcel);
			// 
			// OpenExcelFileDialog
			// 
			this.OpenExcelFileDialog.DefaultExt = "*.xls;*.xlsx";
			this.OpenExcelFileDialog.Filter = "Excel 表格(2007)|*.xlsx|Excel 表格(2003)|*.xls";
			this.OpenExcelFileDialog.Title = "打开一个 Excel 文件";
			// 
			// DataStuName
			// 
			this.DataStuName.HeaderText = "学生姓名";
			this.DataStuName.Name = "DataStuName";
			this.DataStuName.Width = 130;
			// 
			// DataStuDirection
			// 
			this.DataStuDirection.HeaderText = "校车路线";
			this.DataStuDirection.Name = "DataStuDirection";
			this.DataStuDirection.Width = 130;
			// 
			// DataStuIsBWeek
			// 
			this.DataStuIsBWeek.HeaderText = "小周？";
			this.DataStuIsBWeek.Name = "DataStuIsBWeek";
			this.DataStuIsBWeek.Width = 130;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(848, 626);
			this.Controls.Add(this.MainStatusGroup);
			this.Controls.Add(this.TutorProcessExcelGroup);
			this.Controls.Add(this.SysNotiGroup);
			this.Controls.Add(this.NowUsrDataGroup);
			this.Controls.Add(this.TopMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.TopMenu;
			this.Name = "MainWindow";
			this.Text = "管理小板凳";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.Click += new System.EventHandler(this.MainWindow_Click);
			this.TopMenu.ResumeLayout(false);
			this.TopMenu.PerformLayout();
			this.NowUsrDataGroup.ResumeLayout(false);
			this.NowUsrDataGroup.PerformLayout();
			this.MainStatusGroup.ResumeLayout(false);
			this.MainStatusGroup.PerformLayout();
			this.SysNotiGroup.ResumeLayout(false);
			this.TutorProcessExcelGroup.ResumeLayout(false);
			this.TutorProcessExcelGroup.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.StudentData)).EndInit();
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
		private System.Windows.Forms.GroupBox TutorProcessExcelGroup;
		private System.Windows.Forms.OpenFileDialog OpenExcelFileDialog;
		private System.Windows.Forms.TextBox ExcelFilePathTxt;
		private System.Windows.Forms.Button ExcelFileOpenBtn;
		private System.Windows.Forms.Button SureAndUploadBtn;
		private System.Windows.Forms.DataGridView StudentData;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label NowPartOSchoolLbl;
		private System.Windows.Forms.Label NowClassLbl;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataStuName;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataStuDirection;
		private System.Windows.Forms.DataGridViewTextBoxColumn DataStuIsBWeek;
	}
}