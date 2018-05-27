namespace WBPlatform.WinClient.Views
{
    partial class BusesManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusesManager));
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.ExDiscription = new DevComponents.DotNetBar.LabelItem();
            this.UploadData = new DevComponents.DotNetBar.ButtonX();
            this.LoadDataBtn = new DevComponents.DotNetBar.ButtonX();
            this.busDataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.objectIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusTeacherRealName = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.updatedAtDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolBusDataMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除校车记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新这条数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoolBusObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.msgLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.teacherData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allUserObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.busDataGrid)).BeginInit();
            this.SchoolBusDataMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schoolBusObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teacherData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allUserObjectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.DragDropSupport = true;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ExDiscription});
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 680);
            this.metroStatusBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(990, 26);
            this.metroStatusBar1.TabIndex = 9;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // ExDiscription
            // 
            this.ExDiscription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExDiscription.Name = "ExDiscription";
            this.ExDiscription.Symbol = "";
            this.ExDiscription.SymbolSize = 13F;
            this.ExDiscription.Text = "添加、删除或编辑校车数据";
            // 
            // UploadData
            // 
            this.UploadData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.UploadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UploadData.Location = new System.Drawing.Point(847, 646);
            this.UploadData.Name = "UploadData";
            this.UploadData.Size = new System.Drawing.Size(131, 27);
            this.UploadData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.UploadData.TabIndex = 15;
            this.UploadData.Text = "更新所有数据";
            this.UploadData.Click += new System.EventHandler(this.UploadData_Click);
            // 
            // LoadDataBtn
            // 
            this.LoadDataBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LoadDataBtn.Location = new System.Drawing.Point(12, 12);
            this.LoadDataBtn.Name = "LoadDataBtn";
            this.LoadDataBtn.Size = new System.Drawing.Size(149, 26);
            this.LoadDataBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoadDataBtn.TabIndex = 15;
            this.LoadDataBtn.Text = "加载数据";
            this.LoadDataBtn.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // busDataGrid
            // 
            this.busDataGrid.AutoGenerateColumns = false;
            this.busDataGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.busDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.busDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.busDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objectIdDataGridViewTextBoxColumn1,
            this.BusTeacherRealName,
            this.updatedAtDataGridViewTextBoxColumn1});
            this.busDataGrid.ContextMenuStrip = this.SchoolBusDataMenu;
            this.busDataGrid.DataSource = this.schoolBusObjectBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.busDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.busDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.busDataGrid.EnableHeadersVisualStyles = false;
            this.busDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.busDataGrid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.busDataGrid.Location = new System.Drawing.Point(0, 0);
            this.busDataGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.busDataGrid.Name = "busDataGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.busDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.busDataGrid.RowTemplate.Height = 23;
            this.busDataGrid.Size = new System.Drawing.Size(966, 298);
            this.busDataGrid.TabIndex = 12;
            this.busDataGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.busDataGrid_CellBeginEdit);
            this.busDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.busDataGrid_CellContentClick);
            // 
            // objectIdDataGridViewTextBoxColumn1
            // 
            this.objectIdDataGridViewTextBoxColumn1.DataPropertyName = "objectId";
            this.objectIdDataGridViewTextBoxColumn1.HeaderText = "校车ID";
            this.objectIdDataGridViewTextBoxColumn1.Name = "objectIdDataGridViewTextBoxColumn1";
            // 
            // BusTeacherRealName
            // 
            this.BusTeacherRealName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.BusTeacherRealName.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.BusTeacherRealName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BusTeacherRealName.ForeColor = System.Drawing.Color.Black;
            this.BusTeacherRealName.HeaderText = "带车老师";
            this.BusTeacherRealName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BusTeacherRealName.Name = "BusTeacherRealName";
            this.BusTeacherRealName.PasswordChar = '\0';
            this.BusTeacherRealName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BusTeacherRealName.Text = "";
            // 
            // updatedAtDataGridViewTextBoxColumn1
            // 
            this.updatedAtDataGridViewTextBoxColumn1.DataPropertyName = "updatedAt";
            this.updatedAtDataGridViewTextBoxColumn1.HeaderText = "更新时间";
            this.updatedAtDataGridViewTextBoxColumn1.Name = "updatedAtDataGridViewTextBoxColumn1";
            this.updatedAtDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // SchoolBusDataMenu
            // 
            this.SchoolBusDataMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除校车记录ToolStripMenuItem,
            this.更新这条数据ToolStripMenuItem});
            this.SchoolBusDataMenu.Name = "SchoolBusDataMenu";
            this.SchoolBusDataMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // 删除校车记录ToolStripMenuItem
            // 
            this.删除校车记录ToolStripMenuItem.Name = "删除校车记录ToolStripMenuItem";
            this.删除校车记录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除校车记录ToolStripMenuItem.Text = "删除校车记录";
            this.删除校车记录ToolStripMenuItem.Click += new System.EventHandler(this.删除校车记录ToolStripMenuItem_Click);
            // 
            // 更新这条数据ToolStripMenuItem
            // 
            this.更新这条数据ToolStripMenuItem.Name = "更新这条数据ToolStripMenuItem";
            this.更新这条数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.更新这条数据ToolStripMenuItem.Text = "更新这条数据";
            this.更新这条数据ToolStripMenuItem.Click += new System.EventHandler(this.更新这条数据ToolStripMenuItem_Click);
            // 
            // schoolBusObjectBindingSource
            // 
            this.schoolBusObjectBindingSource.DataSource = typeof(WBPlatform.TableObject.SchoolBusObject);
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.msgLabel.Location = new System.Drawing.Point(205, 15);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(0, 21);
            this.msgLabel.TabIndex = 16;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 44);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.busDataGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.teacherData);
            this.splitContainer1.Size = new System.Drawing.Size(966, 596);
            this.splitContainer1.SplitterDistance = 298;
            this.splitContainer1.TabIndex = 17;
            // 
            // teacherData
            // 
            this.teacherData.AllowUserToAddRows = false;
            this.teacherData.AllowUserToDeleteRows = false;
            this.teacherData.AutoGenerateColumns = false;
            this.teacherData.BackgroundColor = System.Drawing.Color.White;
            this.teacherData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teacherData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.objectIdDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.updatedAtDataGridViewTextBoxColumn,
            this.aCLDataGridViewTextBoxColumn});
            this.teacherData.DataSource = this.schoolBusObjectBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.teacherData.DefaultCellStyle = dataGridViewCellStyle4;
            this.teacherData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teacherData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.teacherData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.teacherData.Location = new System.Drawing.Point(0, 0);
            this.teacherData.Name = "teacherData";
            this.teacherData.ReadOnly = true;
            this.teacherData.RowTemplate.Height = 23;
            this.teacherData.Size = new System.Drawing.Size(966, 294);
            this.teacherData.TabIndex = 0;
            // 
            // tableDataGridViewTextBoxColumn
            // 
            this.tableDataGridViewTextBoxColumn.DataPropertyName = "table";
            this.tableDataGridViewTextBoxColumn.HeaderText = "table";
            this.tableDataGridViewTextBoxColumn.Name = "tableDataGridViewTextBoxColumn";
            this.tableDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.objectIdDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.aCLDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // allUserObjectBindingSource
            // 
            this.allUserObjectBindingSource.DataSource = typeof(WBPlatform.TableObject.UserObject);
            // 
            // BusesManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 706);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.UploadData);
            this.Controls.Add(this.LoadDataBtn);
            this.Controls.Add(this.metroStatusBar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BusesManager";
            this.Text = "校车数据管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusesManager_FormClosing);
            this.Load += new System.EventHandler(this.BusesManager_Load);
            this.Shown += new System.EventHandler(this.BusesManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.busDataGrid)).EndInit();
            this.SchoolBusDataMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schoolBusObjectBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teacherData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allUserObjectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem ExDiscription;
        private DevComponents.DotNetBar.Controls.DataGridViewX busDataGrid;
        private DevComponents.DotNetBar.ButtonX LoadDataBtn;
        private System.Windows.Forms.ContextMenuStrip SchoolBusDataMenu;
        private System.Windows.Forms.ToolStripMenuItem 删除校车记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新这条数据ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX UploadData;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.DataGridViewX teacherData;
        private System.Windows.Forms.DataGridViewTextBoxColumn leavingCheckedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn comingCheckedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource schoolBusObjectBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weChatIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCLDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource allUserObjectBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectIdDataGridViewTextBoxColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn BusTeacherRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn1;
    }
}

