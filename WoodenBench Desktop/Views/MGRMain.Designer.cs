namespace WoodenBench.Views
{
    partial class ManagementWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagementWindow));
            this.UsrManGroup = new System.Windows.Forms.GroupBox();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.webNotiSeenDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.weChatIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headImgDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allUserObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UsrManGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allUserObjectBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsrManGroup
            // 
            this.UsrManGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsrManGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.UsrManGroup.Controls.Add(this.dataGridViewX1);
            this.UsrManGroup.Controls.Add(this.comboBox2);
            this.UsrManGroup.Controls.Add(this.comboBox1);
            this.UsrManGroup.Controls.Add(this.label5);
            this.UsrManGroup.ForeColor = System.Drawing.Color.Black;
            this.UsrManGroup.Location = new System.Drawing.Point(12, 228);
            this.UsrManGroup.Name = "UsrManGroup";
            this.UsrManGroup.Size = new System.Drawing.Size(1016, 267);
            this.UsrManGroup.TabIndex = 2;
            this.UsrManGroup.TabStop = false;
            this.UsrManGroup.Text = "用户管理";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.userGroupDataGridViewTextBoxColumn,
            this.webNotiSeenDataGridViewCheckBoxColumn,
            this.weChatIDDataGridViewTextBoxColumn,
            this.realNameDataGridViewTextBoxColumn,
            this.headImgDataDataGridViewTextBoxColumn,
            this.userImageDataGridViewImageColumn,
            this.typeDataGridViewTextBoxColumn,
            this.objectIdDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.updatedAtDataGridViewTextBoxColumn,
            this.aCLDataGridViewTextBoxColumn});
            this.dataGridViewX1.DataSource = this.allUserObjectBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(157)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(9, 46);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(995, 215);
            this.dataGridViewX1.TabIndex = 3;
            // 
            // tableDataGridViewTextBoxColumn
            // 
            this.tableDataGridViewTextBoxColumn.DataPropertyName = "table";
            this.tableDataGridViewTextBoxColumn.HeaderText = "table";
            this.tableDataGridViewTextBoxColumn.Name = "tableDataGridViewTextBoxColumn";
            this.tableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            // 
            // userGroupDataGridViewTextBoxColumn
            // 
            this.userGroupDataGridViewTextBoxColumn.DataPropertyName = "UserGroup";
            this.userGroupDataGridViewTextBoxColumn.HeaderText = "UserGroup";
            this.userGroupDataGridViewTextBoxColumn.Name = "userGroupDataGridViewTextBoxColumn";
            // 
            // webNotiSeenDataGridViewCheckBoxColumn
            // 
            this.webNotiSeenDataGridViewCheckBoxColumn.DataPropertyName = "WebNotiSeen";
            this.webNotiSeenDataGridViewCheckBoxColumn.HeaderText = "WebNotiSeen";
            this.webNotiSeenDataGridViewCheckBoxColumn.Name = "webNotiSeenDataGridViewCheckBoxColumn";
            // 
            // weChatIDDataGridViewTextBoxColumn
            // 
            this.weChatIDDataGridViewTextBoxColumn.DataPropertyName = "WeChatID";
            this.weChatIDDataGridViewTextBoxColumn.HeaderText = "WeChatID";
            this.weChatIDDataGridViewTextBoxColumn.Name = "weChatIDDataGridViewTextBoxColumn";
            // 
            // realNameDataGridViewTextBoxColumn
            // 
            this.realNameDataGridViewTextBoxColumn.DataPropertyName = "RealName";
            this.realNameDataGridViewTextBoxColumn.HeaderText = "RealName";
            this.realNameDataGridViewTextBoxColumn.Name = "realNameDataGridViewTextBoxColumn";
            // 
            // headImgDataDataGridViewTextBoxColumn
            // 
            this.headImgDataDataGridViewTextBoxColumn.DataPropertyName = "HeadImgData";
            this.headImgDataDataGridViewTextBoxColumn.HeaderText = "HeadImgData";
            this.headImgDataDataGridViewTextBoxColumn.Name = "headImgDataDataGridViewTextBoxColumn";
            // 
            // userImageDataGridViewImageColumn
            // 
            this.userImageDataGridViewImageColumn.DataPropertyName = "UserImage";
            this.userImageDataGridViewImageColumn.HeaderText = "UserImage";
            this.userImageDataGridViewImageColumn.Name = "userImageDataGridViewImageColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "_type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "_type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // objectIdDataGridViewTextBoxColumn
            // 
            this.objectIdDataGridViewTextBoxColumn.DataPropertyName = "objectId";
            this.objectIdDataGridViewTextBoxColumn.HeaderText = "objectId";
            this.objectIdDataGridViewTextBoxColumn.Name = "objectIdDataGridViewTextBoxColumn";
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "createdAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "createdAt";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            this.createdAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updatedAtDataGridViewTextBoxColumn
            // 
            this.updatedAtDataGridViewTextBoxColumn.DataPropertyName = "updatedAt";
            this.updatedAtDataGridViewTextBoxColumn.HeaderText = "updatedAt";
            this.updatedAtDataGridViewTextBoxColumn.Name = "updatedAtDataGridViewTextBoxColumn";
            this.updatedAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aCLDataGridViewTextBoxColumn
            // 
            this.aCLDataGridViewTextBoxColumn.DataPropertyName = "ACL";
            this.aCLDataGridViewTextBoxColumn.HeaderText = "ACL";
            this.aCLDataGridViewTextBoxColumn.Name = "aCLDataGridViewTextBoxColumn";
            // 
            // allUserObjectBindingSource
            // 
            this.allUserObjectBindingSource.DataSource = typeof(WoodenBench.Users.AllUserObject);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.comboBox2.ForeColor = System.Drawing.Color.Black;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "true",
            "false"});
            this.comboBox2.Location = new System.Drawing.Point(126, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(878, 20);
            this.comboBox2.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
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
            this.comboBox1.Location = new System.Drawing.Point(9, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(103, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "==";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.groupBox2.Controls.Add(this.Btn_UpdateWebNoti);
            this.groupBox2.Controls.Add(this.WebNotiTi);
            this.groupBox2.Controls.Add(this.WebNotiCo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(511, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 216);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WEB 端通知";
            // 
            // Btn_UpdateWebNoti
            // 
            this.Btn_UpdateWebNoti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_UpdateWebNoti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.Btn_UpdateWebNoti.ForeColor = System.Drawing.Color.Black;
            this.Btn_UpdateWebNoti.Location = new System.Drawing.Point(6, 187);
            this.Btn_UpdateWebNoti.Name = "Btn_UpdateWebNoti";
            this.Btn_UpdateWebNoti.Size = new System.Drawing.Size(490, 22);
            this.Btn_UpdateWebNoti.TabIndex = 4;
            this.Btn_UpdateWebNoti.Text = "更新";
            this.Btn_UpdateWebNoti.UseVisualStyleBackColor = false;
            // 
            // WebNotiTi
            // 
            this.WebNotiTi.BackColor = System.Drawing.Color.White;
            this.WebNotiTi.Dock = System.Windows.Forms.DockStyle.Top;
            this.WebNotiTi.ForeColor = System.Drawing.Color.Black;
            this.WebNotiTi.Location = new System.Drawing.Point(3, 17);
            this.WebNotiTi.Name = "WebNotiTi";
            this.WebNotiTi.Size = new System.Drawing.Size(496, 21);
            this.WebNotiTi.TabIndex = 2;
            // 
            // WebNotiCo
            // 
            this.WebNotiCo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebNotiCo.BackColor = System.Drawing.Color.White;
            this.WebNotiCo.ForeColor = System.Drawing.Color.Black;
            this.WebNotiCo.Location = new System.Drawing.Point(6, 44);
            this.WebNotiCo.Multiline = true;
            this.WebNotiCo.Name = "WebNotiCo";
            this.WebNotiCo.Size = new System.Drawing.Size(490, 137);
            this.WebNotiCo.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.groupBox1.Controls.Add(this.Btn_UpdateWinNoti);
            this.groupBox1.Controls.Add(this.WinNotiTi);
            this.groupBox1.Controls.Add(this.WinNotiCon);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 216);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Windows 客户端通知";
            // 
            // Btn_UpdateWinNoti
            // 
            this.Btn_UpdateWinNoti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_UpdateWinNoti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.Btn_UpdateWinNoti.ForeColor = System.Drawing.Color.Black;
            this.Btn_UpdateWinNoti.Location = new System.Drawing.Point(6, 187);
            this.Btn_UpdateWinNoti.Name = "Btn_UpdateWinNoti";
            this.Btn_UpdateWinNoti.Size = new System.Drawing.Size(490, 22);
            this.Btn_UpdateWinNoti.TabIndex = 2;
            this.Btn_UpdateWinNoti.Text = "更新";
            this.Btn_UpdateWinNoti.UseVisualStyleBackColor = false;
            this.Btn_UpdateWinNoti.Click += new System.EventHandler(this.BtnWinUpdate);
            // 
            // WinNotiTi
            // 
            this.WinNotiTi.BackColor = System.Drawing.Color.White;
            this.WinNotiTi.Dock = System.Windows.Forms.DockStyle.Top;
            this.WinNotiTi.ForeColor = System.Drawing.Color.Black;
            this.WinNotiTi.Location = new System.Drawing.Point(3, 17);
            this.WinNotiTi.Name = "WinNotiTi";
            this.WinNotiTi.Size = new System.Drawing.Size(496, 21);
            this.WinNotiTi.TabIndex = 0;
            // 
            // WinNotiCon
            // 
            this.WinNotiCon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WinNotiCon.BackColor = System.Drawing.Color.White;
            this.WinNotiCon.ForeColor = System.Drawing.Color.Black;
            this.WinNotiCon.Location = new System.Drawing.Point(6, 44);
            this.WinNotiCon.Multiline = true;
            this.WinNotiCon.Name = "WinNotiCon";
            this.WinNotiCon.Size = new System.Drawing.Size(490, 137);
            this.WinNotiCon.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(198)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1016, 222);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ManagementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.UsrManGroup);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManagementWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "管理页面";
            this.Load += new System.EventHandler(this.Management_Load);
            this.UsrManGroup.ResumeLayout(false);
            this.UsrManGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allUserObjectBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn webNotiSeenDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weChatIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn realNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn headImgDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn userImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCLDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource allUserObjectBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}