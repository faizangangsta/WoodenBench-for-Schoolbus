using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace WBPlatform.StaticClasses
{
    public static class LW
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
        public static void D(string Message) => WriteLog(LogType.Info, Message);
        public static void D(object Message) => WriteLog(LogType.Info, Message.ToString());
        public static void E(string Message) => WriteLog(LogType.Err, Message);
        public static void E(object Message) => WriteLog(LogType.Err, Message.ToString());
        public static void C() => WriteLog(LogType.LongChain);
        public static void InitLog()
        {
            LogFilePath = Environment.CurrentDirectory + "\\Logs\\" + DateTime.Now.ToNormalString().Replace(':', '-') + ".log";
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Logs\\");
            Fs = File.CreateText(LogFilePath);
            Fs.AutoFlush = true;
            WriteLog(LogType.Info, "Started Log...");
        }
        private static void WriteLog(LogType level, string Message = "")
        {
            string LogMsg = "";
            if (level == LogType.LongChain)
                LogMsg = "========================================================================\r\n";
            else
                LogMsg += $"[{DateTime.Now.ToNormalString()}+{DateTime.Now.Millisecond.ToString("000")} - {(level.ToString().Length == 4 ? level.ToString() : (level.ToString() + " "))}] {Message}\r\n";

            Debug.Write(LogMsg);
            Console.WriteLine(LogMsg);
            char[] p = LogMsg.ToCharArray();
            lock (Fs)
            {
                Fs.Write(p, 0, p.Length);
            }
            logEvent.LogString = LogMsg;
            logEvent.logType = level;
            onLog?.Invoke(logEvent);
        }
    }
}
