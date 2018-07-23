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
        public DBInternalRequest DBRequest { get; set; }
        public DBInternalReply DBReply { get; set; }
        public DataBaseException(string message) : base(message) { }
        public DataBaseException(string message, Exception inner) : base(message, inner) { }
        public DataBaseException(string message, DBInternalRequest dBRequest = null, DBInternalReply dBReply = null, Exception inner = null) : base(message, inner)
        {
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
            return string.IsNullOrWhiteSpace(_listString) ? new List<string>() : _listString.Split(',').ToList();
        }
        public bool GetBool(string Key) => GetT<bool>(Key);
        public int GetInt(string Key) => GetT<Int32>(Key);
        public DateTime GetDate(string Key) => GetT<DateTime>(Key);

        public T GetT<T>(string Key)
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
        public void Put(string column, object _data)
        {
            if (_data == null) { LW.E("DBOutput: Put " + column + " as null, drop it..."); return; }
            if (_data is Array || _data is IList)
            {
                _data = string.Join(",", (IEnumerable<string>)_data);
            }
            if (Data.ContainsKey(column))
            {
                Data.Remove(column);
                Data.Add(column, _data);
            }
            else
            {
                Data.Add(column, _data);
            }
        }
        public object this[string column] => Data[column];
        public Dictionary<string, object> Data { get; } = new Dictionary<string, object>();

        public DBOutput() { }
        public DBOutput(Dictionary<string, object> _real) { Data = _real; }

        public override string ToString() => JsonConvert.SerializeObject(Data);
    }

}
