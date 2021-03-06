﻿//Game表对应的模型类
using System.Collections.Generic;
using System.Linq;

using WBPlatform.Database;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class NotificationObject : DataTableObject
    {
        //以下对应云端字段名称
        public string Title { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public NotificationType Type { get; set; }
        public List<string> Receivers { get; set; }

        public NotificationObject() { }

        public override string Table => WBConsts.TABLE_Gen_Notification;


        public override void ReadFields(DataBaseIO input)
        {
            base.ReadFields(input);
            Title = input.GetString("Title");
            Content = input.GetString("Content");
            Sender = input.GetString("Sender");
            Receivers = input.GetString("Receiver").Split(';').ToList();
            Type = (NotificationType)input.GetInt("type");
        }

        //写字段信息
        public override void WriteObject(DataBaseIO output, bool all)
        {
            string recv = GetStringRecivers();
            base.WriteObject(output, all);
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
            return recv.EndsWith(";;") ? new string(recv.Take(recv.Length - 1).ToArray()) : recv;
        }
        public override string ToString() => throw new System.NotImplementedException();
    }
}