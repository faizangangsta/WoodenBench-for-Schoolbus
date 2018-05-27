using cn.bmob.io;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using WBPlatform.StaticClasses;
using static WBPlatform.StaticClasses.Crypto;

namespace WBPlatform.TableObject
{
    public class UserChangeRequest : DataTable
    {
        public override string table => WBConsts.TABLE_Gen_UserTable;
        public string UserID { get; set; }
        public string SolverID { get; set; }
        public UserChangeRequestTypes RequestTypes { get; set; }
        public string DetailTexts { get; set; }
        public bool IsSolved { get; set; }
        public string NewContent { get; set; }

        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            UserID = input.getString("UserID");
            SolverID = input.getString("SolverID");
            RequestTypes = (UserChangeRequestTypes)(input.getInt("SolverID").Get());
            DetailTexts = input.getString("DetailTexts");
            IsSolved = input.getBoolean("IsSolved").Get();
            NewContent = input.getString("NewContent");
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("UserID", UserID);
            output.Put("SolverID", SolverID);
            output.Put("RequestType", (int)RequestTypes);
            output.Put("DetailTexts", DetailTexts);
            output.Put("IsSolved", IsSolved);
            output.Put("NewContent", NewContent);

        }
        public override string ToString() => SimpleJson.SimpleJson.SerializeObject(ToDictionary());

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
                { "IsSolved", IsSolved.ToString() },
                { "DetailTexts", DetailTexts }
            };
        }
    }
}