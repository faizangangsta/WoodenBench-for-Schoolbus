using cn.bmob.io;
using cn.bmob.json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench.DelegateClasses;
using WoodenBench.StaClasses;
using WoodenBench.TableObject;
using WoodenBench.Users;
using WoodenBench.Views;
using static WoodenBench.StaClasses.GlobalFunc;

namespace WoodenBench.Events
{
    public class AppEvents
    {
        public static event onExcelProcFinishedHandler onExcelProcFinishedEvent;

        public static void onExcelProcFinished(object sender, ExcelProcFinishedEventArgs e)
        {
            if (onExcelProcFinishedEvent != null) { onExcelProcFinishedEvent(sender, e); }
        }

        public static void RegEvents()
        {
            UserActivity.onUserActivityEvent += UsrLoginWindow.Default.onUsrLgn;
        }
    }


    public class UserActivityEventArgs : EventArgs
    {
        public UserActivityEventArgs() { }
        public ProcStatusEnum ProcessStatus { get; set; }
        public UserActivityEnum Activity { get; set; }
        public AllUserObject AfterChange { get; set; }
        public string Describe { get; set; }
    }


    public class ExcelProcFinishedEventArgs : EventArgs
    {
        public ExcelProcFinishedEventArgs() { }
        public ProcStatusEnum ProcessStatus { get; set; }
    }
}

