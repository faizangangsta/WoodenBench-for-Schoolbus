using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench.Views;
using static WoodenBench.staClass.GlobalFunc;
using static WoodenBench.staClass.UserActivity;

namespace WoodenBench.Views
{
    public partial class Management : Form
    {
        static int UsrLevel;

        public Management(int UserLevel) : base()
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
