namespace WoodenBench.View
{
    partial class Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Management));
            this.UsrManGroup = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_UpdateWebNoti = new System.Windows.Forms.Button();
            this.WebNotiTi = new System.Windows.Forms.TextBox();
            this.WebNotiCo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_UpdateWinNoti = new System.Windows.Forms.Button();
            this.WinNotiTi = new System.Windows.Forms.TextBox();
            this.WinNotiCon = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UsrManGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // UsrManGroup
            // 
            this.UsrManGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsrManGroup.Controls.Add(this.dataGridView1);
            this.UsrManGroup.Controls.Add(this.comboBox2);
            this.UsrManGroup.Controls.Add(this.comboBox1);
            this.UsrManGroup.Controls.Add(this.label5);
            this.UsrManGroup.Location = new System.Drawing.Point(3, 231);
            this.UsrManGroup.Name = "UsrManGroup";
            this.UsrManGroup.Size = new System.Drawing.Size(545, 273);
            this.UsrManGroup.TabIndex = 2;
            this.UsrManGroup.TabStop = false;
            this.UsrManGroup.Text = "用户管理";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "true",
            "false"});
            this.comboBox2.Location = new System.Drawing.Point(123, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(410, 20);
            this.comboBox2.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "objectId",
            "Username",
            "Password",
            "RealName",
            "UsrGroup",
            "IsFstLgn",
            "WebNotiSeen",
            "WeChatID"});
            this.comboBox1.Location = new System.Drawing.Point(6, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "==";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_UpdateWebNoti);
            this.groupBox2.Controls.Add(this.WebNotiTi);
            this.groupBox2.Controls.Add(this.WebNotiCo);
            this.groupBox2.Location = new System.Drawing.Point(431, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 222);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WEB 端通知";
            // 
            // Btn_UpdateWebNoti
            // 
            this.Btn_UpdateWebNoti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_UpdateWebNoti.Location = new System.Drawing.Point(6, 193);
            this.Btn_UpdateWebNoti.Name = "Btn_UpdateWebNoti";
            this.Btn_UpdateWebNoti.Size = new System.Drawing.Size(386, 22);
            this.Btn_UpdateWebNoti.TabIndex = 4;
            this.Btn_UpdateWebNoti.Text = "更新";
            this.Btn_UpdateWebNoti.UseVisualStyleBackColor = true;
            // 
            // WebNotiTi
            // 
            this.WebNotiTi.Dock = System.Windows.Forms.DockStyle.Top;
            this.WebNotiTi.Location = new System.Drawing.Point(3, 17);
            this.WebNotiTi.Name = "WebNotiTi";
            this.WebNotiTi.Size = new System.Drawing.Size(392, 21);
            this.WebNotiTi.TabIndex = 2;
            // 
            // WebNotiCo
            // 
            this.WebNotiCo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebNotiCo.Location = new System.Drawing.Point(6, 44);
            this.WebNotiCo.Multiline = true;
            this.WebNotiCo.Name = "WebNotiCo";
            this.WebNotiCo.Size = new System.Drawing.Size(386, 143);
            this.WebNotiCo.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_UpdateWinNoti);
            this.groupBox1.Controls.Add(this.WinNotiTi);
            this.groupBox1.Controls.Add(this.WinNotiCon);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 222);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Windows 客户端通知";
            // 
            // Btn_UpdateWinNoti
            // 
            this.Btn_UpdateWinNoti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_UpdateWinNoti.Location = new System.Drawing.Point(6, 193);
            this.Btn_UpdateWinNoti.Name = "Btn_UpdateWinNoti";
            this.Btn_UpdateWinNoti.Size = new System.Drawing.Size(410, 22);
            this.Btn_UpdateWinNoti.TabIndex = 2;
            this.Btn_UpdateWinNoti.Text = "更新";
            this.Btn_UpdateWinNoti.UseVisualStyleBackColor = true;
            this.Btn_UpdateWinNoti.Click += new System.EventHandler(this.BtnWinUpdate);
            // 
            // WinNotiTi
            // 
            this.WinNotiTi.Dock = System.Windows.Forms.DockStyle.Top;
            this.WinNotiTi.Location = new System.Drawing.Point(3, 17);
            this.WinNotiTi.Name = "WinNotiTi";
            this.WinNotiTi.Size = new System.Drawing.Size(416, 21);
            this.WinNotiTi.TabIndex = 0;
            // 
            // WinNotiCon
            // 
            this.WinNotiCon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WinNotiCon.Location = new System.Drawing.Point(6, 44);
            this.WinNotiCon.Multiline = true;
            this.WinNotiCon.Name = "WinNotiCon";
            this.WinNotiCon.Size = new System.Drawing.Size(410, 143);
            this.WinNotiCon.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.UsrManGroup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(857, 637);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(524, 221);
            this.dataGridView1.TabIndex = 3;
            // 
            // Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 637);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Management";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "管理页面";
            this.Load += new System.EventHandler(this.Management_Load);
            this.UsrManGroup.ResumeLayout(false);
            this.UsrManGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox UsrManGroup;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox WebNotiTi;
        private System.Windows.Forms.TextBox WebNotiCo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox WinNotiTi;
        private System.Windows.Forms.TextBox WinNotiCon;
        private System.Windows.Forms.Button Btn_UpdateWinNoti;
        private System.Windows.Forms.Button Btn_UpdateWebNoti;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}