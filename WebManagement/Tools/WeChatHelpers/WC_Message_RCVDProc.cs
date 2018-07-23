using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using WBPlatform.Database;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace WBPlatform.WebManagement.Tools
{
    public static partial class WeChatMessageSystem
    {
        private static List<WeChatRcvdMessage> RcvdMessageList { get; set; } = new List<WeChatRcvdMessage>();
        private static Thread ProcessorRCVDThread = new Thread(new ThreadStart(_ProcessRCVD));
        public static (bool, bool, int, int) Status()
        {
            return (ProcessorRCVDThread.IsAlive, ProcessorSENTThread.IsAlive, RcvdMessageList.Count, SentMessageList.Count);
        }

        public static void StartProcessThreads()
        {
            ProcessorSENTThread.Start();
            LW.D("\tWeChatSendThread Started!");
            ProcessorRCVDThread.Start();
            LW.D("\tWeChatRcvdThread Started!");
        }

        public static void AddMessageToList(WeChatRcvdMessage _Message)
        {
            lock (RcvdMessageList) RcvdMessageList.Add(_Message);
        }

        private static Dictionary<string, string> ResponceToMessage(WeChatRcvdMessage Message)
        {
            switch (Message.MessageType)
            {
                case WeChat.RcvdMessageType.text:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "你是说:" + Message.TextContent + "??");
                case WeChat.RcvdMessageType.image:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇这张图片真好看");
                case WeChat.RcvdMessageType.voice:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "哇声音真好听");
                case WeChat.RcvdMessageType.location:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "发个地址干啥，，你想去吗？");
                case WeChat.RcvdMessageType.video:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "啥视频？");
                case WeChat.RcvdMessageType.link:
                    return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, "这啥网站？？");
                case WeChat.RcvdMessageType.EVENT:
                    switch (Message.Event)
                    {
                        case WeChat.Event.click:
                            switch (Message.EventKey)
                            {
                                case "ADD_PASSWORD":
                                    string token = JumpTokens.CreateToken();
                                    if (JumpTokens.TryAdd(token, new JumpTokenInfo(JumpTokenUsage.FreeLogin_View, "JumpToken_FreeLogin", Message.FromUser)))
                                    {
                                        var p = SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null,
                                            "要是想使用Windows 客户端登陆的话\r\n" +
                                            "就点击<a href='https://schoolbus.lhy0403.top/Account/Register/?token=" + token + "&_action=AddPassword&user=" + Message.FromUser + "'>这里</a>" +
                                            "给自己加一个密码吧!");
                                        return p;
                                    }
                                    else
                                    {
                                        return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null,
                                            "我们在处理你的账户时出现了问题，你可能暂时无法添加密码\r\n请与管理员联系，并提供以下内容\r\nCreateToken_Error");
                                    }
                                case "WEB_SERV_VER":
                                    return SendMessageString(WeChat.SentMessageType.textcard, Message.FromUser,
                                        "小板凳平台版本信息",
                                        "这是当前版本信息: \r\n" +
                                        "启动の时间: " + Program.StartUpTime.ToString() + "\r\n\r\n" +
                                        "服务端版本: " + Program.Version + "\r\n" +
                                        "核心库版本: " + WBConsts.CurrentCoreVersion + "\r\n" +
                                        "运行时版本: " + Assembly.GetCallingAssembly().ImageRuntimeVersion + "\r\n\r\n=点击查看系统状态>>", "https://status.schoolbus.lhy0403.top/");
                                default:
                                    LW.E("Recieved Not Supported :::Wechat Event Click::: Key " + Message.EventKey);
                                    return null;
                            }
                        case WeChat.Event.LOCATION:
                            var Latitude = Message.Location.X;
                            var Longitude = Message.Location.Y;
                            var Precision = Message.Precision;
                            var time = Message.RecievedTime;
                            var toUser = Message.FromUser;
                            LW.D($"WeChatMessageResp: Recieved Location: {Latitude}:{Longitude}%{Precision}@{time} form {toUser}");
                            if (DataBaseOperation.QuerySingleData(new DBQuery().WhereEqualTo("Username", toUser), out UserObject _user) == DBQueryStatus.ONE_RESULT)
                            {
                                _user.CurrentPoint = Message.Location;
                                _user.Precision = Precision;
                                if (DataBaseOperation.UpdateData(_user) != DBQueryStatus.ONE_RESULT)
                                    LW.E("WeChatMessageResp: Cannot save User with new Position...");
                                else LW.D("WeChatMessageResp: Succeed Save User with New Position...");
                            }
                            else LW.E("WeChatMessageResp: Cannot find user in Database....");


                            return null;
                    }
                    return null;
            }
            return SendMessageString(WeChat.SentMessageType.text, Message.FromUser, null, Content: "不支持的消息类型");
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
                else Thread.Sleep(200);
            }
        }
    }
}
