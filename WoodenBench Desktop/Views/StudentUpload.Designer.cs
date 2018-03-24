﻿namespace WBServicePlatform.WinClient.Views
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelOperationWindow));
            this.StudentData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.objectIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusDirection = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LSChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CSChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CHChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentDataGridMenuS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除当前行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentDataBindSourc = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.SureAndUploadBtn = new DevComponents.DotNetBar.ButtonX();
            this.OpenExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExcelFilePathTxt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.BusDataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.objectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.busNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusTeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AHChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.updatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schoolBusObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClassPartOS = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExcelFileOpenBtn = new DevComponents.DotNetBar.ButtonX();
            this.ExDiscription = new System.Windows.Forms.Label();
            this.LoadExistStudents = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.ClassNum = new System.Windows.Forms.ComboBox();
            this.ClassYear = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ClsID = new System.Windows.Forms.Label();
            this.ClsDpt = new System.Windows.Forms.Label();
            this.ClsGrade = new System.Windows.Forms.Label();
            this.ClsNum = new System.Windows.Forms.Label();
            this.ClsTID = new System.Windows.Forms.Label();
            this.ClsTName = new System.Windows.Forms.Label();
            this.ClsTPhoneNum = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).BeginInit();
            this.StudentDataGridMenuS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataBindSourc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolBusObjectBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StudentData
            // 
            this.StudentData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentData.AutoGenerateColumns = false;
            this.StudentData.BackgroundColor = System.Drawing.Color.White;
            this.StudentData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.StudentData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objectIdDataGridViewTextBoxColumn,
            this.StudentName,
            this.BusDirection,
            this.BusID,
            this.ClassID,
            this.ParentID,
            this.LSChecked,
            this.CSChecked,
            this.CHChecked,
            this.updatedAtDataGridViewTextBoxColumn});
            this.StudentData.ContextMenuStrip = this.StudentDataGridMenuS;
            this.StudentData.DataSource = this.studentDataBindSourc;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentData.DefaultCellStyle = dataGridViewCellStyle2;
            this.StudentData.EnableHeadersVisualStyles = false;
            this.StudentData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.StudentData.Location = new System.Drawing.Point(9, 52);
            this.StudentData.MultiSelect = false;
            this.StudentData.Name = "StudentData";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.StudentData.RowTemplate.Height = 23;
            this.StudentData.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.Default;
            this.StudentData.SelectAllSignVisible = false;
            this.StudentData.Size = new System.Drawing.Size(837, 367);
            this.StudentData.TabIndex = 6;
            // 
            // objectIdDataGridViewTextBoxColumn
            // 
            this.objectIdDataGridViewTextBoxColumn.DataPropertyName = "objectId";
            this.objectIdDataGridViewTextBoxColumn.HeaderText = "学生ID";
            this.objectIdDataGridViewTextBoxColumn.Name = "objectIdDataGridViewTextBoxColumn";
            // 
            // StudentName
            // 
            this.StudentName.DataPropertyName = "StudentName";
            this.StudentName.HeaderText = "学生姓名";
            this.StudentName.Name = "StudentName";
            // 
            // BusDirection
            // 
            this.BusDirection.HeaderText = "校车方向";
            this.BusDirection.Name = "BusDirection";
            this.BusDirection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BusDirection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BusID
            // 
            this.BusID.DataPropertyName = "BusID";
            this.BusID.HeaderText = "校车ID";
            this.BusID.Name = "BusID";
            this.BusID.ReadOnly = true;
            // 
            // ClassID
            // 
            this.ClassID.DataPropertyName = "ClassID";
            this.ClassID.HeaderText = "班级ID";
            this.ClassID.Name = "ClassID";
            this.ClassID.ReadOnly = true;
            // 
            // ParentID
            // 
            this.ParentID.DataPropertyName = "ParentID";
            this.ParentID.HeaderText = "家长ID";
            this.ParentID.Name = "ParentID";
            this.ParentID.ReadOnly = true;
            // 
            // LSChecked
            // 
            this.LSChecked.DataPropertyName = "LSChecked";
            this.LSChecked.HeaderText = "离校签到";
            this.LSChecked.Name = "LSChecked";
            this.LSChecked.ReadOnly = true;
            // 
            // CSChecked
            // 
            this.CSChecked.DataPropertyName = "CSChecked";
            this.CSChecked.HeaderText = "到家确认";
            this.CSChecked.Name = "CSChecked";
            this.CSChecked.ReadOnly = true;
            // 
            // CHChecked
            // 
            this.CHChecked.DataPropertyName = "CHChecked";
            this.CHChecked.HeaderText = "返校签到";
            this.CHChecked.Name = "CHChecked";
            this.CHChecked.ReadOnly = true;
            // 
            // updatedAtDataGridViewTextBoxColumn
            // 
            this.updatedAtDataGridViewTextBoxColumn.DataPropertyName = "updatedAt";
            this.updatedAtDataGridViewTextBoxColumn.HeaderText = "更新时间";
            this.updatedAtDataGridViewTextBoxColumn.Name = "updatedAtDataGridViewTextBoxColumn";
            this.updatedAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StudentDataGridMenuS
            // 
            this.StudentDataGridMenuS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除当前行ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.StudentDataGridMenuS.Name = "StudentDataGridMenuS";
            this.StudentDataGridMenuS.Size = new System.Drawing.Size(137, 48);
            // 
            // 删除当前行ToolStripMenuItem
            // 
            this.删除当前行ToolStripMenuItem.Name = "删除当前行ToolStripMenuItem";
            this.删除当前行ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除当前行ToolStripMenuItem.Text = "删除当前行";
            this.删除当前行ToolStripMenuItem.Click += new System.EventHandler(this.删除当前行ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // studentDataBindSourc
            // 
            this.studentDataBindSourc.DataSource = typeof(WBServicePlatform.TableObject.StudentObject);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "年级：";
            // 
            // SureAndUploadBtn
            // 
            this.SureAndUploadBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SureAndUploadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SureAndUploadBtn.Location = new System.Drawing.Point(926, 640);
            this.SureAndUploadBtn.Name = "SureAndUploadBtn";
            this.SureAndUploadBtn.Size = new System.Drawing.Size(188, 36);
            this.SureAndUploadBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SureAndUploadBtn.Symbol = "";
            this.SureAndUploadBtn.TabIndex = 3;
            this.SureAndUploadBtn.Text = "确认并上传(&S)";
            this.SureAndUploadBtn.Click += new System.EventHandler(this.SureAndUpload);
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
            this.ExcelFilePathTxt.Location = new System.Drawing.Point(131, 23);
            this.ExcelFilePathTxt.Name = "ExcelFilePathTxt";
            this.ExcelFilePathTxt.PreventEnterBeep = true;
            this.ExcelFilePathTxt.ReadOnly = true;
            this.ExcelFilePathTxt.Size = new System.Drawing.Size(715, 23);
            this.ExcelFilePathTxt.TabIndex = 7;
            this.ExcelFilePathTxt.WatermarkText = "Excel 文件位置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "学部：";
            // 
            // BusDataGrid
            // 
            this.BusDataGrid.AllowUserToAddRows = false;
            this.BusDataGrid.AllowUserToDeleteRows = false;
            this.BusDataGrid.AllowUserToOrderColumns = true;
            this.BusDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BusDataGrid.AutoGenerateColumns = false;
            this.BusDataGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BusDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.BusDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BusDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objectId,
            this.busNameDataGridViewTextBoxColumn,
            this.BusTeacherName,
            this.teacherIDDataGridViewTextBoxColumn,
            this.dataGridViewCheckBoxColumn1,
            this.AHChecked,
            this.dataGridViewCheckBoxColumn2,
            this.updatedAt});
            this.BusDataGrid.DataSource = this.schoolBusObjectBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BusDataGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.BusDataGrid.EnableHeadersVisualStyles = false;
            this.BusDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.BusDataGrid.Location = new System.Drawing.Point(6, 23);
            this.BusDataGrid.Name = "BusDataGrid";
            this.BusDataGrid.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BusDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.BusDataGrid.RowTemplate.Height = 23;
            this.BusDataGrid.SelectAllSignVisible = false;
            this.BusDataGrid.Size = new System.Drawing.Size(896, 204);
            this.BusDataGrid.TabIndex = 11;
            // 
            // objectId
            // 
            this.objectId.DataPropertyName = "objectId";
            this.objectId.HeaderText = "校车ID";
            this.objectId.Name = "objectId";
            this.objectId.ReadOnly = true;
            // 
            // busNameDataGridViewTextBoxColumn
            // 
            this.busNameDataGridViewTextBoxColumn.DataPropertyName = "BusName";
            this.busNameDataGridViewTextBoxColumn.HeaderText = "标识名称";
            this.busNameDataGridViewTextBoxColumn.Name = "busNameDataGridViewTextBoxColumn";
            this.busNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BusTeacherName
            // 
            this.BusTeacherName.HeaderText = "带车老师姓名";
            this.BusTeacherName.Name = "BusTeacherName";
            this.BusTeacherName.ReadOnly = true;
            this.BusTeacherName.Width = 120;
            // 
            // teacherIDDataGridViewTextBoxColumn
            // 
            this.teacherIDDataGridViewTextBoxColumn.DataPropertyName = "TeacherID";
            this.teacherIDDataGridViewTextBoxColumn.HeaderText = "带车老师ID";
            this.teacherIDDataGridViewTextBoxColumn.Name = "teacherIDDataGridViewTextBoxColumn";
            this.teacherIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "CSChecked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "返校确认";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // AHChecked
            // 
            this.AHChecked.DataPropertyName = "AHChecked";
            this.AHChecked.HeaderText = "到站确认";
            this.AHChecked.Name = "AHChecked";
            this.AHChecked.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "LSChecked";
            this.dataGridViewCheckBoxColumn2.HeaderText = "离校确认";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            // 
            // updatedAt
            // 
            this.updatedAt.DataPropertyName = "updatedAt";
            this.updatedAt.HeaderText = "上次更新时间";
            this.updatedAt.Name = "updatedAt";
            this.updatedAt.ReadOnly = true;
            this.updatedAt.Width = 120;
            // 
            // schoolBusObjectBindingSource
            // 
            this.schoolBusObjectBindingSource.DataSource = typeof(WBServicePlatform.TableObject.SchoolBusObject);
            // 
            // ClassPartOS
            // 
            this.ClassPartOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClassPartOS.BackColor = System.Drawing.Color.White;
            this.ClassPartOS.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.studentDataBindSourc, "StudentName", true));
            this.ClassPartOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassPartOS.ForeColor = System.Drawing.Color.Black;
            this.ClassPartOS.FormattingEnabled = true;
            this.ClassPartOS.Items.AddRange(new object[] {
            "小学部",
            "初中部",
            "普通高中部",
            "中加高中部",
            "剑桥高中部"});
            this.ClassPartOS.Location = new System.Drawing.Point(56, 22);
            this.ClassPartOS.Name = "ClassPartOS";
            this.ClassPartOS.Size = new System.Drawing.Size(164, 25);
            this.ClassPartOS.TabIndex = 12;
            this.ClassPartOS.SelectedIndexChanged += new System.EventHandler(this.StuPartOS_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.ExcelFileOpenBtn);
            this.groupBox1.Controls.Add(this.StudentData);
            this.groupBox1.Controls.Add(this.ExcelFilePathTxt);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(262, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 425);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打开并修改学生信息";
            // 
            // ExcelFileOpenBtn
            // 
            this.ExcelFileOpenBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ExcelFileOpenBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ExcelFileOpenBtn.Location = new System.Drawing.Point(9, 23);
            this.ExcelFileOpenBtn.Name = "ExcelFileOpenBtn";
            this.ExcelFileOpenBtn.Size = new System.Drawing.Size(116, 23);
            this.ExcelFileOpenBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ExcelFileOpenBtn.TabIndex = 14;
            this.ExcelFileOpenBtn.Text = "打开 Excel(&E)";
            this.ExcelFileOpenBtn.Click += new System.EventHandler(this.OpenExcel);
            // 
            // ExDiscription
            // 
            this.ExDiscription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExDiscription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExDiscription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ExDiscription.Location = new System.Drawing.Point(926, 443);
            this.ExDiscription.Name = "ExDiscription";
            this.ExDiscription.Size = new System.Drawing.Size(188, 194);
            this.ExDiscription.TabIndex = 19;
            this.ExDiscription.Text = "                  ";
            // 
            // LoadExistStudents
            // 
            this.LoadExistStudents.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LoadExistStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadExistStudents.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.LoadExistStudents.Location = new System.Drawing.Point(6, 122);
            this.LoadExistStudents.Name = "LoadExistStudents";
            this.LoadExistStudents.Size = new System.Drawing.Size(214, 35);
            this.LoadExistStudents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoadExistStudents.TabIndex = 13;
            this.LoadExistStudents.Text = "加载班级数据";
            this.LoadExistStudents.Click += new System.EventHandler(this.LoadExistStudents_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "班级：";
            // 
            // ClassNum
            // 
            this.ClassNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClassNum.BackColor = System.Drawing.Color.White;
            this.ClassNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassNum.ForeColor = System.Drawing.Color.Black;
            this.ClassNum.FormattingEnabled = true;
            this.ClassNum.Items.AddRange(new object[] {
            "一班",
            "二班",
            "三班",
            "四班",
            "五班",
            "六班",
            "七班",
            "八班",
            "九班"});
            this.ClassNum.Location = new System.Drawing.Point(56, 84);
            this.ClassNum.MaxDropDownItems = 10;
            this.ClassNum.Name = "ClassNum";
            this.ClassNum.Size = new System.Drawing.Size(164, 25);
            this.ClassNum.TabIndex = 12;
            // 
            // ClassYear
            // 
            this.ClassYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClassYear.BackColor = System.Drawing.Color.White;
            this.ClassYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassYear.ForeColor = System.Drawing.Color.Black;
            this.ClassYear.FormattingEnabled = true;
            this.ClassYear.Items.AddRange(new object[] {
            "请选择学部"});
            this.ClassYear.Location = new System.Drawing.Point(56, 53);
            this.ClassYear.Name = "ClassYear";
            this.ClassYear.Size = new System.Drawing.Size(164, 25);
            this.ClassYear.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.BusDataGrid);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 443);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(908, 233);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "校车信息";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(18, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 425);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "班级数据";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.ClassPartOS);
            this.groupBox5.Controls.Add(this.LoadExistStudents);
            this.groupBox5.Controls.Add(this.ClassYear);
            this.groupBox5.Controls.Add(this.ClassNum);
            this.groupBox5.Location = new System.Drawing.Point(6, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(226, 163);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "加载班级信息";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.ClsID);
            this.groupBox4.Controls.Add(this.ClsDpt);
            this.groupBox4.Controls.Add(this.ClsGrade);
            this.groupBox4.Controls.Add(this.ClsNum);
            this.groupBox4.Controls.Add(this.ClsTID);
            this.groupBox4.Controls.Add(this.ClsTName);
            this.groupBox4.Controls.Add(this.ClsTPhoneNum);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(6, 191);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(226, 228);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "班级信息";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "班主任手机号码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "班主任姓名：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "班主任ID：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "班级：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "年级：";
            // 
            // ClsID
            // 
            this.ClsID.AutoSize = true;
            this.ClsID.Location = new System.Drawing.Point(124, 44);
            this.ClsID.Name = "ClsID";
            this.ClsID.Size = new System.Drawing.Size(0, 17);
            this.ClsID.TabIndex = 0;
            // 
            // ClsDpt
            // 
            this.ClsDpt.AutoSize = true;
            this.ClsDpt.Location = new System.Drawing.Point(124, 66);
            this.ClsDpt.Name = "ClsDpt";
            this.ClsDpt.Size = new System.Drawing.Size(0, 17);
            this.ClsDpt.TabIndex = 0;
            // 
            // ClsGrade
            // 
            this.ClsGrade.AutoSize = true;
            this.ClsGrade.Location = new System.Drawing.Point(124, 90);
            this.ClsGrade.Name = "ClsGrade";
            this.ClsGrade.Size = new System.Drawing.Size(0, 17);
            this.ClsGrade.TabIndex = 0;
            // 
            // ClsNum
            // 
            this.ClsNum.AutoSize = true;
            this.ClsNum.Location = new System.Drawing.Point(124, 114);
            this.ClsNum.Name = "ClsNum";
            this.ClsNum.Size = new System.Drawing.Size(0, 17);
            this.ClsNum.TabIndex = 0;
            // 
            // ClsTID
            // 
            this.ClsTID.AutoSize = true;
            this.ClsTID.Location = new System.Drawing.Point(124, 138);
            this.ClsTID.Name = "ClsTID";
            this.ClsTID.Size = new System.Drawing.Size(0, 17);
            this.ClsTID.TabIndex = 0;
            // 
            // ClsTName
            // 
            this.ClsTName.AutoSize = true;
            this.ClsTName.Location = new System.Drawing.Point(124, 162);
            this.ClsTName.Name = "ClsTName";
            this.ClsTName.Size = new System.Drawing.Size(0, 17);
            this.ClsTName.TabIndex = 0;
            // 
            // ClsTPhoneNum
            // 
            this.ClsTPhoneNum.AutoSize = true;
            this.ClsTPhoneNum.Location = new System.Drawing.Point(124, 187);
            this.ClsTPhoneNum.Name = "ClsTPhoneNum";
            this.ClsTPhoneNum.Size = new System.Drawing.Size(0, 17);
            this.ClsTPhoneNum.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(61, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "班级ID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "学部：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前选择的班级：";
            // 
            // statusPanel
            // 
            this.statusPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Location = new System.Drawing.Point(393, 267);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(372, 113);
            this.statusPanel.TabIndex = 15;
            this.statusPanel.Visible = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(370, 111);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "当前状态";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExcelOperationWindow
            // 
            this.ClientSize = new System.Drawing.Size(1126, 688);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.ExDiscription);
            this.Controls.Add(this.SureAndUploadBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelOperationWindow";
            this.Text = "上传学生数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExcelOperationWindow_FormClosing);
            this.Load += new System.EventHandler(this.ExcelOperationWindow_Load);
            this.Shown += new System.EventHandler(this.ExcelOperationWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).EndInit();
            this.StudentDataGridMenuS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentDataBindSourc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolBusObjectBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX SureAndUploadBtn;
        private System.Windows.Forms.OpenFileDialog OpenExcelFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuBusDirection;
        private DevComponents.DotNetBar.Controls.TextBoxX ExcelFilePathTxt;
        private System.Windows.Forms.BindingSource studentDataBindSourc;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.DataGridViewX BusDataGrid;
        private System.Windows.Forms.ComboBox ClassPartOS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ClassYear;
        private DevComponents.DotNetBar.ButtonX ExcelFileOpenBtn;
        private DevComponents.DotNetBar.ButtonX LoadExistStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ClassNum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPartOfSchoolDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentYearDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentClassDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentDirectionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherStuDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource schoolBusObjectBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX StudentData;
        private System.Windows.Forms.ContextMenuStrip StudentDataGridMenuS;
        private System.Windows.Forms.ToolStripMenuItem 删除当前行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPartOfSchoolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentDirectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label ExDiscription;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn busNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusTeacherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AHChecked;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAt;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ClsDpt;
        private System.Windows.Forms.Label ClsGrade;
        private System.Windows.Forms.Label ClsNum;
        private System.Windows.Forms.Label ClsTID;
        private System.Windows.Forms.Label ClsTName;
        private System.Windows.Forms.Label ClsTPhoneNum;
        private System.Windows.Forms.Label ClsID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewComboBoxColumn BusDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LSChecked;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CSChecked;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label statusLabel;
    }
}