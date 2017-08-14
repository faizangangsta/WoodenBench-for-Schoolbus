using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoodenBench.StaClasses;

namespace WoodenBench.TableObject
{
    public class StudentDataObject : BmobTable
    {
        public string StudentName { get; set; }
        public string StudentNamePinYin { get; set; }
        public string StudentClass { get; set; }
        public string StudentDirection { get; set; }
        public string StudentPartOfSchool { get; set; }
        public string OtherStuData { get; set; }
        public string StuIdentity { get; set; }
        private string PriTable = Consts.TABLE_N_Mgr_StuData;
        public StudentDataObject() { }
        public override string table
        {
            get
            {
                if (PriTable != null)
                {
                    return PriTable;
                }
                return base.table;
            }
        }
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            StudentName = input.getString("StuName");
            StudentDirection = input.getString("StuDirection");
            StudentClass = input.getString("StuClass");
            StudentPartOfSchool = input.getString("StuPartOfSchool");
            StudentNamePinYin = input.getString("StuNamePinin");
            OtherStuData = input.getString("OtherData");
            StuIdentity = input.getString("StuIdentity");
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("StuNamePinyin", this.StudentNamePinYin);
            output.Put("StuName", this.StudentName);
            output.Put("StuDirection", this.StudentDirection);
            output.Put("StuClass", this.StudentClass);
            output.Put("StuPartOfSchool", this.StudentPartOfSchool);
            output.Put("OtherData", this.OtherStuData);
            output.Put("StuIdentity", this.StuIdentity);
        }
    }
}
