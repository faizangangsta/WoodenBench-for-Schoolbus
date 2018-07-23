using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;

using WBPlatform.Database;
using WBPlatform.DesktopClient.Users;
using WBPlatform.DesktopClient.Views;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace WBPlatform.DesktopClient.StaticClasses
{
    public static partial class GlobalFunctions
    {
        [STAThread]
        public static void Main()
        {
            LW.InitLog();
            LW.D("========= = Start WoodenBench for Schoolbus Windows Client = =========");
            DataBaseOperation.InitialiseClient(IPAddress.Parse("118.190.144.179"));
            
            Application.EnableVisualStyles();
            FileIO.onFileIOCompleted += MainForm.Default.DnFinished;
            LW.D("Basic Events Registration Completed.");

            FileIO.onFileIOCompleted += FileIO_onFileIOCompleted;
            Application.Run(LoginWindow.Default);
        }

        public static UserObject CurrentUser { get; set; } = new UserObject();

        public static void ApplicationExit()
        {
            LW.D("Application will now EXIT, User has been logged off, now Closing Logs and terminal all windows.");
            Application.Exit();
        }

        private static void FileIO_onFileIOCompleted(FileIOEventArgs e)
        {
            if (e.isSucceed) LW.D($"Headimage download completed, at: {e.LocalFilePath}");
            else LW.E(e.ErrDescription);
        }
    }
}