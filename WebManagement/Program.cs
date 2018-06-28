using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement
{
    public class Program
    {
        public static string Version { get; private set; }
        public static DateTime StartUpTime { get; private set; }
        public static void Main(string[] args)
        {
            StatusMonitor.StartMonitorThread();
            StartUpTime = DateTime.Now;
            LogWritter.InitLog();
            Version = new FileInfo(new string(Assembly.GetExecutingAssembly().CodeBase.Skip(8).ToArray())).LastWriteTime.ToString();
            WeChat.ReNewWCCodes();
#if DEBUG
            DBOperations.InitialiseClient(IPAddress.Parse("118.190.144.179"));
#else
            DBOperations.InitialiseClient(IPAddress.Loopback);
#endif
            WeChat.WeChatEncryptor = new WXEncryptedXMLHelper(WeChat.sToken, WeChat.sEncodingAESKey, WeChat.CorpID);

            WeChatMessageSystem.StartProcessThreads();
            MessageBackup.StartBackupThread();
            MessagingSystem.StartProcessThread();

            var webHost = BuildWebHost(args);
            //WeChatMessageProc.SendMessageString(WeChat.SentMessageType.textcard, "@all",
            //    "小板凳服务器启动成功",
            //    "这是当前版本信息: <br />" +
            //    "启动の时间: " + StartUpTime.ToString() + "<br /><br />" +
            //    "服务端版本: " + Version + "<br />" +
            //    "核心库版本: " + WBConsts.CurrentCoreVersion + "<br />" +
            //    "运行时版本: " + Assembly.GetCallingAssembly().ImageRuntimeVersion, "https://schoolbus.lhy0403.top");
            webHost.Run();
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseKestrel()
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();
    }
}
