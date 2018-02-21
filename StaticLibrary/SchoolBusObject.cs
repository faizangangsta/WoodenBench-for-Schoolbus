using cn.bmob.io;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.TableObject
{
    public class SchoolBusObject : BmobTable
    {
        public string BusName { get; set; }
        public string TeacherID { get; set; }
        public string LeavingChecked { get; set; }
        public string ComingChecked { get; set; }

        public string TeacherName { get; set; }

        public SchoolBusObject() { }
        public override string table => Consts.TABLE_N_Mgr_BusData;

        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            BusName = input.getString("BusName");
            TeacherID = input.getString("TeacherObjectID");
            LeavingChecked = input.getString("LeavingChecked");
            ComingChecked = input.getString("ComingChecked");
            TeacherName = input.getString("TeacherRealName");
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("BusName", this.BusName);
            output.Put("TeacherObjectID", this.TeacherID);
            output.Put("ComingChecked", this.ComingChecked);
            output.Put("LeavingChecked", this.LeavingChecked);
            output.Put("TeacherRealName", this.TeacherName);
        }
    }
}
