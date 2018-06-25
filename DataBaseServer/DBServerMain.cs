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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void clientEnumTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> clientConncetionQueryStrings = DatabaseSocketsServer.clientQueryStrings;
                listView1.Items.Clear();
                foreach (KeyValuePair<string, string> item in clientConncetionQueryStrings)
                {
                    listView1.Items.Add(new ListViewItem(item.Key, item.Value));
                }
                dbConnections.Text = "1";
                currentClients.Text = listView1.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage(ex.Message);
            }
        }
    }
}
