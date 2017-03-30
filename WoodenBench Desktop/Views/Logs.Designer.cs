namespace WoodenBench_Desktop.Views
{
	partial class Logs
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logs));
			this.OutputText = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// OutputText
			// 
			this.OutputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.OutputText.Font = new System.Drawing.Font("宋体", 9F);
			this.OutputText.Location = new System.Drawing.Point(12, 11);
			this.OutputText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.OutputText.Multiline = true;
			this.OutputText.Name = "OutputText";
			this.OutputText.Size = new System.Drawing.Size(608, 153);
			this.OutputText.TabIndex = 0;
			this.OutputText.WordWrap = false;
			this.OutputText.TextChanged += new System.EventHandler(this.OutputText_TextChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Font = new System.Drawing.Font("宋体", 9F);
			this.button1.Location = new System.Drawing.Point(12, 169);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(608, 28);
			this.button1.TabIndex = 1;
			this.button1.Text = "隐藏(&H)";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Logs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 9F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(631, 209);
			this.ControlBox = false;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.OutputText);
			this.Font = new System.Drawing.Font("宋体", 7F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Logs";
			this.ShowInTaskbar = false;
			this.Text = "输出";
			this.Load += new System.EventHandler(this.Logs_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox OutputText;
		private System.Windows.Forms.Button button1;
	}
}