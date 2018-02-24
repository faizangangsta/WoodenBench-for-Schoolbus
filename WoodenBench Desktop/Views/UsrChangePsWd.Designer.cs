namespace WBServicePlatform.WinClient.Views
{
    partial class ChangeUserDataWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserDataWindow));
            this.NPasswrodTxt2 = new System.Windows.Forms.TextBox();
            this.NPasswrodTxt1 = new System.Windows.Forms.TextBox();
            this.FPasswordTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SureChangeBtn = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // NPasswrodTxt2
            // 
            this.NPasswrodTxt2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NPasswrodTxt2.BackColor = System.Drawing.Color.White;
            this.NPasswrodTxt2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NPasswrodTxt2.ForeColor = System.Drawing.Color.Black;
            this.NPasswrodTxt2.Location = new System.Drawing.Point(100, 64);
            this.NPasswrodTxt2.Name = "NPasswrodTxt2";
            this.NPasswrodTxt2.PasswordChar = '●';
            this.NPasswrodTxt2.Size = new System.Drawing.Size(206, 23);
            this.NPasswrodTxt2.TabIndex = 3;
            // 
            // NPasswrodTxt1
            // 
            this.NPasswrodTxt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NPasswrodTxt1.BackColor = System.Drawing.Color.White;
            this.NPasswrodTxt1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NPasswrodTxt1.ForeColor = System.Drawing.Color.Black;
            this.NPasswrodTxt1.Location = new System.Drawing.Point(100, 35);
            this.NPasswrodTxt1.Name = "NPasswrodTxt1";
            this.NPasswrodTxt1.PasswordChar = '●';
            this.NPasswrodTxt1.Size = new System.Drawing.Size(206, 23);
            this.NPasswrodTxt1.TabIndex = 2;
            this.NPasswrodTxt1.TextChanged += new System.EventHandler(this.NPasswrodTxt1_TextChanged);
            // 
            // FPasswordTxt
            // 
            this.FPasswordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FPasswordTxt.BackColor = System.Drawing.Color.White;
            this.FPasswordTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FPasswordTxt.ForeColor = System.Drawing.Color.Black;
            this.FPasswordTxt.Location = new System.Drawing.Point(100, 6);
            this.FPasswordTxt.Name = "FPasswordTxt";
            this.FPasswordTxt.PasswordChar = '●';
            this.FPasswordTxt.Size = new System.Drawing.Size(206, 23);
            this.FPasswordTxt.TabIndex = 1;
            this.FPasswordTxt.TextChanged += new System.EventHandler(this.FPasswordTxt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(26, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "确认新密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(50, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "新密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(50, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "原密码";
            // 
            // SureChangeBtn
            // 
            this.SureChangeBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SureChangeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SureChangeBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.SureChangeBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SureChangeBtn.Location = new System.Drawing.Point(12, 102);
            this.SureChangeBtn.Name = "SureChangeBtn";
            this.SureChangeBtn.Size = new System.Drawing.Size(294, 44);
            this.SureChangeBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SureChangeBtn.TabIndex = 4;
            this.SureChangeBtn.Text = "确定(&S)";
            this.SureChangeBtn.Click += new System.EventHandler(this.DoChange);
            // 
            // ChangeUserDataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 158);
            this.Controls.Add(this.SureChangeBtn);
            this.Controls.Add(this.NPasswrodTxt2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NPasswrodTxt1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FPasswordTxt);
            this.Controls.Add(this.label7);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeUserDataWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更改密码";
            this.Load += new System.EventHandler(this.ChangeUserDataWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox NPasswrodTxt2;
        private System.Windows.Forms.TextBox NPasswrodTxt1;
        private System.Windows.Forms.TextBox FPasswordTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX SureChangeBtn;
    }
}