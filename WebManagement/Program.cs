using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.WebManagement.Tools;

namespace WBPlatform.WebManagement
{
    public static class Program
    {
        public static string Version { get; private set; }
        public static DateTime StartUpTime { get; private set; }
        public static Task WebServerTask { get; private set; }
        public static CancellationTokenSource ServerStopToken { get; private set; } = new CancellationTokenSource();
        public static void Main(string[] args)
        {
            LW.InitLog();
            StartUpTime = DateTime.Now;
            LW.D("WoodenBench WebServer Starting....");
            LW.D($"\t Startup Time {StartUpTime.ToString()}.");
            Version = new FileInfo(new string(Assembly.GetExecutingAssembly().CodeBase.Skip(8).ToArray())).LastWriteTime.ToString();
            LW.D($"\t Version {Version}");
            StatusMonitor.StartMonitorThread();
            LW.D("Monitor Thread: Active");
            WeChat.ReNewWCCodes();


            DataBaseOperation.InitialiseClient(IPAddress.Parse("118.190.144.179"));
            //DataBaseOperation.InitialiseClient(IPAddress.Loopback);


            LW.D("Initialising WeChat Data Packet Encryptor.....");
            WeChat.WeChatEncryptor = new WXEncryptedXMLHelper(WeChat.sToken, WeChat.sEncodingAESKey, WeChat.CorpID);

            LW.D("Initialising Core Messaging Systems.....");
            WeChatMessageSystem.StartProcessThreads();
            WeChatMessageBackupService.StartBackupThread();
            MessagingSystem.StartProcessThread();

            LW.D("Building WebHost....");
            var webHost = BuildWebHost(args);
            LW.D("Starting WebHost....");
            LW.C();
            WebServerTask = webHost.RunAsync(ServerStopToken.Token);
            WebServerTask.Wait();
            LW.E("WebServer Stoped! Cancellation Token = " + ServerStopToken.IsCancellationRequested);
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseKestrel()
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();
    }
}
