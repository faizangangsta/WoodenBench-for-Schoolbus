namespace WBServicePlatform.WinClient.Views
{
    partial class Notifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notifications));
            this.singleCastMessages = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loadMessage = new DevComponents.DotNetBar.ButtonX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.msgTitle = new System.Windows.Forms.TextBox();
            this.msgSendID = new System.Windows.Forms.TextBox();
            this.msgRecvID = new System.Windows.Forms.TextBox();
            this.msgType = new System.Windows.Forms.TextBox();
            this.msgContent = new System.Windows.Forms.TextBox();
            this.msgTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.singleCastMessageCount = new System.Windows.Forms.Label();
            this.broadCastMessageCount = new System.Windows.Forms.Label();
            this.copyMessage = new DevComponents.DotNetBar.ButtonX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制这条消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.broadCastMessages = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.singleCastMessages)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.broadCastMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // singleCastMessages
            // 
            this.singleCastMessages.DataSource = typeof(WBServicePlatform.TableObject.NotificationObject);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.loadMessage);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 657);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消息列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 284);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发给我的消息（单播消息）";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 293);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 285);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发给大家的消息（广播消息）";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 581);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "注意：这里只能查询最近100条消息哦！";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Location = new System.Drawing.Point(6, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(453, 256);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "发送时间";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "发送者";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "内容概要";
            this.columnHeader3.Width = 221;
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader6});
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Location = new System.Drawing.Point(6, 22);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(453, 257);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "发送时间";
            this.columnHeader4.Width = 130;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "发送者";
            this.columnHeader5.Width = 88;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "内容概要";
            this.columnHeader6.Width = 222;
            // 
            // loadMessage
            // 
            this.loadMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.loadMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadMessage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.loadMessage.Location = new System.Drawing.Point(6, 609);
            this.loadMessage.Name = "loadMessage";
            this.loadMessage.Size = new System.Drawing.Size(471, 42);
            this.loadMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.loadMessage.TabIndex = 2;
            this.loadMessage.Text = "加载所有通知";
            this.loadMessage.Click += new System.EventHandler(this.loadMessage_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.copyMessage);
            this.groupBox4.Controls.Add(this.msgContent);
            this.groupBox4.Controls.Add(this.msgType);
            this.groupBox4.Controls.Add(this.msgRecvID);
            this.groupBox4.Controls.Add(this.msgTime);
            this.groupBox4.Controls.Add(this.msgSendID);
            this.groupBox4.Controls.Add(this.msgTitle);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(504, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(488, 590);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "消息查看";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "消息标题";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "发送者ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "接收者ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "消息类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "消息正文";
            // 
            // msgTitle
            // 
            this.msgTitle.Location = new System.Drawing.Point(84, 34);
            this.msgTitle.Name = "msgTitle";
            this.msgTitle.Size = new System.Drawing.Size(371, 23);
            this.msgTitle.TabIndex = 1;
            // 
            // msgSendID
            // 
            this.msgSendID.Location = new System.Drawing.Point(84, 92);
            this.msgSendID.Name = "msgSendID";
            this.msgSendID.Size = new System.Drawing.Size(371, 23);
            this.msgSendID.TabIndex = 1;
            // 
            // msgRecvID
            // 
            this.msgRecvID.Location = new System.Drawing.Point(84, 121);
            this.msgRecvID.Name = "msgRecvID";
            this.msgRecvID.Size = new System.Drawing.Size(371, 23);
            this.msgRecvID.TabIndex = 1;
            // 
            // msgType
            // 
            this.msgType.Location = new System.Drawing.Point(84, 150);
            this.msgType.Name = "msgType";
            this.msgType.Size = new System.Drawing.Size(371, 23);
            this.msgType.TabIndex = 1;
            // 
            // msgContent
            // 
            this.msgContent.Location = new System.Drawing.Point(84, 182);
            this.msgContent.Multiline = true;
            this.msgContent.Name = "msgContent";
            this.msgContent.Size = new System.Drawing.Size(371, 351);
            this.msgContent.TabIndex = 1;
            // 
            // msgTime
            // 
            this.msgTime.Location = new System.Drawing.Point(84, 63);
            this.msgTime.Name = "msgTime";
            this.msgTime.Size = new System.Drawing.Size(371, 23);
            this.msgTime.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "发送时间";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "发给我的消息总数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(549, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "广播消息总数：";
            // 
            // singleCastMessageCount
            // 
            this.singleCastMessageCount.AutoSize = true;
            this.singleCastMessageCount.Location = new System.Drawing.Point(647, 34);
            this.singleCastMessageCount.Name = "singleCastMessageCount";
            this.singleCastMessageCount.Size = new System.Drawing.Size(15, 17);
            this.singleCastMessageCount.TabIndex = 3;
            this.singleCastMessageCount.Text = "0";
            // 
            // broadCastMessageCount
            // 
            this.broadCastMessageCount.AutoSize = true;
            this.broadCastMessageCount.Location = new System.Drawing.Point(647, 54);
            this.broadCastMessageCount.Name = "broadCastMessageCount";
            this.broadCastMessageCount.Size = new System.Drawing.Size(15, 17);
            this.broadCastMessageCount.TabIndex = 3;
            this.broadCastMessageCount.Text = "0";
            // 
            // copyMessage
            // 
            this.copyMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.copyMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyMessage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.copyMessage.Location = new System.Drawing.Point(6, 542);
            this.copyMessage.Name = "copyMessage";
            this.copyMessage.Size = new System.Drawing.Size(476, 42);
            this.copyMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.copyMessage.TabIndex = 2;
            this.copyMessage.Text = "复制消息";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看消息ToolStripMenuItem,
            this.复制这条消息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // 复制这条消息ToolStripMenuItem
            // 
            this.复制这条消息ToolStripMenuItem.Name = "复制这条消息ToolStripMenuItem";
            this.复制这条消息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.复制这条消息ToolStripMenuItem.Text = "复制这条消息";
            // 
            // 查看消息ToolStripMenuItem
            // 
            this.查看消息ToolStripMenuItem.Name = "查看消息ToolStripMenuItem";
            this.查看消息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.查看消息ToolStripMenuItem.Text = "查看消息";
            // 
            // broadCastMessages
            // 
            this.broadCastMessages.DataSource = typeof(WBServicePlatform.TableObject.NotificationObject);
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 681);
            this.Controls.Add(this.broadCastMessageCount);
            this.Controls.Add(this.singleCastMessageCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1020, 720);
            this.MinimumSize = new System.Drawing.Size(1020, 720);
            this.Name = "Notifications";
            this.Text = "通知查看";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusesManager_FormClosing);
            this.Load += new System.EventHandler(this.BusesManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.singleCastMessages)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.broadCastMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn leavingCheckedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn comingCheckedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource singleCastMessages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevComponents.DotNetBar.ButtonX loadMessage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox msgContent;
        private System.Windows.Forms.TextBox msgType;
        private System.Windows.Forms.TextBox msgRecvID;
        private System.Windows.Forms.TextBox msgSendID;
        private System.Windows.Forms.TextBox msgTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox msgTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label singleCastMessageCount;
        private System.Windows.Forms.Label broadCastMessageCount;
        private DevComponents.DotNetBar.ButtonX copyMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制这条消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看消息ToolStripMenuItem;
        private System.Windows.Forms.BindingSource broadCastMessages;
    }
}

