//Game表对应的模型类
using cn.bmob.io;
using System;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.TableObject
{
    public class BusReport : DataTable
    {
        //以下对应云端字段名称
        public string TeacherID { get; set; }
        public string BusID { get; set; }
        public BusReportTypeE ReportType { get; set; }
        public string OtherData { get; set; }

        //构造函数
        public BusReport() { }

        public override string table => WBConsts.TABLE_Mgr_WeekIssue;

        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            TeacherID = input.getString("ReportTeacherID");
            BusID = input.getString("ReportBusID");
            ReportType = (BusReportTypeE)input.getInt("ReportType").Get();
            OtherData = input.getString("DetailedInformation");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("ReportTeacherID", TeacherID);
            output.Put("ReportBusID", BusID);
            output.Put("ReportType", (int)ReportType);
            output.Put("DetailedInformation", OtherData);
        }
    }
}