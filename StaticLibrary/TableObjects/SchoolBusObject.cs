﻿using Newtonsoft.Json;

using System.Collections.Generic;

using WBPlatform.Database;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class SchoolBusObject : DataTableObject
    {
        public string BusName { get; set; }
        public string TeacherID { get; set; }

        public bool AHChecked { get; set; }
        public bool CSChecked { get; set; }
        public bool LSChecked { get; set; }

        public SchoolBusObject() { }
        public override string Table => WBConsts.TABLE_Mgr_BusData;

        public override void ReadFields(DataBaseIO input)
        {
            base.ReadFields(input);
            BusName = input.GetString("BusName");
            TeacherID = input.GetString("TeacherObjectID");
            LSChecked = input.GetBool("LSChecked");
            CSChecked = input.GetBool("CSChecked");
            AHChecked = input.GetBool("AHChecked");
        }

        public override void WriteObject(DataBaseIO output, bool all)
        {
            base.WriteObject(output, all);
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
                { "BusID", ObjectId },
                { "CreatedAt", CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") },
                { "Name", BusName },
                { "TeacherID", TeacherID },
                { "ArriveHome", AHChecked.ToString().ToLower() },
                { "ComingSchool", CSChecked.ToString().ToLower() },
                { "LeavingSchool", LSChecked.ToString().ToLower() }
            };
        }
        public override string ToString() => JsonConvert.SerializeObject(ToDictionary());
    }
}
