using System;

namespace WBPlatform.StaticClasses
{
    public class Rootobject
    {
        public DateTime ReportTime { get; set; }
        public int SessionsCount { get; set; }
        public bool SessionThread { get; set; }
        public int Tokens { get; set; }
        public bool WeChatRCVDThreadStatus { get; set; }
        public bool WeChatSENTThreadStatus { get; set; }
        public int WeChatRCVDListCount { get; set; }
        public int WeChatSENTListCount { get; set; }
        public bool Database { get; set; }
        public bool CoreMessageSystemThread { get; set; }
        public int CoreMessageSystemCount { get; set; }
        public bool MessageBackupThread { get; set; }
        public int MessageBackupCount { get; set; }
        public string StartupTime { get; set; }
        public string ServerVer { get; set; }
        public string CoreLibVer { get; set; }
        public string NetCoreCLRVer { get; set; }
    }
}