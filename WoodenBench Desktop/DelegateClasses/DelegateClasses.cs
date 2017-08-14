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

    public delegate void _nullArgDelegate();

    public delegate void onUserActivityHandler(UserActivityEventArgs e);

    public delegate void onExcelProcFinishedHandler(object sender, ExcelProcFinishedEventArgs e);
}
