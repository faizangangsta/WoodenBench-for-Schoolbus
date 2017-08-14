using DevComponents.DotNetBar.Controls;
using System;
using System.Drawing;

namespace WoodenBench
{
    public partial class StartControl : SlidePanel
    {
        public StartControl()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            itemPanel1.Location = new Point((Width - itemPanel1.Width) / 2 + 16, ((Height - labelX1.Height - 16) - itemPanel1.Height) / 2 + labelX1.Height + 16);
            labelX1.Location = new Point((Width - itemPanel1.Width) / 2 - 25, ((Height - labelX1.Height - 16) - itemPanel1.Height) / 2 + labelX1.Height - 50);

            base.OnResize(e);
        }

        private void StartControl_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            IsOpen = false;
        }
    }
}
