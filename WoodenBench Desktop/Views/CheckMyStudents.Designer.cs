namespace WoodenBench.Views
{
    partial class CheckMyStudents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckMyStudents));
            this.teacherBasicData = new System.Windows.Forms.GroupBox();
            this.myDirection = new System.Windows.Forms.Label();
            this.LeaveNumber = new System.Windows.Forms.Label();
            this.BackNumber = new System.Windows.Forms.Label();
            this.BackChecked = new System.Windows.Forms.Label();
            this.LeavingChecked = new System.Windows.Forms.Label();
            this.ExpNumber = new System.Windows.Forms.Label();
            this.myID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentDataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.studentDataObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExDescription = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadAll = new DevComponents.DotNetBar.ButtonX();
            this.studentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentPartOfSchoolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentClassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leaveCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.parentLeaveCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.comingCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.parentComingCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UpdateAll = new DevComponents.DotNetBar.ButtonX();
            this.teacherBasicData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataObjectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // teacherBasicData
            // 
            this.teacherBasicData.Controls.Add(this.myDirection);
            this.teacherBasicData.Controls.Add(this.LeaveNumber);
            this.teacherBasicData.Controls.Add(this.BackNumber);
            this.teacherBasicData.Controls.Add(this.BackChecked);
            this.teacherBasicData.Controls.Add(this.LeavingChecked);
            this.teacherBasicData.Controls.Add(this.ExpNumber);
            this.teacherBasicData.Controls.Add(this.myID);
            this.teacherBasicData.Controls.Add(this.label7);
            this.teacherBasicData.Controls.Add(this.label5);
            this.teacherBasicData.Controls.Add(this.label3);
            this.teacherBasicData.Controls.Add(this.label6);
            this.teacherBasicData.Controls.Add(this.label2);
            this.teacherBasicData.Controls.Add(this.label4);
            this.teacherBasicData.Controls.Add(this.label1);
            this.teacherBasicData.Location = new System.Drawing.Point(12, 16);
            this.teacherBasicData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teacherBasicData.Name = "teacherBasicData";
            this.teacherBasicData.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teacherBasicData.Size = new System.Drawing.Size(204, 171);
            this.teacherBasicData.TabIndex = 0;
            this.teacherBasicData.TabStop = false;
            this.teacherBasicData.Text = "基本信息";
            this.teacherBasicData.Enter += new System.EventHandler(this.teacherBasicData_Enter);
            // 
            // myDirection
            // 
            this.myDirection.AutoSize = true;
            this.myDirection.Location = new System.Drawing.Point(102, 23);
            this.myDirection.Name = "myDirection";
            this.myDirection.Size = new System.Drawing.Size(32, 16);
            this.myDirection.TabIndex = 1;
            this.myDirection.Text = "方向";
            // 
            // LeaveNumber
            // 
            this.LeaveNumber.AutoSize = true;
            this.LeaveNumber.Location = new System.Drawing.Point(102, 80);
            this.LeaveNumber.Name = "LeaveNumber";
            this.LeaveNumber.Size = new System.Drawing.Size(14, 16);
            this.LeaveNumber.TabIndex = 1;
            this.LeaveNumber.Text = "0";
            // 
            // BackNumber
            // 
            this.BackNumber.AutoSize = true;
            this.BackNumber.Location = new System.Drawing.Point(102, 98);
            this.BackNumber.Name = "BackNumber";
            this.BackNumber.Size = new System.Drawing.Size(14, 16);
            this.BackNumber.TabIndex = 1;
            this.BackNumber.Text = "0";
            // 
            // BackChecked
            // 
            this.BackChecked.AutoSize = true;
            this.BackChecked.Location = new System.Drawing.Point(102, 136);
            this.BackChecked.Name = "BackChecked";
            this.BackChecked.Size = new System.Drawing.Size(14, 16);
            this.BackChecked.TabIndex = 1;
            this.BackChecked.Text = "0";
            // 
            // LeavingChecked
            // 
            this.LeavingChecked.AutoSize = true;
            this.LeavingChecked.Location = new System.Drawing.Point(102, 117);
            this.LeavingChecked.Name = "LeavingChecked";
            this.LeavingChecked.Size = new System.Drawing.Size(14, 16);
            this.LeavingChecked.TabIndex = 1;
            this.LeavingChecked.Text = "0";
            // 
            // ExpNumber
            // 
            this.ExpNumber.AutoSize = true;
            this.ExpNumber.Location = new System.Drawing.Point(102, 61);
            this.ExpNumber.Name = "ExpNumber";
            this.ExpNumber.Size = new System.Drawing.Size(14, 16);
            this.ExpNumber.TabIndex = 1;
            this.ExpNumber.Text = "0";
            // 
            // myID
            // 
            this.myID.AutoSize = true;
            this.myID.Location = new System.Drawing.Point(102, 42);
            this.myID.Name = "myID";
            this.myID.Size = new System.Drawing.Size(56, 16);
            this.myID.TabIndex = 1;
            this.myID.Text = "00000000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "返校家长确认：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "返校人数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "我管理的校车：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "离校家长确认：";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "离校人数：";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "应到人数：";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "校车ID：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // StudentDataGrid
            // 
            this.StudentDataGrid.AllowUserToAddRows = false;
            this.StudentDataGrid.AllowUserToDeleteRows = false;
            this.StudentDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentDataGrid.AutoGenerateColumns = false;
            this.StudentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentNameDataGridViewTextBoxColumn,
            this.studentPartOfSchoolDataGridViewTextBoxColumn,
            this.studentYearDataGridViewTextBoxColumn,
            this.studentClassDataGridViewTextBoxColumn,
            this.leaveCheckedDataGridViewCheckBoxColumn,
            this.parentLeaveCheckedDataGridViewCheckBoxColumn,
            this.comingCheckedDataGridViewCheckBoxColumn,
            this.parentComingCheckedDataGridViewCheckBoxColumn});
            this.StudentDataGrid.DataSource = this.studentDataObjectBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.StudentDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.StudentDataGrid.Location = new System.Drawing.Point(222, 16);
            this.StudentDataGrid.Name = "StudentDataGrid";
            this.StudentDataGrid.RowTemplate.Height = 23;
            this.StudentDataGrid.Size = new System.Drawing.Size(666, 442);
            this.StudentDataGrid.TabIndex = 1;
            this.StudentDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentDataGrid_CellEndEdit);
            // 
            // studentDataObjectBindingSource
            // 
            this.studentDataObjectBindingSource.DataSource = typeof(WoodenBench.TableObject.StudentDataObject);
            // 
            // ExDescription
            // 
            this.ExDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExDescription.AutoSize = true;
            this.ExDescription.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.ExDescription.Location = new System.Drawing.Point(12, 461);
            this.ExDescription.Name = "ExDescription";
            this.ExDescription.Size = new System.Drawing.Size(0, 19);
            this.ExDescription.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Location = new System.Drawing.Point(12, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 180);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "管理选项";
            this.groupBox1.Visible = false;
            // 
            // LoadAll
            // 
            this.LoadAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LoadAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.LoadAll.Location = new System.Drawing.Point(12, 194);
            this.LoadAll.Name = "LoadAll";
            this.LoadAll.Size = new System.Drawing.Size(204, 33);
            this.LoadAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoadAll.TabIndex = 0;
            this.LoadAll.Text = "加载所有";
            this.LoadAll.Click += new System.EventHandler(this.LoadAll_Click);
            // 
            // studentNameDataGridViewTextBoxColumn
            // 
            this.studentNameDataGridViewTextBoxColumn.DataPropertyName = "StudentName";
            this.studentNameDataGridViewTextBoxColumn.HeaderText = "学生姓名";
            this.studentNameDataGridViewTextBoxColumn.Name = "studentNameDataGridViewTextBoxColumn";
            // 
            // studentPartOfSchoolDataGridViewTextBoxColumn
            // 
            this.studentPartOfSchoolDataGridViewTextBoxColumn.DataPropertyName = "StudentPartOfSchool";
            this.studentPartOfSchoolDataGridViewTextBoxColumn.HeaderText = "学部";
            this.studentPartOfSchoolDataGridViewTextBoxColumn.Name = "studentPartOfSchoolDataGridViewTextBoxColumn";
            this.studentPartOfSchoolDataGridViewTextBoxColumn.Width = 80;
            // 
            // studentYearDataGridViewTextBoxColumn
            // 
            this.studentYearDataGridViewTextBoxColumn.DataPropertyName = "StudentYear";
            this.studentYearDataGridViewTextBoxColumn.HeaderText = "年级";
            this.studentYearDataGridViewTextBoxColumn.Name = "studentYearDataGridViewTextBoxColumn";
            this.studentYearDataGridViewTextBoxColumn.Width = 60;
            // 
            // studentClassDataGridViewTextBoxColumn
            // 
            this.studentClassDataGridViewTextBoxColumn.DataPropertyName = "StudentClass";
            this.studentClassDataGridViewTextBoxColumn.HeaderText = "班级";
            this.studentClassDataGridViewTextBoxColumn.Name = "studentClassDataGridViewTextBoxColumn";
            this.studentClassDataGridViewTextBoxColumn.Width = 60;
            // 
            // leaveCheckedDataGridViewCheckBoxColumn
            // 
            this.leaveCheckedDataGridViewCheckBoxColumn.DataPropertyName = "LeaveChecked";
            this.leaveCheckedDataGridViewCheckBoxColumn.HeaderText = "离校签到";
            this.leaveCheckedDataGridViewCheckBoxColumn.Name = "leaveCheckedDataGridViewCheckBoxColumn";
            this.leaveCheckedDataGridViewCheckBoxColumn.Width = 80;
            // 
            // parentLeaveCheckedDataGridViewCheckBoxColumn
            // 
            this.parentLeaveCheckedDataGridViewCheckBoxColumn.DataPropertyName = "ParentLeaveChecked";
            this.parentLeaveCheckedDataGridViewCheckBoxColumn.HeaderText = "家长确认";
            this.parentLeaveCheckedDataGridViewCheckBoxColumn.Name = "parentLeaveCheckedDataGridViewCheckBoxColumn";
            this.parentLeaveCheckedDataGridViewCheckBoxColumn.Width = 80;
            // 
            // comingCheckedDataGridViewCheckBoxColumn
            // 
            this.comingCheckedDataGridViewCheckBoxColumn.DataPropertyName = "ComingChecked";
            this.comingCheckedDataGridViewCheckBoxColumn.HeaderText = "返校签到";
            this.comingCheckedDataGridViewCheckBoxColumn.Name = "comingCheckedDataGridViewCheckBoxColumn";
            this.comingCheckedDataGridViewCheckBoxColumn.Width = 80;
            // 
            // parentComingCheckedDataGridViewCheckBoxColumn
            // 
            this.parentComingCheckedDataGridViewCheckBoxColumn.DataPropertyName = "ParentComingChecked";
            this.parentComingCheckedDataGridViewCheckBoxColumn.HeaderText = "家长确认";
            this.parentComingCheckedDataGridViewCheckBoxColumn.Name = "parentComingCheckedDataGridViewCheckBoxColumn";
            this.parentComingCheckedDataGridViewCheckBoxColumn.Width = 80;
            // 
            // UpdateAll
            // 
            this.UpdateAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.UpdateAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.UpdateAll.Location = new System.Drawing.Point(12, 234);
            this.UpdateAll.Name = "UpdateAll";
            this.UpdateAll.Size = new System.Drawing.Size(204, 38);
            this.UpdateAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.UpdateAll.TabIndex = 4;
            this.UpdateAll.Text = "更新数据";
            this.UpdateAll.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // CheckMyStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 489);
            this.Controls.Add(this.UpdateAll);
            this.Controls.Add(this.LoadAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExDescription);
            this.Controls.Add(this.StudentDataGrid);
            this.Controls.Add(this.teacherBasicData);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CheckMyStudents";
            this.Text = "我管理的";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckMyStudents_FormClosing);
            this.Load += new System.EventHandler(this.CheckMyStudents_Load);
            this.Shown += new System.EventHandler(this.CheckMyStudents_Shown);
            this.teacherBasicData.ResumeLayout(false);
            this.teacherBasicData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataObjectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox teacherBasicData;
        private System.Windows.Forms.Label myID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label myDirection;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.DataGridViewX StudentDataGrid;
        private System.Windows.Forms.Label ExDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label BackNumber;
        private System.Windows.Forms.Label ExpNumber;
        private System.Windows.Forms.Label BackChecked;
        private System.Windows.Forms.Label LeavingChecked;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource studentDataObjectBindingSource;
        private DevComponents.DotNetBar.ButtonX LoadAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LeaveNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPartOfSchoolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn leaveCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn parentLeaveCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn comingCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn parentComingCheckedDataGridViewCheckBoxColumn;
        private DevComponents.DotNetBar.ButtonX UpdateAll;
    }
}