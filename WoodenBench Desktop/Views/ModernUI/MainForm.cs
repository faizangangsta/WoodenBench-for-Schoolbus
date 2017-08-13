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

namespace WoodenBench
{
    public partial class MainForm : MetroAppForm
    {
        StartControl _StartControl = null; // Start control displayed on startup
        MetroBillCommands _Commands = null; // All application commands
        public MainForm()
        {
            InitializeComponent();
            // Prepare commands
            _Commands = new MetroBillCommands() { ToggleStartControl = new Command(components) };
            _Commands.ToggleStartControl.Executed += new EventHandler(ToggleStartControlExecuted);
            _Commands.ChangeMetroTheme = new Command(components, new EventHandler(ChangeMetroThemeExecuted));

            SuspendLayout();
            _StartControl = new StartControl();
            Controls.Add(_StartControl);
            _StartControl.BringToFront();
            _StartControl.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
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
        }


        private void ChangeMetroThemeExecuted(object sender, EventArgs e)
        {
            ICommandSource source = (ICommandSource)sender;
            MetroColorGeneratorParameters theme = (MetroColorGeneratorParameters)source.CommandParameter;
            StyleManager.MetroColorGeneratorParameters = theme;
        }

        private void ToggleStartControlExecuted(object sender, EventArgs e)
        {
            _StartControl.IsOpen = !_StartControl.IsOpen;
        }
        

        protected override void OnLoad(EventArgs e)
        {
            UpdateControlsSizeAndLocation();
            base.OnLoad(e);
        }

        private Rectangle GetStartControlBounds()
        {
            int captionHeight = metroShell1.MetroTabStrip.GetCaptionHeight() + 2;
            Thickness borderThickness = GetBorderThickness();
            return new Rectangle((int)borderThickness.Left, captionHeight, Width - (int)borderThickness.Horizontal, Height - captionHeight +20);
        }
        private void UpdateControlsSizeAndLocation()
        {
            if (_StartControl != null)
            {
                if (!_StartControl.IsOpen) _StartControl.OpenBounds = GetStartControlBounds();
                else _StartControl.Bounds = GetStartControlBounds();
                if (!IsModalPanelDisplayed) _StartControl.BringToFront();
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
            MessageBoxEx.Show(this, "MetroShell Help Button Clicked", "Metro Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroShell1_SelectedTabChanged(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }

        private void metroShell1_Click(object sender, EventArgs e)
        {

        }
    }
}