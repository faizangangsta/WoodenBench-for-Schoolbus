using System.Collections.Generic;
using Newtonsoft.Json;
using WBPlatform.Database;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class SchoolBusObject : _DataTableObject
    {
        public string BusName { get; set; }
        public string TeacherID { get; set; }

        public bool AHChecked { get; set; }
        public bool CSChecked { get; set; }
        public bool LSChecked { get; set; }

        public SchoolBusObject() { }
        public override string table => WBConsts.TABLE_Mgr_BusData;

        public override void readFields(DBInput input)
        {
            base.readFields(input);
            BusName = input.GetString("BusName");
            TeacherID = input.GetString("TeacherObjectID");
            LSChecked = input.GetBool("LSChecked");
            CSChecked = input.GetBool("CSChecked");
            AHChecked = input.GetBool("AHChecked");
        }

        public override void write(DBOutput output, bool all)
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
