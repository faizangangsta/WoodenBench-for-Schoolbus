using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench.Views;
using static WoodenBench.StaClasses.GlobalFunc;

namespace WoodenBench.Views
{
    public partial class ManagementWindow : DevComponents.DotNetBar.Metro.MetroForm
    {
        static int UsrLevel;

        public ManagementWindow(int UserLevel) : base()
        {
            InitializeComponent();
            UsrLevel = UserLevel;
        }

        private void Management_Load(object sender, EventArgs e)
        {

        }

        private void BtnWinUpdate(object sender, EventArgs e)
        {

        }        
    }
}
