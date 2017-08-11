﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoodenBench.Events;
using WoodenBench.StaClasses;

namespace WoodenBench.DelegateClasses
{
    public delegate void onUserLoginDelegateVoid();

    public delegate void onUserActivityHandler(UserActivityEventArgs e);

    public delegate void onExcelProcFinishedHandler(object sender, ExcelProcFinishedEventArgs e);
}
