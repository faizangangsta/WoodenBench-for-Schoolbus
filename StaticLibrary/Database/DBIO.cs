using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using WBPlatform.Database;
using WBPlatform.Database.Connection;
using WBPlatform.Database.Internal;
using WBPlatform.StaticClasses;
using Newtonsoft.Json;
using System.Collections;

namespace WBPlatform.Database.DBIOCommand
{

    [Serializable]
    public class DataBaseException : Exception
    {
        public DatabaseResult ErrorType { get; private set; }
        public DBInternalRequest DBRequest { get; set; }
        public DBInternalReply DBReply { get; set; }
        public DataBaseException(string message, DatabaseResult errorType) : base(message)
        {
            ErrorType = errorType;
        }
        public DataBaseException(string message, DatabaseResult errorType, Exception inner) : base(message, inner)
        {
            ErrorType = errorType;
        }
        public DataBaseException(string message, DatabaseResult errorType, DBInternalRequest dBRequest = null, DBInternalReply dBReply = null, Exception inner = null) : base(message, inner)
        {
            ErrorType = errorType;
            DBRequest = dBRequest;
            DBReply = dBReply;
        }
        protected DataBaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
    public class DBInput
    {
        private Dictionary<string, object> real = new Dictionary<string, object>();

        public string GetString(string Key) => GetT<string>(Key);
        public List<string> GetList(string Key)
        {
            string _listString = GetString(Key);
            return _listString.Split(',').ToList();
        }
        public bool GetBool(string Key) => GetT<bool>(Key);
        public int GetInt(string Key) => GetT<Int32>(Key);
        public DateTime GetDate(string Key) => GetT<DateTime>(Key);

        private T GetT<T>(string Key)
        {
            if (real.ContainsKey(Key)) return (T)Convert.ChangeType(real[Key], typeof(T));
            else throw new KeyNotFoundException("真的没有这个键..." + Key);
        }
        public DBInput() { }
        public DBInput(string JSONString) { real = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSONString); }
        public DBInput(Dictionary<string, object> _real) { real = _real; }

        public override string ToString() => JsonConvert.SerializeObject(real);
    }
    public class DBOutput
    {
        private Dictionary<string, object> real = new Dictionary<string, object>();
        public void Put(string column, object data)
        {
            if (data is Array || data is IList)
            {
                data = string.Join(",", ((IEnumerable<string>)data));
            }
            if (real.ContainsKey(column))
            {
                real.Remove(column);
                real.Add(column, data);
            }
            else
            {
                real.Add(column, data);
            }
        }
        public Dictionary<string, object> GetData() => real;

        public DBOutput() { }
        public DBOutput(Dictionary<string, object> _real) { real = _real; }
        public DBOutput(string JSONString) { real = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSONString); }

        public override string ToString() => JsonConvert.SerializeObject(real);
    }

}
