using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoodenBench.DelegateClasses;

namespace WoodenBench.StaClasses
{
    public static class ExcelApplication
    {
        public static event onExcelProcFinishedHandler onExcelProcFinishedEvent;

        public static void onExcelProcFinished(object sender, ExcelProcFinishedEventArgs e)
        {
            if (onExcelProcFinishedEvent != null) { onExcelProcFinishedEvent(sender, e); }
        }

        public static int GetLastLineOfExcel(Microsoft.Office.Interop.Excel.Workbook xWorkbook)
        {
            int LineNum;
            for (LineNum = 1; LineNum <= 100; LineNum++)
            {
                if (Convert.ToString(xWorkbook.Worksheets[1].Cells[LineNum, 1].Value) == null)
                    return LineNum;
            }
            return 0;
        }
    }

    public class ExcelProcFinishedEventArgs : EventArgs
    {
        public ExcelProcFinishedEventArgs() { }
        public ProcStatE ProcessStatus { get; set; }
    }
}
