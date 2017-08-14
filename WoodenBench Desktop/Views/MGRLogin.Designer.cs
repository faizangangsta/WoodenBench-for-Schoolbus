namespace WoodenBench.Views
{
    partial class MGRLoginWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MGRLoginWindow));
            this.LoginMgrBtn = new System.Windows.Forms.Button();
            this.RealNameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.UsrNameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginMgrBtn
            // 
            this.LoginMgrBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginMgrBtn.Location = new System.Drawing.Point(12, 99);
            this.LoginMgrBtn.Name = "LoginMgrBtn";
            this.LoginMgrBtn.Size = new System.Drawing.Size(452, 26);
            this.LoginMgrBtn.TabIndex = 6;
            this.LoginMgrBtn.Text = "登录管理界面(&L)";
            this.LoginMgrBtn.UseVisualStyleBackColor = true;
            this.LoginMgrBtn.Click += new System.EventHandler(this.LoginMgrBtn_Click);
            // 
            // RealNameTxt
            // 
            this.RealNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RealNameTxt.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.RealNameTxt.Location = new System.Drawing.Point(71, 70);
            this.RealNameTxt.Name = "RealNameTxt";
            this.RealNameTxt.Size = new System.Drawing.Size(394, 23);
            this.RealNameTxt.TabIndex = 5;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTxt.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.PasswordTxt.Location = new System.Drawing.Point(71, 41);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '●';
            this.PasswordTxt.Size = new System.Drawing.Size(394, 23);
            this.PasswordTxt.TabIndex = 4;
            // 
            // UsrNameTxt
            // 
            this.UsrNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsrNameTxt.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.UsrNameTxt.Location = new System.Drawing.Point(70, 12);
            this.UsrNameTxt.Name = "UsrNameTxt";
            this.UsrNameTxt.Size = new System.Drawing.Size(395, 23);
            this.UsrNameTxt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "真实姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // MGRLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 137);
            this.Controls.Add(this.LoginMgrBtn);
            this.Controls.Add(this.RealNameTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsrNameTxt);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MGRLogin";
            this.Text = "管理页面登录";
            this.Load += new System.EventHandler(this.MGRLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoginMgrBtn;
        private System.Windows.Forms.TextBox RealNameTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.TextBox UsrNameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}