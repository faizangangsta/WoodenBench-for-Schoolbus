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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelOperationWindow));
            this.StudentData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentPartOfSchoolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentClassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentDirectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolBusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentDataGridMenuS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除当前行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentDataObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.SureAndUploadBtn = new DevComponents.DotNetBar.ButtonX();
            this.OpenExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExcelFilePathTxt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.BusDataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.objectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.busNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leavingCheckedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comingCheckedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schoolBusObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StuPartOS = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExcelFileOpenBtn = new DevComponents.DotNetBar.ButtonX();
            this.LoadExistStudents = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.StuClass = new System.Windows.Forms.ComboBox();
            this.StuYear = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExDiscription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).BeginInit();
            this.StudentDataGridMenuS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolBusObjectBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.dataGridViewTextBoxColumn1,
            this.studentNameDataGridViewTextBoxColumn,
            this.studentPartOfSchoolDataGridViewTextBoxColumn,
            this.studentYearDataGridViewTextBoxColumn,
            this.studentClassDataGridViewTextBoxColumn,
            this.studentDirectionDataGridViewTextBoxColumn,
            this.SchoolBusID,
            this.dataGridViewTextBoxColumn2});
            this.StudentData.ContextMenuStrip = this.StudentDataGridMenuS;
            this.StudentData.DataSource = this.studentDataObjectBindingSource;
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
            this.StudentData.Location = new System.Drawing.Point(9, 94);
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
            this.StudentData.Size = new System.Drawing.Size(1021, 270);
            this.StudentData.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "objectId";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "学生ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // studentNameDataGridViewTextBoxColumn
            // 
            this.studentNameDataGridViewTextBoxColumn.DataPropertyName = "StudentName";
            this.studentNameDataGridViewTextBoxColumn.Frozen = true;
            this.studentNameDataGridViewTextBoxColumn.HeaderText = "学生姓名";
            this.studentNameDataGridViewTextBoxColumn.Name = "studentNameDataGridViewTextBoxColumn";
            // 
            // studentPartOfSchoolDataGridViewTextBoxColumn
            // 
            this.studentPartOfSchoolDataGridViewTextBoxColumn.DataPropertyName = "StudentPartOfSchool";
            this.studentPartOfSchoolDataGridViewTextBoxColumn.Frozen = true;
            this.studentPartOfSchoolDataGridViewTextBoxColumn.HeaderText = "学部";
            this.studentPartOfSchoolDataGridViewTextBoxColumn.Name = "studentPartOfSchoolDataGridViewTextBoxColumn";
            // 
            // studentYearDataGridViewTextBoxColumn
            // 
            this.studentYearDataGridViewTextBoxColumn.DataPropertyName = "StudentYear";
            this.studentYearDataGridViewTextBoxColumn.Frozen = true;
            this.studentYearDataGridViewTextBoxColumn.HeaderText = "年级";
            this.studentYearDataGridViewTextBoxColumn.Name = "studentYearDataGridViewTextBoxColumn";
            // 
            // studentClassDataGridViewTextBoxColumn
            // 
            this.studentClassDataGridViewTextBoxColumn.DataPropertyName = "StudentClass";
            this.studentClassDataGridViewTextBoxColumn.Frozen = true;
            this.studentClassDataGridViewTextBoxColumn.HeaderText = "班级";
            this.studentClassDataGridViewTextBoxColumn.Name = "studentClassDataGridViewTextBoxColumn";
            // 
            // studentDirectionDataGridViewTextBoxColumn
            // 
            this.studentDirectionDataGridViewTextBoxColumn.DataPropertyName = "StudentDirection";
            this.studentDirectionDataGridViewTextBoxColumn.Frozen = true;
            this.studentDirectionDataGridViewTextBoxColumn.HeaderText = "校车路线";
            this.studentDirectionDataGridViewTextBoxColumn.Name = "studentDirectionDataGridViewTextBoxColumn";
            // 
            // SchoolBusID
            // 
            this.SchoolBusID.DataPropertyName = "BusID";
            this.SchoolBusID.Frozen = true;
            this.SchoolBusID.HeaderText = "校车ID";
            this.SchoolBusID.Name = "SchoolBusID";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "updatedAt";
            this.dataGridViewTextBoxColumn2.HeaderText = "上次更新";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
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
            // studentDataObjectBindingSource
            // 
            this.studentDataObjectBindingSource.DataSource = typeof(WoodenBench.TableObject.StudentDataObject);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(175, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "年级：";
            // 
            // SureAndUploadBtn
            // 
            this.SureAndUploadBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SureAndUploadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SureAndUploadBtn.Location = new System.Drawing.Point(859, 51);
            this.SureAndUploadBtn.Name = "SureAndUploadBtn";
            this.SureAndUploadBtn.Size = new System.Drawing.Size(171, 37);
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
            this.ExcelFilePathTxt.Size = new System.Drawing.Size(899, 23);
            this.ExcelFilePathTxt.TabIndex = 7;
            this.ExcelFilePathTxt.WatermarkText = "Excel 文件位置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
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
            this.teacherIDDataGridViewTextBoxColumn,
            this.leavingCheckedDataGridViewTextBoxColumn,
            this.comingCheckedDataGridViewTextBoxColumn,
            this.updatedAt,
            this.createdAt});
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
            this.BusDataGrid.Size = new System.Drawing.Size(1024, 204);
            this.BusDataGrid.TabIndex = 11;
            this.BusDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellContentClick);
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
            // leavingCheckedDataGridViewTextBoxColumn
            // 
            this.leavingCheckedDataGridViewTextBoxColumn.DataPropertyName = "LeavingChecked";
            this.leavingCheckedDataGridViewTextBoxColumn.HeaderText = "离校检查";
            this.leavingCheckedDataGridViewTextBoxColumn.Name = "leavingCheckedDataGridViewTextBoxColumn";
            this.leavingCheckedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comingCheckedDataGridViewTextBoxColumn
            // 
            this.comingCheckedDataGridViewTextBoxColumn.DataPropertyName = "ComingChecked";
            this.comingCheckedDataGridViewTextBoxColumn.HeaderText = "返校检查";
            this.comingCheckedDataGridViewTextBoxColumn.Name = "comingCheckedDataGridViewTextBoxColumn";
            this.comingCheckedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updatedAt
            // 
            this.updatedAt.DataPropertyName = "updatedAt";
            this.updatedAt.HeaderText = "上次更新时间";
            this.updatedAt.Name = "updatedAt";
            this.updatedAt.ReadOnly = true;
            this.updatedAt.Width = 120;
            // 
            // createdAt
            // 
            this.createdAt.DataPropertyName = "createdAt";
            this.createdAt.HeaderText = "创建时间";
            this.createdAt.Name = "createdAt";
            this.createdAt.ReadOnly = true;
            // 
            // schoolBusObjectBindingSource
            // 
            this.schoolBusObjectBindingSource.DataSource = typeof(WoodenBench.TableObject.SchoolBusObject);
            // 
            // StuPartOS
            // 
            this.StuPartOS.BackColor = System.Drawing.Color.White;
            this.StuPartOS.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.studentDataObjectBindingSource, "StudentName", true));
            this.StuPartOS.ForeColor = System.Drawing.Color.Black;
            this.StuPartOS.FormattingEnabled = true;
            this.StuPartOS.Items.AddRange(new object[] {
            "小学部",
            "初中部",
            "普通高中部",
            "中加高中部",
            "剑桥高中部"});
            this.StuPartOS.Location = new System.Drawing.Point(56, 58);
            this.StuPartOS.Name = "StuPartOS";
            this.StuPartOS.Size = new System.Drawing.Size(113, 24);
            this.StuPartOS.TabIndex = 12;
            this.StuPartOS.SelectedIndexChanged += new System.EventHandler(this.StuPartOS_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.ExDiscription);
            this.groupBox1.Controls.Add(this.ExcelFileOpenBtn);
            this.groupBox1.Controls.Add(this.SureAndUploadBtn);
            this.groupBox1.Controls.Add(this.LoadExistStudents);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.StuClass);
            this.groupBox1.Controls.Add(this.StuYear);
            this.groupBox1.Controls.Add(this.StuPartOS);
            this.groupBox1.Controls.Add(this.StudentData);
            this.groupBox1.Controls.Add(this.ExcelFilePathTxt);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1036, 370);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "学生信息";
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
            // LoadExistStudents
            // 
            this.LoadExistStudents.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LoadExistStudents.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.LoadExistStudents.Location = new System.Drawing.Point(456, 58);
            this.LoadExistStudents.Name = "LoadExistStudents";
            this.LoadExistStudents.Size = new System.Drawing.Size(116, 24);
            this.LoadExistStudents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoadExistStudents.TabIndex = 13;
            this.LoadExistStudents.Text = "加载已有记录";
            this.LoadExistStudents.Click += new System.EventHandler(this.LoadExistStudents_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(316, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "班级：";
            // 
            // StuClass
            // 
            this.StuClass.BackColor = System.Drawing.Color.White;
            this.StuClass.ForeColor = System.Drawing.Color.Black;
            this.StuClass.FormattingEnabled = true;
            this.StuClass.Items.AddRange(new object[] {
            "一班",
            "二班",
            "三班",
            "四班",
            "五班",
            "六班",
            "七班",
            "八班",
            "九班"});
            this.StuClass.Location = new System.Drawing.Point(366, 58);
            this.StuClass.Name = "StuClass";
            this.StuClass.Size = new System.Drawing.Size(85, 24);
            this.StuClass.TabIndex = 12;
            // 
            // StuYear
            // 
            this.StuYear.BackColor = System.Drawing.Color.White;
            this.StuYear.ForeColor = System.Drawing.Color.Black;
            this.StuYear.FormattingEnabled = true;
            this.StuYear.Items.AddRange(new object[] {
            "请选择学部"});
            this.StuYear.Location = new System.Drawing.Point(225, 58);
            this.StuYear.Name = "StuYear";
            this.StuYear.Size = new System.Drawing.Size(85, 24);
            this.StuYear.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.BusDataGrid);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 388);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1036, 233);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "校车信息";
            // 
            // ExDiscription
            // 
            this.ExDiscription.AutoSize = true;
            this.ExDiscription.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ExDiscription.Location = new System.Drawing.Point(593, 61);
            this.ExDiscription.Name = "ExDiscription";
            this.ExDiscription.Size = new System.Drawing.Size(0, 21);
            this.ExDiscription.TabIndex = 19;
            // 
            // ExcelOperationWindow
            // 
            this.ClientSize = new System.Drawing.Size(1060, 633);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelOperationWindow";
            this.Text = "上传学生数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExcelOperationWindow_FormClosing);
            this.Load += new System.EventHandler(this.ExcelOperationWindow_Load);
            this.Shown += new System.EventHandler(this.ExcelOperationWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.StudentData)).EndInit();
            this.StudentDataGridMenuS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentDataObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolBusObjectBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX SureAndUploadBtn;
        private System.Windows.Forms.OpenFileDialog OpenExcelFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuBusDirection;
        private DevComponents.DotNetBar.Controls.TextBoxX ExcelFilePathTxt;
        private System.Windows.Forms.BindingSource studentDataObjectBindingSource;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.DataGridViewX BusDataGrid;
        private System.Windows.Forms.ComboBox StuPartOS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox StuYear;
        private DevComponents.DotNetBar.ButtonX ExcelFileOpenBtn;
        private DevComponents.DotNetBar.ButtonX LoadExistStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox StuClass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPartOfSchoolDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentYearDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentClassDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentDirectionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherStuDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource schoolBusObjectBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn busNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leavingCheckedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comingCheckedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAt;
        private DevComponents.DotNetBar.Controls.DataGridViewX StudentData;
        private System.Windows.Forms.ContextMenuStrip StudentDataGridMenuS;
        private System.Windows.Forms.ToolStripMenuItem 删除当前行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPartOfSchoolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentDirectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolBusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label ExDiscription;
    }
}