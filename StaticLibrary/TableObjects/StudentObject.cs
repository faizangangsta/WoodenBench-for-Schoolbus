using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.TableObject
{
    public class StudentObject : BmobTable
    {

        public string StudentName { get; set; }

        public string BusID { get; set; }
        public string Sex { get; set; }

        public string ClassID { get; set; }
        public bool LSChecked { get; set; }
        public bool CSChecked { get; set; }
        public bool AHChecked { get; set; }

        public string ParentsID { get; set; }
        

        public override string table => WBConsts.TABLE_N_Mgr_StuData;

        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            StudentName = input.getString("StuName");
            BusID = input.getString("BusID");
            Sex = input.getString("Sex");
            ClassID = input.getString("ClassID");
            ParentsID = input.getString("ParentsIDs");
            CSChecked = input.getBoolean("CSChecked").Get();
            LSChecked = input.getBoolean("LSChecked").Get();
            AHChecked = input.getBoolean("CHChecked").Get();
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("StuName", StudentName);
            output.Put("BusID", BusID);
            output.Put("Sex", Sex);
            output.Put("ClassID", ClassID);
            output.Put("ParentsIDs", ParentsID);
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
        public override string ToString()
        {
            return SimpleJson.SimpleJson.SerializeObject(ToDictionary());
        }
    }
}
