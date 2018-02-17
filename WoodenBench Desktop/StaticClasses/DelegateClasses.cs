using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoodenBench.StaticClasses;
using WoodenBench.Users;

namespace WoodenBench.DelegateClasses
{
    public delegate void nullArgDelegate();

    public delegate void FileIOCompletedEventHandler(FileIOEventArgs e);

    public delegate void UserActivityHandler(UserActivityEventArgs e);

    public delegate void ExcelProcFinishedHandler(ExcelProcessEventArgs e);

    public delegate void DalegateFunction<Type_A>(Type_A type1);

    public delegate void DalegateFunction<Type_A, Type_B>(Type_A type1, Type_B type2);

    public class InternalEventArgs : EventArgs
    {
        public ProcStatE ProcessStatus { get; set; }
        public string Description { get; set; }
        public Exception Exception { get; set; }
        public override string ToString() => (ProcessStatus == ProcStatE.FailedWithErr) ? Exception.Message : Description;
    }
}
