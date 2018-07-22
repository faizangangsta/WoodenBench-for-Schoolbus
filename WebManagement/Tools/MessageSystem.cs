using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private static List<InternalMessage> MessageList { get; set; } = new List<InternalMessage>();
        private static Thread ProcThread = new Thread(new ThreadStart(_ProcThread));

        public static void StartProcessThread()
        {
            ProcThread.Start();
            LW.D("\tCoreMessaging System Started!");
        }


        public static void AddMessageProcesses(params InternalMessage[] message)
        {
            //LW.D("New Message is to add into list: " + JsonConvert.SerializeObject(message));
            lock (MessageList) MessageList.AddRange(message);
        }
        private static void _ProcThread()
        {
            InternalMessage message;
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
                if (message != null && !_ProcessMessage(message)) MessageList.Add(message);
                else Thread.Sleep(500);
                Thread.Sleep(100);
            }
        }

        private static bool _ProcessMessage(InternalMessage message)
        {
            switch (message._Type)
            {
                case GlobalMessageTypes.UCR_Created_TO_ADMIN:
                    {
                        if ((int)GetAdminUsers(out List<UserObject> adminUsers_UCR_Request) < 1)
                        {
                            LW.E("No Administrator found!! thus no UserRequest can be solved!");
                            return false;
                        }
                        else
                        {
                            WeChatSentMessage UCR_Created_TO_ADMIN_Msg = new WeChatSentMessage(
                                WeChat.SentMessageType.textcard,
                                "管理员通知",
                                $"你有一条来自 {message.User.RealName} 的工单有待处理：\r\n{message.User.RealName}请求把 {((UserChangeRequest)message.DataObject).RequestTypes.ToString()} 修改成{((UserChangeRequest)message.DataObject).NewContent }\r\n请尽快处理！",
                                "http://schoolbus.lhy0403.top/Manage/ChangeRequest?arg=manage&reqId=" + message.ObjectId,
                                (from usr in adminUsers_UCR_Request select usr.UserName).ToArray());
                            WeChatMessageSystem.AddToSendList(UCR_Created_TO_ADMIN_Msg);
                            return true;
                        }
                    }
                case GlobalMessageTypes.UCR_Created__TO_User:
                    {
                        WeChatSentMessage UCR_Created_TO_User_Msg = new WeChatSentMessage(WeChat.SentMessageType.textcard, "工单提交成功！",
                                        "你申请修改账户 " + ((UserChangeRequest)message.DataObject).RequestTypes.ToString() + " 信息的工单已经提交成功！\r\n" +
                                        "工单编号：" + ((UserChangeRequest)message.DataObject).ObjectId + "\r\n" +
                                        "状态：正在等待审核", "http://schoolbus.lhy0403.top/Manage/ChangeRequest?arg=my&reqId=" + message.ObjectId, message.User.UserName);
                        WeChatMessageSystem.AddToSendList(UCR_Created_TO_User_Msg);
                        return true;
                    }
                case GlobalMessageTypes.UCR_Procceed_TO_User:
                    {
                        switch (DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("objectId", message.ObjectId), out UserObject requestSender))
                        {
                            case DBQueryStatus.ONE_RESULT:
                                string stat = ((UserChangeRequest)message.DataObject).Status == UserChangeRequestProcessStatus.Accepted ? "审核通过" : "未通过";
                                WeChatSentMessage _WMessage = new WeChatSentMessage(WeChat.SentMessageType.textcard, "工单状态提醒",
                                    "你申请修改账户 " + ((UserChangeRequest)message.DataObject).RequestTypes.ToString() + " 信息的工单发生了状态变动！\r\n" +
                                        "工单编号：" + ((UserChangeRequest)message.DataObject).ObjectId + "\r\n" +
                                        "审核结果：" + stat + "\r\n请点击查看详细内容", "http://schoolbus.lhy0403.top/Manage/ChangeRequest?arg=my&reqId=" + ((UserChangeRequest)message.DataObject).ObjectId, requestSender.UserName);
                                WeChatMessageSystem.AddToSendList(_WMessage);
                                return true;
                            case DBQueryStatus.INTERNAL_ERROR:
                            case DBQueryStatus.NO_RESULTS:
                            case DBQueryStatus.MORE_RESULTS:
                            default:
                                LW.E("Failed to get user who requested to change something.... userId=" + message.ObjectId);
                                return false;
                        }
                    }
                case GlobalMessageTypes.UCR_Procced_TO_ADMIN:
                    //No Process due to.... No use..
                    throw new NotSupportedException("鬼知道你干嘛要调这个函数");
                case GlobalMessageTypes.User__Pending_Verify:
                    if ((int)GetAdminUsers(out List<UserObject> adminUsers_createUser) < 1)
                    {
                        LW.E("No Administrator found!! thus no Register Request can be solved!");
                        return false;
                    }
                    else
                    {
                        string escapedString = (string)PublicTools.EncodeString(message.DataObject.ToString());
                        string URL = Convert.ToBase64String(Encoding.UTF8.GetBytes(escapedString), Base64FormattingOptions.None);
                        WeChatSentMessage _message = new WeChatSentMessage(WeChat.SentMessageType.textcard, "新用户注册审核通知",
                            $"有一位新用户在{message.User.CreatedAt.ToString()}申请了注册用户，请审核！" +
                            $"\r\n提供的姓名：{message.User.RealName}" +
                            $"\r\n手机号码：{message.User.PhoneNumber}",
                            "http://schoolbus.lhy0403.top/Manage/UserManage?from=userCreate&mode=edit&uid=" + message.User.ObjectId
                            + "&msg=" + URL,
                            (from usr in adminUsers_createUser select usr.UserName).ToArray());
                        WeChatMessageSystem.AddToSendList(_message);

                        return true;
                    }
                case GlobalMessageTypes.User__Finishd_Verify:
                    return false;
                case GlobalMessageTypes.Bus_Status_Report_TC:
                    return false;
                case GlobalMessageTypes.Bus_Status_Report_TP:
                    return false;
                default: throw new NotSupportedException("不支持就是不支持……");
            }
        }

        private static DBQueryStatus GetAdminUsers(out List<UserObject> adminUsers) => DataBaseOperation.QueryMultipleData(new DBQuery().WhereEqualTo("isAdmin", true), out adminUsers);
    }
    public class InternalMessage
    {
        public GlobalMessageTypes _Type { get; set; }
        public UserObject User { get; set; }
        public object DataObject { get; set; }
        public string ObjectId { get; set; }
    }
}
