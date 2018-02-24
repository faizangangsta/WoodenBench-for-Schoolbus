using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WBServicePlatform.StaticClasses;

namespace WBServicePlatform.TableObject
{
    public class ClassObject : BmobTable
    {
        public string CDepartment { get; set; }
        public string CGrade { get; set; }
        public string CNumber { get; set; }

        public string TeacherID { get; set; }

        public ClassObject() { }
        public override string table => Consts.TABLE_N_Mgr_Classes;

        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            CDepartment = input.getString("ClassDepartment");
            CGrade = input.getString("ClassGrade");
            CNumber = input.getString("ClassNumber");
            TeacherID = input.getString("TeacherID");
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("ClassDepartment", CDepartment);
            output.Put("ClassGrade", CGrade);
            output.Put("ClassNumber", CNumber);
            output.Put("TeacherID", TeacherID);
        }
    }
}
