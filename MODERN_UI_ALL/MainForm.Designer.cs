namespace MetroBill
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
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.metroShell1 = new DevComponents.DotNetBar.Metro.MetroShell();
            this.metroTabPanel2 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroToolbar2 = new DevComponents.DotNetBar.Metro.MetroToolbar();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.newClientButton = new DevComponents.DotNetBar.ButtonItem();
            this.clientReportButton = new DevComponents.DotNetBar.ButtonItem();
            this.metroTabPanel1 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroToolbar1 = new DevComponents.DotNetBar.Metro.MetroToolbar();
            this.voidInvoiceButton = new DevComponents.DotNetBar.ButtonItem();
            this.addNoteButton = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.newInvoiceButton = new DevComponents.DotNetBar.ButtonItem();
            this.markAsPaidButton = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.metroTabItem1 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItem2 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.colorThemeButton = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.metroShell1.SuspendLayout();
            this.metroTabPanel2.SuspendLayout();
            this.metroTabPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.DragDropSupport = true;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1});
            this.metroStatusBar1.Location = new System.Drawing.Point(1, 518);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(851, 22);
            this.metroStatusBar1.TabIndex = 0;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "READY";
            // 
            // metroShell1
            // 
            this.metroShell1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroShell1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroShell1.CaptionVisible = true;
            this.metroShell1.Controls.Add(this.metroTabPanel2);
            this.metroShell1.Controls.Add(this.metroTabPanel1);
            this.metroShell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroShell1.ForeColor = System.Drawing.Color.Black;
            this.metroShell1.HelpButtonText = "打开网页版";
            this.metroShell1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroTabItem1,
            this.metroTabItem2});
            this.metroShell1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.metroShell1.Location = new System.Drawing.Point(1, 1);
            this.metroShell1.Name = "metroShell1";
            this.metroShell1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.colorThemeButton,
            this.qatCustomizeItem1});
            this.metroShell1.SettingsButtonText = "设置";
            this.metroShell1.Size = new System.Drawing.Size(851, 517);
            this.metroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.metroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.metroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.metroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.metroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.metroShell1.SystemText.QatDialogAddButton = "&Add >>";
            this.metroShell1.SystemText.QatDialogCancelButton = "Cancel";
            this.metroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.metroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.metroShell1.SystemText.QatDialogOkButton = "OK";
            this.metroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatDialogRemoveButton = "&Remove";
            this.metroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.metroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.metroShell1.TabIndex = 1;
            this.metroShell1.TabStripFont = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell1.Text = "metroShell1";
            this.metroShell1.SelectedTabChanged += new System.EventHandler(this.metroShell1_SelectedTabChanged);
            this.metroShell1.SettingsButtonClick += new System.EventHandler(this.metroShell1_SettingsButtonClick);
            this.metroShell1.HelpButtonClick += new System.EventHandler(this.metroShell1_HelpButtonClick);
            this.metroShell1.Click += new System.EventHandler(this.metroShell1_Click);
            // 
            // metroTabPanel2
            // 
            this.metroTabPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel2.Controls.Add(this.metroToolbar2);
            this.metroTabPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPanel2.Location = new System.Drawing.Point(0, 52);
            this.metroTabPanel2.Name = "metroTabPanel2";
            this.metroTabPanel2.Padding = new System.Windows.Forms.Padding(16, 3, 16, 40);
            this.metroTabPanel2.Size = new System.Drawing.Size(851, 465);
            // 
            // 
            // 
            this.metroTabPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel2.TabIndex = 2;
            // 
            // metroToolbar2
            // 
            this.metroToolbar2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroToolbar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroToolbar2.ContainerControlProcessDialogKey = true;
            this.metroToolbar2.DragDropSupport = true;
            this.metroToolbar2.ExpandDirection = DevComponents.DotNetBar.Metro.eExpandDirection.Top;
            this.metroToolbar2.ExtraItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem9});
            this.metroToolbar2.ForeColor = System.Drawing.Color.Black;
            this.metroToolbar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.newClientButton,
            this.clientReportButton});
            this.metroToolbar2.Location = new System.Drawing.Point(250, 427);
            this.metroToolbar2.Name = "metroToolbar2";
            this.metroToolbar2.Size = new System.Drawing.Size(388, 38);
            this.metroToolbar2.TabIndex = 1;
            this.metroToolbar2.Text = "Clients";
            // 
            // buttonItem9
            // 
            this.buttonItem9.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem9.Image = global::MetroBill.Properties.Resources.Delete1;
            this.buttonItem9.ImageAlt = global::MetroBill.Properties.Resources.DeleteWhite;
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.Text = "Delete Client";
            this.buttonItem9.Tooltip = "Deletes selected client";
            // 
            // newClientButton
            // 
            this.newClientButton.Image = global::MetroBill.Properties.Resources.User1;
            this.newClientButton.ImageAlt = global::MetroBill.Properties.Resources.UserWhite1;
            this.newClientButton.Name = "newClientButton";
            this.newClientButton.Text = "Add new client";
            this.newClientButton.Tooltip = "Add new client";
            // 
            // clientReportButton
            // 
            this.clientReportButton.Image = global::MetroBill.Properties.Resources.Table1;
            this.clientReportButton.ImageAlt = global::MetroBill.Properties.Resources.TableWhite1;
            this.clientReportButton.Name = "clientReportButton";
            this.clientReportButton.Text = "Client Report";
            this.clientReportButton.Tooltip = "Client Activity Report";
            // 
            // metroTabPanel1
            // 
            this.metroTabPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel1.Controls.Add(this.metroToolbar1);
            this.metroTabPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPanel1.Location = new System.Drawing.Point(0, 52);
            this.metroTabPanel1.Name = "metroTabPanel1";
            this.metroTabPanel1.Padding = new System.Windows.Forms.Padding(16, 3, 16, 40);
            this.metroTabPanel1.Size = new System.Drawing.Size(851, 465);
            // 
            // 
            // 
            this.metroTabPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel1.TabIndex = 1;
            this.metroTabPanel1.Visible = false;
            // 
            // metroToolbar1
            // 
            this.metroToolbar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroToolbar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroToolbar1.ContainerControlProcessDialogKey = true;
            this.metroToolbar1.DragDropSupport = true;
            this.metroToolbar1.ExpandDirection = DevComponents.DotNetBar.Metro.eExpandDirection.Top;
            this.metroToolbar1.ExtraItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.voidInvoiceButton,
            this.addNoteButton,
            this.buttonItem7});
            this.metroToolbar1.ForeColor = System.Drawing.Color.Black;
            this.metroToolbar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.newInvoiceButton,
            this.markAsPaidButton,
            this.buttonItem8});
            this.metroToolbar1.Location = new System.Drawing.Point(250, 420);
            this.metroToolbar1.Name = "metroToolbar1";
            this.metroToolbar1.Size = new System.Drawing.Size(388, 38);
            this.metroToolbar1.TabIndex = 0;
            this.metroToolbar1.Text = "Invoices";
            // 
            // voidInvoiceButton
            // 
            this.voidInvoiceButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.voidInvoiceButton.Image = global::MetroBill.Properties.Resources.Delete1;
            this.voidInvoiceButton.ImageAlt = global::MetroBill.Properties.Resources.DeleteWhite;
            this.voidInvoiceButton.Name = "voidInvoiceButton";
            this.voidInvoiceButton.Text = "Void Invoice";
            this.voidInvoiceButton.Tooltip = "Void Selected Invoice";
            // 
            // addNoteButton
            // 
            this.addNoteButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.addNoteButton.Image = global::MetroBill.Properties.Resources.BookNote;
            this.addNoteButton.ImageAlt = global::MetroBill.Properties.Resources.BookNoteWhite;
            this.addNoteButton.Name = "addNoteButton";
            this.addNoteButton.Text = "Add a Note";
            this.addNoteButton.Tooltip = "Add note to selected invoice";
            // 
            // buttonItem7
            // 
            this.buttonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem7.Image = global::MetroBill.Properties.Resources.PaperClip;
            this.buttonItem7.ImageAlt = global::MetroBill.Properties.Resources.PaperClipWhite;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Text = "Attach a File";
            this.buttonItem7.Tooltip = "Attach a file to selected invoice";
            // 
            // newInvoiceButton
            // 
            this.newInvoiceButton.Image = global::MetroBill.Properties.Resources.NewInvoice1;
            this.newInvoiceButton.ImageAlt = global::MetroBill.Properties.Resources.NewInvoiceWhite;
            this.newInvoiceButton.Name = "newInvoiceButton";
            this.newInvoiceButton.Text = "Create New Invoice";
            this.newInvoiceButton.Tooltip = "Create New Invoice";
            // 
            // markAsPaidButton
            // 
            this.markAsPaidButton.Image = global::MetroBill.Properties.Resources.MarkAsPaid;
            this.markAsPaidButton.ImageAlt = global::MetroBill.Properties.Resources.MarkAsPaidWhite;
            this.markAsPaidButton.Name = "markAsPaidButton";
            this.markAsPaidButton.Text = "Mark As Paid";
            this.markAsPaidButton.Tooltip = "Mark selected invoice as PAID";
            // 
            // buttonItem8
            // 
            this.buttonItem8.Image = global::MetroBill.Properties.Resources.Print1;
            this.buttonItem8.ImageAlt = global::MetroBill.Properties.Resources.PrintWhite;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.Text = "Print selected invoice";
            this.buttonItem8.Tooltip = "Print selected invoice";
            // 
            // metroTabItem1
            // 
            this.metroTabItem1.Name = "metroTabItem1";
            this.metroTabItem1.Panel = this.metroTabPanel1;
            this.metroTabItem1.Text = "&INVOICES";
            // 
            // metroTabItem2
            // 
            this.metroTabItem2.Checked = true;
            this.metroTabItem2.Name = "metroTabItem2";
            this.metroTabItem2.Panel = this.metroTabPanel2;
            this.metroTabItem2.Text = "&CLIENTS";
            this.metroTabItem2.Click += new System.EventHandler(this.metroTabItem2_Click);
            // 
            // colorThemeButton
            // 
            this.colorThemeButton.AutoExpandOnClick = true;
            this.colorThemeButton.CanCustomize = false;
            this.colorThemeButton.Image = global::MetroBill.Properties.Resources.ColorScheme;
            this.colorThemeButton.Name = "colorThemeButton";
            this.colorThemeButton.ShowSubItems = false;
            this.colorThemeButton.Text = "Metro Color Themes";
            this.colorThemeButton.Tooltip = "Choose Metro Color Theme";
            this.colorThemeButton.Click += new System.EventHandler(this.colorThemeButton_Click);
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.BeginGroup = true;
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(853, 541);
            this.Controls.Add(this.metroShell1);
            this.Controls.Add(this.metroStatusBar1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "管理";
            this.metroShell1.ResumeLayout(false);
            this.metroShell1.PerformLayout();
            this.metroTabPanel2.ResumeLayout(false);
            this.metroTabPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.Metro.MetroShell metroShell1;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel1;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel2;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem1;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem2;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Metro.MetroToolbar metroToolbar1;
        private DevComponents.DotNetBar.ButtonItem newInvoiceButton;
        private DevComponents.DotNetBar.ButtonItem voidInvoiceButton;
        private DevComponents.DotNetBar.ButtonItem addNoteButton;
        private DevComponents.DotNetBar.ButtonItem markAsPaidButton;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.Metro.MetroToolbar metroToolbar2;
        private DevComponents.DotNetBar.ButtonItem newClientButton;
        private DevComponents.DotNetBar.ButtonItem clientReportButton;
        private DevComponents.DotNetBar.ButtonItem buttonItem8;
        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        private DevComponents.DotNetBar.ButtonItem colorThemeButton;
        private DevComponents.DotNetBar.LabelItem labelItem1;
    }
}