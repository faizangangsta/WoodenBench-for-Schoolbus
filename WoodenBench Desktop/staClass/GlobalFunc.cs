using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench.TableObjects;
using WoodenBench.View;

namespace WoodenBench.staClass
{
    public static partial class GlobalFunc
    {
        [STAThread]
        static void Main()
        {
            DebugMessage("Application Started");
            staClass.GlobalFunc.InitBmobObject();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UsrLoginForm());
        }
        public static AllUsersTable CurrentUser { get; set; }
        public static BmobWindows Bmob { get; set; }
        public static void InitBmobObject()
        {
            Bmob = new BmobWindows();
            Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
            BmobDebug.level = BmobDebug.Level.TRACE;
            DebugMessage("Bmob log level is set to 'trace'");
            BmobDebug.Register(Message => { Console.WriteLine(Message); });
        }
        public static void DebugMessage(object Message)
        {
            Debug.Write(DateTime.Now.ToLongTimeString());
            Debug.WriteLine(Message);
        }
        public static void ApplicationExit()
        {
            DebugMessage("Application Exit");
            Application.Exit();
        }
    }
}
