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
                    onExcelProcFinished("", ExcelOperationE.OpenApp, OperationStatus.Completed);
                }
                catch (Exception ex)
                {
                    onExcelProcFinished("", ExcelOperationE.OpenApp, OperationStatus.Failed, ex.Message);
                }
            }
            else
            {
                onExcelProcFinished("", ExcelOperationE.OpenApp, OperationStatus.Completed, "Excel is Already started");
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
                    onExcelProcFinished("", ExcelOperationE.QuitApp, OperationStatus.Completed);
                }
                catch (Exception ex)
                {
                    onExcelProcFinished("", ExcelOperationE.QuitApp, OperationStatus.Failed, ex.Message);
                }
            }
            else
            {
                onExcelProcFinished("", ExcelOperationE.QuitApp, OperationStatus.Completed, "Excel Application not running");
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public bool OpenExcelFile(string FilePath, bool ReadOnly, bool Editable)
        {
            try
            {
                xWorkbook = ExcelApp.Workbooks._Open(FilePath, ReadOnly: ReadOnly, Editable: Editable);
                onExcelProcFinished(FilePath, ExcelOperationE.Open, OperationStatus.Completed);
                return true;
            }
            catch (Exception ex)
            {
                onExcelProcFinished(FilePath, ExcelOperationE.Open, OperationStatus.Failed, ex.Message);
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
            => (T)xWorkbook.Worksheets[WorkSheetNum].Cells[LineNum, ColNum].Value;

        public void onExcelProcFinished(string FilePath, ExcelOperationE procEnum, OperationStatus Status, string ErrDetail = "")
        {
            ExcelProcessEventArgs e = new ExcelProcessEventArgs()
            {
                FileProcedPath = FilePath,
                ExcelProcType = procEnum,
                ProcessStatus = Status,
                ErrDescription = ErrDetail
            };
            if (onExcelProcFinishedEvent != null) { onExcelProcFinishedEvent(e); }
        }
    }

    public class ExcelProcessEventArgs : InternalEventArgs
    {
        public ExcelProcessEventArgs() { }
        public string FileProcedPath { get; set; }
        public ExcelOperationE ExcelProcType { get; set; }
    }
}
