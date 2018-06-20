using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WBPlatform.Database
{
    public class DBQuery
    {
        public int _Limit { get; set; }
        public int _Skip { get; set; }
        public Dictionary<string, object> EqualTo { get; private set; } = new Dictionary<string, object>();
        public Dictionary<string, List<object>> Contain { get; private set; } = new Dictionary<string, List<object>>();

        public DBQuery WhereEqualTo(string column, object value)
        {
            EqualTo.Add(column, value);
            return this;
        }
        public DBQuery WhereExistsInArray<T>(string column, params T[] values)
        {
            Contain.Add(column, new List<object>());
            foreach (T item in values)
            {
                Contain[column].Add(item);
            }
            return this;
        }
        public DBQuery Limit(int limit) { _Limit = limit; return this; }
        public DBQuery Skip(int skip) { _Skip = skip; return this; }

        public override string ToString() => JsonConvert.SerializeObject(this);
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
            if (data is Array)
            {
                data = string.Join(",", data as Array);
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

    //............................................................INTERNAL CONTACTION............................................................\\
    public class DBInternalQuery
    {
        public int operation { get; set; }
        public string TableName { get; set; }
        public string queryString;
        public string queryObjectString;

        public static DBInternalQuery FromJSONString(string JSONString) => JsonConvert.DeserializeObject<DBInternalQuery>(JSONString);

        public override string ToString() => JsonConvert.SerializeObject(this);

    }

    public class DBInternalReply
    {
        public int DBResultCode { get; set; }
        public int DBOperation { get; set; }
        public string Message { get; set; }
        public string resultString { get; set; }
        public string resultObjectString { get; set; }

        public static DBInternalReply FromJSONString(string JSONString) => JsonConvert.DeserializeObject<DBInternalReply>(JSONString);

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
