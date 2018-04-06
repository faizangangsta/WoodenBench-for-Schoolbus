using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WBServicePlatform.WinClient.DelegateClasses;

namespace WBServicePlatform.StaticClasses
{
    public class ExcelApplication
    {
        bool IsExcelOpened = false;
        bool IsFileOpened = false;
        string FilePath;
        Excel.ApplicationClass ExcelApp;
        Excel.WorkbookClass xWorkbook;

        public ExcelApplication()
        {
            try
            {
                ExcelApp = new Excel.ApplicationClass();
                IsExcelOpened = true;
                LogWritter.ErrorMessage("Excel Opened!");
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage("Excel Opening Error: " + ex.Message);
            }
        }

        public bool QuitExcel()
        {
            try
            {
                ExcelApp.Quit();
                IsExcelOpened = false;
                LogWritter.ErrorMessage("Excel Quited!");
                return true;
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage("Excel Quiting Error: " + ex.Message);
                return false;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public bool OpenExcelFile(string FilePath, bool ReadOnly, bool Editable)
        {
            try
            {
                xWorkbook = (Excel.WorkbookClass)ExcelApp.Workbooks._Open(FilePath, ReadOnly: ReadOnly, Editable: Editable);
                LogWritter.ErrorMessage($"Excel Open File Seccess: FilePath: {FilePath}, ReadOnly: {ReadOnly.ToString()}");
                return true;
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage("Excel Open File Error: " + ex.Message);
                return false;
            }
        }

        public int LastLine(int StartFrom, int EndAt, int ifErrReturnVal = 0, int WorkSheetNum = 1, int ColumnNumber = 1)
        {
            int LineNum;
            for (LineNum = StartFrom; LineNum <= EndAt; LineNum++)
            {
                if (ReadContent<string>(LineNum, ColumnNumber, WorkSheetNum) == null) return LineNum;
            }
            return ifErrReturnVal;
        }

        public T ReadContent<T>(int LineNum, int ColNum, int WorkSheetNum = 1) => (T)(((Excel.WorksheetClass)xWorkbook.Worksheets[WorkSheetNum]).Cells[LineNum, ColNum]);
    }
}
