//Game表对应的模型类
using cn.bmob.io;
using System;
using WoodenBench.StaClasses;

namespace WoodenBench.TableObject
{
    class NotificationObject : BmobTable
    {
        //以下对应云端字段名称
        public string Notification_Title { get; set; }
        public string Notification_Content { get; set; }

        //构造函数
        public NotificationObject() { }

        public override string table { get => Consts.TABLE_N_Gen_Notifi; }

        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            Notification_Title = input.getString("NTitle");
            Notification_Content = input.getString("DataContent");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("NTitle", this.Notification_Title);
            output.Put("DataContent", this.Notification_Content);
        }
    }
}