using System.Collections.Generic;
using System.Linq;
using System.Threading;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace WBPlatform.WebManagement.Tools
{
    public class MessageBackup
    {
        public static int GetCount { get => list.Count; }
        public static bool GetStatus { get => NotificationBackupThread.IsAlive; }
        private static Thread NotificationBackupThread = new Thread(new ThreadStart(_Process));
        private static List<NotificationObject> list { get; set; } = new List<NotificationObject>();
        public static void StartBackupThread() => NotificationBackupThread.Start();

        public static void AddToSendList(string users, string Title, string Content)
        {
            // If is @all defaultly set it to Broadcast, else ClientToClient
            NotificationType _type = users == "@all" ? NotificationType.WeChatBroadCast : NotificationType.WeChatC2C;

            // If is broadcast, set "@all" into the list., else, convert users into a list.
            List<string> targetUsers = _type == NotificationType.WeChatBroadCast ? new List<string>() { "@all" } : users.Split(';').ToList();

            // If reciver is larger than 1; set tp multicast....
            _type = targetUsers.Count > 1 ? NotificationType.WeChatMultiCast : _type;

            NotificationObject notification = new NotificationObject()
            {
                Content = (Content ?? ""),
                Receivers = targetUsers,
                Sender = "WebServer",
                Title = Title ?? "",
                Type = _type
            };
            lock (list) { list.Add(notification); }
        }

        private static void _Process()
        {
            NotificationObject message;
            while (true)
            {
                lock (list)
                {
                    if (list.Count != 0)
                    {
                        message = list[list.Count - 1];
                        list.Remove(list.Last());
                    }
                    else message = null;
                }
                if (message != null) Database.CreateData(message, out string objectId);
                else Thread.Sleep(500);
                Thread.Sleep(200);
            }
        }
    }
}
