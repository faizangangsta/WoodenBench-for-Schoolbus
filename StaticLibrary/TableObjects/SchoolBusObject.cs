using cn.bmob.io;
using System.Collections.Generic;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class SchoolBusObject : DataTable
    {
        public string BusName { get; set; }
        public string TeacherID { get; set; }

        public bool AHChecked { get; set; }
        public bool CSChecked { get; set; }
        public bool LSChecked { get; set; }

        public SchoolBusObject() { }
        public override string table => WBConsts.TABLE_Mgr_BusData;

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

        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>
            {
                { "BusID", objectId },
                { "CreatedAt", createdAt },
                { "Name", BusName },
                { "TeacherID", TeacherID },
                { "ArriveHome", AHChecked.ToString().ToLower() },
                { "ComingSchool", CSChecked.ToString().ToLower() },
                { "LeavingSchool", LSChecked.ToString().ToLower() },
            };
        }
        public override string ToString()
        {
            return SimpleJson.SimpleJson.SerializeObject(ToDictionary());
        }
    }
}
