//Game表对应的模型类
using cn.bmob.io;
using System;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.TableObject
{
    public class NotificationObject : BmobTable
    {
        //以下对应云端字段名称
        public string Name { get; set; }
        public string Notification_Title { get; set; }
        public string Notification_Content { get; set; }
        public string OtherData { get; set; }
        
        public NotificationObject() { }

        public override string table => WBConsts.TABLE_N_Gen_Notifi;


        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            Name = input.getString("Name");
            Notification_Title = input.getString("NTitle");
            Notification_Content = input.getString("DataContent");
            OtherData = input.getString("OtherData");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("Name", this.Name);
            output.Put("NTitle", this.Notification_Title);
            output.Put("DataContent", this.Notification_Content);
            output.Put("OtherData", this.OtherData);
        }
    }
}