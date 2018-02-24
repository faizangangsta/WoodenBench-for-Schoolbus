using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.WinClient.StaticClasses;
using WBServicePlatform.WinClient.Users;

namespace WBServicePlatform.WinClient.DelegateClasses
{
    public delegate void NullArgDelegate();

    public delegate void FileIOCompletedEventHandler(FileIOEventArgs e);

    public delegate void UserActivityHandler(UserActivityEventArgs e);

    public delegate void ExcelProcFinishedHandler(ExcelProcessEventArgs e);

    public delegate void DalegateFunction<Type_A>(Type_A type1);

    public delegate void DalegateFunction<Type_A, Type_B>(Type_A type1, Type_B type2);

    public abstract class InternalEventArgs : EventArgs
    {
        public OperationStatus ProcessStatus { get; set; }
        public string ErrDescription { get; set; }
        public override string ToString() => (ProcessStatus == OperationStatus.Failed) ? ErrDescription : ProcessStatus.ToString();
    }
}
