using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;

namespace WBPlatform.WebManagement.Tools
{
    public static class StatusMonitor
    {
        private static Thread _MonitorThread = new Thread(new ThreadStart(ThreadWork));
        private static Dictionary<string, object> status = new Dictionary<string, object>();
        private static UdpClient client = new UdpClient(0, AddressFamily.InterNetwork);
        private static IPEndPoint endpoint = new IPEndPoint(IPAddress.Broadcast, 58720);

        public static void StartMonitorThread() => _MonitorThread.Start();
        private static void ThreadWork()
        {
            while (true)
            {
                status.Clear();
                status.Add("ReportTime", DateTime.Now);
                status.Add("SessionsCount", Sessions.GetCount);
                status.Add("SessionThread", true);
                status.Add("Tokens", JumpTokens.GetCount);
                status.Add("WeChatRCVDThreadStatus", WeChatMessageSystem.Status()[0]);
                status.Add("WeChatSENTThreadStatus", WeChatMessageSystem.Status()[1]);
                status.Add("WeChatRCVDListCount", WeChatMessageSystem.Status()[2]);
                status.Add("WeChatSENTListCount", WeChatMessageSystem.Status()[3]);
                status.Add("Database", Database.isInitiallised);
                status.Add("CoreMessageSystemThread", MessagingSystem.GetStatus);
                status.Add("CoreMessageSystemCount", MessagingSystem.GetCount);
                status.Add("MessageBackupThread", MessageBackup.GetStatus);
                status.Add("MessageBackupCount", MessageBackup.GetCount);
                status.Add("StartupTime", Program.StartUpTime.ToString());
                status.Add("ServerVer", Program.Version);
                status.Add("CoreLibVer", WBConsts.CurrentCoreVersion);
                status.Add("NetCoreCLRVer", Assembly.GetCallingAssembly().ImageRuntimeVersion);


                string data = SimpleJson.SimpleJson.SerializeObject(status);

                byte[] ipByte = Encoding.UTF8.GetBytes(data);
                client.Send(ipByte, ipByte.Length, endpoint);
                Thread.Sleep(5000);
            }
        }
    }
}