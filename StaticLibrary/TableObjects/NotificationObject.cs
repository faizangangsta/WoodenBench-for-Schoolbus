//Game表对应的模型类
using cn.bmob.io;
using System;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.TableObject
{
    public class NotificationObject : DataTable
    {
        //以下对应云端字段名称
        public string Title { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public NotificationType Type { get; set; }
        public string Receiver { get; set; }

        public NotificationObject() { }

        public override string table => WBConsts.TABLE_Gen_Notification;


        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            Title = input.getString("Title");
            Content = input.getString("Content");
            Sender = input.getString("Sender");
            Receiver = input.getString("Receiver");
            Type = (NotificationType)input.getInt("Type").Get();
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("Title", Title);
            output.Put("Content", Content);
            output.Put("Type", (int)Type);
            output.Put("Sender", Sender);
            output.Put("Receiver", Receiver);
        }
    }
}