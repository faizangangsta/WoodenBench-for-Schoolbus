﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

using WBPlatform.StaticClasses;

namespace WBPlatform.WebManagement.Tools
{
    public static partial class WeChatMessageSystem
    {
        private static List<WeChatSentMessage> SentMessageList { get; set; } = new List<WeChatSentMessage>();
        private static Thread ProcessorSENTThread = new Thread(new ThreadStart(_ProcessSENT));

        public static void AddToSendList(WeChatSentMessage message) { lock (SentMessageList) SentMessageList.Add(message); }
        private static void _ProcessSENT()
        {
            WeChatSentMessage message;
            while (true)
            {
                lock (SentMessageList)
                {
                    if (SentMessageList.Count != 0)
                    {
                        message = SentMessageList[SentMessageList.Count - 1];
                        SentMessageList.Remove(SentMessageList.Last());
                    }
                    else message = null;
                }
                if (message != null) SendMessagePacket(message);
                else Thread.Sleep(500);
                Thread.Sleep(100);
            }
        }
        private static Dictionary<string, string> SendMessagePacket(WeChatSentMessage message)
        {
            string users = "";
            foreach (string item in message.toUser)
            {
                users = users + item + "|";
            }
            return SendMessageString(message.type, users, message.Title, message.Content, message.URL_OnClick);
        }

        private static Dictionary<string, string> SendMessageString(WeChat.SentMessageType MessageType, string users, string Title, string Content, string URL)
        {
            MessageBackup.AddToSendList(users, Title, Content);
            WeChat.ReNewWCCodes();
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
            return Ultilities.HTTPPost("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + WeChat.AccessToken, Message);
        }
    }
}
