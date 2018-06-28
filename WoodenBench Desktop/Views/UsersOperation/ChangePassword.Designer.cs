namespace WBPlatform.DesktopClient.Views
{
    partial class ChangePasswordForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ClearPassword = new DevComponents.DotNetBar.ButtonX();
            this.DochangePassword = new DevComponents.DotNetBar.ButtonX();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.NewPassword2 = new System.Windows.Forms.TextBox();
            this.NewPassword1 = new System.Windows.Forms.TextBox();
            this.prePassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PhoneNumLAbel = new System.Windows.Forms.LinkLabel();
            this.realnameLabel = new System.Windows.Forms.LinkLabel();
            this.UserLogonNamelabel = new System.Windows.Forms.Label();
            this.userIDLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SexLabel = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ClearPassword);
            this.groupBox2.Controls.Add(this.DochangePassword);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.NewPassword2);
            this.groupBox2.Controls.Add(this.NewPassword1);
            this.groupBox2.Controls.Add(this.prePassword);
            this.groupBox2.Location = new System.Drawing.Point(194, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(418, 196);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "更改密码";
            // 
            // ClearPassword
            // 
            this.ClearPassword.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ClearPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearPassword.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ClearPassword.Location = new System.Drawing.Point(9, 125);
            this.ClearPassword.Name = "ClearPassword";
            this.ClearPassword.Size = new System.Drawing.Size(199, 26);
            this.ClearPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ClearPassword.TabIndex = 6;
            this.ClearPassword.Text = "清空(&R)";
            this.ClearPassword.Click += new System.EventHandler(this.ClearPassword_Click);
            // 
            // DochangePassword
            // 
            this.DochangePassword.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DochangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DochangePassword.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.DochangePassword.Location = new System.Drawing.Point(214, 125);
            this.DochangePassword.Name = "DochangePassword";
            this.DochangePassword.Size = new System.Drawing.Size(198, 26);
            this.DochangePassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DochangePassword.TabIndex = 7;
            this.DochangePassword.Text = "更改密码(&P)";
            this.DochangePassword.Click += new System.EventHandler(this.DochangePassword_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "重新输入：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "新密码：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "原密码：";
            // 
            // NewPassword2
            // 
            this.NewPassword2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewPassword2.Location = new System.Drawing.Point(80, 86);
            this.NewPassword2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewPassword2.Name = "NewPassword2";
            this.NewPassword2.PasswordChar = '·';
            this.NewPassword2.Size = new System.Drawing.Size(332, 22);
            this.NewPassword2.TabIndex = 5;
            // 
            // NewPassword1
            // 
            this.NewPassword1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewPassword1.Location = new System.Drawing.Point(80, 55);
            this.NewPassword1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewPassword1.Name = "NewPassword1";
            this.NewPassword1.PasswordChar = '·';
            this.NewPassword1.Size = new System.Drawing.Size(332, 22);
            this.NewPassword1.TabIndex = 3;
            this.NewPassword1.TextChanged += new System.EventHandler(this.NewPassword1_TextChanged);
            // 
            // prePassword
            // 
            this.prePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prePassword.Location = new System.Drawing.Point(80, 24);
            this.prePassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prePassword.Name = "prePassword";
            this.prePassword.PasswordChar = '·';
            this.prePassword.Size = new System.Drawing.Size(332, 22);
            this.prePassword.TabIndex = 1;
            this.prePassword.TextChanged += new System.EventHandler(this.prePassword_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PhoneNumLAbel);
            this.groupBox1.Controls.Add(this.realnameLabel);
            this.groupBox1.Controls.Add(this.UserLogonNamelabel);
            this.groupBox1.Controls.Add(this.userIDLabel);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.SexLabel);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(176, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // PhoneNumLAbel
            // 
            this.PhoneNumLAbel.AutoSize = true;
            this.PhoneNumLAbel.Location = new System.Drawing.Point(60, 115);
            this.PhoneNumLAbel.Name = "PhoneNumLAbel";
            this.PhoneNumLAbel.Size = new System.Drawing.Size(73, 13);
            this.PhoneNumLAbel.TabIndex = 9;
            this.PhoneNumLAbel.TabStop = true;
            this.PhoneNumLAbel.Text = "18888888888";
            // 
            // realnameLabel
            // 
            this.realnameLabel.AutoSize = true;
            this.realnameLabel.Location = new System.Drawing.Point(60, 92);
            this.realnameLabel.Name = "realnameLabel";
            this.realnameLabel.Size = new System.Drawing.Size(72, 13);
            this.realnameLabel.TabIndex = 7;
            this.realnameLabel.TabStop = true;
            this.realnameLabel.Text = "小红红红红";
            // 
            // UserLogonNamelabel
            // 
            this.UserLogonNamelabel.AutoSize = true;
            this.UserLogonNamelabel.Location = new System.Drawing.Point(60, 45);
            this.UserLogonNamelabel.Name = "UserLogonNamelabel";
            this.UserLogonNamelabel.Size = new System.Drawing.Size(79, 13);
            this.UserLogonNamelabel.TabIndex = 3;
            this.UserLogonNamelabel.Text = "usernameuser";
            // 
            // userIDLabel
            // 
            this.userIDLabel.AutoSize = true;
            this.userIDLabel.Location = new System.Drawing.Point(60, 22);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(47, 13);
            this.userIDLabel.TabIndex = 1;
            this.userIDLabel.Text = "ffffffffff";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "手机号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "姓名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "用户名：";
            // 
            // SexLabel
            // 
            this.SexLabel.AutoSize = true;
            this.SexLabel.Location = new System.Drawing.Point(60, 68);
            this.SexLabel.Name = "SexLabel";
            this.SexLabel.Size = new System.Drawing.Size(33, 13);
            this.SexLabel.TabIndex = 5;
            this.SexLabel.TabStop = true;
            this.SexLabel.Text = "男女";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "性别：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "用户ID：";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 216);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(640, 255);
            this.MinimumSize = new System.Drawing.Size(640, 255);
            this.Name = "ChangePasswordForm";
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.ButtonX ClearPassword;
        private DevComponents.DotNetBar.ButtonX DochangePassword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox NewPassword2;
        private System.Windows.Forms.TextBox NewPassword1;
        private System.Windows.Forms.TextBox prePassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel PhoneNumLAbel;
        private System.Windows.Forms.LinkLabel realnameLabel;
        private System.Windows.Forms.Label UserLogonNamelabel;
        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel SexLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
    }
}