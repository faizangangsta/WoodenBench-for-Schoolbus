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
            Application.Run(new MainForm());
        }

        public static AllUserObject CurrentUser { get; set; }

        public static BmobWindows _BmobWin { get; set; }
        
        public static void RegEvents()
        {
            UserActivity.onUserActivityEvent += UsrLoginWindow.Default.onUsrLgn;
        }

        public static void InitBmobObject()
        {
            _BmobWin = new BmobWindows();
            _BmobWin.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
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

        public static string RandomString(int Length, bool Symbols, string CustomStr = "")
        {
            byte[] b = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, f = CustomStr;
            f += "0123456789";
            f += "abcdefghijklmnopqrstuvwxyz";
            f += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (Symbols) f += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}（）_——-~·、，。；‘“’”《》￥……~";
            for (int i = 0; i < Length; i++)
            {
                s += f.Substring(r.Next(0, f.Length - 1), 1);
            }
            return s;
        }
    }
}
