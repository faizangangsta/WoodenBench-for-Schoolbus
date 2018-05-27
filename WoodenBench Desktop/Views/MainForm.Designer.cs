namespace WBPlatform.WinClient.Views
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.userLbl = new DevComponents.DotNetBar.LabelX();
            this.mainPanel = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.UploadStuDataTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.MyStudentDataInfo = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.NotificationCenter = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.myAccount = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.MgrLoginTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.helpTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.LogoffTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.appSettingsTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            this.userRole = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.userLbl.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.userLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.userLbl.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLbl.ForeColor = System.Drawing.Color.Black;
            this.userLbl.Location = new System.Drawing.Point(7, 5);
            this.userLbl.Name = "labelX1";
            this.userLbl.Size = new System.Drawing.Size(289, 40);
            this.userLbl.TabIndex = 6;
            this.userLbl.Text = "主菜单";
            // 
            // itemPanel1
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.mainPanel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mainPanel.ContainerControlProcessDialogKey = true;
            this.mainPanel.DragDropSupport = true;
            this.mainPanel.ForeColor = System.Drawing.Color.Black;
            this.mainPanel.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.mainPanel.Location = new System.Drawing.Point(58, 78);
            this.mainPanel.Name = "itemPanel1";
            this.mainPanel.ReserveLeftSpace = false;
            this.mainPanel.Size = new System.Drawing.Size(568, 296);
            this.mainPanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.mainPanel.TabIndex = 7;
            this.mainPanel.Text = "itemPanels";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.ItemSpacing = 6;
            this.itemContainer1.MinimumSize = new System.Drawing.Size(560, 0);
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.ResizeItemsToFit = false;
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.UploadStuDataTile,
            this.MyStudentDataInfo,
            this.NotificationCenter,
            this.myAccount,
            this.MgrLoginTile,
            this.helpTile,
            this.LogoffTile,
            this.appSettingsTile});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // UploadStuDataTile
            // 
            this.UploadStuDataTile.Image = global::WBPlatform.WinClient.Properties.Resources.Invoice;
            this.UploadStuDataTile.Name = "UploadStuDataTile";
            this.UploadStuDataTile.SymbolColor = System.Drawing.Color.Empty;
            this.UploadStuDataTile.Text = "\r\n<br/>\r\n<font size=\"+4\">上传<br/>学生信息</font>";
            this.UploadStuDataTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.UploadStuDataTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(83)))), ((int)(((byte)(117)))));
            this.UploadStuDataTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(155)))));
            this.UploadStuDataTile.TileStyle.BackColorGradientAngle = 45;
            this.UploadStuDataTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UploadStuDataTile.TileStyle.PaddingBottom = 4;
            this.UploadStuDataTile.TileStyle.PaddingLeft = 4;
            this.UploadStuDataTile.TileStyle.PaddingRight = 4;
            this.UploadStuDataTile.TileStyle.PaddingTop = 4;
            this.UploadStuDataTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.UploadStuDataTile.TitleText = "Students";
            this.UploadStuDataTile.Click += new System.EventHandler(this.UploadStuDataTile_Click);
            // 
            // MyStudentDataInfo
            // 
            this.MyStudentDataInfo.Image = global::WBPlatform.WinClient.Properties.Resources.Web;
            this.MyStudentDataInfo.Name = "MyStudentDataInfo";
            this.MyStudentDataInfo.SymbolColor = System.Drawing.Color.Empty;
            this.MyStudentDataInfo.Text = "\r\n<br/>\r\n<font size=\"+4\">签到信息<br/>查询</font>";
            this.MyStudentDataInfo.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange;
            // 
            // 
            // 
            this.MyStudentDataInfo.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.MyStudentDataInfo.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(57)))), ((int)(((byte)(0)))));
            this.MyStudentDataInfo.TileStyle.BackColorGradientAngle = 45;
            this.MyStudentDataInfo.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MyStudentDataInfo.TileStyle.PaddingBottom = 4;
            this.MyStudentDataInfo.TileStyle.PaddingLeft = 4;
            this.MyStudentDataInfo.TileStyle.PaddingRight = 4;
            this.MyStudentDataInfo.TileStyle.PaddingTop = 4;
            this.MyStudentDataInfo.TileStyle.TextColor = System.Drawing.Color.White;
            this.MyStudentDataInfo.TitleText = "Check in";
            this.MyStudentDataInfo.Click += new System.EventHandler(this.MyStudentData_Click);
            // 
            // NotificationCenter
            // 
            this.NotificationCenter.Image = global::WBPlatform.WinClient.Properties.Resources.Charts;
            this.NotificationCenter.Name = "NotificationCenter";
            this.NotificationCenter.SymbolColor = System.Drawing.Color.Empty;
            this.NotificationCenter.Text = "\r\n<br/>\r\n<font size=\"+4\">通知查看</font>\r\n<br/>\r\n查看使用通知";
            this.NotificationCenter.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.NotificationCenter.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.NotificationCenter.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
            this.NotificationCenter.TileStyle.BackColorGradientAngle = 45;
            this.NotificationCenter.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NotificationCenter.TileStyle.PaddingBottom = 4;
            this.NotificationCenter.TileStyle.PaddingLeft = 4;
            this.NotificationCenter.TileStyle.PaddingRight = 4;
            this.NotificationCenter.TileStyle.PaddingTop = 4;
            this.NotificationCenter.TileStyle.TextColor = System.Drawing.Color.White;
            this.NotificationCenter.TitleText = "Notifications";
            this.NotificationCenter.Click += new System.EventHandler(this.NotificationCenter_Click);
            // 
            // myAccount
            // 
            this.myAccount.Name = "myAccount";
            this.myAccount.Symbol = "";
            this.myAccount.SymbolColor = System.Drawing.Color.Empty;
            this.myAccount.SymbolSize = 42F;
            this.myAccount.Text = "\r\n<br/>\r\n<font size=\"+4\">我的账户</font>\r\n<br/>修改账户信息";
            this.myAccount.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet;
            // 
            // 
            // 
            this.myAccount.TileStyle.BackColorGradientAngle = 45;
            this.myAccount.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.myAccount.TileStyle.PaddingBottom = 4;
            this.myAccount.TileStyle.PaddingLeft = 4;
            this.myAccount.TileStyle.PaddingRight = 4;
            this.myAccount.TileStyle.PaddingTop = 4;
            this.myAccount.TileStyle.TextColor = System.Drawing.Color.White;
            this.myAccount.TitleText = "My Account";
            this.myAccount.Click += new System.EventHandler(this.myAccount_Click);
            // 
            // MgrLoginTile
            // 
            this.MgrLoginTile.Image = global::WBPlatform.WinClient.Properties.Resources.TableReportt;
            this.MgrLoginTile.Name = "MgrLoginTile";
            this.MgrLoginTile.SymbolColor = System.Drawing.Color.Empty;
            this.MgrLoginTile.Text = "\r\n<br/>\r\n<font size=\"+4\">管理中心</font><br/>\r\n管理通知和用户";
            this.MgrLoginTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta;
            // 
            // 
            // 
            this.MgrLoginTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.MgrLoginTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(98)))), ((int)(((byte)(185)))));
            this.MgrLoginTile.TileStyle.BackColorGradientAngle = 45;
            this.MgrLoginTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MgrLoginTile.TileStyle.PaddingBottom = 4;
            this.MgrLoginTile.TileStyle.PaddingLeft = 4;
            this.MgrLoginTile.TileStyle.PaddingRight = 4;
            this.MgrLoginTile.TileStyle.PaddingTop = 4;
            this.MgrLoginTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.MgrLoginTile.TitleText = "Management";
            this.MgrLoginTile.Click += new System.EventHandler(this.MgrLoginTile_Click);
            // 
            // helpTile
            // 
            this.helpTile.Image = global::WBPlatform.WinClient.Properties.Resources.Help;
            this.helpTile.Name = "helpTile";
            this.helpTile.SymbolColor = System.Drawing.Color.Empty;
            this.helpTile.Text = "\r\n<br/>\r\n<font size=\"+4\">帮助</font>\r\n<br/>如何使用本软件";
            this.helpTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            // 
            // 
            // 
            this.helpTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(102)))), ((int)(((byte)(168)))));
            this.helpTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(120)))), ((int)(((byte)(190)))));
            this.helpTile.TileStyle.BackColorGradientAngle = 45;
            this.helpTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.helpTile.TileStyle.PaddingBottom = 4;
            this.helpTile.TileStyle.PaddingLeft = 4;
            this.helpTile.TileStyle.PaddingRight = 4;
            this.helpTile.TileStyle.PaddingTop = 4;
            this.helpTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.helpTile.TitleText = "Help";
            this.helpTile.Click += new System.EventHandler(this.helpTile_Click);
            // 
            // LogoffTile
            // 
            this.LogoffTile.Name = "LogoffTile";
            this.LogoffTile.Symbol = "";
            this.LogoffTile.SymbolColor = System.Drawing.Color.Empty;
            this.LogoffTile.SymbolSize = 40F;
            this.LogoffTile.Text = "\r\n<br/>\r\n<font size=\"+4\">注销</font>\r\n<br/>返回登录页面";
            this.LogoffTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            // 
            // 
            // 
            this.LogoffTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(76)))), ((int)(((byte)(41)))));
            this.LogoffTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(67)))), ((int)(((byte)(37)))));
            this.LogoffTile.TileStyle.BackColorGradientAngle = 45;
            this.LogoffTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LogoffTile.TileStyle.PaddingBottom = 4;
            this.LogoffTile.TileStyle.PaddingLeft = 4;
            this.LogoffTile.TileStyle.PaddingRight = 4;
            this.LogoffTile.TileStyle.PaddingTop = 4;
            this.LogoffTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.LogoffTile.TitleText = "Logoff";
            this.LogoffTile.Click += new System.EventHandler(this.LogOutUsrTile);
            // 
            // appSettingsTile
            // 
            this.appSettingsTile.Image = global::WBPlatform.WinClient.Properties.Resources.Details;
            this.appSettingsTile.Name = "appSettingsTile";
            this.appSettingsTile.SymbolColor = System.Drawing.Color.Empty;
            this.appSettingsTile.Text = "\r\n<br/>\r\n<font size=\"+4\">应用设置</font>\r\n<br/>更改首选项";
            this.appSettingsTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            // 
            // 
            // 
            this.appSettingsTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(55)))), ((int)(((byte)(76)))));
            this.appSettingsTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.appSettingsTile.TileStyle.BackColorGradientAngle = 45;
            this.appSettingsTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.appSettingsTile.TileStyle.PaddingBottom = 4;
            this.appSettingsTile.TileStyle.PaddingLeft = 4;
            this.appSettingsTile.TileStyle.PaddingRight = 4;
            this.appSettingsTile.TileStyle.PaddingTop = 4;
            this.appSettingsTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.appSettingsTile.TitleText = "Settings";
            this.appSettingsTile.Visible = false;
            this.appSettingsTile.Click += new System.EventHandler(this.appSettingsTile_Click);
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(475, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(124, 58);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "<div align=\"right\"><font size=\"+4\">Name</font><br/>ID</div>";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX2.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelX2.Click += new System.EventHandler(this.labelX2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "当前用户角色：";
            // 
            // userRole
            // 
            this.userRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userRole.AutoSize = true;
            this.userRole.BackColor = System.Drawing.Color.White;
            this.userRole.ForeColor = System.Drawing.Color.Black;
            this.userRole.Location = new System.Drawing.Point(100, 403);
            this.userRole.Name = "userRole";
            this.userRole.Size = new System.Drawing.Size(53, 12);
            this.userRole.TabIndex = 10;
            this.userRole.Text = "一般用户";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ForeColor = System.Drawing.Color.Black;
            this.pictureBox1.InitialImage = global::WBPlatform.WinClient.Properties.Resources.Person;
            this.pictureBox1.Location = new System.Drawing.Point(605, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 58);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(675, 416);
            this.Controls.Add(this.userRole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userLbl);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(691, 455);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 2, 1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "校车小板凳管理平台";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX userLbl;
        private DevComponents.DotNetBar.ItemPanel mainPanel;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem UploadStuDataTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem NotificationCenter;
        private DevComponents.DotNetBar.Metro.MetroTileItem MyStudentDataInfo;
        private DevComponents.DotNetBar.Metro.MetroTileItem myAccount;
        private DevComponents.DotNetBar.Metro.MetroTileItem MgrLoginTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem appSettingsTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem helpTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem LogoffTile;
        public System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label userRole;
    }
}