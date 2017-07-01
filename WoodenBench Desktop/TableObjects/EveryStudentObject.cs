using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoodenBench.TableObjects
{
	public class EveryStudentData : BmobTable
	{
		public string StudentName { get; set; }
		public string StudentDirection { get; set; }
		public string StudentClass { get; set; }
        public string StudentPartOfSchool { get; set; }
        public string StudentNamePinYin { get; set; }
		private string PriTable;
		public EveryStudentData(String TableName) { PriTable = TableName; }
		public EveryStudentData() { }
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
			StudentIsBWeek = input.getBoolean("StuIsBigWeek").ToString();
			StudentClass = input.getString("StuClass");
			StudentPartOfSchool = input.getString("StuPartOfSchool");
            StudentNamePinYin = input.getString("StuNamePinin");
		}

		public override void write(BmobOutput output, bool all)
		{
			base.write(output, all);
            output.Put("StuNamePinyin", this.StudentNamePinYin);
			output.Put("StuName", this.StudentName);
			output.Put("StuDirection", this.StudentDirection);
			output.Put("StuIsBigWeek", this.StudentIsBWeek);
			output.Put("StuClass", this.StudentClass);
			output.Put("StuPartOfSchool", this.StudentPartOfSchool);
		}
	}
}
