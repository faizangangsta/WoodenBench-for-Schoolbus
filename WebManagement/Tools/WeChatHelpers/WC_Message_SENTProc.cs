using System;
using System.Collections.Generic;
using System.Linq;
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
                else Thread.Sleep(200);
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

        private static Dictionary<string, string> SendMessageString(WeChatSMsg MessageType, string users, string Title, string Content, string URL = null)
        {
            WeChatMessageBackupService.AddToSendList(users, Title, Content);
            WeChatHelper.ReNewWCCodes();
            string Message = "{\"touser\":\"" + users + "\",\"msgtype\":\"" + MessageType.ToString() + "\",\"agentid\":" + XConfig.Current.WeChat.AgentId + ",\"" + MessageType.ToString() + "\":";
            switch (MessageType)
            {
                case WeChatSMsg.text:
                    Message = Message + $"{{\"content\":\"{Content}\r\n\r\n MST: {DateTime.Now.ToNormalString()}\"}}";
                    break;
                case WeChatSMsg.textcard:
                    Message = Message + $"{{\"title\":\"{Title}\",\"description\":\"{Content}\",\"url\":\"{URL}\"}}";
                    break;
            }
            Message = Message + "}";
            LW.D("WeChat Message Sent: " + Message);
            return PublicTools.HTTPPost("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + WeChatHelper.AccessToken, Message);
        }
    }
}
