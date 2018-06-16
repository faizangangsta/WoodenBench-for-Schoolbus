using System;
using System.Collections.Generic;
using System.IO;
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
            UdpClient client = new UdpClient(new IPEndPoint(IPAddress.Any, 58720));
            IPEndPoint RemoteUDPSender = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] RcvdByte = client.Receive(ref RemoteUDPSender);
                HomeController.ServerStatus = Encoding.UTF8.GetString(RcvdByte);
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();
    }
}
