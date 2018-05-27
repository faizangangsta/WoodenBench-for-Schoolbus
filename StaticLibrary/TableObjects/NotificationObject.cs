//Game表对应的模型类
using cn.bmob.io;
using System;
using System.Linq;
using System.Collections.Generic;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class NotificationObject : DataTable
    {
        //以下对应云端字段名称
        public string Title { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public NotificationType Type { get; set; }
        public List<string> Receivers { get; set; }

        public NotificationObject() { }

        public override string table => WBConsts.TABLE_Gen_Notification;


        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            Title = input.getString("Title");
            Content = input.getString("Content");
            Sender = input.getString("Sender");
            Receivers = input.getString("Receiver").Split(';').ToList();
            Type = (NotificationType)input.getInt("Type").Get();
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            string recv = GetStringRecivers();
            base.write(output, all);
            output.Put("Title", Title);
            output.Put("Content", Content);
            output.Put("Type", (int)Type);
            output.Put("Sender", Sender);
            output.Put("Receiver", recv);
        }

        public string GetStringRecivers()
        {
            string recv = "";
            if (Receivers[0].StartsWith("@all")) recv = "@all;";
            else foreach (string item in Receivers) recv = recv + item + ";";
            return (recv.EndsWith(";;") ? new string(recv.Take(recv.Length - 1).ToArray()) : recv);
        }
    }
}