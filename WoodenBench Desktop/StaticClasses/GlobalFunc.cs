using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.DesktopClient.Users;
using WBPlatform.DesktopClient.Views;

namespace WBPlatform.DesktopClient.StaticClasses
{
    public static partial class GlobalFunc
    {
        [STAThread]
        static void Main()
        {
            LogWritter.InitLog();
            LogWritter.DebugMessage("========= = Start WoodenBench for Schoolbus Windows Client = =========");
            Database.Database.InitialiseClient();
            Application.EnableVisualStyles();
            FileIO.onFileIOCompleted += MainForm.Default.DnFinished;
            LogWritter.DebugMessage("Basic Events Registration Completed.");

            FileIO.onFileIOCompleted += FileIO_onFileIOCompleted;
            Application.Run(UsrLoginWindow.Default);
        }
        public static UserObject CurrentUser { get; set; } = new UserObject();
        //public static BmobWindows _BmobWin { get; set; }
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