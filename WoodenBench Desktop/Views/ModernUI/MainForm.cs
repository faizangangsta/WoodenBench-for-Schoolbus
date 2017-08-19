using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar;
using System.Diagnostics;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.Metro.ColorTables;
using static WoodenBench.StaClasses.GlobalFunc;
using System.Security;

namespace WoodenBench.Views.ModernView
{
    public partial class MainForm : MetroAppForm
    {
        MenuUsrControl UsrMenu = null; // Start control displayed on startup
        MetroBillCommands _Commands = null; // All application commands    
        public class MetroBillCommands
        {
            public Command ChangeMetroTheme { get; set; }
        }
        public MainForm()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            // Prepare commands
            _Commands = new MetroBillCommands();
            _Commands.ChangeMetroTheme = new Command(components, new EventHandler(ChangeMetroThemeExecuted));

            SuspendLayout();
            UsrMenu = new MenuUsrControl();
            Controls.Add(UsrMenu);
            UsrMenu.BringToFront();
            //UsrMenu.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
            ResumeLayout(false);
            // Add metro color themes
            MetroColorGeneratorParameters[] metroThemes = MetroColorGeneratorParameters.GetAllPredefinedThemes();
            foreach (MetroColorGeneratorParameters mt in metroThemes)
            {
                ButtonItem theme = new ButtonItem(mt.ThemeName, mt.ThemeName)
                {
                    Command = _Commands.ChangeMetroTheme,
                    CommandParameter = mt
                };
                colorThemeButton.SubItems.Add(theme);
            }
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static MainForm defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e) { defaultInstance = null; }
        public static MainForm Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new MainForm();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion
        
        private void ChangeMetroThemeExecuted(object sender, EventArgs e)
        {
            ICommandSource source = (ICommandSource)sender;
            MetroColorGeneratorParameters theme = (MetroColorGeneratorParameters)source.CommandParameter;
            StyleManager.MetroColorGeneratorParameters = theme;
        }

        protected override void OnLoad(EventArgs e)
        {
            UpdateControlsSizeAndLocation();
            base.OnLoad(e);
        }

        private void UpdateControlsSizeAndLocation()
        {
            if (UsrMenu != null)
            {
                if (!UsrMenu.IsOpen) UsrMenu.OpenBounds = GetStartControlBounds();
                else UsrMenu.Bounds = GetStartControlBounds();
                if (!IsModalPanelDisplayed) UsrMenu.BringToFront();
            }
            Rectangle GetStartControlBounds()
            {
                int captionHeight = MainShell.MetroTabStrip.GetCaptionHeight() + 3;
                Thickness borderThickness = GetBorderThickness();
                return new Rectangle((int)borderThickness.Left, captionHeight, Width - (int)borderThickness.Horizontal, Height - captionHeight + 20);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            UpdateControlsSizeAndLocation();
            base.OnResize(e);
        }


        private void metroShell1_SettingsButtonClick(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, "MetroShell Settings Button Clicked", "Metro Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroShell1_HelpButtonClick(object sender, EventArgs e)
        {
            Process.Start("http://lhy0403.iego.net/SchoolBusMgr/");
        }

        private void metroShell1_SelectedTabChanged(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }

        private void MainForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            UsrMenu.Dispose();
            ApplicationExit();
        }

        private void metroShell1_Click(object sender, EventArgs e)
        {

        }
    }
}