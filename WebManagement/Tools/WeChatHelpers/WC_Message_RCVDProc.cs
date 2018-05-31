using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

using WBPlatform.StaticClasses;

namespace WBPlatform.WebManagement.Tools
{
    public static partial class WeChatMessageSystem
    {
        private static List<WeChatRcvdMessage> RcvdMessageList { get; set; } = new List<WeChatRcvdMessage>();
        private static Thread ProcessorRCVDThread = new Thread(new ThreadStart(_ProcessRCVD));

        public static void StartProc()
        {
            ProcessorSENTThread.Start();
            ProcessorRCVDThread.Start();
        }

        public static void onMsgRcvd(WeChatRcvdMessage _Message)
        {
            lock (RcvdMessageList) RcvdMessageList.Add(_Message);
        }

        private static Dictionary<string, string> ResponceToMessage(WeChatRcvdMessage Message)
        {
            switch (Message.MessageType)
            {
                case WeChat.RcvdMessageType.text:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "你是说:" + Message.TextContent + "??", null);
                case WeChat.RcvdMessageType.image:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇这张图片真好看", null);
                case WeChat.RcvdMessageType.voice:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇声音真好听", null);
                case WeChat.RcvdMessageType.location:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "发个地址干啥，，你想去吗？", null);
                case WeChat.RcvdMessageType.video:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "啥视频？", null);
                case WeChat.RcvdMessageType.link:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "这啥网站？？", null);
                case WeChat.RcvdMessageType.EVENT:
                    switch (Message.Event)
                    {
                        case WeChat.Event.click:
                            switch (Message.EventKey)
                            {
                                case "ADD_PASSWORD":
                                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null,
                                        "要是想使用Windows 客户端登陆的话\r\n" +
                                        ///Home/Register?token={token}&user=&action=register
                                        "就点击<a href='https://schoolbus.lhy0403.top/Home/Register/?action=AddPassword&user=" + Message.FromUser + "'>这里</a>" +
                                        "给自己加一个密码吧!", null);
                                case "WEB_SERV_VER":
                                    return SendMessageString(WeChat.SentMessageType.textcard, Message.FromUser,
                                        "小板凳平台版本信息",
                                        "这是当前版本信息: \r\n" +
                                        "启动の时间: " + Program.StartUpTime.ToString() + "\r\n\r\n" +
                                        "服务端版本: " + Program.Version + "\r\n" +
                                        "核心库版本: " + WBConsts.CurrentCoreVersion + "\r\n" +
                                        "运行时版本: " + Assembly.GetCallingAssembly().ImageRuntimeVersion, "https://schoolbus.lhy0403.top/Home/Version");
                                default: return null;
                            }
                        default: return null;
                    }
                default: return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, Content: "不支持的消息类型", URL: null);
            }
        }

        private static void _ProcessRCVD()
        {
            WeChatRcvdMessage message;
            while (true)
            {
                lock (RcvdMessageList)
                {
                    if (RcvdMessageList.Count != 0)
                    {
                        message = RcvdMessageList[RcvdMessageList.Count - 1];
                        RcvdMessageList.Remove(RcvdMessageList.Last());
                    }
                    else message = null;
                }
                if (message != null) ResponceToMessage(message);
                else Thread.Sleep(500);
                Thread.Sleep(100);
            }
        }
    }
}
