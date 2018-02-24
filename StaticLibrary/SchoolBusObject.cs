using cn.bmob.io;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.TableObject
{
    public class SchoolBusObject : BmobTable
    {
        public string BusName { get; set; }
        public string TeacherID { get; set; }
        public bool AHChecked { get; set; }
        public bool CSChecked { get; set; }
        public bool LSChecked { get; set; }

        public SchoolBusObject() { }
        public override string table => Consts.TABLE_N_Mgr_BusData;

        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            BusName = input.getString("BusName");
            TeacherID = input.getString("TeacherObjectID");
            LSChecked = input.getBoolean("LSChecked").Get();
            CSChecked = input.getBoolean("CSChecked").Get();
            AHChecked = input.getBoolean("AHChecked").Get();
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("BusName", BusName);
            output.Put("TeacherObjectID", TeacherID);
            output.Put("CSChecked", CSChecked);
            output.Put("LSChecked", LSChecked);
            output.Put("AHChecked", AHChecked);
        }
    }
}
