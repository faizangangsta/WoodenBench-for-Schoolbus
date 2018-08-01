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

            var v = XConfig.LoadAll();
            if (!(v.Item1 && v.Item2)) return;

            StatusMonitor.StartMonitorThread();
            WeChatHelper.ReNewWCCodes();

            DataBaseOperation.InitialiseClient();
            //DataBaseOperation.InitialiseClient(IPAddress.Loopback);

            WeChatHelper.InitialiseExcryptor();

            LW.D("Initialising Core Messaging Systems.....");
            WeChatMessageSystem.StartProcessThreads();
            WeChatMessageBackupService.StartBackupThread();
            MessagingSystem.StartProcessThread();

            var webHost = BuildWebHost(XConfig.CurrentConfig.ApplicationInsightInstrumentationKey, args);
            LW.D("Starting WebHost....");

            WebServerTask = webHost.RunAsync(ServerStopToken.Token);
            WebServerTask.Wait();
            LW.E("WebServer Stoped! Cancellation Token = " + ServerStopToken.IsCancellationRequested);
        }

        public static IWebHost BuildWebHost(string instrumentationKey, string[] args)
        {
            LW.D("Building WebHost....");
            var host = WebHost.CreateDefaultBuilder(args)
                 .UseIISIntegration()
                 .UseKestrel()
                 .UseApplicationInsights(instrumentationKey)
                 .UseStartup<Startup>()
                 .Build();
            return host;
        }
    }
}
