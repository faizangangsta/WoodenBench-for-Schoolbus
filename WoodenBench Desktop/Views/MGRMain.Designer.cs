namespace WBServicePlatform.WinClient.Views
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
            this.ContentTxBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ColNameTx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.objIDItem = new DevComponents.Editors.ComboItem();
            this.UsrNmeItem = new DevComponents.Editors.ComboItem();
            this.RelNmeItem = new DevComponents.Editors.ComboItem();
            this.WebNotiSItem = new DevComponents.Editors.ComboItem();
            this.WCIdItem = new DevComponents.Editors.ComboItem();
            this.SearchBtn = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.allUserObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.WebNotiTi = new System.Windows.Forms.TextBox();
            this.WebNotiCo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.WinNotiTi = new System.Windows.Forms.TextBox();
            this.WinNotiCon = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateBtn = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.objectIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weChatIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headImgDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.webNotiSeenDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isFstLoginDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isBusTeacherDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.UsrManGroup.BackColor = System.Drawing.Color.White;
            this.UsrManGroup.Controls.Add(this.ContentTxBox);
            this.UsrManGroup.Controls.Add(this.ColNameTx);
            this.UsrManGroup.Controls.Add(this.SearchBtn);
            this.UsrManGroup.Controls.Add(this.dataGridViewX1);
            this.UsrManGroup.Controls.Add(this.label5);
            this.UsrManGroup.ForeColor = System.Drawing.Color.Black;
            this.UsrManGroup.Location = new System.Drawing.Point(12, 225);
            this.UsrManGroup.Name = "UsrManGroup";
            this.UsrManGroup.Size = new System.Drawing.Size(1116, 470);
            this.UsrManGroup.TabIndex = 2;
            this.UsrManGroup.TabStop = false;
            this.UsrManGroup.Text = "用户管理";
            // 
            // ContentTxBox
            // 
            this.ContentTxBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentTxBox.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ContentTxBox.Border.Class = "TextBoxBorder";
            this.ContentTxBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ContentTxBox.DisabledBackColor = System.Drawing.Color.White;
            this.ContentTxBox.ForeColor = System.Drawing.Color.Black;
            this.ContentTxBox.Location = new System.Drawing.Point(198, 19);
            this.ContentTxBox.Name = "ContentTxBox";
            this.ContentTxBox.PreventEnterBeep = true;
            this.ContentTxBox.Size = new System.Drawing.Size(807, 21);
            this.ContentTxBox.TabIndex = 6;
            // 
            // ColNameTx
            // 
            this.ColNameTx.DisplayMember = "Text";
            this.ColNameTx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ColNameTx.ForeColor = System.Drawing.Color.Black;
            this.ColNameTx.FormattingEnabled = true;
            this.ColNameTx.ItemHeight = 15;
            this.ColNameTx.Items.AddRange(new object[] {
            this.objIDItem,
            this.UsrNmeItem,
            this.RelNmeItem,
            this.WebNotiSItem,
            this.WCIdItem});
            this.ColNameTx.Location = new System.Drawing.Point(9, 19);
            this.ColNameTx.Name = "ColNameTx";
            this.ColNameTx.Size = new System.Drawing.Size(160, 21);
            this.ColNameTx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ColNameTx.TabIndex = 5;
            // 
            // objIDItem
            // 
            this.objIDItem.Text = "objectId";
            // 
            // UsrNmeItem
            // 
            this.UsrNmeItem.Text = "Username";
            // 
            // RelNmeItem
            // 
            this.RelNmeItem.Text = "RealName";
            // 
            // WebNotiSItem
            // 
            this.WebNotiSItem.Text = "WebNotiSeen";
            // 
            // WCIdItem
            // 
            this.WCIdItem.Text = "WeChatID";
            // 
            // SearchBtn
            // 
            this.SearchBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.SearchBtn.Location = new System.Drawing.Point(1011, 20);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(93, 20);
            this.SearchBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SearchBtn.TabIndex = 4;
            this.SearchBtn.Text = "查询";
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UpdateBtn,
            this.objectIdDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.userGroupDataGridViewTextBoxColumn,
            this.weChatIDDataGridViewTextBoxColumn,
            this.realNameDataGridViewTextBoxColumn,
            this.headImgDataDataGridViewTextBoxColumn,
            this.userImageDataGridViewImageColumn,
            this.webNotiSeenDataGridViewCheckBoxColumn,
            this.isFstLoginDataGridViewCheckBoxColumn,
            this.isBusTeacherDataGridViewCheckBoxColumn,
            this.updatedAtDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn});
            this.dataGridViewX1.DataSource = this.allUserObjectBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(9, 46);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(1095, 418);
            this.dataGridViewX1.TabIndex = 3;
            this.dataGridViewX1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellContentClick);
            // 
            // allUserObjectBindingSource
            // 
            this.allUserObjectBindingSource.DataSource = typeof(WBServicePlatform.TableObject.AllUserObject);
            this.allUserObjectBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.allUserObjectBindingSource_ListChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(175, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "==";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonX2);
            this.groupBox2.Controls.Add(this.WebNotiTi);
            this.groupBox2.Controls.Add(this.WebNotiCo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(561, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 216);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WEB 端通知";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "标题：";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(6, 188);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(540, 22);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "更新";
            this.buttonX2.Click += new System.EventHandler(this.Btn_UpdateWebNoti_Click);
            // 
            // WebNotiTi
            // 
            this.WebNotiTi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebNotiTi.BackColor = System.Drawing.Color.White;
            this.WebNotiTi.ForeColor = System.Drawing.Color.Black;
            this.WebNotiTi.Location = new System.Drawing.Point(53, 17);
            this.WebNotiTi.Name = "WebNotiTi";
            this.WebNotiTi.Size = new System.Drawing.Size(493, 21);
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
            this.WebNotiCo.Size = new System.Drawing.Size(540, 137);
            this.WebNotiCo.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.Controls.Add(this.WinNotiTi);
            this.groupBox1.Controls.Add(this.WinNotiCon);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 216);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Windows 客户端通知";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "标题：";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(6, 188);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(540, 22);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "更新";
            this.buttonX1.Click += new System.EventHandler(this.Btn_UpdateWinNoti_Click);
            // 
            // WinNotiTi
            // 
            this.WinNotiTi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WinNotiTi.BackColor = System.Drawing.Color.White;
            this.WinNotiTi.ForeColor = System.Drawing.Color.Black;
            this.WinNotiTi.Location = new System.Drawing.Point(51, 17);
            this.WinNotiTi.Name = "WinNotiTi";
            this.WinNotiTi.Size = new System.Drawing.Size(495, 21);
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
            this.WinNotiCon.Size = new System.Drawing.Size(540, 137);
            this.WinNotiCon.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1116, 222);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.HeaderText = "√";
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.ReadOnly = true;
            this.UpdateBtn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UpdateBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.UpdateBtn.Text = "更新";
            this.UpdateBtn.ToolTipText = "更新";
            this.UpdateBtn.Width = 30;
            // 
            // objectIdDataGridViewTextBoxColumn
            // 
            this.objectIdDataGridViewTextBoxColumn.DataPropertyName = "objectId";
            this.objectIdDataGridViewTextBoxColumn.HeaderText = "用户ID";
            this.objectIdDataGridViewTextBoxColumn.Name = "objectIdDataGridViewTextBoxColumn";
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "用户名";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "密码";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            // 
            // userGroupDataGridViewTextBoxColumn
            // 
            this.userGroupDataGridViewTextBoxColumn.DataPropertyName = "UserGroup";
            this.userGroupDataGridViewTextBoxColumn.HeaderText = "用户组";
            this.userGroupDataGridViewTextBoxColumn.Name = "userGroupDataGridViewTextBoxColumn";
            // 
            // weChatIDDataGridViewTextBoxColumn
            // 
            this.weChatIDDataGridViewTextBoxColumn.DataPropertyName = "WeChatID";
            this.weChatIDDataGridViewTextBoxColumn.HeaderText = "微信号";
            this.weChatIDDataGridViewTextBoxColumn.Name = "weChatIDDataGridViewTextBoxColumn";
            // 
            // realNameDataGridViewTextBoxColumn
            // 
            this.realNameDataGridViewTextBoxColumn.DataPropertyName = "RealName";
            this.realNameDataGridViewTextBoxColumn.HeaderText = "用户全名";
            this.realNameDataGridViewTextBoxColumn.Name = "realNameDataGridViewTextBoxColumn";
            // 
            // headImgDataDataGridViewTextBoxColumn
            // 
            this.headImgDataDataGridViewTextBoxColumn.DataPropertyName = "HeadImgData";
            this.headImgDataDataGridViewTextBoxColumn.HeaderText = "头像数据";
            this.headImgDataDataGridViewTextBoxColumn.Name = "headImgDataDataGridViewTextBoxColumn";
            // 
            // userImageDataGridViewImageColumn
            // 
            this.userImageDataGridViewImageColumn.DataPropertyName = "UserImage";
            this.userImageDataGridViewImageColumn.HeaderText = "用户头像";
            this.userImageDataGridViewImageColumn.Name = "userImageDataGridViewImageColumn";
            // 
            // webNotiSeenDataGridViewCheckBoxColumn
            // 
            this.webNotiSeenDataGridViewCheckBoxColumn.DataPropertyName = "WebNotiSeen";
            this.webNotiSeenDataGridViewCheckBoxColumn.HeaderText = "网页通知已读";
            this.webNotiSeenDataGridViewCheckBoxColumn.Name = "webNotiSeenDataGridViewCheckBoxColumn";
            // 
            // isFstLoginDataGridViewCheckBoxColumn
            // 
            this.isFstLoginDataGridViewCheckBoxColumn.DataPropertyName = "isFstLogin";
            this.isFstLoginDataGridViewCheckBoxColumn.HeaderText = "首次登陆";
            this.isFstLoginDataGridViewCheckBoxColumn.Name = "isFstLoginDataGridViewCheckBoxColumn";
            // 
            // isBusTeacherDataGridViewCheckBoxColumn
            // 
            this.isBusTeacherDataGridViewCheckBoxColumn.DataPropertyName = "IsBusTeacher";
            this.isBusTeacherDataGridViewCheckBoxColumn.HeaderText = "校车老师";
            this.isBusTeacherDataGridViewCheckBoxColumn.Name = "isBusTeacherDataGridViewCheckBoxColumn";
            // 
            // updatedAtDataGridViewTextBoxColumn
            // 
            this.updatedAtDataGridViewTextBoxColumn.DataPropertyName = "updatedAt";
            this.updatedAtDataGridViewTextBoxColumn.HeaderText = "修改时间";
            this.updatedAtDataGridViewTextBoxColumn.Name = "updatedAtDataGridViewTextBoxColumn";
            this.updatedAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "createdAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "创建时间";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            this.createdAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ManagementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 707);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox WebNotiTi;
        private System.Windows.Forms.TextBox WebNotiCo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox WinNotiTi;
        private System.Windows.Forms.TextBox WinNotiCon;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.BindingSource allUserObjectBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX SearchBtn;
        private DevComponents.DotNetBar.Controls.TextBoxX ContentTxBox;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ColNameTx;
        private DevComponents.Editors.ComboItem objIDItem;
        private DevComponents.Editors.ComboItem UsrNmeItem;
        private DevComponents.Editors.ComboItem RelNmeItem;
        private DevComponents.Editors.ComboItem WebNotiSItem;
        private DevComponents.Editors.ComboItem WCIdItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn UpdateBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weChatIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn realNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn headImgDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn userImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn webNotiSeenDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isFstLoginDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isBusTeacherDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
    }
}