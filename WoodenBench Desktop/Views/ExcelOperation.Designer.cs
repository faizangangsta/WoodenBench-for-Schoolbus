namespace WoodenBench.Views
{
    partial class ExcelOperationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelOperationWindow));
            this.StudentData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StuDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NowPartOSchoolLbl = new System.Windows.Forms.Label();
            this.NowClassLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SureAndUploadBtn = new DevComponents.DotNetBar.ButtonX();
            this.ExcelFileOpenBtn = new DevComponents.DotNetBar.ButtonX();
            this.OpenExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExcelFilePathTxt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.ExDiscription = new DevComponents.DotNetBar.LabelItem();
            this.radialMenu2 = new DevComponents.DotNetBar.RadialMenu();
            this.radialMenuItem1 = new DevComponents.DotNetBar.RadialMenuItem();
            this.radialMenuItem2 = new DevComponents.DotNetBar.RadialMenuItem();
            this.radialMenuItem3 = new DevComponents.DotNetBar.RadialMenuItem();
            this.radialMenuItem4 = new DevComponents.DotNetBar.RadialMenuItem();
            this.radialMenuItem5 = new DevComponents.DotNetBar.RadialMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StudentData
            // 
            this.StudentData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentName,
            this.StudentClass,
            this.StuDepartment,
            this.BusDirection});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentData.DefaultCellStyle = dataGridViewCellStyle1;
            this.StudentData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.StudentData.Location = new System.Drawing.Point(12, 29);
            this.StudentData.Name = "StudentData";
            this.StudentData.RowTemplate.Height = 23;
            this.StudentData.Size = new System.Drawing.Size(731, 497);
            this.StudentData.TabIndex = 6;
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "学生姓名";
            this.StudentName.Name = "StudentName";
            this.StudentName.Width = 150;
            // 
            // StudentClass
            // 
            this.StudentClass.HeaderText = "班级";
            this.StudentClass.Name = "StudentClass";
            this.StudentClass.ReadOnly = true;
            // 
            // StuDepartment
            // 
            this.StuDepartment.HeaderText = "学部";
            this.StuDepartment.Name = "StuDepartment";
            // 
            // BusDirection
            // 
            this.BusDirection.HeaderText = "校车方向";
            this.BusDirection.Name = "BusDirection";
            this.BusDirection.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.NowPartOSchoolLbl);
            this.groupBox1.Controls.Add(this.NowClassLbl);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(749, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 345);
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
            this.NowPartOSchoolLbl.Size = new System.Drawing.Size(155, 106);
            this.NowPartOSchoolLbl.TabIndex = 2;
            this.NowPartOSchoolLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NowClassLbl
            // 
            this.NowClassLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NowClassLbl.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.NowClassLbl.Location = new System.Drawing.Point(6, 35);
            this.NowClassLbl.Name = "NowClassLbl";
            this.NowClassLbl.Size = new System.Drawing.Size(155, 39);
            this.NowClassLbl.TabIndex = 2;
            this.NowClassLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // SureAndUploadBtn
            // 
            this.SureAndUploadBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SureAndUploadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SureAndUploadBtn.Location = new System.Drawing.Point(749, 482);
            this.SureAndUploadBtn.Name = "SureAndUploadBtn";
            this.SureAndUploadBtn.Size = new System.Drawing.Size(167, 44);
            this.SureAndUploadBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SureAndUploadBtn.Symbol = "";
            this.SureAndUploadBtn.TabIndex = 3;
            this.SureAndUploadBtn.Text = "确认并上传(&S)";
            this.SureAndUploadBtn.Click += new System.EventHandler(this.SureAndUpload);
            // 
            // ExcelFileOpenBtn
            // 
            this.ExcelFileOpenBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ExcelFileOpenBtn.Location = new System.Drawing.Point(12, 2);
            this.ExcelFileOpenBtn.Name = "ExcelFileOpenBtn";
            this.ExcelFileOpenBtn.Size = new System.Drawing.Size(118, 21);
            this.ExcelFileOpenBtn.TabIndex = 0;
            this.ExcelFileOpenBtn.Text = "打开Excel文件(&O)";
            this.ExcelFileOpenBtn.Click += new System.EventHandler(this.OpenExcel);
            // 
            // OpenExcelFileDialog
            // 
            this.OpenExcelFileDialog.DefaultExt = "*.xls;*.xlsx";
            this.OpenExcelFileDialog.Filter = "Excel 表格(2007)|*.xlsx|Excel 表格(2003)|*.xls";
            this.OpenExcelFileDialog.Title = "打开一个 Excel 文件";
            // 
            // ExcelFilePathTxt
            // 
            this.ExcelFilePathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExcelFilePathTxt.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ExcelFilePathTxt.Border.Class = "TextBoxBorder";
            this.ExcelFilePathTxt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ExcelFilePathTxt.DisabledBackColor = System.Drawing.Color.White;
            this.ExcelFilePathTxt.ForeColor = System.Drawing.Color.Black;
            this.ExcelFilePathTxt.Location = new System.Drawing.Point(137, 2);
            this.ExcelFilePathTxt.Name = "ExcelFilePathTxt";
            this.ExcelFilePathTxt.PreventEnterBeep = true;
            this.ExcelFilePathTxt.Size = new System.Drawing.Size(779, 21);
            this.ExcelFilePathTxt.TabIndex = 7;
            // 
            // metroStatusBar1
            // 
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.DragDropSupport = true;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ExDiscription});
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 532);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(928, 22);
            this.metroStatusBar1.TabIndex = 8;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // ExDiscription
            // 
            this.ExDiscription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExDiscription.Name = "ExDiscription";
            this.ExDiscription.Symbol = "";
            this.ExDiscription.SymbolSize = 13F;
            this.ExDiscription.Text = "打开Excel文件并上传学生数据";
            // 
            // radialMenu2
            // 
            // 
            // 
            // 
            this.radialMenu2.Colors.RadialMenuItemDisabledForeground = System.Drawing.Color.Empty;
            this.radialMenu2.Diameter = 200;
            this.radialMenu2.Image = global::WoodenBench.Properties.Resources.RadialMenuIcon;
            this.radialMenu2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.radialMenuItem1,
            this.radialMenuItem2,
            this.radialMenuItem3,
            this.radialMenuItem4,
            this.radialMenuItem5});
            this.radialMenu2.Location = new System.Drawing.Point(806, 419);
            this.radialMenu2.MenuType = DevComponents.DotNetBar.eRadialMenuType.Circular;
            this.radialMenu2.Name = "radialMenu2";
            this.radialMenu2.Size = new System.Drawing.Size(28, 28);
            this.radialMenu2.TabIndex = 5;
            this.radialMenu2.Text = "radialMenu2";
            // 
            // radialMenuItem1
            // 
            this.radialMenuItem1.CircularBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(71)))));
            this.radialMenuItem1.CircularMenuDiameter = 28;
            this.radialMenuItem1.Name = "radialMenuItem1";
            this.radialMenuItem1.Symbol = "";
            this.radialMenuItem1.Text = "Item 1";
            // 
            // radialMenuItem2
            // 
            this.radialMenuItem2.CircularBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(72)))), ((int)(((byte)(35)))));
            this.radialMenuItem2.CircularMenuDiameter = 28;
            this.radialMenuItem2.Name = "radialMenuItem2";
            this.radialMenuItem2.Symbol = "";
            this.radialMenuItem2.Text = "Item 2";
            // 
            // radialMenuItem3
            // 
            this.radialMenuItem3.CircularBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(202)))), ((int)(((byte)(98)))));
            this.radialMenuItem3.CircularMenuDiameter = 28;
            this.radialMenuItem3.Name = "radialMenuItem3";
            this.radialMenuItem3.Symbol = "";
            this.radialMenuItem3.Text = "Item 3";
            // 
            // radialMenuItem4
            // 
            this.radialMenuItem4.CircularBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(112)))), ((int)(((byte)(22)))));
            this.radialMenuItem4.CircularMenuDiameter = 28;
            this.radialMenuItem4.Name = "radialMenuItem4";
            this.radialMenuItem4.Symbol = "";
            this.radialMenuItem4.Text = "Item 4";
            // 
            // radialMenuItem5
            // 
            this.radialMenuItem5.CircularBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.radialMenuItem5.CircularMenuDiameter = 28;
            this.radialMenuItem5.Name = "radialMenuItem5";
            this.radialMenuItem5.Symbol = "";
            this.radialMenuItem5.Text = "Item 5";
            // 
            // ExcelOperationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 554);
            this.Controls.Add(this.radialMenu2);
            this.Controls.Add(this.metroStatusBar1);
            this.Controls.Add(this.ExcelFilePathTxt);
            this.Controls.Add(this.StudentData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExcelFileOpenBtn);
            this.Controls.Add(this.SureAndUploadBtn);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelOperationWindow";
            this.Text = "上传学生数据";
            this.Load += new System.EventHandler(this.ExcelOperation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem1;
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem2;
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem3;
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem4;
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label NowPartOSchoolLbl;
        private System.Windows.Forms.Label NowClassLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX SureAndUploadBtn;
        private DevComponents.DotNetBar.ButtonX ExcelFileOpenBtn;
        private System.Windows.Forms.OpenFileDialog OpenExcelFileDialog;
        private DevComponents.DotNetBar.Controls.DataGridViewX StudentData;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuBusDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusDirection;
        private DevComponents.DotNetBar.Controls.TextBoxX ExcelFilePathTxt;
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem ExDiscription;
        private DevComponents.DotNetBar.RadialMenu radialMenu2;
    }
}