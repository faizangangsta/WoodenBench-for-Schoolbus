namespace WoodenBench.Views.ModernView
{
    partial class UsrLoginWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrLoginWindow));
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PswdTxt = new System.Windows.Forms.TextBox();
            this.CancelBtn = new DevComponents.DotNetBar.ButtonX();
            this.DoLoginBtn = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginResult = new System.Windows.Forms.Label();
            this.NewUserLabel = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.MainStyle = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTxt.BackColor = System.Drawing.Color.White;
            this.UserNameTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameTxt.ForeColor = System.Drawing.Color.Black;
            this.UserNameTxt.Location = new System.Drawing.Point(89, 9);
            this.UserNameTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(258, 23);
            this.UserNameTxt.TabIndex = 0;
            this.UserNameTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // PswdTxt
            // 
            this.PswdTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PswdTxt.BackColor = System.Drawing.Color.White;
            this.PswdTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PswdTxt.ForeColor = System.Drawing.Color.Black;
            this.PswdTxt.Location = new System.Drawing.Point(89, 40);
            this.PswdTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PswdTxt.Name = "PswdTxt";
            this.PswdTxt.PasswordChar = '●';
            this.PswdTxt.ShortcutsEnabled = false;
            this.PswdTxt.Size = new System.Drawing.Size(258, 23);
            this.PswdTxt.TabIndex = 2;
            this.PswdTxt.WordWrap = false;
            this.PswdTxt.TextChanged += new System.EventHandler(this.PswdTxt_TextChanged);
            // 
            // CancelBtn
            // 
            this.CancelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(124, 83);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.CancelBtn.Size = new System.Drawing.Size(113, 30);
            this.CancelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // DoLoginBtn
            // 
            this.DoLoginBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DoLoginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoLoginBtn.Location = new System.Drawing.Point(245, 83);
            this.DoLoginBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DoLoginBtn.Name = "DoLoginBtn";
            this.DoLoginBtn.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.DoLoginBtn.Size = new System.Drawing.Size(113, 30);
            this.DoLoginBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.DoLoginBtn.Symbol = "";
            this.DoLoginBtn.SymbolSize = 15F;
            this.DoLoginBtn.TabIndex = 4;
            this.DoLoginBtn.Text = "登录(&L)";
            this.DoLoginBtn.Click += new System.EventHandler(this.DoLogin);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(42, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码：";
            // 
            // LoginResult
            // 
            this.LoginResult.AutoSize = true;
            this.LoginResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.LoginResult.ForeColor = System.Drawing.Color.Black;
            this.LoginResult.Location = new System.Drawing.Point(30, 129);
            this.LoginResult.Name = "LoginResult";
            this.LoginResult.Size = new System.Drawing.Size(0, 17);
            this.LoginResult.TabIndex = 6;
            // 
            // NewUserLabel
            // 
            this.NewUserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewUserLabel.AutoSize = true;
            this.NewUserLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.NewUserLabel.ForeColor = System.Drawing.Color.Black;
            this.NewUserLabel.Location = new System.Drawing.Point(14, 96);
            this.NewUserLabel.Name = "NewUserLabel";
            this.NewUserLabel.Size = new System.Drawing.Size(54, 17);
            this.NewUserLabel.TabIndex = 7;
            this.NewUserLabel.TabStop = true;
            this.NewUserLabel.Text = "新用户 ?";
            this.NewUserLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateUsr);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.linkLabel1.ForeColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(14, 79);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 17);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "家长登录";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ParentsLogin);
            // 
            // MainStyle
            // 
            this.MainStyle.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Light;
            this.MainStyle.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204))))));
            // 
            // UsrLoginWindow
            // 
            this.AcceptButton = this.DoLoginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(372, 125);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.NewUserLabel);
            this.Controls.Add(this.LoginResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DoLoginBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.PswdTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNameTxt);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsrLoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.Load += new System.EventHandler(this.UsrLoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PswdTxt;
        private DevComponents.DotNetBar.ButtonX CancelBtn;
        private DevComponents.DotNetBar.ButtonX DoLoginBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LoginResult;
        private System.Windows.Forms.LinkLabel NewUserLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public DevComponents.DotNetBar.StyleManager MainStyle;
    }
}

