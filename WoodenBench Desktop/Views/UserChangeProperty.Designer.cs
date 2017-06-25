namespace WoodenBench_Desktop
{
	partial class ChangeUserData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserData));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuperuserRefuse = new System.Windows.Forms.Label();
            this.ChangePartOfSchool = new System.Windows.Forms.Button();
            this.UserActChangeBtn = new System.Windows.Forms.Button();
            this.UsrGroupDrop = new System.Windows.Forms.ComboBox();
            this.UsrGroup = new System.Windows.Forms.Label();
            this.UsrIDLbl = new System.Windows.Forms.Label();
            this.UsrNameLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.NPasswrodTxt2 = new System.Windows.Forms.TextBox();
            this.NPasswrodTxt1 = new System.Windows.Forms.TextBox();
            this.FPasswordTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.SuperuserRefuse);
            this.groupBox1.Controls.Add(this.ChangePartOfSchool);
            this.groupBox1.Controls.Add(this.UserActChangeBtn);
            this.groupBox1.Controls.Add(this.UsrGroupDrop);
            this.groupBox1.Controls.Add(this.UsrGroup);
            this.groupBox1.Controls.Add(this.UsrIDLbl);
            this.groupBox1.Controls.Add(this.UsrNameLbl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户基本信息";
            // 
            // SuperuserRefuse
            // 
            this.SuperuserRefuse.AutoSize = true;
            this.SuperuserRefuse.ForeColor = System.Drawing.Color.Red;
            this.SuperuserRefuse.Location = new System.Drawing.Point(154, 106);
            this.SuperuserRefuse.Name = "SuperuserRefuse";
            this.SuperuserRefuse.Size = new System.Drawing.Size(125, 12);
            this.SuperuserRefuse.TabIndex = 6;
            this.SuperuserRefuse.Text = "超级用户，不允许降权";
            this.SuperuserRefuse.Visible = false;
            // 
            // ChangePartOfSchool
            // 
            this.ChangePartOfSchool.Location = new System.Drawing.Point(102, 102);
            this.ChangePartOfSchool.Name = "ChangePartOfSchool";
            this.ChangePartOfSchool.Size = new System.Drawing.Size(46, 20);
            this.ChangePartOfSchool.TabIndex = 5;
            this.ChangePartOfSchool.Text = "更改";
            this.ChangePartOfSchool.UseVisualStyleBackColor = true;
            this.ChangePartOfSchool.Click += new System.EventHandler(this.ChangePartOfSchool_Click);
            // 
            // UserActChangeBtn
            // 
            this.UserActChangeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserActChangeBtn.Location = new System.Drawing.Point(212, 100);
            this.UserActChangeBtn.Name = "UserActChangeBtn";
            this.UserActChangeBtn.Size = new System.Drawing.Size(68, 23);
            this.UserActChangeBtn.TabIndex = 4;
            this.UserActChangeBtn.Text = "确定(&E)";
            this.UserActChangeBtn.UseVisualStyleBackColor = true;
            this.UserActChangeBtn.Visible = false;
            this.UserActChangeBtn.Click += new System.EventHandler(this.SureChangeUserData);
            // 
            // UsrGroupDrop
            // 
            this.UsrGroupDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UsrGroupDrop.FormattingEnabled = true;
            this.UsrGroupDrop.Items.AddRange(new object[] {
            "小学部         班主任",
            "初中部         班主任",
            "普通高中部   班主任",
            "中加高中部   班主任",
            "留学生部      班主任",
            "剑桥高中部   班主任",
            "校车管理老师",
            "家长"});
            this.UsrGroupDrop.Location = new System.Drawing.Point(16, 102);
            this.UsrGroupDrop.Name = "UsrGroupDrop";
            this.UsrGroupDrop.Size = new System.Drawing.Size(139, 20);
            this.UsrGroupDrop.TabIndex = 0;
            this.UsrGroupDrop.Visible = false;
            // 
            // UsrGroup
            // 
            this.UsrGroup.AutoSize = true;
            this.UsrGroup.Location = new System.Drawing.Point(89, 73);
            this.UsrGroup.Name = "UsrGroup";
            this.UsrGroup.Size = new System.Drawing.Size(59, 12);
            this.UsrGroup.TabIndex = 4;
            this.UsrGroup.Text = "UserGroup";
            // 
            // UsrIDLbl
            // 
            this.UsrIDLbl.AutoSize = true;
            this.UsrIDLbl.Location = new System.Drawing.Point(89, 48);
            this.UsrIDLbl.Name = "UsrIDLbl";
            this.UsrIDLbl.Size = new System.Drawing.Size(41, 12);
            this.UsrIDLbl.TabIndex = 4;
            this.UsrIDLbl.Text = "UserID";
            // 
            // UsrNameLbl
            // 
            this.UsrNameLbl.AutoSize = true;
            this.UsrNameLbl.Location = new System.Drawing.Point(89, 26);
            this.UsrNameLbl.Name = "UsrNameLbl";
            this.UsrNameLbl.Size = new System.Drawing.Size(53, 12);
            this.UsrNameLbl.TabIndex = 4;
            this.UsrNameLbl.Text = "UserName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "用户组";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户 ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.NPasswrodTxt2);
            this.groupBox2.Controls.Add(this.NPasswrodTxt1);
            this.groupBox2.Controls.Add(this.FPasswordTxt);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(304, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 149);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "更改密码";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(9, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "确定(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DoChange);
            // 
            // NPasswrodTxt2
            // 
            this.NPasswrodTxt2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NPasswrodTxt2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.NPasswrodTxt2.Location = new System.Drawing.Point(77, 76);
            this.NPasswrodTxt2.Name = "NPasswrodTxt2";
            this.NPasswrodTxt2.PasswordChar = '●';
            this.NPasswrodTxt2.Size = new System.Drawing.Size(133, 23);
            this.NPasswrodTxt2.TabIndex = 3;
            // 
            // NPasswrodTxt1
            // 
            this.NPasswrodTxt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NPasswrodTxt1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.NPasswrodTxt1.Location = new System.Drawing.Point(77, 49);
            this.NPasswrodTxt1.Name = "NPasswrodTxt1";
            this.NPasswrodTxt1.PasswordChar = '●';
            this.NPasswrodTxt1.Size = new System.Drawing.Size(133, 23);
            this.NPasswrodTxt1.TabIndex = 2;
            this.NPasswrodTxt1.TextChanged += new System.EventHandler(this.NPasswrodTxt1_TextChanged);
            // 
            // FPasswordTxt
            // 
            this.FPasswordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FPasswordTxt.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FPasswordTxt.Location = new System.Drawing.Point(77, 23);
            this.FPasswordTxt.Name = "FPasswordTxt";
            this.FPasswordTxt.PasswordChar = '●';
            this.FPasswordTxt.Size = new System.Drawing.Size(133, 23);
            this.FPasswordTxt.TabIndex = 1;
            this.FPasswordTxt.TextChanged += new System.EventHandler(this.FPasswordTxt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "确认新密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "新密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "原密码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(10, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(329, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "警告：经过任何一项更改后，用户将会被注销来重载用户配置";
            // 
            // ChangeUserData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 184);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(549, 223);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(549, 223);
            this.Name = "ChangeUserData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更改用户信息";
            this.Load += new System.EventHandler(this.ChangeUserData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label UsrGroup;
		private System.Windows.Forms.Label UsrIDLbl;
		private System.Windows.Forms.Label UsrNameLbl;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button UserActChangeBtn;
		private System.Windows.Forms.TextBox NPasswrodTxt2;
		private System.Windows.Forms.TextBox NPasswrodTxt1;
		private System.Windows.Forms.TextBox FPasswordTxt;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox UsrGroupDrop;
		private System.Windows.Forms.Button ChangePartOfSchool;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label SuperuserRefuse;
	}
}