using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace WBPlatform.StaticClasses
{
    public static class LogWritter
    {
        public class OnLogChangedEventArgs : EventArgs
        {
            public OnLogChangedEventArgs(string logString, LogType logType)
            {
                LogString = logString;
                this.logType = logType;
            }
            public string LogString { get; set; }
            public LogType logType { get; set; }
        }
        public delegate void OnLogWrited(OnLogChangedEventArgs logchange);
        public static event OnLogWrited onLog;

        private static OnLogChangedEventArgs logEvent = new OnLogChangedEventArgs("", LogType.LongChain); 
        private static StreamWriter Fs { get; set; }
        private static string LogFilePath { get; set; }
        public static void DebugMessage(string Message) => WriteLog(LogType.Info, Message);
        public static void ErrorMessage(string Message) => WriteLog(LogType.Err, Message);
        public static void InitLog()
        {
            LogFilePath = Environment.CurrentDirectory + "\\Logs\\" + DateTime.Now.Ticks + ".log";
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Logs\\");
            Fs = File.CreateText(LogFilePath);
            Fs.AutoFlush = true;
            WriteLog(LogType.Info, "Started Log...");
        }
        public static void WriteLog(LogType level, string Message = "")
        {
            string LogMsg = "";
            if (level == LogType.LongChain) LogMsg = "=========================================================\r\n";
            else LogMsg += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}+{DateTime.Now.Millisecond.ToString("000")} - {(level.ToString().Length == 4 ? level.ToString() : (level.ToString() + " "))}] {Message}";
            Debug.Write(LogMsg);
            Console.WriteLine(LogMsg);
            char[] p = Encoding.UTF8.GetChars(Encoding.UTF8.GetBytes(LogMsg));
            lock (Fs)
            {
                Fs.Write(p, 0, p.Length);
                Fs.Write(new char[] { '\r', '\n' }, 0, 2);
            }
            logEvent.LogString = LogMsg + "\r\n";
            logEvent.logType = level;
            onLog?.Invoke(logEvent);
        }
    }
}
