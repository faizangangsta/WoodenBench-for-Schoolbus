using System.Collections.Generic;
using Newtonsoft.Json;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class SchoolBusObject : DataTableObject
    {
        public string BusName { get; set; }
        public string TeacherID { get; set; }

        public bool AHChecked { get; set; }
        public bool CSChecked { get; set; }
        public bool LSChecked { get; set; }

        public SchoolBusObject() { }
        public override string table => WBConsts.TABLE_Mgr_BusData;

        public override void readFields(DataBaseInput input)
        {
            base.readFields(input);
            BusName = input.getString("BusName");
            TeacherID = input.getString("TeacherObjectID");
            LSChecked = input.getBoolean("LSChecked");
            CSChecked = input.getBoolean("CSChecked");
            AHChecked = input.getBoolean("AHChecked");
        }

        public override void write(DataBaseOutput output, bool all)
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
        public override string ToString() => JsonConvert.SerializeObject(ToDictionary());

    }
}
