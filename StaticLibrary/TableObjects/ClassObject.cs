using System.Collections.Generic;
using Newtonsoft.Json;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class ClassObject : DataTableObject
    {
        public string CDepartment { get; set; }
        public string CGrade { get; set; }
        public string CNumber { get; set; }

        public string TeacherID { get; set; }

        public ClassObject() { }
        public override string table => WBConsts.TABLE_Mgr_Classes;
        
        public override void readFields(DataBaseInput input)
        {
            base.readFields(input);
            CDepartment = input.getString("ClassDepartment");
            CGrade = input.getString("ClassGrade");
            CNumber = input.getString("ClassNumber");
            TeacherID = input.getString("TeacherID");
        }

        public override void write(DataBaseOutput output, bool all)
        {
            base.write(output, all);
            output.Put("ClassDepartment", CDepartment);
            output.Put("ClassGrade", CGrade);
            output.Put("ClassNumber", CNumber);
            output.Put("TeacherID", TeacherID);
        }

        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>
            {
                { "ClassID", objectId },
                { "ClassDepartment", CDepartment },
                { "ClassGrade", CGrade },
                { "ClassNumber", CNumber },
                { "TeacherID", TeacherID },
                { "CreatedAt", createdAt },
                { "UpdatedAt", updatedAt },
            };
        }
        public override string ToString() => JsonConvert.SerializeObject(ToDictionary());
    }
}
