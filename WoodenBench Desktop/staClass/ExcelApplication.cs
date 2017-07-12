using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoodenBench.staClass
{
    public static class ExcelApplication
    {
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

}
