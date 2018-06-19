using WBPlatform.Database;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class BusReport : _DataTableObject
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
        public override void readFields(DBInput input)
        {
            base.readFields(input);
            TeacherID = input.GetString("ReportTeacherID");
            BusID = input.GetString("ReportBusID");
            ReportType = (BusReportTypeE)input.GetInt("ReportType");
            OtherData = input.GetString("DetailedInformation");
        }

        //写字段信息
        public override void write(DBOutput output, bool all)
        {
            base.write(output, all);
            output.Put("ReportTeacherID", TeacherID);
            output.Put("ReportBusID", BusID);
            output.Put("ReportType", (int)ReportType);
            output.Put("DetailedInformation", OtherData);
        }
    }
}