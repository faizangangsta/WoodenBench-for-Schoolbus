using WBPlatform.Databases;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class BusReport : DataTableObject
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
        public override void readFields(DataBaseInput input)
        {
            base.readFields(input);
            TeacherID = input.getString("ReportTeacherID");
            BusID = input.getString("ReportBusID");
            ReportType = (BusReportTypeE)input.getInt("ReportType");
            OtherData = input.getString("DetailedInformation");
        }

        //写字段信息
        public override void write(DataBaseOutput output, bool all)
        {
            base.write(output, all);
            output.Put("ReportTeacherID", TeacherID);
            output.Put("ReportBusID", BusID);
            output.Put("ReportType", (int)ReportType);
            output.Put("DetailedInformation", OtherData);
        }
    }
}