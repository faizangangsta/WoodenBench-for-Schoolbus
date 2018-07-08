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

namespace WBPlatform.ServiceStatus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Thread(new ThreadStart(GetStateString)).Start();
            BuildWebHost(args).Run();
        }
        public static void GetStateString()
        {
            //UdpClient client = new UdpClient(new IPEndPoint(IPAddress.Any, 58720));
            //IPEndPoint RemoteUDPSender = new IPEndPoint(IPAddress.Any, 0);
            //while (true)
            //{
            //    byte[] RcvdByte = client.Receive(ref RemoteUDPSender);
            //    HomeController.ServerStatus = Encoding.UTF8.GetString(RcvdByte);
            //}
            NamedPipeClientStream client = new NamedPipeClientStream("localhost", "83302E23-6377-4DD1-8EE9-21895EDF404E", PipeDirection.In);
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
