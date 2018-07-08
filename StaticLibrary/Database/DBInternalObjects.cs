using System;
using Newtonsoft.Json;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.Internal
{
    //............................................................INTERNAL CONTACTION............................................................\\
    public class DBInternalRequest
    {
        public DBOperation operation { get; set; }
        public string TableName { get; set; }
        public DBQuery Query { get; set; }
        public string objectString { get; set; }

        public DBInternalRequest()
        {
            operation = 0;
            TableName = "";
            Query = new DBQuery();
            objectString = "";
        }

        public static DBInternalRequest FromJSONString(string JSONString) => JsonConvert.DeserializeObject<DBInternalRequest>(JSONString);

        public override string ToString() => JsonConvert.SerializeObject(this);

    }
    public class DBInternalReply
    {
        public DataBaseStatus Result { get; set; }
        public string objectString { get; set; }
        public DBInternalReply()
        {
            Result = new DataBaseStatus();
            objectString = "";
        }
        public static DBInternalReply FromJSONString(string JSONString) => JsonConvert.DeserializeObject<DBInternalReply>(JSONString);

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
    public class DataBaseStatus
    {
        public DBQueryStatus DBResultCode { get; set; }
        public DBOperation DBOperation { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
