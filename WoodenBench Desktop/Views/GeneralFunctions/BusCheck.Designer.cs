namespace WBPlatform.DesktopClient.Views
{
    partial class BusCheckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusCheckForm));
            this.teacherBasicData = new System.Windows.Forms.GroupBox();
            this.myDirection = new System.Windows.Forms.Label();
            this.LeaveNumber = new System.Windows.Forms.Label();
            this.BackNumber = new System.Windows.Forms.Label();
            this.LeavingChecked = new System.Windows.Forms.Label();
            this.ExpNumber = new System.Windows.Forms.Label();
            this.myID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentDataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.studentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.busIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lSCheckedDataGridViewCheckBoxColumn = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.aHCheckedDataGridViewCheckBoxColumn = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.cSCheckedDataGridViewCheckBoxColumn = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.parentsIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentDataObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExDescription = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadAll = new DevComponents.DotNetBar.ButtonX();
            this.UpdateAll = new DevComponents.DotNetBar.ButtonX();
            this.teacherBasicData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataObjectBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // teacherBasicData
            // 
            this.teacherBasicData.BackColor = System.Drawing.Color.White;
            this.teacherBasicData.Controls.Add(this.myDirection);
            this.teacherBasicData.Controls.Add(this.LeaveNumber);
            this.teacherBasicData.Controls.Add(this.BackNumber);
            this.teacherBasicData.Controls.Add(this.LeavingChecked);
            this.teacherBasicData.Controls.Add(this.ExpNumber);
            this.teacherBasicData.Controls.Add(this.myID);
            this.teacherBasicData.Controls.Add(this.label5);
            this.teacherBasicData.Controls.Add(this.label3);
            this.teacherBasicData.Controls.Add(this.label6);
            this.teacherBasicData.Controls.Add(this.label2);
            this.teacherBasicData.Controls.Add(this.label4);
            this.teacherBasicData.Controls.Add(this.label1);
            this.teacherBasicData.ForeColor = System.Drawing.Color.Black;
            this.teacherBasicData.Location = new System.Drawing.Point(12, 16);
            this.teacherBasicData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teacherBasicData.Name = "teacherBasicData";
            this.teacherBasicData.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teacherBasicData.Size = new System.Drawing.Size(204, 147);
            this.teacherBasicData.TabIndex = 0;
            this.teacherBasicData.TabStop = false;
            this.teacherBasicData.Text = "基本信息";
            // 
            // myDirection
            // 
            this.myDirection.AutoSize = true;
            this.myDirection.BackColor = System.Drawing.Color.White;
            this.myDirection.ForeColor = System.Drawing.Color.Black;
            this.myDirection.Location = new System.Drawing.Point(102, 23);
            this.myDirection.Name = "myDirection";
            this.myDirection.Size = new System.Drawing.Size(32, 17);
            this.myDirection.TabIndex = 1;
            this.myDirection.Text = "方向";
            // 
            // LeaveNumber
            // 
            this.LeaveNumber.AutoSize = true;
            this.LeaveNumber.BackColor = System.Drawing.Color.White;
            this.LeaveNumber.ForeColor = System.Drawing.Color.Black;
            this.LeaveNumber.Location = new System.Drawing.Point(102, 80);
            this.LeaveNumber.Name = "LeaveNumber";
            this.LeaveNumber.Size = new System.Drawing.Size(15, 17);
            this.LeaveNumber.TabIndex = 1;
            this.LeaveNumber.Text = "0";
            // 
            // BackNumber
            // 
            this.BackNumber.AutoSize = true;
            this.BackNumber.BackColor = System.Drawing.Color.White;
            this.BackNumber.ForeColor = System.Drawing.Color.Black;
            this.BackNumber.Location = new System.Drawing.Point(102, 98);
            this.BackNumber.Name = "BackNumber";
            this.BackNumber.Size = new System.Drawing.Size(15, 17);
            this.BackNumber.TabIndex = 1;
            this.BackNumber.Text = "0";
            // 
            // LeavingChecked
            // 
            this.LeavingChecked.AutoSize = true;
            this.LeavingChecked.BackColor = System.Drawing.Color.White;
            this.LeavingChecked.ForeColor = System.Drawing.Color.Black;
            this.LeavingChecked.Location = new System.Drawing.Point(102, 117);
            this.LeavingChecked.Name = "LeavingChecked";
            this.LeavingChecked.Size = new System.Drawing.Size(15, 17);
            this.LeavingChecked.TabIndex = 1;
            this.LeavingChecked.Text = "0";
            // 
            // ExpNumber
            // 
            this.ExpNumber.AutoSize = true;
            this.ExpNumber.BackColor = System.Drawing.Color.White;
            this.ExpNumber.ForeColor = System.Drawing.Color.Black;
            this.ExpNumber.Location = new System.Drawing.Point(102, 61);
            this.ExpNumber.Name = "ExpNumber";
            this.ExpNumber.Size = new System.Drawing.Size(15, 17);
            this.ExpNumber.TabIndex = 1;
            this.ExpNumber.Text = "0";
            // 
            // myID
            // 
            this.myID.AutoSize = true;
            this.myID.BackColor = System.Drawing.Color.White;
            this.myID.ForeColor = System.Drawing.Color.Black;
            this.myID.Location = new System.Drawing.Point(102, 40);
            this.myID.Name = "myID";
            this.myID.Size = new System.Drawing.Size(64, 17);
            this.myID.TabIndex = 1;
            this.myID.Text = "00000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(43, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "返校人数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "我管理的校车：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(19, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "离校家长确认：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(43, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "离校人数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(43, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "应到人数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(54, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "校车ID：";
            // 
            // StudentDataGrid
            // 
            this.StudentDataGrid.AllowUserToAddRows = false;
            this.StudentDataGrid.AllowUserToDeleteRows = false;
            this.StudentDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentDataGrid.AutoGenerateColumns = false;
            this.StudentDataGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.StudentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentNameDataGridViewTextBoxColumn,
            this.busIDDataGridViewTextBoxColumn,
            this.sexDataGridViewTextBoxColumn,
            this.classIDDataGridViewTextBoxColumn,
            this.lSCheckedDataGridViewCheckBoxColumn,
            this.aHCheckedDataGridViewCheckBoxColumn,
            this.cSCheckedDataGridViewCheckBoxColumn,
            this.parentsIDDataGridViewTextBoxColumn,
            this.updatedAtDataGridViewTextBoxColumn});
            this.StudentDataGrid.DataSource = this.studentDataObjectBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.StudentDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.StudentDataGrid.Location = new System.Drawing.Point(222, 16);
            this.StudentDataGrid.Name = "StudentDataGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.StudentDataGrid.RowTemplate.Height = 23;
            this.StudentDataGrid.Size = new System.Drawing.Size(759, 478);
            this.StudentDataGrid.TabIndex = 1;
            this.StudentDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentDataGrid_CellEndEdit);
            // 
            // studentNameDataGridViewTextBoxColumn
            // 
            this.studentNameDataGridViewTextBoxColumn.DataPropertyName = "StudentName";
            this.studentNameDataGridViewTextBoxColumn.HeaderText = "学生姓名";
            this.studentNameDataGridViewTextBoxColumn.Name = "studentNameDataGridViewTextBoxColumn";
            // 
            // busIDDataGridViewTextBoxColumn
            // 
            this.busIDDataGridViewTextBoxColumn.DataPropertyName = "BusID";
            this.busIDDataGridViewTextBoxColumn.HeaderText = "校车ID";
            this.busIDDataGridViewTextBoxColumn.Name = "busIDDataGridViewTextBoxColumn";
            // 
            // sexDataGridViewTextBoxColumn
            // 
            this.sexDataGridViewTextBoxColumn.DataPropertyName = "Sex";
            this.sexDataGridViewTextBoxColumn.HeaderText = "性别";
            this.sexDataGridViewTextBoxColumn.Name = "sexDataGridViewTextBoxColumn";
            // 
            // classIDDataGridViewTextBoxColumn
            // 
            this.classIDDataGridViewTextBoxColumn.DataPropertyName = "ClassID";
            this.classIDDataGridViewTextBoxColumn.HeaderText = "班级ID";
            this.classIDDataGridViewTextBoxColumn.Name = "classIDDataGridViewTextBoxColumn";
            // 
            // lSCheckedDataGridViewCheckBoxColumn
            // 
            this.lSCheckedDataGridViewCheckBoxColumn.Checked = true;
            this.lSCheckedDataGridViewCheckBoxColumn.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.lSCheckedDataGridViewCheckBoxColumn.CheckValue = "N";
            this.lSCheckedDataGridViewCheckBoxColumn.DataPropertyName = "LSChecked";
            this.lSCheckedDataGridViewCheckBoxColumn.HeaderText = "离校";
            this.lSCheckedDataGridViewCheckBoxColumn.Name = "lSCheckedDataGridViewCheckBoxColumn";
            this.lSCheckedDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // aHCheckedDataGridViewCheckBoxColumn
            // 
            this.aHCheckedDataGridViewCheckBoxColumn.Checked = true;
            this.aHCheckedDataGridViewCheckBoxColumn.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.aHCheckedDataGridViewCheckBoxColumn.CheckValue = "N";
            this.aHCheckedDataGridViewCheckBoxColumn.DataPropertyName = "AHChecked";
            this.aHCheckedDataGridViewCheckBoxColumn.HeaderText = "到家";
            this.aHCheckedDataGridViewCheckBoxColumn.Name = "aHCheckedDataGridViewCheckBoxColumn";
            this.aHCheckedDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cSCheckedDataGridViewCheckBoxColumn
            // 
            this.cSCheckedDataGridViewCheckBoxColumn.Checked = true;
            this.cSCheckedDataGridViewCheckBoxColumn.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cSCheckedDataGridViewCheckBoxColumn.CheckValue = "N";
            this.cSCheckedDataGridViewCheckBoxColumn.DataPropertyName = "CSChecked";
            this.cSCheckedDataGridViewCheckBoxColumn.HeaderText = "返校";
            this.cSCheckedDataGridViewCheckBoxColumn.Name = "cSCheckedDataGridViewCheckBoxColumn";
            this.cSCheckedDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // parentsIDDataGridViewTextBoxColumn
            // 
            this.parentsIDDataGridViewTextBoxColumn.DataPropertyName = "ParentsID";
            this.parentsIDDataGridViewTextBoxColumn.HeaderText = "家长ID";
            this.parentsIDDataGridViewTextBoxColumn.Name = "parentsIDDataGridViewTextBoxColumn";
            // 
            // updatedAtDataGridViewTextBoxColumn
            // 
            this.updatedAtDataGridViewTextBoxColumn.DataPropertyName = "updatedAt";
            this.updatedAtDataGridViewTextBoxColumn.HeaderText = "更新时间";
            this.updatedAtDataGridViewTextBoxColumn.Name = "updatedAtDataGridViewTextBoxColumn";
            this.updatedAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // studentDataObjectBindingSource
            // 
            this.studentDataObjectBindingSource.DataSource = typeof(WBPlatform.TableObject.StudentObject);
            // 
            // ExDescription
            // 
            this.ExDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExDescription.AutoSize = true;
            this.ExDescription.BackColor = System.Drawing.Color.White;
            this.ExDescription.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.ExDescription.ForeColor = System.Drawing.Color.Black;
            this.ExDescription.Location = new System.Drawing.Point(12, 478);
            this.ExDescription.Name = "ExDescription";
            this.ExDescription.Size = new System.Drawing.Size(0, 20);
            this.ExDescription.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.LoadAll);
            this.groupBox1.Controls.Add(this.UpdateAll);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 107);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "管理选项";
            // 
            // LoadAll
            // 
            this.LoadAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LoadAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.LoadAll.Location = new System.Drawing.Point(6, 22);
            this.LoadAll.Name = "LoadAll";
            this.LoadAll.Size = new System.Drawing.Size(192, 33);
            this.LoadAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoadAll.TabIndex = 0;
            this.LoadAll.Text = "加载所有数据";
            this.LoadAll.Click += new System.EventHandler(this.LoadAll_Click);
            // 
            // UpdateAll
            // 
            this.UpdateAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.UpdateAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.UpdateAll.Location = new System.Drawing.Point(6, 61);
            this.UpdateAll.Name = "UpdateAll";
            this.UpdateAll.Size = new System.Drawing.Size(192, 34);
            this.UpdateAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.UpdateAll.TabIndex = 4;
            this.UpdateAll.Text = "更新数据";
            this.UpdateAll.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // CheckMyStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExDescription);
            this.Controls.Add(this.StudentDataGrid);
            this.Controls.Add(this.teacherBasicData);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CheckMyStudents";
            this.Text = "我的校车 - 登记查询和修改";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckMyStudents_FormClosing);
            this.Load += new System.EventHandler(this.CheckMyStudents_Load);
            this.Shown += new System.EventHandler(this.CheckMyStudents_Shown);
            this.teacherBasicData.ResumeLayout(false);
            this.teacherBasicData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataObjectBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label BackNumber;
        private System.Windows.Forms.Label ExpNumber;
        private System.Windows.Forms.Label LeavingChecked;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource studentDataObjectBindingSource;
        private DevComponents.DotNetBar.ButtonX LoadAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LeaveNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPartOfSchoolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn leaveCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn parentLeaveCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn comingCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn parentComingCheckedDataGridViewCheckBoxColumn;
        private DevComponents.DotNetBar.ButtonX UpdateAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn busIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classIDDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn lSCheckedDataGridViewCheckBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn aHCheckedDataGridViewCheckBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn cSCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentsIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
    }
}