using System;
using Newtonsoft.Json;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.Internal
{
    //............................................................INTERNAL CONTACTION............................................................\\
    public class DBInternalRequest
    {
        public DatabaseOperation operation { get; set; }
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
        public DatabaseOperationMessage Result { get; set; }
        public string objectString { get; set; }
        public DBInternalReply()
        {
            Result = new DatabaseOperationMessage();
            objectString = "";
        }
        public static DBInternalReply FromJSONString(string JSONString) => JsonConvert.DeserializeObject<DBInternalReply>(JSONString);

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
    public class DatabaseOperationMessage
    {
        public DatabaseResult DBResultCode { get; set; }
        public DatabaseOperation DBOperation { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
