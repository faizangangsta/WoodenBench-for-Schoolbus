using Excel =  Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WBServicePlatform.DelegateClasses;

namespace WBServicePlatform.StaticClasses
{
    public class ExcelApplication
    {
        public static event ExcelProcFinishedHandler onExcelProcFinishedEvent;
        bool IsExcelOpened = false;
        bool IsFileOpened = false;
        string FilePath;
        Excel.Application ExcelApp;
        Excel.Workbook xWorkbook;

        public ExcelApplication() { OpenExcelApp(); }

        public void OpenExcelApp()
        {
            if (!IsExcelOpened)
            {
                try
                {
                    ExcelApp = new Excel.Application();
                    IsExcelOpened = true;
                    onExcelProcFinished("", ExcelFileProcE.StartExcelApp, ProcStatE.Completed);
                }
                catch (Exception ex)
                {
                    onExcelProcFinished("", ExcelFileProcE.StartExcelApp, ProcStatE.FailedWithErr, ex.Message, ex);
                }
            }
            else
            {
                onExcelProcFinished("", ExcelFileProcE.StartExcelApp, ProcStatE.Completed, "Excel is Already started", null);
            }
        }

        public void QuitExcel()
        {
            if (IsExcelOpened)
            {
                try
                {
                    ExcelApp.Quit();
                    IsExcelOpened = false;
                    onExcelProcFinished("", ExcelFileProcE.QuitExcelApp, ProcStatE.Completed);
                }
                catch (Exception ex)
                {
                    onExcelProcFinished("", ExcelFileProcE.QuitExcelApp, ProcStatE.FailedWithErr, ex.Message, ex);
                }
            }
            else
            {
                onExcelProcFinished("", ExcelFileProcE.QuitExcelApp, ProcStatE.Completed, "Excel Application not running");
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public bool OpenExcelFile(string FilePath, bool ReadOnly, bool Editable)
        {
            try
            {
                xWorkbook = ExcelApp.Workbooks._Open(FilePath, ReadOnly: ReadOnly, Editable: Editable);
                onExcelProcFinished(FilePath, ExcelFileProcE.Open, ProcStatE.Completed);
                return true;
            }
            catch (Exception ex)
            {
                onExcelProcFinished(FilePath, ExcelFileProcE.Open, ProcStatE.FailedWithErr, ex.Message, ex);
                return false;
            }
        }

        public int LastLine(int StartFrom, int EndAt, int ifErrReturnVal = 0, int WorkSheetNum = 1)
        {
            int LineNum;
            for (LineNum = StartFrom; LineNum <= EndAt; LineNum++)
            {
                if ((string)(xWorkbook.Worksheets[WorkSheetNum].Cells[LineNum, 1].Value) == null) return LineNum;
            }
            return ifErrReturnVal;
        }

        public T ReadContent<T>(int LineNum, int ColNum, int WorkSheetNum = 1)
        {
            return (T)xWorkbook.Worksheets[WorkSheetNum].Cells[LineNum, ColNum].Value;
        }

        public void onExcelProcFinished(string FilePath, ExcelFileProcE procEnum, ProcStatE Status, string Describe = "", Exception exception = null)
        {
            ExcelProcessEventArgs e = new ExcelProcessEventArgs()
            {
                FileProcedPath = FilePath,
                ExcelProcType = procEnum,
                ProcessStatus = Status,
                Description = Describe,
                Exception = exception
            };
            if (onExcelProcFinishedEvent != null) { onExcelProcFinishedEvent(e); }
        }
    }

    public class ExcelProcessEventArgs : InternalEventArgs
    {
        public ExcelProcessEventArgs() { }
        public string FileProcedPath { get; set; }
        public ExcelFileProcE ExcelProcType { get; set; }
    }
}
