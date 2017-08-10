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
            this.TutorProcessExcelGroup = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NowPartOSchoolLbl = new System.Windows.Forms.Label();
            this.NowClassLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StudentData = new System.Windows.Forms.DataGridView();
            this.DataStuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataStuDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SureAndUploadBtn = new System.Windows.Forms.Button();
            this.ExcelFilePathTxt = new System.Windows.Forms.TextBox();
            this.ExcelFileOpenBtn = new System.Windows.Forms.Button();
            this.OpenExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.TutorProcessExcelGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TutorProcessExcelGroup
            // 
            this.TutorProcessExcelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TutorProcessExcelGroup.Controls.Add(this.groupBox1);
            this.TutorProcessExcelGroup.Controls.Add(this.StudentData);
            this.TutorProcessExcelGroup.Controls.Add(this.SureAndUploadBtn);
            this.TutorProcessExcelGroup.Controls.Add(this.ExcelFilePathTxt);
            this.TutorProcessExcelGroup.Controls.Add(this.ExcelFileOpenBtn);
            this.TutorProcessExcelGroup.Location = new System.Drawing.Point(12, 12);
            this.TutorProcessExcelGroup.Name = "TutorProcessExcelGroup";
            this.TutorProcessExcelGroup.Size = new System.Drawing.Size(904, 508);
            this.TutorProcessExcelGroup.TabIndex = 8;
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
            this.groupBox1.Location = new System.Drawing.Point(744, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 392);
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
            this.NowPartOSchoolLbl.Size = new System.Drawing.Size(142, 100);
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
            this.NowClassLbl.Size = new System.Drawing.Size(142, 39);
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
            this.DataStuDirection});
            this.StudentData.Location = new System.Drawing.Point(6, 56);
            this.StudentData.Name = "StudentData";
            this.StudentData.RowTemplate.Height = 23;
            this.StudentData.Size = new System.Drawing.Size(732, 442);
            this.StudentData.TabIndex = 4;
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
            // SureAndUploadBtn
            // 
            this.SureAndUploadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SureAndUploadBtn.Location = new System.Drawing.Point(744, 454);
            this.SureAndUploadBtn.Name = "SureAndUploadBtn";
            this.SureAndUploadBtn.Size = new System.Drawing.Size(154, 44);
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
            this.ExcelFilePathTxt.Size = new System.Drawing.Size(767, 21);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(928, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBar
            // 
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.StatusBar.Size = new System.Drawing.Size(913, 17);
            this.StatusBar.Spring = true;
            this.StatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExcelOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 554);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TutorProcessExcelGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelOperation";
            this.Text = "上传学生信息";
            this.Load += new System.EventHandler(this.ExcelOperation_Load);
            this.TutorProcessExcelGroup.ResumeLayout(false);
            this.TutorProcessExcelGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox TutorProcessExcelGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label NowPartOSchoolLbl;
        private System.Windows.Forms.Label NowClassLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView StudentData;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataStuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataStuDirection;
        private System.Windows.Forms.Button SureAndUploadBtn;
        private System.Windows.Forms.TextBox ExcelFilePathTxt;
        private System.Windows.Forms.Button ExcelFileOpenBtn;
        private System.Windows.Forms.OpenFileDialog OpenExcelFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar;
    }
}