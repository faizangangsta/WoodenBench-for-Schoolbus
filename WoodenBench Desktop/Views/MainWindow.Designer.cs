namespace WoodenBench.Views
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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.用户UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改用户信息DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出用户EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminManage = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NowUsrDataGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TUsrWCIDL = new System.Windows.Forms.Label();
            this.TUsrGroupL = new System.Windows.Forms.Label();
            this.TUsrIDL = new System.Windows.Forms.Label();
            this.TUsrRNameL = new System.Windows.Forms.Label();
            this.TUsrNameL = new System.Windows.Forms.Label();
            this.MainStatusGroup = new System.Windows.Forms.StatusStrip();
            this.BtomStaLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BUsrNameL = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BUsrRNameL = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtomStaLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BUsrIDL = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtomStaLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BUsrGroupL = new System.Windows.Forms.ToolStripStatusLabel();
            this.SysNotiGroup = new System.Windows.Forms.GroupBox();
            this.NotificationContentLabel = new System.Windows.Forms.Label();
            this.NotificationTitleLabel = new System.Windows.Forms.Label();
            this.NotificationWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.textBoxItem1 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.TopMenu.SuspendLayout();
            this.NowUsrDataGroup.SuspendLayout();
            this.MainStatusGroup.SuspendLayout();
            this.SysNotiGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.TopMenu.ForeColor = System.Drawing.Color.Black;
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.用户UToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(867, 25);
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
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(112, 6);
            this.toolStripSeparator2.Click += new System.EventHandler(this.StrangeBar);
            // 
            // 用户UToolStripMenuItem
            // 
            this.用户UToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更改用户信息DToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出用户EToolStripMenuItem,
            this.AdminManage});
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
            // AdminManage
            // 
            this.AdminManage.Enabled = false;
            this.AdminManage.ForeColor = System.Drawing.Color.Red;
            this.AdminManage.Name = "AdminManage";
            this.AdminManage.Size = new System.Drawing.Size(165, 22);
            this.AdminManage.Text = "管理员页面(&M)";
            this.AdminManage.Visible = false;
            this.AdminManage.Click += new System.EventHandler(this.管理员页面MToolStripMenuItem_Click);
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
            this.NowUsrDataGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.NowUsrDataGroup.Controls.Add(this.label4);
            this.NowUsrDataGroup.Controls.Add(this.label3);
            this.NowUsrDataGroup.Controls.Add(this.label2);
            this.NowUsrDataGroup.Controls.Add(this.label5);
            this.NowUsrDataGroup.Controls.Add(this.label1);
            this.NowUsrDataGroup.Controls.Add(this.TUsrWCIDL);
            this.NowUsrDataGroup.Controls.Add(this.TUsrGroupL);
            this.NowUsrDataGroup.Controls.Add(this.TUsrIDL);
            this.NowUsrDataGroup.Controls.Add(this.TUsrRNameL);
            this.NowUsrDataGroup.Controls.Add(this.TUsrNameL);
            this.NowUsrDataGroup.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NowUsrDataGroup.ForeColor = System.Drawing.Color.Black;
            this.NowUsrDataGroup.Location = new System.Drawing.Point(647, 27);
            this.NowUsrDataGroup.Name = "NowUsrDataGroup";
            this.NowUsrDataGroup.Size = new System.Drawing.Size(208, 143);
            this.NowUsrDataGroup.TabIndex = 4;
            this.NowUsrDataGroup.TabStop = false;
            this.NowUsrDataGroup.Text = "当前用户信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(30, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "微信号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "当前用户组";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "当前用户ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(18, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "真实姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "当前用户名";
            // 
            // TUsrWCIDL
            // 
            this.TUsrWCIDL.AutoSize = true;
            this.TUsrWCIDL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.TUsrWCIDL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TUsrWCIDL.ForeColor = System.Drawing.Color.Black;
            this.TUsrWCIDL.Location = new System.Drawing.Point(80, 109);
            this.TUsrWCIDL.Name = "TUsrWCIDL";
            this.TUsrWCIDL.Size = new System.Drawing.Size(59, 17);
            this.TUsrWCIDL.TabIndex = 3;
            this.TUsrWCIDL.Text = "WChatID";
            // 
            // TUsrGroupL
            // 
            this.TUsrGroupL.AutoSize = true;
            this.TUsrGroupL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.TUsrGroupL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TUsrGroupL.ForeColor = System.Drawing.Color.Black;
            this.TUsrGroupL.Location = new System.Drawing.Point(80, 87);
            this.TUsrGroupL.Name = "TUsrGroupL";
            this.TUsrGroupL.Size = new System.Drawing.Size(76, 17);
            this.TUsrGroupL.TabIndex = 2;
            this.TUsrGroupL.Text = "User Group";
            // 
            // TUsrIDL
            // 
            this.TUsrIDL.AutoSize = true;
            this.TUsrIDL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.TUsrIDL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TUsrIDL.ForeColor = System.Drawing.Color.Black;
            this.TUsrIDL.Location = new System.Drawing.Point(80, 66);
            this.TUsrIDL.Name = "TUsrIDL";
            this.TUsrIDL.Size = new System.Drawing.Size(48, 17);
            this.TUsrIDL.TabIndex = 1;
            this.TUsrIDL.Text = "UserID";
            // 
            // TUsrRNameL
            // 
            this.TUsrRNameL.AutoSize = true;
            this.TUsrRNameL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.TUsrRNameL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TUsrRNameL.ForeColor = System.Drawing.Color.Black;
            this.TUsrRNameL.Location = new System.Drawing.Point(80, 44);
            this.TUsrRNameL.Name = "TUsrRNameL";
            this.TUsrRNameL.Size = new System.Drawing.Size(78, 17);
            this.TUsrRNameL.TabIndex = 0;
            this.TUsrRNameL.Text = "UserRName";
            // 
            // TUsrNameL
            // 
            this.TUsrNameL.AutoSize = true;
            this.TUsrNameL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.TUsrNameL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TUsrNameL.ForeColor = System.Drawing.Color.Black;
            this.TUsrNameL.Location = new System.Drawing.Point(80, 22);
            this.TUsrNameL.Name = "TUsrNameL";
            this.TUsrNameL.Size = new System.Drawing.Size(70, 17);
            this.TUsrNameL.TabIndex = 0;
            this.TUsrNameL.Text = "UserName";
            // 
            // MainStatusGroup
            // 
            this.MainStatusGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.MainStatusGroup.ForeColor = System.Drawing.Color.Black;
            this.MainStatusGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtomStaLabel1,
            this.BUsrNameL,
            this.toolStripStatusLabel1,
            this.BUsrRNameL,
            this.BtomStaLabel2,
            this.BUsrIDL,
            this.BtomStaLabel3,
            this.BUsrGroupL});
            this.MainStatusGroup.Location = new System.Drawing.Point(0, 552);
            this.MainStatusGroup.Name = "MainStatusGroup";
            this.MainStatusGroup.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.MainStatusGroup.Size = new System.Drawing.Size(867, 22);
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
            // BUsrNameL
            // 
            this.BUsrNameL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BUsrNameL.Name = "BUsrNameL";
            this.BUsrNameL.Size = new System.Drawing.Size(117, 17);
            this.BUsrNameL.Spring = true;
            this.BUsrNameL.Text = "NowUser";
            this.BUsrNameL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel1.Text = "用户真实姓名：";
            // 
            // BUsrRNameL
            // 
            this.BUsrRNameL.Name = "BUsrRNameL";
            this.BUsrRNameL.Size = new System.Drawing.Size(117, 17);
            this.BUsrRNameL.Spring = true;
            this.BUsrRNameL.Text = "UserRName";
            this.BUsrRNameL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtomStaLabel2
            // 
            this.BtomStaLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtomStaLabel2.Name = "BtomStaLabel2";
            this.BtomStaLabel2.Size = new System.Drawing.Size(93, 17);
            this.BtomStaLabel2.Text = "   当前用户ID：";
            this.BtomStaLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BUsrIDL
            // 
            this.BUsrIDL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BUsrIDL.Name = "BUsrIDL";
            this.BUsrIDL.Size = new System.Drawing.Size(117, 17);
            this.BUsrIDL.Spring = true;
            this.BUsrIDL.Text = "NowUserID";
            this.BUsrIDL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtomStaLabel3
            // 
            this.BtomStaLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtomStaLabel3.Name = "BtomStaLabel3";
            this.BtomStaLabel3.Size = new System.Drawing.Size(92, 17);
            this.BtomStaLabel3.Text = "   当前用户组：";
            this.BtomStaLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BUsrGroupL
            // 
            this.BUsrGroupL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BUsrGroupL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BUsrGroupL.Name = "BUsrGroupL";
            this.BUsrGroupL.Size = new System.Drawing.Size(117, 17);
            this.BUsrGroupL.Spring = true;
            this.BUsrGroupL.Text = "NowUserGroup";
            this.BUsrGroupL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SysNotiGroup
            // 
            this.SysNotiGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SysNotiGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.SysNotiGroup.Controls.Add(this.NotificationContentLabel);
            this.SysNotiGroup.Controls.Add(this.NotificationTitleLabel);
            this.SysNotiGroup.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SysNotiGroup.ForeColor = System.Drawing.Color.Black;
            this.SysNotiGroup.Location = new System.Drawing.Point(647, 176);
            this.SysNotiGroup.Name = "SysNotiGroup";
            this.SysNotiGroup.Size = new System.Drawing.Size(208, 373);
            this.SysNotiGroup.TabIndex = 6;
            this.SysNotiGroup.TabStop = false;
            this.SysNotiGroup.Text = "通知区域";
            // 
            // NotificationContentLabel
            // 
            this.NotificationContentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotificationContentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.NotificationContentLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NotificationContentLabel.ForeColor = System.Drawing.Color.Black;
            this.NotificationContentLabel.Location = new System.Drawing.Point(14, 68);
            this.NotificationContentLabel.Name = "NotificationContentLabel";
            this.NotificationContentLabel.Size = new System.Drawing.Size(177, 302);
            this.NotificationContentLabel.TabIndex = 1;
            this.NotificationContentLabel.Text = "内容";
            // 
            // NotificationTitleLabel
            // 
            this.NotificationTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotificationTitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.NotificationTitleLabel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.NotificationTitleLabel.ForeColor = System.Drawing.Color.Black;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(13, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 168);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "上传学生信息";
            // 
            // contextMenuBar1
            // 
            this.contextMenuBar1.AntiAlias = true;
            this.contextMenuBar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.contextMenuBar1.IsMaximized = false;
            this.contextMenuBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1});
            this.contextMenuBar1.Location = new System.Drawing.Point(282, 0);
            this.contextMenuBar1.Name = "contextMenuBar1";
            this.contextMenuBar1.Size = new System.Drawing.Size(393, 26);
            this.contextMenuBar1.Stretch = true;
            this.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.contextMenuBar1.TabIndex = 8;
            this.contextMenuBar1.TabStop = false;
            this.contextMenuBar1.Text = "contextMenuBar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.AutoExpandOnClick = true;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2,
            this.labelItem1});
            this.buttonItem1.Text = "buttonItem1";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBoxItem1});
            this.buttonItem2.Text = "buttonItem2";
            // 
            // textBoxItem1
            // 
            this.textBoxItem1.Name = "textBoxItem1";
            this.textBoxItem1.Text = "textBoxItem1";
            this.textBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // labelItem1
            // 
            this.labelItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.labelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.labelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.labelItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.PaddingBottom = 1;
            this.labelItem1.PaddingLeft = 10;
            this.labelItem1.PaddingTop = 1;
            this.labelItem1.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.labelItem1.Text = "labelItem1";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(279, 64);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(115, 38);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "buttonX1";
            this.buttonX1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 574);
            this.Controls.Add(this.contextMenuBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainStatusGroup);
            this.Controls.Add(this.SysNotiGroup);
            this.Controls.Add(this.NowUsrDataGroup);
            this.Controls.Add(this.TopMenu);
            this.DoubleBuffered = true;
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
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
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
        private System.Windows.Forms.ToolStripStatusLabel BUsrNameL;
        private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel2;
        private System.Windows.Forms.ToolStripStatusLabel BUsrIDL;
        private System.Windows.Forms.ToolStripStatusLabel BtomStaLabel3;
        private System.Windows.Forms.ToolStripStatusLabel BUsrGroupL;
        private System.Windows.Forms.Label TUsrWCIDL;
        private System.Windows.Forms.Label TUsrGroupL;
        private System.Windows.Forms.Label TUsrIDL;
        private System.Windows.Forms.Label TUsrNameL;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TUsrRNameL;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel BUsrRNameL;
        private System.Windows.Forms.ToolStripMenuItem AdminManage;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}