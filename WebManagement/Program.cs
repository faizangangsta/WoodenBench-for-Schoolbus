using System;
using System.IO;
using System.Linq;
using System.Reflection;

using cn.bmob.api;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using WBServicePlatform.StaticClasses;
using WBServicePlatform.WebManagement.Tools;

namespace WBServicePlatform.WebManagement
{
    public class Program
    {
        public static BmobWindows _Bmob { get; set; }
        public static string Version { get; private set; }
        public static DateTime StartUpTime { get; private set; }
        public static void Main(string[] args)
        {
            Version = new FileInfo(new string(Assembly.GetExecutingAssembly().CodeBase.Skip(8).ToArray())).LastWriteTime.ToString();
            _Bmob = new BmobWindows();
            _Bmob.initialize(WBConsts.BmobAppKey, WBConsts.BmobRESTKey);
            WeChat.ReNewWCCodes();
            WeChat.WeChatEncryptor = new WXEncryptedXMLHelper(WeChat.sToken, WeChat.sEncodingAESKey, WeChat.CorpID);
            WeChatMessageProc.StartProc();
            StartUpTime = DateTime.Now;
            var webHost = BuildWebHost(args);
            WeChatMessageProc.SendMessageString(WeChat.SentMessageType.textcard, "@all",
                "小板凳服务器启动成功",
                "这是当前版本信息: <br />" +
                "启动の时间: " + StartUpTime.ToString() + "<br /><br />" +
                "服务端版本: " + Version + "<br />" +
                "核心库版本: " + WBConsts.CurrentCoreVersion + "<br />" +
                "运行时版本: " + Assembly.GetCallingAssembly().ImageRuntimeVersion, "https://schoolbus.lhy0403.top");
            webHost.Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseKestrel()
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();
        }
    }
}
