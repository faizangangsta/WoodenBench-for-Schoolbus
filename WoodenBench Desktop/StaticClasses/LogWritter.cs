using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using WBServicePlatform.WinClient.StaticClasses;
using WBServicePlatform.WinClient.Users;

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
            FileIO.onFileIOCompleted += FileIO_onFileIOCompleted;
        }

        private static void FileIO_onFileIOCompleted(FileIOEventArgs e)
        {
            DebugMessage("Now the event FileIO_onFileIOCompleted");
            switch (e.ProcessStatus)
            {
                case OperationStatus.Completed:
                    WriteLog(LogLevel.Infomation, "Head image download completed. LocalFilePath: " + e.LocalFilePath);
                    break;
                case OperationStatus.Failed | OperationStatus.Unknown:
                    WriteLog(LogLevel.Error, e.ErrDescription);
                    break;
            }
            WriteLog(LogLevel.Seperator);
        }
        
        private static void WriteLog(LogLevel level, string Message = "")
        {
            lock (Fs)
            {
                StringBuilder LogMsg = new StringBuilder();
                if (level == LogLevel.Seperator)
                {
                    LogMsg.Append("====================================================================================" + Environment.NewLine);
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
                }
                Debug.Write(LogMsg.ToString());
                char[] p = Encoding.UTF8.GetChars(UTF8Encoding.UTF8.GetBytes(LogMsg.ToString()));
                Fs.Write(p, 0, p.Length);
                Fs.Write(new char[] { '\r', '\n' }, 0, 2);
                Fs.AutoFlush = true;
            }
        }
    }
}
