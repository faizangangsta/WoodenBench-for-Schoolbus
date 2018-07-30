using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Reflection;
using System.Text;
using System.Threading;
using WBPlatform.Database.Connection;
using WBPlatform.StaticClasses;
using WBPlatform.WebManagement.Controllers;

namespace WBPlatform.WebManagement.Tools
{
    public static class StatusMonitor
    {
        private static Thread _MonitorThread = new Thread(new ThreadStart(ThreadWork));
        private static Dictionary<string, object> status = new Dictionary<string, object>();
        private static NamedPipeServerStream pipe = new NamedPipeServerStream(XConfig.CurrentConfig.StatusReportNamedPipe, PipeDirection.Out);

        public static void StartMonitorThread()
        {
            LW.D("Starting Monitor Thread");
            _MonitorThread.Start();
            LW.D("Monitor Thread: Active");
        }
        private static void ThreadWork()
        {
            while (true)
            {
                status.Clear();
                status.Add("ReportTime", DateTime.Now);
                status.Add("SessionsCount", BaseController.GetCount);
                status.Add("SessionThread", true);
                status.Add("Tokens", ExecuteOnceTicket.GetCount);
                var WeChatStatus = WeChatMessageSystem.Status();
                status.Add("WeChatRCVDThreadStatus", WeChatStatus.Item1);
                status.Add("WeChatSENTThreadStatus", WeChatStatus.Item2);
                status.Add("WeChatRCVDListCount", WeChatStatus.Item3);
                status.Add("WeChatSENTListCount", WeChatStatus.Item4);
                status.Add("Database", DatabaseSocketsClient.Connected);
                status.Add("CoreMessageSystemThread", MessagingSystem.GetStatus);
                status.Add("CoreMessageSystemCount", MessagingSystem.GetCount);
                status.Add("MessageBackupThread", WeChatMessageBackupService.GetStatus);
                status.Add("MessageBackupCount", WeChatMessageBackupService.GetCount);
                status.Add("StartupTime", Program.StartUpTime.ToString());
                status.Add("ServerVer", Program.Version);
                status.Add("CoreLibVer", WBConsts.CurrentCoreVersion);
                status.Add("NetCoreCLRVer", Assembly.GetCallingAssembly().ImageRuntimeVersion);
                string data = JsonConvert.SerializeObject(status);

                byte[] ipByte = Encoding.UTF8.GetBytes(data);
                //client.Send(ipByte, ipByte.Length, endpoint);
                if (!pipe.IsConnected)
                {
                    pipe.WaitForConnection();
                }
                pipe.Write(ipByte, 0, ipByte.Length);
                pipe.Flush();
                pipe.WaitForPipeDrain();
                Thread.Sleep(5000);
            }
        }
    }
}