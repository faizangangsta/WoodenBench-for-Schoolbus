using System.Collections.Generic;
using Newtonsoft.Json;
using WBPlatform.Database;
using WBPlatform.Database.DBIOCommand;
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
        public override string Table => WBConsts.TABLE_Mgr_Classes;
        
        public override void ReadFields(DataBaseIO input)
        {
            base.ReadFields(input);
            CDepartment = input.GetString("ClassDepartment");
            CGrade = input.GetString("ClassGrade");
            CNumber = input.GetString("ClassNumber");
            TeacherID = input.GetString("TeacherID");
        }

        public override void WriteObject(DataBaseIO output, bool all)
        {
            base.WriteObject(output, all);
            output.Put("ClassDepartment", CDepartment);
            output.Put("ClassGrade", CGrade);
            output.Put("ClassNumber", CNumber);
            output.Put("TeacherID", TeacherID);
        }

        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>
            {
                { "ClassID", ObjectId },
                { "ClassDepartment", CDepartment },
                { "ClassGrade", CGrade },
                { "ClassNumber", CNumber },
                { "TeacherID", TeacherID },
                { "CreatedAt", CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") },
                { "UpdatedAt", UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") },
            };
        }
        public override string ToString() => JsonConvert.SerializeObject(ToDictionary());
    }
}
