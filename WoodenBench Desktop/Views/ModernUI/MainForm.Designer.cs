namespace WoodenBench
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainShell = new DevComponents.DotNetBar.Metro.MetroShell();
            this.colorThemeButton = new DevComponents.DotNetBar.ButtonItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // metroShell1
            // 
            this.MainShell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.MainShell.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MainShell.CaptionVisible = true;
            this.MainShell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainShell.ForeColor = System.Drawing.Color.Black;
            this.MainShell.HelpButtonText = "打开网页版";
            this.MainShell.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.MainShell.Location = new System.Drawing.Point(1, 1);
            this.MainShell.Name = "metroShell1";
            this.MainShell.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.colorThemeButton});
            this.MainShell.SettingsButtonText = "设置";
            this.MainShell.Size = new System.Drawing.Size(877, 638);
            this.MainShell.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.MainShell.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.MainShell.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.MainShell.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.MainShell.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.MainShell.SystemText.QatDialogAddButton = "&Add >>";
            this.MainShell.SystemText.QatDialogCancelButton = "Cancel";
            this.MainShell.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.MainShell.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.MainShell.SystemText.QatDialogOkButton = "OK";
            this.MainShell.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.MainShell.SystemText.QatDialogRemoveButton = "&Remove";
            this.MainShell.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.MainShell.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.MainShell.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.MainShell.TabIndex = 1;
            this.MainShell.TabStripFont = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainShell.Text = "metroShell1";
            this.MainShell.SelectedTabChanged += new System.EventHandler(this.metroShell1_SelectedTabChanged);
            this.MainShell.SettingsButtonClick += new System.EventHandler(this.metroShell1_SettingsButtonClick);
            this.MainShell.HelpButtonClick += new System.EventHandler(this.metroShell1_HelpButtonClick);
            this.MainShell.Click += new System.EventHandler(this.metroShell1_Click);
            // 
            // colorThemeButton
            // 
            this.colorThemeButton.AutoExpandOnClick = true;
            this.colorThemeButton.CanCustomize = false;
            this.colorThemeButton.Image = global::WoodenBench.Properties.Resources.ColorScheme;
            this.colorThemeButton.Name = "colorThemeButton";
            this.colorThemeButton.ShowSubItems = false;
            this.colorThemeButton.Text = "颜色主题";
            this.colorThemeButton.ThemeAware = true;
            this.colorThemeButton.Tooltip = "选择一个主题";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Light;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204))))));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(879, 640);
            this.Controls.Add(this.MainShell);
            this.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Metro.MetroShell MainShell;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonItem colorThemeButton;
    }
}