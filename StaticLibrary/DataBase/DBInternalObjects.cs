using System;
using Newtonsoft.Json;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.Internal
{
    //............................................................INTERNAL CONTACTION............................................................\\
    public class DBInternalRequest
    {
        public DBVerbs operation { get; set; }
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

        public static bool FromJSONString(string JSONString, out DBInternalRequest request)
        {
            try
            {
                request = JsonConvert.DeserializeObject<DBInternalRequest>(JSONString);
            }
            finally { }
            return request != null;
        }

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
        public DBVerbs DBOperation { get; set; }
        public string Message { get; set; }
        public DataBaseException Exception { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
