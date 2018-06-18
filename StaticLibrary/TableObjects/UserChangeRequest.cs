using System.Collections.Generic;
using Newtonsoft.Json;
using WBPlatform.Databases;
using WBPlatform.StaticClasses;

namespace WBPlatform.TableObject
{
    public class UserChangeRequest : DataTableObject
    {
        public override string table => WBConsts.TABLE_Gen_UserRequest;
        public string UserID { get; set; }
        public string SolverID { get; set; }
        public UserChangeRequestTypes RequestTypes { get; set; }
        public string DetailTexts { get; set; }
        public UserChangeRequestProcessStatus Status { get; set; }
        public UserChangeRequestRefusedReasons ProcessResultReason { get; set; }
        public string NewContent { get; set; }

        public override void readFields(DataBaseInput input)
        {
            base.readFields(input);
            UserID = input.getString("UserID");
            SolverID = input.getString("SolverID");
            RequestTypes = (UserChangeRequestTypes)(input.getInt("RequestType"));
            DetailTexts = input.getString("DetailTexts");
            NewContent = input.getString("NewContent");
            ProcessResultReason = (UserChangeRequestRefusedReasons)input.getInt("ResultReason");
            Status = (UserChangeRequestProcessStatus)input.getInt("Status");
        }

        public override void write(DataBaseOutput output, bool all)
        {
            base.write(output, all);
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
                { "requestID", objectId },
                { "UserID", UserID },
                { "SolverID", SolverID },
                { "RequestType", RequestTypes.ToString() },
                { "CreatedAt", createdAt },
                { "NewContent", NewContent },
                { "IsSolved", (Status != UserChangeRequestProcessStatus.NotSolved).ToString() },
                { "DetailTexts", DetailTexts }
            };
        }
    }
}
