using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.DBServer
{
    static class Program
    {
        public static MainForm mainForm { get; set; }
        [STAThread]
        static void Main()
        {
            LogWritter.InitLog();
            DatabaseCore.InitialiseDBConnection();
            DatabaseSocketsServer.InitialiseSockets();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            try
            {
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                while (true)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
