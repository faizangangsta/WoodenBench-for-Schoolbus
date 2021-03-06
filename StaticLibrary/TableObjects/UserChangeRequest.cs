﻿using System.Collections.Generic;
using Newtonsoft.Json;
using WBPlatform.Database;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class UserChangeRequest : DataTableObject
    {
        public override string Table => WBConsts.TABLE_Gen_UserRequest;
        public string UserID { get; set; }
        public string SolverID { get; set; }
        public UserChangeRequestTypes RequestTypes { get; set; }
        public string DetailTexts { get; set; }
        public UCRProcessStatus Status { get; set; }
        public UCRRefusedReasons ProcessResultReason { get; set; }
        public string NewContent { get; set; }

        public override void ReadFields(DataBaseIO input)
        {
            base.ReadFields(input);
            UserID = input.GetString("UserID");
            SolverID = input.GetString("SolverID");
            RequestTypes = (UserChangeRequestTypes)input.GetInt("RequestType");
            DetailTexts = input.GetString("DetailTexts");
            NewContent = input.GetString("NewContent");
            ProcessResultReason = (UCRRefusedReasons)input.GetInt("ResultReason");
            Status = (UCRProcessStatus)input.GetInt("Status");
        }

        public override void WriteObject(DataBaseIO output, bool all)
        {
            base.WriteObject(output, all);
            output.Put("UserID", UserID);
            output.Put("SolverID", SolverID);
            output.Put("RequestType", (int)RequestTypes);
            output.Put("DetailTexts", DetailTexts);
            output.Put("NewContent", NewContent);
            output.Put("Status", (int)Status);
            output.Put("ResultReason", (int)ProcessResultReason);
        }
        public override string ToString() => JsonConvert.SerializeObject(ToDictionary());

        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>
            {
                { "requestID", ObjectId },
                { "UserID", UserID },
                { "SolverID", SolverID },
                { "RequestType", RequestTypes.ToString() },
                { "CreatedAt", CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") },
                { "NewContent", NewContent },
                { "IsSolved", (Status != UCRProcessStatus.NotSolved).ToString() },
                { "DetailTexts", DetailTexts }
            };
        }
    }
}
