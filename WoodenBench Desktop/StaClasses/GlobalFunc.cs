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
using WoodenBench.TableObject;
using WoodenBench.Users;
using WoodenBench.Views;
using WoodenBench.Views.ModernView;

namespace WoodenBench.StaClasses
{
    public static partial class GlobalFunc
    {
        [MTAThread]
        static void Main()
        {
            DebugMessage("Application Started");
            InitBmobObject();
            Application.EnableVisualStyles();
            RegEvents();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(UsrLoginWindow.Default);
        }

        public static AllUserObject CurrentUser { get; set; }

        public static BmobWindows _BmobWin { get; set; }

        public static void RegEvents()
        {
            UserActivity.onUserActivityEvent += UsrLoginWindow.Default.onUsrLgn;
            FileIO.onFileIOCompleted += MenuUsrControl.DnFinished;
        }

        public static void InitBmobObject()
        {
            BmobDebug.level = BmobDebug.Level.TRACE;
            DebugMessage("Bmob log level is set to 'trace'");
            BmobDebug.Register(Message => { DebugMessage(Message); });
            _BmobWin = new BmobWindows();
            _BmobWin.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
        }

        public static void DebugMessage(object Message)
        {
            Debug.Write(DateTime.Now.ToLongTimeString());
            Debug.WriteLine(" - " + Message);
        }

        public static void ApplicationExit()
        {
            UserActivity.LogOut();
            DebugMessage("Application Exit");
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
