using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using System.IO.Pipes;
using System.Text;
using System.Threading;

using WBPlatform.StaticClasses;

namespace WBPlatform.ServiceStatus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LW.SetLogLevel(LogLevel.Dbg);
            LW.InitLog();

            var v = XConfig.LoadAll();
            if (!(v.Item1 && v.Item2)) return;

            new Thread(new ThreadStart(GetStateString)).Start();
            BuildWebHost(args).Run();
        }
        public static void GetStateString()
        {
            NamedPipeClientStream client = new NamedPipeClientStream("localhost", XConfig.CurrentConfig.StatusReportNamedPipe, PipeDirection.In);
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
                .UseApplicationInsights(XConfig.CurrentConfig.ApplicationInsightInstrumentationKey)
                .UseStartup<Startup>()
                .Build();
    }
}
