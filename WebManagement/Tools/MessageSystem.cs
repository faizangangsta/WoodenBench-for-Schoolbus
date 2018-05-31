using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace WBPlatform.WebManagement.Tools
{
    public static class MessagingSystem
    {
        private static List<GlobalMessage> MessageList { get; set; } = new List<GlobalMessage>();
        private static Thread ProcThread = new Thread(new ThreadStart(_ProcThread));

        public static void StartProcess() => ProcThread.Start();
        public static void onChangeRequest_Created()
        {
            GlobalMessage message = new GlobalMessage() { type = GlobalMessageTypes.UCR_Created, DataString = "" };
            AddToList(message);
        }

        private static void AddToList(GlobalMessage message)
        {
            lock (MessageList)
            {
                MessageList.Add(message);
            }
        }
        private static void _ProcThread()
        {
            GlobalMessage message;
            while (true)
            {
                lock (MessageList)
                {
                    if (MessageList.Count != 0)
                    {
                        message = MessageList[MessageList.Count - 1];
                        MessageList.Remove(MessageList.Last());
                    }
                    else message = null;
                }
                if (message != null) _ProcessMessage(message);
                else Thread.Sleep(500);
                Thread.Sleep(100);
            }
        }
        private static void _ProcessMessage(GlobalMessage message)
        {
            switch (message.type)
            {
                case GlobalMessageTypes.UCR_Created:
                    DatabaseQuery query = new DatabaseQuery();
                    query.WhereEqualTo("isAdmin", true);
                    if ((int)Database.QueryMultipleData(query, out List<UserObject> adminUsers) < 1)
                    { 
                        // DO ERROR LOG HERE....
                        return;
                    }
                    List<string> adminWeChatIDs = new List<string>();
                    foreach (UserObject admin in adminUsers)
                    {
                        adminWeChatIDs.Add(admin.UserName);
                    }
                    WeChatSentMessage WCMsg = new WeChatSentMessage(WeChat.SentMessageType.textcard, "管理员通知", "你有一条新的工单有待处理！", "http://schoolbus.lhy0403.top/Manage/Query?targ=changereq&allowedit=true", adminWeChatIDs.ToArray());
                    WeChatMessageSystem.AddToSendList(WCMsg);
                    break;
                case GlobalMessageTypes.UCR_Solved:
                    break;
                default:
                    break;
            }
        }
    }
    public class GlobalMessage
    {
        public GlobalMessageTypes type { get; set; }
        public string DataString { get; set; }
    }
}
