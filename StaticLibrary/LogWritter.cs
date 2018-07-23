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
            public OnLogChangedEventArgs(string logString, LogLevel logType)
            {
                LogString = logString;
                this.logType = logType;
            }
            public string LogString { get; set; }
            public LogLevel logType { get; set; }
        }
        public delegate void OnLogWrited(OnLogChangedEventArgs logchange);
        public static event OnLogWrited OnLog;
        private static LogLevel _LogLevel { get; set; } = LogLevel.Err;
        public static void SetLogLevel(LogLevel level) { _LogLevel = level; }
        private static OnLogChangedEventArgs logEvent = new OnLogChangedEventArgs("", LogLevel.Dbg);
        private static StreamWriter Fs { get; set; }
        private static string LogFilePath { get; set; }
        public static void D(string Message) => WriteLog(LogLevel.Info, Message);
        public static void D(object Message) => WriteLog(LogLevel.Info, Message.ToString());
        public static void E(string Message) => WriteLog(LogLevel.Err, Message);
        public static void E(object Message) => WriteLog(LogLevel.Err, Message.ToString());
        public static void InitLog(LogLevel level = LogLevel.Err)
        {
            LogFilePath = Environment.CurrentDirectory + "\\Logs\\" + DateTime.Now.ToNormalString().Replace(':', '-') + ".log";
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Logs\\");
            Fs = File.CreateText(LogFilePath);
            Fs.AutoFlush = true;
            E("Log is Now Initialised!");
        }
        private static void WriteLog(LogLevel level, string Message)
        {
            if (level < _LogLevel) return;
            string LogMsg = $"[{DateTime.Now.ToNormalString()}+{DateTime.Now.Millisecond.ToString("000")} - {(level.ToString().Length == 4 ? level.ToString() : (level.ToString() + " "))}] {Message}\r\n";

            Debug.Write(LogMsg);
            ConsoleColor _color = Console.ForegroundColor;
            switch (level)
            {
                case LogLevel.Err:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LogLevel.Dbg:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.Write(LogMsg);
            Console.ForegroundColor = _color;
            char[] p = LogMsg.ToCharArray();
            lock (Fs)
            {
                Fs.Write(p, 0, p.Length);
            }
            logEvent.LogString = LogMsg;
            logEvent.logType = level;
            OnLog?.Invoke(logEvent);
        }
    }
}
