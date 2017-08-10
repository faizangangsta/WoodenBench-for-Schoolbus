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
using WoodenBench.Views;
using static WoodenBench.StaClasses.GlobalFunc;
using static WoodenBench.TableObject.AllUserObject;

namespace WoodenBench.GlobalEvents
{
    public class AppEvents
    {
        public static event onUserActivityHandler onUserActivityEvent;
        public static event onExcelProcFinishedHandler onExcelProcFinishedEvent;

        public static void onUserActivity(object sender, UserActivityEventArgs e)
        {
            if (onUserActivityEvent != null) { onUserActivityEvent(sender, e); }
        }
        public static void onExcelProcFinished(object sender, ExcelProcFinishedEventArgs e)
        {
            if (onExcelProcFinishedEvent != null) { onExcelProcFinishedEvent(sender, e); }
        }

        public static void RegEvents()
        {
            AppEvents.onUserActivityEvent += UsrLoginWindow.Default.EventRegister_Test;
        }
    }


    public class UserActivityEventArgs : EventArgs
    {
        public UserActivityEventArgs(UserActivityEnum Trigger, AllUserObject BChangeVal, AllUserObject AChangeVal, ProcStatusEnum Status)
        {
            Activity = Trigger;
            BeforeChange = BChangeVal;
            AfterChange = AChangeVal;
            ProcessStatus = Status;
        }
        public ProcStatusEnum ProcessStatus { get; }
        public UserActivityEnum Activity { get; }
        public AllUserObject BeforeChange { get; }
        public AllUserObject AfterChange { get; }
    }


    public class ExcelProcFinishedEventArgs : EventArgs
    {
        public ExcelProcFinishedEventArgs(ProcStatusEnum Status)
        {
            ProcessStatus = Status;
        }
        public ProcStatusEnum ProcessStatus { get; }
    }
}

