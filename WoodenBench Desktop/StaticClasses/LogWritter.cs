using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using WBServicePlatform.Users;

namespace WBServicePlatform.StaticClasses
{
    public static class LogWritter
    {
        private static StreamWriter Fs { get; set; }

        private static string LogFilePath { get; set; }

        public static void BmobDebugMsg(object Message) => WriteLog(LogLevel.Infomation, Message.ToString());

        public static void DebugMessage(string Message) => WriteLog(LogLevel.Infomation, Message);

        public static void ErrorMessage(string Message) => WriteLog(LogLevel.Error, Message);

        public static void InitLog()
        {
            LogFilePath = Environment.CurrentDirectory + "\\Logs\\" + DateTime.Now.Ticks + ".log";
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Logs\\");
            Fs = File.CreateText(LogFilePath);
            UserActivity.onUserActivityEvent += UserActivity_onUserActivityEvent;
            ExcelApplication.onExcelProcFinishedEvent += ExcelApplication_onExcelProcFinishedEvent;
            FileIO.onFileIOCompleted += FileIO_onFileIOCompleted;
        }

        private static void FileIO_onFileIOCompleted(FileIOEventArgs e)
        {
            DebugMessage("Now the event FileIO_onFileIOCompleted is taken, below is the detail: ");
            switch (e.ProcessStatus)
            {
                case ProcStatE.Completed:
                    switch (e.DownloadType)
                    {
                        case DownloadType.SingleUserHeadImage:
                            WriteLog(LogLevel.Infomation, "Head image download completed.");
                            break;
                        case DownloadType.AllUserHeadImage:
                            WriteLog(LogLevel.Infomation, "Head image for all users Download Completed");
                            break;
                    }
                    WriteLog(LogLevel.Infomation, "LocalFilePath: " + e.LocalFilePath);
                    break;
                case ProcStatE.Failed | ProcStatE.FailedWithErr | ProcStatE.Unknown:
                    WriteLog(LogLevel.Error, e.Description + " - " + e.Exception?.Message);
                    break;
            }
            WriteLog(LogLevel.Seperator);
        }

        private static void ExcelApplication_onExcelProcFinishedEvent(ExcelProcessEventArgs e)
        {
            DebugMessage("Now the event ExcelApplication_onExcelProcFinishedEvent is taken, below is the detail.. ");
            switch (e.ProcessStatus)
            {
                case ProcStatE.Completed:
                    string tmpstr = "";
                    switch (e.ExcelProcType)
                    {
                        case ExcelFileProcE.Open:
                            tmpstr = "OpenFile " + e.FileProcedPath;
                            break;
                        case ExcelFileProcE.Read:
                            tmpstr = "ReadFile " + e.FileProcedPath;
                            break;
                        case ExcelFileProcE.Close:
                            tmpstr = "Close " + e.FileProcedPath;
                            break;
                        case ExcelFileProcE.Write:
                            tmpstr = "Write " + e.FileProcedPath;
                            break;
                    }
                    WriteLog(LogLevel.Infomation, "Excel File Process Completed, Proc Type is: " + tmpstr);
                    break;
                case ProcStatE.Failed | ProcStatE.FailedWithErr | ProcStatE.Unknown:
                    WriteLog(LogLevel.Error, e.Description);
                    WriteLog(LogLevel.Error, e.Exception?.Message);
                    break;
            }
            WriteLog(LogLevel.Seperator);
        }

        private static void UserActivity_onUserActivityEvent(UserActivityEventArgs e)
        {
            DebugMessage("Now the event UserActivity_onUserActivityEvent is taken, below is the detail.. ");
            string UsrActivityStr = "";
            switch (e.ProcessStatus)
            {
                case ProcStatE.Completed:
                    switch (e.Activity)
                    {
                        case UsrActvtiE.UsrLogin:
                            UsrActivityStr = "User Login Succeed and the detail is; ";
                            break;
                        case UsrActvtiE.UserLogOff:
                            UsrActivityStr = "User Logoff Succeed and the detail is; ";
                            break;
                        case UsrActvtiE.UserChangePassword:
                            UsrActivityStr = "User Change Password Succeed and the detail is; ";
                            break;
                        case UsrActvtiE.UserUploadHImage:
                            UsrActivityStr = "User Login Upload its Headimage and the detail is; ";
                            break;
                        case UsrActvtiE.UserCompare:
                            UsrActivityStr = "User Login Compare operation and the detail is; ";
                            break;
                        case UsrActvtiE.UserCreate:
                            UsrActivityStr = "User Created Success and the detail is; ";
                            break;
                    }
                    UsrActivityStr = UsrActivityStr + e.Description;
                    WriteLog(LogLevel.Infomation, UsrActivityStr);
                    break;
                case ProcStatE.Failed | ProcStatE.FailedWithErr | ProcStatE.Unknown:
                    switch (e.Activity)
                    {
                        case UsrActvtiE.UsrLogin:
                            UsrActivityStr = "User Login FAILED and the detail is; ";
                            break;
                        case UsrActvtiE.UserLogOff:
                            UsrActivityStr = "User Logoff FAILED and the detail is; ";
                            break;
                        case UsrActvtiE.UserChangePassword:
                            UsrActivityStr = "User Change Password FAILED and the detail is; ";
                            break;
                        case UsrActvtiE.UserUploadHImage:
                            UsrActivityStr = "User Upload Headimage and the detail is; ";
                            break;
                        case UsrActvtiE.UserCompare:
                            UsrActivityStr = "User Compare FAILED and the detail is; ";
                            break;
                        case UsrActvtiE.UserCreate:
                            UsrActivityStr = "User Create FAILED and the detail is; ";
                            break;
                    }
                    UsrActivityStr = UsrActivityStr + e.Description;
                    WriteLog(LogLevel.Error, UsrActivityStr);
                    WriteLog(LogLevel.Error, e.Description);
                    WriteLog(LogLevel.Error, e.Exception?.Message);
                    break;
            }
            WriteLog(LogLevel.Seperator);
        }


        private static void WriteLog(LogLevel level, string Message = "")
        {
            StringBuilder LogMsg = new StringBuilder();
            if (level == LogLevel.Seperator)
            {
                LogMsg.Append("================================================================" + Environment.NewLine);
            }
            else
            {
                string levelstr = "";
                switch (level)
                {
                    case LogLevel.Error:
                        levelstr = "Err ";
                        break;
                    case LogLevel.Infomation:
                        levelstr = "Info";
                        break;
                }
                LogMsg.Append(DateTime.Now.ToLongTimeString());
                LogMsg.Append(" - ");
                LogMsg.Append(levelstr);
                LogMsg.Append(" - ");
                LogMsg.Append(Message);
                LogMsg.Append(Environment.NewLine);
                Debug.Write(LogMsg.ToString());
                string logLine = Convert.ToBase64String(Encoding.UTF8.GetBytes(LogMsg.ToString()));
                char[] p = Encoding.UTF8.GetChars(UTF8Encoding.UTF8.GetBytes(logLine));
                Fs.Write(p, 0, p.Length);
                Fs.Write(new char[] { '\r', '\n' }, 0, 2);
                Fs.AutoFlush = true;
            }
        }
    }
}
