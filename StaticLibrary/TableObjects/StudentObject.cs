using System.Collections.Generic;

using Newtonsoft.Json;

using WBPlatform.Databases;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class StudentObject : DataTableObject
    {

        public string StudentName { get; set; }

        public string BusID { get; set; }
        public string Sex { get; set; }

        public string ClassID { get; set; }
        public bool LSChecked { get; set; }
        public bool CSChecked { get; set; }
        public bool AHChecked { get; set; }

        //public string ParentsID { get; set; }
        

        public override string table => WBConsts.TABLE_Mgr_StuData;

        public override void readFields(DataBaseInput input)
        {
            base.readFields(input);
            StudentName = input.getString("StuName");
            BusID = input.getString("BusID");
            Sex = input.getString("Sex");
            ClassID = input.getString("ClassID");
            //ParentsID = input.getString("ParentsIDs");
            CSChecked = input.getBoolean("CSChecked");
            LSChecked = input.getBoolean("LSChecked");
            AHChecked = input.getBoolean("CHChecked");
        }

        public override void write(DataBaseOutput output, bool all)
        {
            base.write(output, all);
            output.Put("StuName", StudentName);
            output.Put("BusID", BusID);
            output.Put("Sex", Sex);
            output.Put("ClassID", ClassID);
            //output.Put("ParentsIDs", ParentsID);
            output.Put("CHChecked", AHChecked);
            output.Put("CSChecked", CSChecked);
            output.Put("LSChecked", LSChecked);
        }
        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>
            {
                { "StuID", objectId },
                { "Name", StudentName },
                { "Sex", Sex },
                { "BusID", BusID },
                { "ClassID", ClassID },
                { "ComingChecked", CSChecked.ToString().ToLower() },
                { "LeavingChecked", LSChecked.ToString() },
                { "ParentLeavingChecked", AHChecked.ToString() },
            };
        }
        public override string ToString() => JsonConvert.SerializeObject(ToDictionary());
    }
}
