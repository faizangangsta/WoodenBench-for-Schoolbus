using System;
using Newtonsoft.Json;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.Internal
{
    //............................................................INTERNAL CONTACTION............................................................\\
    public class DBInternalRequest
    {
        public DBVerbs Operation { get; set; }
        public string TableName { get; set; }
        public DBQuery Query { get; set; }
        public string ObjectString { get; set; }

        public DBInternalRequest()
        {
            Operation = 0;
            TableName = "";
            Query = new DBQuery();
            ObjectString = "";
        }

        public static bool FromJSONString(string JSONString, out DBInternalRequest request)
        {
            request = JsonConvert.DeserializeObject<DBInternalRequest>(JSONString);
            return request != null;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);

    }
    public class DBInternalReply
    {
        public string ObjectString { get; set; }
        public DBInternalReply()
        {
            ObjectString = "";
        }
        public static DBInternalReply FromJSONString(string JSONString) => JsonConvert.DeserializeObject<DBInternalReply>(JSONString);

        public override string ToString() => JsonConvert.SerializeObject(this);

        public DBQueryStatus DBResultCode { get; set; }
        public DBVerbs DBOperation { get; set; }
        public string Message { get; set; }
        public DataBaseException Exception { get; set; }
    }
}
