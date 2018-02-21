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
using WBServicePlatform.TableObject;
using WBServicePlatform.Users;
using WBServicePlatform.Views;

namespace WBServicePlatform.StaticClasses
{
    public static partial class GlobalFunc
    {
        [STAThread]
        static void Main()
        {
            LogWritter.InitLog();
            LogWritter.DebugMessage("========= = Start WoodenBench for Schoolbus Windows Client = =========");
            LogWritter.DebugMessage("Application Log Started, And now to the Initialization of Bmob Object.");
            InitBmobObject();
            Application.EnableVisualStyles();
            RegEvents();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(UsrLoginWindow.Default);
        }

        public static AllUserObject CurrentUser { get; set; }

        public static BmobWindows _BmobWin { get; set; }

        public static void ApplicationExit()
        {
            UserActivity.LogOut();
            LogWritter.DebugMessage("Application will now EXIT, User has been logged off, now" +
                " Closing Logs and terminal all windows.");
            Application.Exit();
            //Environment.Exit(0);
        }

        private static void RegEvents()
        {
            UserActivity.onUserActivityEvent += UsrLoginWindow.Default.onUsrLgn;
            UserActivity.onUserActivityEvent += CreateUserWindow.Default.onUserActivity;
            ExcelApplication.onExcelProcFinishedEvent += ExcelOperationWindow.Default.onExcelFilePorcFinished;
            FileIO.onFileIOCompleted += Views.MainForm.Default.DnFinished;
            LogWritter.DebugMessage("Basic Events Registration Completed.");
        }

        private static void InitBmobObject()
        {
            LogWritter.DebugMessage("Bmob log level is gonna set to \"trace\"");
            BmobDebug.Register(LogWritter.BmobDebugMsg, BmobDebug.Level.TRACE);
            _BmobWin = new BmobWindows();
            _BmobWin.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
            LogWritter.DebugMessage("Bmob Object is now initialized and ready to use.");
        }
    }
}
