namespace WoodenBench
{
    partial class StartControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.newInvoiceTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.newClientTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.reportTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.unpaidTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ytdTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.devCoTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.appViewTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.helpTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.salesTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(55, 69);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(289, 40);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "主菜单";
            // 
            // itemPanel1
            // 
            this.itemPanel1.AutoScroll = true;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.DragDropSupport = true;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.itemPanel1.Location = new System.Drawing.Point(55, 115);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.ReserveLeftSpace = false;
            this.itemPanel1.Size = new System.Drawing.Size(571, 296);
            this.itemPanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.itemPanel1.TabIndex = 3;
            this.itemPanel1.Text = "itemPanel1";
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
            this.newInvoiceTile,
            this.newClientTile,
            this.reportTile,
            this.unpaidTile,
            this.ytdTile,
            this.devCoTile,
            this.appViewTile,
            this.helpTile,
            this.salesTile});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // newInvoiceTile
            // 
            this.newInvoiceTile.Image = global::WoodenBench.Properties.Resources.Invoice;
            this.newInvoiceTile.Name = "newInvoiceTile";
            this.newInvoiceTile.SymbolColor = System.Drawing.Color.Empty;
            this.newInvoiceTile.Text = "<font size=\"+2\">1.</font>\r\n<br/>\r\n<font size=\"+4\">上传学生信息</font>\r\n<br/>导入并上传校车<br/" +
    ">\r\n数据";
            this.newInvoiceTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.newInvoiceTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(83)))), ((int)(((byte)(117)))));
            this.newInvoiceTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(155)))));
            this.newInvoiceTile.TileStyle.BackColorGradientAngle = 45;
            this.newInvoiceTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.newInvoiceTile.TileStyle.PaddingBottom = 4;
            this.newInvoiceTile.TileStyle.PaddingLeft = 4;
            this.newInvoiceTile.TileStyle.PaddingRight = 4;
            this.newInvoiceTile.TileStyle.PaddingTop = 4;
            this.newInvoiceTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.newInvoiceTile.TitleText = "Students";
            // 
            // newClientTile
            // 
            this.newClientTile.Image = global::WoodenBench.Properties.Resources.contact;
            this.newClientTile.Name = "newClientTile";
            this.newClientTile.SymbolColor = System.Drawing.Color.Empty;
            this.newClientTile.Text = "<font size=\"+2\">2.</font>\r\n<br/>\r\n<font size=\"+4\">Add new<br/>client</font>";
            this.newClientTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            // 
            // 
            // 
            this.newClientTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(151)))), ((int)(((byte)(42)))));
            this.newClientTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(177)))), ((int)(((byte)(51)))));
            this.newClientTile.TileStyle.BackColorGradientAngle = 45;
            this.newClientTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.newClientTile.TileStyle.PaddingBottom = 4;
            this.newClientTile.TileStyle.PaddingLeft = 4;
            this.newClientTile.TileStyle.PaddingRight = 4;
            this.newClientTile.TileStyle.PaddingTop = 4;
            this.newClientTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.newClientTile.TitleText = "Users";
            // 
            // reportTile
            // 
            this.reportTile.Image = global::WoodenBench.Properties.Resources.Charts;
            this.reportTile.Name = "reportTile";
            this.reportTile.SymbolColor = System.Drawing.Color.Empty;
            this.reportTile.Text = "<font size=\"+2\">3.</font>\r\n<br/>\r\n<font size=\"+4\">Financial<br/>reports</font>";
            this.reportTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.reportTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.reportTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
            this.reportTile.TileStyle.BackColorGradientAngle = 45;
            this.reportTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reportTile.TileStyle.PaddingBottom = 4;
            this.reportTile.TileStyle.PaddingLeft = 4;
            this.reportTile.TileStyle.PaddingRight = 4;
            this.reportTile.TileStyle.PaddingTop = 4;
            this.reportTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.reportTile.TitleText = "Reports";
            // 
            // unpaidTile
            // 
            this.unpaidTile.Image = global::WoodenBench.Properties.Resources.Unpaid;
            this.unpaidTile.Name = "unpaidTile";
            this.unpaidTile.SymbolColor = System.Drawing.Color.Empty;
            this.unpaidTile.Text = "<font size=\"+2\">4.</font>\r\n<br/>\r\n<font size=\"+4\">Unpaid<br/>invoices</font>";
            this.unpaidTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange;
            // 
            // 
            // 
            this.unpaidTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.unpaidTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(57)))), ((int)(((byte)(0)))));
            this.unpaidTile.TileStyle.BackColorGradientAngle = 45;
            this.unpaidTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.unpaidTile.TileStyle.PaddingBottom = 4;
            this.unpaidTile.TileStyle.PaddingLeft = 4;
            this.unpaidTile.TileStyle.PaddingRight = 4;
            this.unpaidTile.TileStyle.PaddingTop = 4;
            this.unpaidTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.unpaidTile.TitleText = "Invoices";
            // 
            // ytdTile
            // 
            this.ytdTile.Image = global::WoodenBench.Properties.Resources.TableReportt;
            this.ytdTile.Name = "ytdTile";
            this.ytdTile.SymbolColor = System.Drawing.Color.Empty;
            this.ytdTile.Text = "<font size=\"+2\">5.</font>\r\n<br/>\r\n<font size=\"+4\">Year to date<br/>earnings</font" +
    ">";
            this.ytdTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta;
            // 
            // 
            // 
            this.ytdTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.ytdTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(98)))), ((int)(((byte)(185)))));
            this.ytdTile.TileStyle.BackColorGradientAngle = 45;
            this.ytdTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ytdTile.TileStyle.PaddingBottom = 4;
            this.ytdTile.TileStyle.PaddingLeft = 4;
            this.ytdTile.TileStyle.PaddingRight = 4;
            this.ytdTile.TileStyle.PaddingTop = 4;
            this.ytdTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.ytdTile.TitleText = "Reports";
            // 
            // devCoTile
            // 
            this.devCoTile.Name = "devCoTile";
            this.devCoTile.Symbol = "";
            this.devCoTile.SymbolColor = System.Drawing.Color.Empty;
            this.devCoTile.SymbolSize = 42F;
            this.devCoTile.Text = "<font size=\"+2\">6.</font>\r\n<br/>\r\n<font size=\"+4\">我的账户</font>\r\n<br/>管理我的账户";
            this.devCoTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet;
            // 
            // 
            // 
            this.devCoTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.devCoTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(61)))));
            this.devCoTile.TileStyle.BackColorGradientAngle = 45;
            this.devCoTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.devCoTile.TileStyle.PaddingBottom = 4;
            this.devCoTile.TileStyle.PaddingLeft = 4;
            this.devCoTile.TileStyle.PaddingRight = 4;
            this.devCoTile.TileStyle.PaddingTop = 4;
            this.devCoTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.devCoTile.TitleText = "My Account";
            // 
            // appViewTile
            // 
            this.appViewTile.Image = global::WoodenBench.Properties.Resources.Details;
            this.appViewTile.Name = "appViewTile";
            this.appViewTile.SymbolColor = System.Drawing.Color.Empty;
            this.appViewTile.Text = "<font size=\"+2\">7.</font>\r\n<br/>\r\n<font size=\"+4\">应用设置</font>\r\n<br/>更改首选项";
            this.appViewTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            // 
            // 
            // 
            this.appViewTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(55)))), ((int)(((byte)(76)))));
            this.appViewTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.appViewTile.TileStyle.BackColorGradientAngle = 45;
            this.appViewTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.appViewTile.TileStyle.PaddingBottom = 4;
            this.appViewTile.TileStyle.PaddingLeft = 4;
            this.appViewTile.TileStyle.PaddingRight = 4;
            this.appViewTile.TileStyle.PaddingTop = 4;
            this.appViewTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.appViewTile.TitleText = "Settings";
            // 
            // helpTile
            // 
            this.helpTile.Image = global::WoodenBench.Properties.Resources.Help;
            this.helpTile.Name = "helpTile";
            this.helpTile.SymbolColor = System.Drawing.Color.Empty;
            this.helpTile.Text = "<font size=\"+2\">8.</font>\r\n<br/>\r\n<font size=\"+4\">帮助</font>\r\n<br/>如何使用本软件";
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
            // 
            // salesTile
            // 
            this.salesTile.Name = "salesTile";
            this.salesTile.Symbol = "";
            this.salesTile.SymbolColor = System.Drawing.Color.Empty;
            this.salesTile.SymbolSize = 40F;
            this.salesTile.Text = "<font size=\"+2\">9.</font>\r\n<br/>\r\n<font size=\"+4\">注销</font>\r\n<br/>返回登录页面";
            this.salesTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            // 
            // 
            // 
            this.salesTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(76)))), ((int)(((byte)(41)))));
            this.salesTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(67)))), ((int)(((byte)(37)))));
            this.salesTile.TileStyle.BackColorGradientAngle = 45;
            this.salesTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.salesTile.TileStyle.PaddingBottom = 4;
            this.salesTile.TileStyle.PaddingLeft = 4;
            this.salesTile.TileStyle.PaddingRight = 4;
            this.salesTile.TileStyle.PaddingTop = 4;
            this.salesTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.salesTile.TitleText = "Exit";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(463, 7);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(115, 47);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "<div align=\"right\"><font size=\"+4\">Wile</font><br/>E. Coyote</div>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::WoodenBench.Properties.Resources.Person;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(584, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 33);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.Image = global::WoodenBench.Properties.Resources.Details;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem2.Text = "<font size=\"+4\">\r\nSwitch to\r\n<br/>\r\napp\r\n</font>";
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Maroon;
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(55)))), ((int)(((byte)(76)))));
            this.metroTileItem2.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.metroTileItem2.TileStyle.BackColorGradientAngle = 45;
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem2.TileStyle.PaddingBottom = 4;
            this.metroTileItem2.TileStyle.PaddingLeft = 4;
            this.metroTileItem2.TileStyle.PaddingRight = 4;
            this.metroTileItem2.TileStyle.PaddingTop = 4;
            this.metroTileItem2.TileStyle.TextColor = System.Drawing.Color.White;
            this.metroTileItem2.TitleText = "返回";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(21, 14);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(121, 40);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.TabIndex = 8;
            this.buttonX1.Text = "返回(&B)";
            this.buttonX1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // StartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.itemPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "StartControl";
            this.Size = new System.Drawing.Size(636, 420);
            this.Load += new System.EventHandler(this.StartControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem newInvoiceTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem newClientTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem salesTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem reportTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem unpaidTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem ytdTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem helpTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem devCoTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem appViewTile;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}
