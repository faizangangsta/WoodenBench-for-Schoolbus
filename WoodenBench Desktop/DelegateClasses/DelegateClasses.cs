using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoodenBench.GlobalEvents;

namespace WoodenBench.DelegateClasses
{
    public delegate void onUserLoginDelegateVoid(string e);

    public delegate void onUserActivityHandler(object sender, UserActivityEventArgs e);

    public delegate void onExcelProcFinishedHandler(object sender, ExcelProcFinishedEventArgs e);
}
