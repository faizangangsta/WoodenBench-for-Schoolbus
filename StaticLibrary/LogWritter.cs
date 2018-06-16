using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace WBPlatform.StaticClasses
{
    public static class LogWritter
    {
        private static StreamWriter Fs { get; set; }
        private static string LogFilePath { get; set; }
        public static void BmobDebugMsg(object Message) => WriteLog(LogType.Info, Message.ToString());
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
            else LogMsg += $"{DateTime.Now.ToLongTimeString()} - {(level.ToString().Length == 4 ? level.ToString() : (level.ToString() + " "))} - {Message}";
            Debug.Write(LogMsg);
            Console.WriteLine(LogMsg);
            char[] p = Encoding.UTF8.GetChars(Encoding.UTF8.GetBytes(LogMsg));
            lock (Fs)
            {
                Fs.Write(p, 0, p.Length);
                Fs.Write(new char[] { '\r', '\n' }, 0, 2);
            }
        }
    }
}
