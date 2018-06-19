using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WBPlatform.Database
{
    public class DBQuery
    {
        public int _Limit { get; private set; } = 100;
        public int _Skip { get; private set; } = 0;
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
        public string GetString(string Key) => GetT<string>(Key);
        public List<T> GetList<T>(string Key) => GetT<List<T>>(Key);
        public bool GetBool(string Key) => GetT<bool>(Key);
        public int GetInt(string Key) => GetT<int>(Key);

        public DBInput(string data) { real = JsonConvert.DeserializeObject<Dictionary<string, object>>(data); }

        private T GetT<T>(string Key)
        {
            if (real.ContainsKey(Key)) return (T)real[Key];
            else throw new KeyNotFoundException("真的没有这个键..." + Key);
        }

        private Dictionary<string, object> real;
    }

    public class DBOutput
    {
        public void Put(string column, object data)
        {
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
        private Dictionary<string, object> real = new Dictionary<string, object>();
        public override string ToString() => JsonConvert.SerializeObject(real);
    }

    //............................................................INTERNAL CONTACTION............................................................\\
    public class DBInternalQuery
    {
        public int operation { get; set; }
        public string TableName { get; set; }
        public string queryString = "";
        public string queryObjectString = "";
        public override string ToString() => JsonConvert.SerializeObject(this);

    }

    public class DBInternalReply
    {
        public int DBResultCode { get; }
        public int DBOperation { get; }
        public string resultString = "";
        public string resultObjectString = "";
        public static DBInternalReply GetParsedReply(string fullReply) => JsonConvert.DeserializeObject<DBInternalReply>(fullReply);
    }
}
