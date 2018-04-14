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
    public delegate void FileIOCompletedEventHandler(FileIOEventArgs e);

    public abstract class InternalEventArgs : EventArgs
    {
        public bool isSucceed { get; set; }
        public string ErrDescription { get; set; }
        public override string ToString() => (isSucceed) ? "Succeed" : ErrDescription;
    }
}
