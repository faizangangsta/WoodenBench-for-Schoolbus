using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.TableObject
{
    public class StudentDataObject : BmobTable
    {
        public string StudentName { get; set; }

        public string BusID { get; set; }
        public string ClassID { get; set; }
        public string ParentID { get; set; }

        public bool LSChecked { get; set; }
        public bool CSChecked { get; set; }
        public bool CHChecked { get; set; }

        public StudentDataObject() { }
        public override string table => Consts.TABLE_N_Mgr_StuData;

        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            StudentName = input.getString("StuName");
            BusID = input.getString("BusID");
            ParentID = input.getString("ParentID");
            ClassID = input.getString("ClassID");
            CSChecked = input.getBoolean("CSChecked").Get();
            LSChecked = input.getBoolean("LSChecked").Get();
            CHChecked = input.getBoolean("CHChecked").Get();
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("StuName", StudentName);
            output.Put("BusID", BusID);
            output.Put("ParentID", ParentID);
            output.Put("ClassID", ClassID);
            output.Put("CHChecked", CHChecked);
            output.Put("CSChecked", CSChecked);
            output.Put("LSChecked", LSChecked);
        }
    }
}
