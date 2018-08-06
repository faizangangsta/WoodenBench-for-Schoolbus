using System;
using System.Collections;
using System.Collections.Generic;

using WBPlatform.StaticClasses;

namespace WBPlatform.Database.DBIOCommand
{
    public class DataBaseIO
    {
        public DataBaseIO() { }
        public DataBaseIO(Dictionary<string, object> data) { Data = data; }
        public object this[string column] => Data[column];

        public Dictionary<string, object> Data { get; private set; } = new Dictionary<string, object>();


        public T GetT<T>(string Key)
        {
            if (Data.ContainsKey(Key)) return (T)Convert.ChangeType(Data[Key], typeof(T));
            else throw new KeyNotFoundException("真的没有这个键..." + Key);
        }

        public void Put(string column, object data)
        {
            if (data == null) { LW.E("DBOutput: Put " + column + " as null, drop it..."); return; }
            if (data is ICollection)
            {
                data = string.Join(",", (IEnumerable<string>)data);
            }
            if (Data.ContainsKey(column))
            {
                Data.Remove(column);
                Data.Add(column, data);
            }
            else
            {
                Data.Add(column, data);
            }
        }
    }
}
