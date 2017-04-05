namespace AULWriter
{
    partial class frmAULWriter
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAULWriter));
			this.btnExit = new System.Windows.Forms.Button();
			this.btnProduce = new System.Windows.Forms.Button();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnExpt = new System.Windows.Forms.Button();
			this.txtExpt = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnDest = new System.Windows.Forms.Button();
			this.txtDest = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSrc = new System.Windows.Forms.Button();
			this.txtSrc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ofdSrc = new System.Windows.Forms.OpenFileDialog();
			this.sfdDest = new System.Windows.Forms.SaveFileDialog();
			this.ofdExpt = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnExit
			// 
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnExit.Location = new System.Drawing.Point(372, 208);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(57, 23);
			this.btnExit.TabIndex = 1;
			this.btnExit.Text = "退出(&X)";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnProduce
			// 
			this.btnProduce.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnProduce.Location = new System.Drawing.Point(270, 208);
			this.btnProduce.Name = "btnProduce";
			this.btnProduce.Size = new System.Drawing.Size(95, 23);
			this.btnProduce.TabIndex = 0;
			this.btnProduce.Text = "生成(&G)";
			this.btnProduce.UseVisualStyleBackColor = true;
			this.btnProduce.Click += new System.EventHandler(this.btnProduce_Click);
			// 
			// txtUrl
			// 
			this.txtUrl.Location = new System.Drawing.Point(77, 30);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(288, 21);
			this.txtUrl.TabIndex = 21;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 33);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 12);
			this.label5.TabIndex = 20;
			this.label5.Text = "更新网址:";
			// 
			// btnExpt
			// 
			this.btnExpt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnExpt.Location = new System.Drawing.Point(371, 154);
			this.btnExpt.Name = "btnExpt";
			this.btnExpt.Size = new System.Drawing.Size(58, 21);
			this.btnExpt.TabIndex = 19;
			this.btnExpt.Text = "选择(&S)";
			this.btnExpt.UseVisualStyleBackColor = true;
			this.btnExpt.Click += new System.EventHandler(this.btnSearExpt_Click);
			// 
			// txtExpt
			// 
			this.txtExpt.Location = new System.Drawing.Point(77, 56);
			this.txtExpt.Multiline = true;
			this.txtExpt.Name = "txtExpt";
			this.txtExpt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtExpt.Size = new System.Drawing.Size(288, 119);
			this.txtExpt.TabIndex = 18;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 12);
			this.label4.TabIndex = 17;
			this.label4.Text = "排除文件:";
			// 
			// btnDest
			// 
			this.btnDest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDest.Location = new System.Drawing.Point(372, 181);
			this.btnDest.Name = "btnDest";
			this.btnDest.Size = new System.Drawing.Size(58, 21);
			this.btnDest.TabIndex = 16;
			this.btnDest.Text = "选择(&S)";
			this.btnDest.UseVisualStyleBackColor = true;
			this.btnDest.Click += new System.EventHandler(this.btnSearDes_Click);
			// 
			// txtDest
			// 
			this.txtDest.Location = new System.Drawing.Point(77, 181);
			this.txtDest.Name = "txtDest";
			this.txtDest.Size = new System.Drawing.Size(288, 21);
			this.txtDest.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 185);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 12);
			this.label3.TabIndex = 14;
			this.label3.Text = "保存位置:";
			// 
			// btnSrc
			// 
			this.btnSrc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSrc.Location = new System.Drawing.Point(371, 5);
			this.btnSrc.Name = "btnSrc";
			this.btnSrc.Size = new System.Drawing.Size(58, 21);
			this.btnSrc.TabIndex = 13;
			this.btnSrc.Text = "选择(&S)";
			this.btnSrc.UseVisualStyleBackColor = true;
			this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
			// 
			// txtSrc
			// 
			this.txtSrc.Location = new System.Drawing.Point(77, 5);
			this.txtSrc.Name = "txtSrc";
			this.txtSrc.Size = new System.Drawing.Size(288, 21);
			this.txtSrc.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 12);
			this.label2.TabIndex = 11;
			this.label2.Text = "主程序:";
			// 
			// ofdSrc
			// 
			this.ofdSrc.DefaultExt = "*.exe";
			this.ofdSrc.Filter = "程序文件(*.exe)|*.exe|所有文件(*.*)|*.*";
			this.ofdSrc.Title = "请选择主程序文件";
			this.ofdSrc.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdDest_FileOk);
			// 
			// sfdDest
			// 
			this.sfdDest.CheckPathExists = false;
			this.sfdDest.DefaultExt = "*.xml";
			this.sfdDest.FileName = "AutoUpdaterList.xml";
			this.sfdDest.Filter = "XML文件(*.xml)|*.xml";
			this.sfdDest.Title = "请选择保存位置";
			this.sfdDest.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdSrcPath_FileOk);
			// 
			// ofdExpt
			// 
			this.ofdExpt.DefaultExt = "*.*";
			this.ofdExpt.Filter = "所有文件(*.*)|*.*";
			this.ofdExpt.Multiselect = true;
			this.ofdExpt.Title = "请选择主程序文件";
			this.ofdExpt.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdExpt_FileOk);
			// 
			// frmAULWriter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(437, 244);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnProduce);
			this.Controls.Add(this.btnSrc);
			this.Controls.Add(this.txtUrl);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtSrc);
			this.Controls.Add(this.btnExpt);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtExpt);
			this.Controls.Add(this.txtDest);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnDest);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAULWriter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Auto Update Writer";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnProduce;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog ofdSrc;
        private System.Windows.Forms.SaveFileDialog sfdDest;
        private System.Windows.Forms.OpenFileDialog ofdExpt;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnExpt;
		private System.Windows.Forms.TextBox txtExpt;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnDest;
		private System.Windows.Forms.TextBox txtDest;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSrc;
		private System.Windows.Forms.TextBox txtSrc;
		private System.Windows.Forms.Label label2;
	}
}

