using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
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
            InitBmobObject();
            Application.EnableVisualStyles();
            RegEvents();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(UsrLoginWindow.Default);
        }

        public static UserObject CurrentUser { get; set; }

        public static BmobWindows _BmobWin { get; set; }

        public static void ApplicationExit()
        {
            UserActivity.LogOut();
            LogWritter.DebugMessage("Application will now EXIT, User has been logged off, now Closing Logs and terminal all windows.");
            Application.Exit();
        }

        private static void RegEvents()
        {
            UserActivity.onUserActivityEvent += UsrLoginWindow.Default.onUsrLgn;
            ExcelApplication.onExcelProcFinishedEvent += StudentUploadWindow.Default.onExcelFilePorcFinished;
            FileIO.onFileIOCompleted += Views.MainForm.Default.DnFinished;
            LogWritter.DebugMessage("Basic Events Registration Completed.");
        }

        private static void InitBmobObject()
        {
            LogWritter.DebugMessage("Now to the Initialization of Bmob Object.");
            LogWritter.DebugMessage("Bmob log level is gonna set to \"trace\"");
            BmobDebug.Register(LogWritter.BmobDebugMsg, BmobDebug.Level.TRACE);
            _BmobWin = new BmobWindows();
            _BmobWin.initialize(WBConsts.BmobAppKey, WBConsts.BmobRESTKey);
            LogWritter.DebugMessage("Bmob Object is now initialized and ready to use.");
        }
    }
}
