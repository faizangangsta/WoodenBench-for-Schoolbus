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
            LogWritter.InitLog();
            LogWritter.DebugMessage("========= = Start WoodenBench for Schoolbus Windows Client = =========");
            DatabaseOperation.InitialiseClient(IPAddress.Parse("118.190.144.179"));
            
            Application.EnableVisualStyles();
            FileIO.onFileIOCompleted += MainForm.Default.DnFinished;
            LogWritter.DebugMessage("Basic Events Registration Completed.");

            FileIO.onFileIOCompleted += FileIO_onFileIOCompleted;
            Application.Run(LoginWindow.Default);
        }

        public static UserObject CurrentUser { get; set; } = new UserObject();

        public static void ApplicationExit()
        {
            LogWritter.DebugMessage("Application will now EXIT, User has been logged off, now Closing Logs and terminal all windows.");
            Application.Exit();
        }

        private static void FileIO_onFileIOCompleted(FileIOEventArgs e)
        {
            if (e.isSucceed) LogWritter.WriteLog(LogType.Info, $"Headimage download completed, at: {e.LocalFilePath}");
            else LogWritter.WriteLog(LogType.Err, e.ErrDescription);
            LogWritter.WriteLog(LogType.LongChain);
        }
    }
}