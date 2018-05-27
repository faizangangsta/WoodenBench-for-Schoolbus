using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using WBPlatform.StaticClasses;
using WBPlatform.WinClient.StaticClasses;
using WBPlatform.WinClient.Users;

namespace WBPlatform.WinClient.DelegateClasses
{
    public delegate void FileIOCompletedEventHandler(FileIOEventArgs e);

    public abstract class InternalEventArgs : EventArgs
    {
        public bool isSucceed { get; set; }
        public string ErrDescription { get; set; }
        public override string ToString() => (isSucceed) ? "Succeed" : ErrDescription;
    }
}
