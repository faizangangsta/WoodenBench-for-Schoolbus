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

        public string StudentPartOfSchool { get; set; }
        public string StudentYear { get; set; }
        public string StudentClass { get; set; }

        public string StudentDirection { get; set; }

        public string BusID { get; set; }

        public string OtherStuData { get; set; }

        public bool LeaveChecked { get; set; }
        public  bool ComeChecked { get; set; }

        public bool ParentLeaveChecked { get; set; }
        public  bool ParentComeChecked { get; set; }

        public StudentDataObject() { }
        public override string table => Consts.TABLE_N_Mgr_StuData;

        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            StudentName = input.getString("StuName");
            StudentDirection = input.getString("StuDirection");
            BusID = input.getString("BusID");

            StudentPartOfSchool = input.getString("StuPartOfSchool");
            StudentYear = input.getString("StuYear");
            StudentClass = input.getString("StuClass");
            OtherStuData = input.getString("OtherData");

            ComeChecked = input.getBoolean("ComingChecked").Get();
            LeaveChecked = input.getBoolean("LeaveChecked").Get();
            ParentLeaveChecked = input.getBoolean("ParenLeaveChecked").Get();
            ParentComeChecked = input.getBoolean("ParentComingChecked").Get();
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("StuYear", this.StudentYear);
            output.Put("StuName", this.StudentName);
            output.Put("StuDirection", this.StudentDirection);
            output.Put("BusID", this.BusID);

            output.Put("StuPartOfSchool", this.StudentPartOfSchool);
            output.Put("StuClass", this.StudentClass);
            output.Put("OtherData", this.OtherStuData);

            output.Put("ParentComingChecked", ParentComeChecked);
            output.Put("ParenLeaveChecked", ParentLeaveChecked);
            output.Put("ComingChecked", ComeChecked);
            output.Put("LeaveChecked", LeaveChecked);
        }
    }
}
