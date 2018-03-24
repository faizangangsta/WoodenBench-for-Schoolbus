using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                case WeChat.RecivedMessageType.text:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "你是说:" + Message.TextContent, null);
                case WeChat.RecivedMessageType.image:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇这张图片真好看", null);
                case WeChat.RecivedMessageType.voice:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇声音真好听", null);
                case WeChat.RecivedMessageType.location:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇这个地方好神秘", null);
                case WeChat.RecivedMessageType.video:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇视频好刺激", null);
                case WeChat.RecivedMessageType.link:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "这啥网站？？", null);
                case WeChat.RecivedMessageType.EVENT:
                    switch (Message.Event)
                    {
                        case WeChat.Event.click:
                            return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, Message.FromUser + "你点的应该是" + Message.EventKey, null);
                        default:
                            return null;
                    }
                default:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, Message.FromUser + "没有类型" + Message.MessageType.ToString(), null);
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
                Thread.Sleep(200);
            }
        }


        public static Dictionary<string, string> SendMessageString(WeChat.SentMessageType MessageType, string users, string Title, string Content, string URL)
        {
            string ret = "{\"touser\":\"" + users + "\",\"msgtype\":\"" + MessageType.ToString() + "\",\"agentid\":" + WeChat.agentId + ",\"" + MessageType.ToString() + "\":";
            switch (MessageType)
            {
                case WeChat.SentMessageType.text:
                    ret = ret + "{\"content\":\"" + Content + "\"}";
                    break;
                case WeChat.SentMessageType.textcard:
                    ret = ret + "{\"title\":\"" + Title + "\",\"description\":\"" + Content + "\",\"url\":\"" + URL + "\"}";
                    break;
            }

            ret = ret + "}";

            return HTTPOperations.HTTPPost("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + WeChat.AccessToken, ret);
        }
    }
}
