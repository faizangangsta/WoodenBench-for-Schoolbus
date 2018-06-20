using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.DBServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogWritter.onLog += LogWritter_onLog;
        }

        private void LogWritter_onLog(LogWritter.OnLogChangedEventArgs logchange)
        {
            logsTextbox.Invoke(new Action(delegate { logsTextbox.Text += logchange.LogString; }));
        }
    }
}
