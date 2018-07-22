using WBPlatform.Database;
using WBPlatform.Database.DBIOCommand;
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

        public override string Table => WBConsts.TABLE_Mgr_WeekIssue;
                //读字段信息
        public override void ReadFields(DBInput input)
        {
            base.ReadFields(input);
            TeacherID = input.GetString("ReportTeacherID");
            BusID = input.GetString("ReportBusID");
            ReportType = (BusReportTypeE)input.GetInt("ReportType");
            OtherData = input.GetString("DetailedInformation");
        }

        //写字段信息
        public override void WriteObject(DBOutput output, bool all)
        {
            base.WriteObject(output, all);
            output.Put("ReportTeacherID", TeacherID);
            output.Put("ReportBusID", BusID);
            output.Put("ReportType", (int)ReportType);
            output.Put("DetailedInformation", OtherData);
        }
        public override string ToString() => throw new System.NotImplementedException();
    }
}