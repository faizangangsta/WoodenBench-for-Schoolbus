namespace WoodenBench_Desktop
{
	partial class UsrLoginForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrLoginForm));
			this.UserNameTxt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.PswdTxt = new System.Windows.Forms.TextBox();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.DoLoginBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.LoginResult = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// UserNameTxt
			// 
			this.UserNameTxt.Location = new System.Drawing.Point(85, 20);
			this.UserNameTxt.Name = "UserNameTxt";
			this.UserNameTxt.Size = new System.Drawing.Size(237, 21);
			this.UserNameTxt.TabIndex = 0;
			this.UserNameTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "用户名：";
			// 
			// PswdTxt
			// 
			this.PswdTxt.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.PswdTxt.Location = new System.Drawing.Point(85, 47);
			this.PswdTxt.Name = "PswdTxt";
			this.PswdTxt.PasswordChar = '●';
			this.PswdTxt.ShortcutsEnabled = false;
			this.PswdTxt.Size = new System.Drawing.Size(237, 23);
			this.PswdTxt.TabIndex = 2;
			this.PswdTxt.WordWrap = false;
			this.PswdTxt.TextChanged += new System.EventHandler(this.PswdTxt_TextChanged);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(191, 86);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 3;
			this.CancelBtn.Text = "取消(&C)";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.button1_Click);
			// 
			// DoLoginBtn
			// 
			this.DoLoginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DoLoginBtn.Location = new System.Drawing.Point(272, 86);
			this.DoLoginBtn.Name = "DoLoginBtn";
			this.DoLoginBtn.Size = new System.Drawing.Size(75, 23);
			this.DoLoginBtn.TabIndex = 4;
			this.DoLoginBtn.Text = "登陆(&L)";
			this.DoLoginBtn.UseVisualStyleBackColor = true;
			this.DoLoginBtn.Click += new System.EventHandler(this.DoLogin);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(38, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "密码：";
			// 
			// LoginResult
			// 
			this.LoginResult.AutoSize = true;
			this.LoginResult.ForeColor = System.Drawing.Color.Red;
			this.LoginResult.Location = new System.Drawing.Point(26, 91);
			this.LoginResult.Name = "LoginResult";
			this.LoginResult.Size = new System.Drawing.Size(0, 12);
			this.LoginResult.TabIndex = 6;
			// 
			// UsrLoginForm
			// 
			this.AcceptButton = this.DoLoginBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(359, 121);
			this.Controls.Add(this.LoginResult);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DoLoginBtn);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.PswdTxt);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.UserNameTxt);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(375, 160);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(375, 160);
			this.Name = "UsrLoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用户登录";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.UsrLoginForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox UserNameTxt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox PswdTxt;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button DoLoginBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label LoginResult;
	}
}

