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
            Fs.AutoFlush = true;
            FileIO.onFileIOCompleted += FileIO_onFileIOCompleted;
        }

        private static void FileIO_onFileIOCompleted(FileIOEventArgs e)
        {
            if (e.isSucceed) WriteLog(LogLevel.Infomation, $"Headimage download completed, at: {e.LocalFilePath}");
            else WriteLog(LogLevel.Error, e.ErrDescription);
            WriteLog(LogLevel.LongChain);
        }

        private static void WriteLog(LogLevel level, string Message = "")
        {
            string LogMsg = "";
            if (level == LogLevel.LongChain)
                LogMsg += "=========================================================\r\n";
            else
            {
                string levelstr = "";
                switch (level)
                {
                    case LogLevel.Error: levelstr = "Err "; break;
                    case LogLevel.Infomation: levelstr = "Info"; break;
                }
                LogMsg += $"{DateTime.Now.ToLongTimeString()} - {levelstr} - {Message}";
            }
            Debug.Write(LogMsg);
            char[] p = Encoding.UTF8.GetChars(UTF8Encoding.UTF8.GetBytes(LogMsg));
            lock (Fs)
            {
                Fs.Write(p, 0, p.Length);
                Fs.Write(new char[] { '\r', '\n' }, 0, 2);
            }
        }
    }
}
