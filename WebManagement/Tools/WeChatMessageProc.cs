using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.WebManagement.Tools
{
    public static class WeChatMessageProc
    {
        public static List<WeChatMessage> MessageList = new List<WeChatMessage>();
        private static Thread ProcessorThread = new Thread(new ThreadStart(_Process));

        public static void StartProc() => ProcessorThread.Start();

        private static Dictionary<string, string> ResponceToMessage(WeChatMessage Message)
        {
            switch (Message.MessageType)
            {
                case WeChat.RcvdMessageType.text:
                    //Process some user inputs....
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "你是说:" + Message.TextContent, null);
                case WeChat.RcvdMessageType.image:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇这张图片真好看", null);
                case WeChat.RcvdMessageType.voice:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇声音真好听", null);
                case WeChat.RcvdMessageType.location:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇这个地方好神秘", null);
                case WeChat.RcvdMessageType.video:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇视频好刺激", null);
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
                                        "要是想使用Windows 客户端登陆的话<br />" +
                                        ///Home/Register?token={token}&user=&action=register
                                        "就点击<a href='https://schoolbus.lhy0403.top/Home/Register/?action=AddPassword&user=" + Message.FromUser + "'>这里</a>" +
                                        "给自己加一个密码吧!", null);
                                case "WEB_SERV_VER":
                                    return SendMessageString(WeChat.SentMessageType.textcard, Message.FromUser,
                                        "小板凳平台版本信息",
                                        "这是当前版本信息: <br />" +
                                        "服务端版本: " + Program.Version + "<br />" +
                                        "核心库版本: " + WBConsts.CurrentCoreVersion + "<br />" +
                                        "运行时版本: " + Assembly.GetCallingAssembly().ImageRuntimeVersion, "https://schoolbus.lhy0403.top/Home/Version");
                                default: return null;
                            }
                        default: return null;
                    }
                case WeChat.RcvdMessageType._DEVELOPER_ERROR_REPORT:
                    return SendMessageString(WeChat.SentMessageType.text, "@all", null, Message.TextContent, null);
                default: return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, Message.FromUser + " " + Message.MessageType.ToString(), null);
            }
        }

        private static void _Process()
        {
            WeChatMessage message;
            while (true)
            {
                lock (MessageList)
                {
                    if (MessageList.Count != 0)
                    {
                        message = MessageList[MessageList.Count - 1];
                        MessageList.Remove(MessageList.Last());
                    }
                    else
                    {
                        message = null;
                    }
                }
                if (message != null)
                {
                    ResponceToMessage(message);
                }
                else Thread.Sleep(500);
                Thread.Sleep(100);
            }
        }


        public static Dictionary<string, string> SendMessageString(WeChat.SentMessageType MessageType, string users, string Title, string Content, string URL)
        {
            string Message = "{\"touser\":\"" + users + "\",\"msgtype\":\"" + MessageType.ToString() + "\",\"agentid\":" + WeChat.agentId + ",\"" + MessageType.ToString() + "\":";
            switch (MessageType)
            {
                case WeChat.SentMessageType.text:
                    Message = Message + "{\"content\":\"" + Content + "\"}";
                    break;
                case WeChat.SentMessageType.textcard:
                    Message = Message + "{\"title\":\"" + Title + "\",\"description\":\"" + Content + "\",\"url\":\"" + URL + "\"}";
                    break;
            }

            Message = Message + "}";

            return HTTPOperations.HTTPPost("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + WeChat.AccessToken, Message);
        }
    }
}
