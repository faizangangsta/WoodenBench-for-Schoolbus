using System.Collections.Generic;
using System.Linq;
using System.Threading;

using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace WBPlatform.WebManagement.Tools
{
    public static class MessagingSystem
    {
        public static int GetCount { get => MessageList.Count; }
        public static bool GetStatus { get => ProcThread.IsAlive; }
        private static List<GlobalMessage> MessageList { get; set; } = new List<GlobalMessage>();
        private static Thread ProcThread = new Thread(new ThreadStart(_ProcThread));

        public static void StartProcessThread() => ProcThread.Start();
        public static void onChangeRequest_Created(UserChangeRequest request, UserObject user)
        {
            GlobalMessage messageAdmin = new GlobalMessage() { type = GlobalMessageTypes.UCR_Created_TO_ADMIN, dataObject = request, user = user, objectId = request.objectId };
            GlobalMessage message_User = new GlobalMessage() { type = GlobalMessageTypes.UCR_Created_TO_User, dataObject = request, user = user, objectId = request.objectId };
            AddToList(messageAdmin, message_User);
        }

        public static void onChangeRequest_Solved(UserChangeRequest request, UserObject user)
        {
            GlobalMessage message_User = new GlobalMessage() { type = GlobalMessageTypes.UCR_Procced_TO_User, dataObject = request, user = user, objectId = request.UserID };
            AddToList(message_User);
        }

        private static void AddToList(params GlobalMessage[] message) { lock (MessageList) MessageList.AddRange(message); }
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
                case GlobalMessageTypes.UCR_Created_TO_ADMIN:
                    {
                        DBQuery query = new DBQuery();
                        query.WhereEqualTo("isAdmin", true);
                        if ((int)DBOperations.QueryMultipleData(query, out List<UserObject> adminUsers) < 1)
                        {
                            LogWritter.ErrorMessage("No Administrator found!!, thus no UserRequest can be solved!");
                            // DO ERROR LOG HERE....
                            return;
                        }
                        List<string> adminWeChatIDs = new List<string>();
                        foreach (UserObject admin in adminUsers) adminWeChatIDs.Add(admin.UserName);
                        WeChatSentMessage UCR_Created_TO_ADMIN_Msg = new WeChatSentMessage(
                            WeChat.SentMessageType.textcard,
                            "管理员通知",
                            $"你有一条来自 {message.user.RealName} 的工单有待处理：\r\n{message.user.RealName}请求把 {((UserChangeRequest)message.dataObject).RequestTypes.ToString()} 修改成{((UserChangeRequest)message.dataObject).NewContent }\r\n请尽快处理！",
                            "http://schoolbus.lhy0403.top/Manage/ChangeRequest?arg=manage&reqId=" + message.objectId,
                            adminWeChatIDs.ToArray());
                        WeChatMessageSystem.AddToSendList(UCR_Created_TO_ADMIN_Msg);
                        break;
                    }
                case GlobalMessageTypes.UCR_Created_TO_User:
                    {
                        WeChatSentMessage UCR_Created_TO_User_Msg = new WeChatSentMessage(WeChat.SentMessageType.textcard, "工单提交成功！",
                                        "你申请修改账户 " + ((UserChangeRequest)message.dataObject).RequestTypes.ToString() + " 信息的工单已经提交成功！\r\n" +
                                        "工单编号：" + ((UserChangeRequest)message.dataObject).objectId + "\r\n" +
                                        "状态：正在等待审核", "http://schoolbus.lhy0403.top/Manage/ChangeRequest?arg=my&reqId=" + message.objectId, message.user.UserName);
                        WeChatMessageSystem.AddToSendList(UCR_Created_TO_User_Msg);
                        break;
                    }
                case GlobalMessageTypes.UCR_Procced_TO_User:
                    {
                        switch (DBOperations.QuerySingleData(new DBQuery().WhereEqualTo("objectId", message.objectId), out UserObject requestSender))
                        {
                            case DatabaseResult.ONE_RESULT:
                                string stat = (((UserChangeRequest)message.dataObject).Status) == UserChangeRequestProcessStatus.Accepted ? "审核通过" : "审核未通过";
                                WeChatSentMessage _WMessage = new WeChatSentMessage(WeChat.SentMessageType.textcard, "工单状态提醒",
                                    "你申请修改账户 " + ((UserChangeRequest)message.dataObject).RequestTypes.ToString() + " 信息的工单已经审核完毕！\r\n" +
                                        "工单编号：" + ((UserChangeRequest)message.dataObject).objectId + "\r\n" +
                                        "审核结果：" + stat + "\r\n请点击查看详细内容", "http://schoolbus.lhy0403.top/Manage/ChangeRequest?arg=my&reqId=" + ((UserChangeRequest)(message.dataObject)).objectId, requestSender.UserName);
                                WeChatMessageSystem.AddToSendList(_WMessage);
                                break;
                            case DatabaseResult.INTERNAL_ERROR:
                            case DatabaseResult.NO_RESULTS:
                            case DatabaseResult.MORE_RESULTS:
                            default:
                                LogWritter.ErrorMessage("Failed to get user who requested to change something.... userId=" + message.objectId);
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
    public class GlobalMessage
    {
        public GlobalMessageTypes type { get; set; }
        public UserObject user { get; set; }
        public object dataObject { get; set; }
        public string objectId { get; set; }
    }
}
