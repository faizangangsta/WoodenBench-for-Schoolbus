using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;
using WBPlatform.WinClient.Users;
using WBPlatform.WinClient.Views;

namespace WBPlatform.WinClient.StaticClasses
{
    public static partial class GlobalFunc
    {
        [STAThread]
        static void Main()
        {
            LogWritter.InitLog();
            LogWritter.DebugMessage("========= = Start WoodenBench for Schoolbus Windows Client = =========");
            Database.Initialise();
            Application.EnableVisualStyles();
            FileIO.onFileIOCompleted += Views.MainForm.Default.DnFinished;
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