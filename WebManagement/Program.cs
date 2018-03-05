using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using cn.bmob.api;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.WebManagement
{
    public class Program
    {
        public static BmobWindows _Bmob { get; set; }

        public static void Main(string[] args)
        {
            _Bmob = new BmobWindows();
            _Bmob.initialize(WBConst.BmobAppKey, WBConst.BmobRESTKey);
            Tools.SessionManager.InitialiseWeChatCodes();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseApplicationInsights().UseStartup<Startup>().Build();
    }
}
