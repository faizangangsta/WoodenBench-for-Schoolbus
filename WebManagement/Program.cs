using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using cn.bmob.api;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WBServicePlatform.StaticClasses;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement
{
    public class Program
    {
        public static BmobWindows _Bmob { get; set; }
        public static WXEncryptedXMLHelper _WeChatEncryptor { get; set; }
        public static string Version { get; private set; }
        public static void Main(string[] args)
        { 
            char[] p = (Assembly.GetExecutingAssembly().CodeBase.Skip(8).ToArray());
            Version = new FileInfo(new string(p)).LastWriteTime.ToString();
            _Bmob = new BmobWindows();
            _Bmob.initialize(WBConsts.BmobAppKey, WBConsts.BmobRESTKey);
            Sessions.InitialiseWeChatCodes();
            _WeChatEncryptor = new WXEncryptedXMLHelper(WeChat.sToken, WeChat.sEncodingAESKey, WeChat.CorpID);
            WeChatMessageProc.StartProc();
            WeChatMessageProc.SendMessageString(WeChat.SentMessageType.textcard, "@all", "已经启动！", "小板凳已经启动\r\n启动时间是" + DateTime.Now.ToString(), "https://schoolbus.lhy0403.top");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseIISIntegration().UseKestrel().UseApplicationInsights().UseStartup<Startup>().Build();
        }
    }
}
