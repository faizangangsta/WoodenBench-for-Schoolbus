using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WBPlatform.StaticClasses;

namespace WBPlatform.ServiceStatus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LW.SetLogLevel(StaticClasses.LogLevel.Dbg);
            LW.InitLog();
            new Thread(new ThreadStart(GetStateString)).Start();
            BuildWebHost(args).Run();
        }
        public static void GetStateString()
        {
            NamedPipeClientStream client = new NamedPipeClientStream("localhost", "83302E23-6377-4DD1-8EE9-21895EDF404E", PipeDirection.In);
            while (true)
            {
                client.Connect();
                while (client.IsConnected)
                {
                    var data = new byte[65535];
                    var count = client.Read(data, 0, data.Length);
                    if (count > 0)
                    {
                        HomeController.ServerStatus = Encoding.UTF8.GetString(data, 0, count);
                    }
                }
                LW.E("GetStateString: DisConnected from the WBWebServer....");
                Thread.Sleep(1000);
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseKestrel()
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();
    }
}
