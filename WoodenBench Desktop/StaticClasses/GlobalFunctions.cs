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
            LW.SetLogLevel(LogLevel.Dbg);
            LW.InitLog();
            LW.D("========= = Start WoodenBench for Schoolbus Windows Client = =========");
            if (!XConfig.LoadConfig("XConfig.conf"))
            {
                LW.E("Config Loading Failed! Check file...");
                return;
            }
            
            DataBaseOperation.InitialiseClient();            
            Application.EnableVisualStyles();
            Application.Run(LoginWindow.Default);
        }

        public static UserObject CurrentUser { get; set; } = UserObject.DefaultValue;

        public static void ApplicationExit()
        {
            LW.D("Terminating Application.....");
            Database.Connection.DatabaseSocketsClient.KillConnection();
            Application.Exit();
        }
    }
}