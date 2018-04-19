using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WBServicePlatform.Databases;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.TableObject;
using WBServicePlatform.WinClient.Users;
using WBServicePlatform.WinClient.Views;

namespace WBServicePlatform.WinClient.StaticClasses
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
            if (e.isSucceed) LogWritter.WriteLog(LogLevel.Infomation, $"Headimage download completed, at: {e.LocalFilePath}");
            else LogWritter.WriteLog(LogLevel.Error, e.ErrDescription);
            LogWritter.WriteLog(LogLevel.LongChain);
        }
    }
}