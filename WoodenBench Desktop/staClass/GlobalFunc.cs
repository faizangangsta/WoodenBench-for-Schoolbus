using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench_Desktop.TableObjects;
using WoodenBench_Desktop.View;

namespace WoodenBench_Desktop.staClass
{
    /// <summary>
    /// The public static class which contains Bmob variable, to be called
    /// </summary>
    public static partial class GlobalFunc
    {
        /// <summary>
		/// Main Entry of the Application
		/// </summary>
		[STAThread]
        static void Main()
        {
            DebugMessage("Application Started");
            //Initialize bmob Client
            staClass.GlobalFunc.InitBmobObject();
            ///Auto Generated
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ///Run specific window, with its name is "UsrLoginForm"
			Application.Run(new UsrLoginForm());
        }
        /// <summary>
        /// Static CurrentUser Data as <see cref="AllUsersTable"/>
        /// </summary>
        public static AllUsersTable CurrentUser { get; set; }

        /// <summary>
        /// Static variable, name is Bmob
        /// </summary>
        public static BmobWindows Bmob { get; set; }
        
        /// <summary>
        /// Initialize Bmob, using App Key and REST Key
        /// </summary>
        public static void InitBmobObject()
        {
            Bmob = new BmobWindows();
            // Nobody can use bmob, before initialize it.
            Bmob.initialize("b770100ff0051b0c313c1a0e975711e6", "281fb4c79c3a3391ae6764fa56d1468d");
            //Write Debug message into Debu.Writeline()
            BmobDebug.level = BmobDebug.Level.TRACE;
            DebugMessage("Bmob log level is set to 'trace'");
            BmobDebug.Register(Message => { Console.WriteLine(Message); });
        }

        /// <summary>
        /// Write Debug Message in the Debug window
        /// Instead of using <see cref="Console.WriteLine"/>
        /// </summary>
        /// <param name="Message">Msg object, not only string</param>
        public static void DebugMessage(object Message)
        {
            Debug.Write(DateTime.Now.ToLongTimeString());
            Debug.WriteLine(Message);
        }
        /// <summary>
        /// Called when the application exits.
        /// </summary>
        public static void ApplicationExit()
        {

            DebugMessage("Application Exits.");
        }
    }
}
