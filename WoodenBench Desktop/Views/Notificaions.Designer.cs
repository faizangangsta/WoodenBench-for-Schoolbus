namespace WBPlatform.WinClient.Views
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制这条消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMessage = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.msgContent = new System.Windows.Forms.TextBox();
            this.msgType = new System.Windows.Forms.TextBox();
            this.msgRecvID = new System.Windows.Forms.TextBox();
            this.msgTime = new System.Windows.Forms.TextBox();
            this.msgSendID = new System.Windows.Forms.TextBox();
            this.msgTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.copyMessage = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.loadMessage);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 432);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消息列表";
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
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(6, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(436, 356);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "发送者";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "发送时间";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "内容概要";
            this.columnHeader3.Width = 204;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看消息ToolStripMenuItem,
            this.复制这条消息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // 查看消息ToolStripMenuItem
            // 
            this.查看消息ToolStripMenuItem.Name = "查看消息ToolStripMenuItem";
            this.查看消息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.查看消息ToolStripMenuItem.Text = "查看消息";
            // 
            // 复制这条消息ToolStripMenuItem
            // 
            this.复制这条消息ToolStripMenuItem.Name = "复制这条消息ToolStripMenuItem";
            this.复制这条消息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.复制这条消息ToolStripMenuItem.Text = "复制这条消息";
            // 
            // loadMessage
            // 
            this.loadMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.loadMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadMessage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.loadMessage.Location = new System.Drawing.Point(6, 384);
            this.loadMessage.Name = "loadMessage";
            this.loadMessage.Size = new System.Drawing.Size(436, 42);
            this.loadMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.loadMessage.TabIndex = 2;
            this.loadMessage.Text = "加载所有通知";
            this.loadMessage.Click += new System.EventHandler(this.loadMessage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "注意：这里只能查询最近100条消息哦！";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox4.Location = new System.Drawing.Point(466, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(406, 356);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "查看消息";
            // 
            // msgContent
            // 
            this.msgContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgContent.Location = new System.Drawing.Point(84, 182);
            this.msgContent.Multiline = true;
            this.msgContent.Name = "msgContent";
            this.msgContent.Size = new System.Drawing.Size(289, 156);
            this.msgContent.TabIndex = 1;
            this.msgContent.Text = "`";
            // 
            // msgType
            // 
            this.msgType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgType.Location = new System.Drawing.Point(84, 150);
            this.msgType.Name = "msgType";
            this.msgType.Size = new System.Drawing.Size(289, 23);
            this.msgType.TabIndex = 1;
            this.msgType.Text = "`";
            // 
            // msgRecvID
            // 
            this.msgRecvID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgRecvID.Location = new System.Drawing.Point(84, 121);
            this.msgRecvID.Name = "msgRecvID";
            this.msgRecvID.Size = new System.Drawing.Size(289, 23);
            this.msgRecvID.TabIndex = 1;
            // 
            // msgTime
            // 
            this.msgTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgTime.Location = new System.Drawing.Point(84, 63);
            this.msgTime.Name = "msgTime";
            this.msgTime.Size = new System.Drawing.Size(289, 23);
            this.msgTime.TabIndex = 1;
            // 
            // msgSendID
            // 
            this.msgSendID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgSendID.Location = new System.Drawing.Point(84, 92);
            this.msgSendID.Name = "msgSendID";
            this.msgSendID.Size = new System.Drawing.Size(289, 23);
            this.msgSendID.TabIndex = 1;
            // 
            // msgTitle
            // 
            this.msgTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgTitle.Location = new System.Drawing.Point(84, 34);
            this.msgTitle.Name = "msgTitle";
            this.msgTitle.Size = new System.Drawing.Size(289, 23);
            this.msgTitle.TabIndex = 1;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "消息类型";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "发送时间";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "消息标题";
            // 
            // copyMessage
            // 
            this.copyMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.copyMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyMessage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.copyMessage.Location = new System.Drawing.Point(466, 396);
            this.copyMessage.Name = "copyMessage";
            this.copyMessage.Size = new System.Drawing.Size(406, 42);
            this.copyMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.copyMessage.TabIndex = 2;
            this.copyMessage.Text = "复制消息";
            this.copyMessage.Click += new System.EventHandler(this.copyMessage_Click);
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 459);
            this.Controls.Add(this.copyMessage);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1020, 694);
            this.MinimumSize = new System.Drawing.Size(903, 498);
            this.Name = "Notifications";
            this.Text = "通知查看";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusesManager_FormClosing);
            this.Load += new System.EventHandler(this.BusesManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn leavingCheckedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn comingCheckedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
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
        private DevComponents.DotNetBar.ButtonX copyMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制这条消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看消息ToolStripMenuItem;
    }
}

