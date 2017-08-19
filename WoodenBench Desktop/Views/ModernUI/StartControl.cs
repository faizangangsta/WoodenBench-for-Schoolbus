using DevComponents.DotNetBar.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using static WoodenBench.StaClasses.GlobalFunc;
using static WoodenBench.StaClasses.FileIO;
using WoodenBench.StaClasses;

namespace WoodenBench.Views.ModernView
{
    public partial class MenuUsrControl : SlidePanel
    {

        public MenuUsrControl() : base()
        {
            InitializeComponent();

            if (defaultInstance == null) defaultInstance = this;
        }
        #region For us easier to call
        private static MenuUsrControl defaultInstance { get; set; }
        public static MenuUsrControl Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new MenuUsrControl();
                }
                return defaultInstance;
            }
        }
        #endregion

        protected override void OnResize(EventArgs e)
        {
            itemPanel1.Location = new Point((Width - itemPanel1.Width) / 2 + 16, ((Height - labelX1.Height - 16) - itemPanel1.Height) / 2 + labelX1.Height + 16);
            labelX1.Location = new Point((Width - itemPanel1.Width) / 2 - 25, ((Height - labelX1.Height - 16) - itemPanel1.Height) / 2 + labelX1.Height - 50);

            base.OnResize(e);
        }

        private void StartControl_Load(object sender, EventArgs e)
        {
            labelX2.Text = "<div align=\"right\"><font size=\"+4\">"
                + CurrentUser.RealName + "</font><br/>" + CurrentUser.objectId + "</div>";
            DownloadFile(CurrentUser.UserImage.url, Environment.CurrentDirectory + "//Temp//" + CurrentUser.UserName + "-HImg.png");
        }

        public static void DnFinished(fileIOCompletedEventArgs e)
        {
            if (e.ProcessStatus == ProcStatE.Completed)
            {
                Default.pictureBox1.BackgroundImage = BytesToImage(ReadFileBytes(e.LocalFilePath));
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            IsOpen = false;
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }
    }
}
