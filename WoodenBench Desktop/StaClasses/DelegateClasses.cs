using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoodenBench.StaClasses;
using WoodenBench.Users;

namespace WoodenBench.DelegateClasses
{
    public delegate void nullArgDelegate();

    public delegate void FileIOCompletedEventHandler(fileIOCompletedEventArgs e);

    public delegate void UserActivityHandler(UserActivityEventArgs e);

    public delegate void ExcelProcFinishedHandler(ExcelProcFinishedEventArgs e);

    public class internalEventArgs : EventArgs
    {
        public ProcStatE ProcessStatus { get; set; }
        public string Description { get; set; }
        public Exception Exception { get; set; }
        public override string ToString()
        {
            if (ProcessStatus == ProcStatE.FailedWithErr) return Exception.Message;
            else return Description;
            return (ProcessStatus == ProcStatE.FailedWithErr) ? Exception.Message : Description;
        }
    }
}
