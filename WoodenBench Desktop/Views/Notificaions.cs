using cn.bmob.io;
using cn.bmob.response;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WBServicePlatform.TableObject;
using WBServicePlatform.StaticClasses;
using static WBServicePlatform.WinClient.StaticClasses.GlobalFunc;
using WBServicePlatform.WinClient.Users;

namespace WBServicePlatform.WinClient.Views
{
    public partial class Notifications : MetroForm
    {
        public Notifications()
        {
            InitializeComponent();
            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static Notifications defaultInstance { get; set; }
        static void DefaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        public static Notifications Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new Notifications();
                    defaultInstance.FormClosed += new FormClosedEventHandler(DefaultInstance_FormClosed);
                }
                return defaultInstance;
            }
        }
        #endregion

        private void BusesManager_Load(object sender, EventArgs e)
        {

        }
        
        private void BusesManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Default.Show();
        }
    }
}