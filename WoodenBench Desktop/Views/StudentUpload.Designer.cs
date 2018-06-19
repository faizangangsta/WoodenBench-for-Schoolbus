namespace WBPlatform.DesktopClient.Views
{
    partial class StudentUploadWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentUploadWindow));
            this.StudentData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.objectIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusDirection = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.BusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentDataBindSourc = new System.Windows.Forms.BindingSource(this.components);
            this.SureAndUploadBtn = new DevComponents.DotNetBar.ButtonX();
            this.OpenExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExcelFilePathTxt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.BusDataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.objectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.busNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.AHChecked = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.dataGridViewCheckBoxColumn2 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.updatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schoolBusObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExcelFileOpenBtn = new DevComponents.DotNetBar.ButtonX();
            this.ExDiscription = new System.Windows.Forms.ListBox();
            this.LoadExistStudents = new DevComponents.DotNetBar.ButtonX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radialMenu1 = new DevComponents.DotNetBar.RadialMenu();
            this.radialMenuItem1 = new DevComponents.DotNetBar.RadialMenuItem();
            this.radialMenuItem2 = new DevComponents.DotNetBar.RadialMenuItem();
            this.radialMenuItem3 = new DevComponents.DotNetBar.RadialMenuItem();
            this.radialMenuItem4 = new DevComponents.DotNetBar.RadialMenuItem();
            this.radialMenuItem5 = new DevComponents.DotNetBar.RadialMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ClsTPhoneNum = new System.Windows.Forms.Label();
            this.ClsTName = new System.Windows.Forms.Label();
            this.ClsTID = new System.Windows.Forms.Label();
            this.ClsNum = new System.Windows.Forms.Label();
            this.ClsGrade = new System.Windows.Forms.Label();
            this.ClsDpt = new System.Windows.Forms.Label();
            this.ClsID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataBindSourc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolBusObjectBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.updatedAtDataGridViewTextBoxColumn});
            this.StudentData.DataSource = this.studentDataBindSourc;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentData.DefaultCellStyle = dataGridViewCellStyle2;
            this.StudentData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
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
            this.StudentData.Size = new System.Drawing.Size(839, 377);
            this.StudentData.TabIndex = 6;
            this.StudentData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.StudentData_CellMouseClick);
            // 
            // objectIdDataGridViewTextBoxColumn
            // 
            this.objectIdDataGridViewTextBoxColumn.DataPropertyName = "objectId";
            this.objectIdDataGridViewTextBoxColumn.HeaderText = "学生ID";
            this.objectIdDataGridViewTextBoxColumn.Name = "objectIdDataGridViewTextBoxColumn";
            this.objectIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StudentName
            // 
            this.StudentName.DataPropertyName = "StudentName";
            this.StudentName.HeaderText = "学生姓名";
            this.StudentName.Name = "StudentName";
            // 
            // BusDirection
            // 
            this.BusDirection.DisplayMember = "Text";
            this.BusDirection.DropDownHeight = 106;
            this.BusDirection.DropDownWidth = 121;
            this.BusDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BusDirection.HeaderText = "校车方向";
            this.BusDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BusDirection.IntegralHeight = false;
            this.BusDirection.ItemHeight = 16;
            this.BusDirection.Name = "BusDirection";
            this.BusDirection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BusDirection.RightToLeft = System.Windows.Forms.RightToLeft.No;
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
            this.ParentID.DataPropertyName = "ParentsID";
            this.ParentID.HeaderText = "家长ID";
            this.ParentID.Name = "ParentID";
            this.ParentID.ReadOnly = true;
            this.ParentID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // updatedAtDataGridViewTextBoxColumn
            // 
            this.updatedAtDataGridViewTextBoxColumn.DataPropertyName = "updatedAt";
            this.updatedAtDataGridViewTextBoxColumn.HeaderText = "更新时间";
            this.updatedAtDataGridViewTextBoxColumn.Name = "updatedAtDataGridViewTextBoxColumn";
            this.updatedAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // studentDataBindSourc
            // 
            this.studentDataBindSourc.DataSource = typeof(WBPlatform.TableObject.StudentObject);
            // 
            // SureAndUploadBtn
            // 
            this.SureAndUploadBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SureAndUploadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SureAndUploadBtn.Location = new System.Drawing.Point(913, 650);
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
            this.ExcelFilePathTxt.Size = new System.Drawing.Size(717, 23);
            this.ExcelFilePathTxt.TabIndex = 7;
            this.ExcelFilePathTxt.WatermarkText = "Excel 文件位置";
            // 
            // BusDataGrid
            // 
            this.BusDataGrid.AllowUserToAddRows = false;
            this.BusDataGrid.AllowUserToDeleteRows = false;
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
            this.BusDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusDataGrid.EnableHeadersVisualStyles = false;
            this.BusDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.BusDataGrid.Location = new System.Drawing.Point(3, 19);
            this.BusDataGrid.MultiSelect = false;
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
            this.BusDataGrid.Size = new System.Drawing.Size(889, 211);
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
            // teacherIDDataGridViewTextBoxColumn
            // 
            this.teacherIDDataGridViewTextBoxColumn.DataPropertyName = "TeacherID";
            this.teacherIDDataGridViewTextBoxColumn.HeaderText = "带车老师ID";
            this.teacherIDDataGridViewTextBoxColumn.Name = "teacherIDDataGridViewTextBoxColumn";
            this.teacherIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.Checked = true;
            this.dataGridViewCheckBoxColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.dataGridViewCheckBoxColumn1.CheckValue = "N";
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "CSChecked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "返校确认";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AHChecked
            // 
            this.AHChecked.Checked = true;
            this.AHChecked.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.AHChecked.CheckValue = "N";
            this.AHChecked.DataPropertyName = "AHChecked";
            this.AHChecked.HeaderText = "到站确认";
            this.AHChecked.Name = "AHChecked";
            this.AHChecked.ReadOnly = true;
            this.AHChecked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.Checked = true;
            this.dataGridViewCheckBoxColumn2.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.dataGridViewCheckBoxColumn2.CheckValue = "N";
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "LSChecked";
            this.dataGridViewCheckBoxColumn2.HeaderText = "离校确认";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.schoolBusObjectBindingSource.DataSource = typeof(WBPlatform.TableObject.SchoolBusObject);
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
            this.groupBox1.Location = new System.Drawing.Point(247, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(854, 435);
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
            this.ExDiscription.BackColor = System.Drawing.Color.White;
            this.ExDiscription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExDiscription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExDiscription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ExDiscription.ForeColor = System.Drawing.Color.Black;
            this.ExDiscription.IntegralHeight = false;
            this.ExDiscription.ItemHeight = 17;
            this.ExDiscription.Items.AddRange(new object[] {
            "加载窗体"});
            this.ExDiscription.Location = new System.Drawing.Point(3, 19);
            this.ExDiscription.Name = "ExDiscription";
            this.ExDiscription.Size = new System.Drawing.Size(181, 168);
            this.ExDiscription.TabIndex = 19;
            // 
            // LoadExistStudents
            // 
            this.LoadExistStudents.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LoadExistStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadExistStudents.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.LoadExistStudents.Location = new System.Drawing.Point(6, 234);
            this.LoadExistStudents.Name = "LoadExistStudents";
            this.LoadExistStudents.Size = new System.Drawing.Size(214, 34);
            this.LoadExistStudents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoadExistStudents.TabIndex = 13;
            this.LoadExistStudents.Text = "加载班级数据";
            this.LoadExistStudents.Click += new System.EventHandler(this.LoadExistStudents_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.BusDataGrid);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 453);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(895, 233);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "校车信息";
            // 
            // statusPanel
            // 
            this.statusPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.statusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.ForeColor = System.Drawing.Color.Black;
            this.statusPanel.Location = new System.Drawing.Point(386, 272);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(372, 113);
            this.statusPanel.TabIndex = 15;
            this.statusPanel.Visible = false;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.White;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(370, 111);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "当前状态";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.BackColor = System.Drawing.Color.White;
            this.groupBox6.Controls.Add(this.ExDiscription);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(914, 454);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(187, 190);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "操作记录";
            // 
            // radialMenu1
            // 
            this.radialMenu1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.radialMenu1.Colors.RadialMenuItemDisabledForeground = System.Drawing.Color.Empty;
            this.radialMenu1.ForeColor = System.Drawing.Color.Black;
            this.radialMenu1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.radialMenuItem1,
            this.radialMenuItem2,
            this.radialMenuItem3,
            this.radialMenuItem4,
            this.radialMenuItem5});
            this.radialMenu1.Location = new System.Drawing.Point(1086, 1);
            this.radialMenu1.Name = "radialMenu1";
            this.radialMenu1.Size = new System.Drawing.Size(28, 28);
            this.radialMenu1.SubMenuEdgeWidth = 20;
            this.radialMenu1.Symbol = "";
            this.radialMenu1.SymbolSize = 13F;
            this.radialMenu1.TabIndex = 15;
            this.radialMenu1.Text = "radialMenu1";
            this.radialMenu1.Visible = false;
            this.radialMenu1.MenuClosed += new System.EventHandler(this.radialMenu1_MenuClosed);
            this.radialMenu1.ItemClick += new System.EventHandler(this.radialMenu1_ItemClick);
            // 
            // radialMenuItem1
            // 
            this.radialMenuItem1.Name = "radialMenuItem1";
            this.radialMenuItem1.Symbol = "";
            this.radialMenuItem1.Text = "编辑";
            // 
            // radialMenuItem2
            // 
            this.radialMenuItem2.Name = "radialMenuItem2";
            this.radialMenuItem2.Symbol = "";
            this.radialMenuItem2.Text = "移除";
            // 
            // radialMenuItem3
            // 
            this.radialMenuItem3.Name = "radialMenuItem3";
            this.radialMenuItem3.Symbol = "";
            this.radialMenuItem3.Text = "彻底删除";
            // 
            // radialMenuItem4
            // 
            this.radialMenuItem4.Name = "radialMenuItem4";
            this.radialMenuItem4.Symbol = "";
            this.radialMenuItem4.Text = "复制";
            // 
            // radialMenuItem5
            // 
            this.radialMenuItem5.Name = "radialMenuItem5";
            this.radialMenuItem5.Symbol = "";
            this.radialMenuItem5.Text = "重输";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前选择的班级：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(74, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "学部：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(61, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "班级ID：";
            // 
            // ClsTPhoneNum
            // 
            this.ClsTPhoneNum.AutoSize = true;
            this.ClsTPhoneNum.BackColor = System.Drawing.Color.White;
            this.ClsTPhoneNum.ForeColor = System.Drawing.Color.Black;
            this.ClsTPhoneNum.Location = new System.Drawing.Point(124, 204);
            this.ClsTPhoneNum.Name = "ClsTPhoneNum";
            this.ClsTPhoneNum.Size = new System.Drawing.Size(0, 17);
            this.ClsTPhoneNum.TabIndex = 0;
            // 
            // ClsTName
            // 
            this.ClsTName.AutoSize = true;
            this.ClsTName.BackColor = System.Drawing.Color.White;
            this.ClsTName.ForeColor = System.Drawing.Color.Black;
            this.ClsTName.Location = new System.Drawing.Point(124, 177);
            this.ClsTName.Name = "ClsTName";
            this.ClsTName.Size = new System.Drawing.Size(0, 17);
            this.ClsTName.TabIndex = 0;
            // 
            // ClsTID
            // 
            this.ClsTID.AutoSize = true;
            this.ClsTID.BackColor = System.Drawing.Color.White;
            this.ClsTID.ForeColor = System.Drawing.Color.Black;
            this.ClsTID.Location = new System.Drawing.Point(124, 151);
            this.ClsTID.Name = "ClsTID";
            this.ClsTID.Size = new System.Drawing.Size(0, 17);
            this.ClsTID.TabIndex = 0;
            // 
            // ClsNum
            // 
            this.ClsNum.AutoSize = true;
            this.ClsNum.BackColor = System.Drawing.Color.White;
            this.ClsNum.ForeColor = System.Drawing.Color.Black;
            this.ClsNum.Location = new System.Drawing.Point(124, 125);
            this.ClsNum.Name = "ClsNum";
            this.ClsNum.Size = new System.Drawing.Size(0, 17);
            this.ClsNum.TabIndex = 0;
            // 
            // ClsGrade
            // 
            this.ClsGrade.AutoSize = true;
            this.ClsGrade.BackColor = System.Drawing.Color.White;
            this.ClsGrade.ForeColor = System.Drawing.Color.Black;
            this.ClsGrade.Location = new System.Drawing.Point(124, 99);
            this.ClsGrade.Name = "ClsGrade";
            this.ClsGrade.Size = new System.Drawing.Size(0, 17);
            this.ClsGrade.TabIndex = 0;
            // 
            // ClsDpt
            // 
            this.ClsDpt.AutoSize = true;
            this.ClsDpt.BackColor = System.Drawing.Color.White;
            this.ClsDpt.ForeColor = System.Drawing.Color.Black;
            this.ClsDpt.Location = new System.Drawing.Point(124, 73);
            this.ClsDpt.Name = "ClsDpt";
            this.ClsDpt.Size = new System.Drawing.Size(0, 17);
            this.ClsDpt.TabIndex = 0;
            // 
            // ClsID
            // 
            this.ClsID.AutoSize = true;
            this.ClsID.BackColor = System.Drawing.Color.White;
            this.ClsID.ForeColor = System.Drawing.Color.Black;
            this.ClsID.Location = new System.Drawing.Point(124, 49);
            this.ClsID.Name = "ClsID";
            this.ClsID.Size = new System.Drawing.Size(0, 17);
            this.ClsID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(74, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "年级：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(74, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "班级：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(49, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "班主任ID：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(38, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "班主任姓名：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(14, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "班主任手机号码：";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.LoadExistStudents);
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
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(226, 435);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "班级信息";
            // 
            // StudentUploadWindow
            // 
            this.ClientSize = new System.Drawing.Size(1113, 698);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.radialMenu1);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.SureAndUploadBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentUploadWindow";
            this.Text = "我的班级 - 上传学生数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExcelOperationWindow_FormClosing);
            this.Load += new System.EventHandler(this.ExcelOperationWindow_Load);
            this.Shown += new System.EventHandler(this.ExcelOperationWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataBindSourc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolBusObjectBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusPanel.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX SureAndUploadBtn;
        private System.Windows.Forms.OpenFileDialog OpenExcelFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuBusDirection;
        private DevComponents.DotNetBar.Controls.TextBoxX ExcelFilePathTxt;
        private System.Windows.Forms.BindingSource studentDataBindSourc;
        private DevComponents.DotNetBar.Controls.DataGridViewX BusDataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX ExcelFileOpenBtn;
        private DevComponents.DotNetBar.ButtonX LoadExistStudents;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPartOfSchoolDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentYearDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentClassDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentDirectionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherStuDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource schoolBusObjectBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX StudentData;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPartOfSchoolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentDirectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ListBox ExDiscription;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.GroupBox groupBox6;
        private DevComponents.DotNetBar.RadialMenu radialMenu1;
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem1;
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem2;
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem3;
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem4;
        private DevComponents.DotNetBar.RadialMenuItem radialMenuItem5;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn BusDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn busNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherIDDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn dataGridViewCheckBoxColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn AHChecked;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAt;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ClsID;
        private System.Windows.Forms.Label ClsDpt;
        private System.Windows.Forms.Label ClsGrade;
        private System.Windows.Forms.Label ClsNum;
        private System.Windows.Forms.Label ClsTID;
        private System.Windows.Forms.Label ClsTName;
        private System.Windows.Forms.Label ClsTPhoneNum;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}