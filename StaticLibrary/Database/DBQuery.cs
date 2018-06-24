using System.Collections.Generic;
using Newtonsoft.Json;

namespace WBPlatform.Database
{
    public class DBQuery
    {
        public int _Limit { get; set; }
        public int _Skip { get; set; }
        public Dictionary<string, object> EqualTo { get; private set; } = new Dictionary<string, object>();
        public Dictionary<string, string> Contains { get; private set; } = new Dictionary<string, string>();
        public Dictionary<string, List<string>> ContainedInArray { get; private set; } = new Dictionary<string, List<string>>();

        public DBQuery WhereEqualTo(string column, object value)
        {
            EqualTo.Add(column, value);
            return this;
        }
        public DBQuery WhereContainsValue(string column, string value)
        {
            Contains.Add(column, value);
            return this;
        }
        public DBQuery WhereContainedInArray<T>(string column, params T[] values)
        {
            ContainedInArray.Add(column, new List<string>());
            foreach (T item in values)
            {
                ContainedInArray[column].Add(item.ToString());
            }
            return this;
        }
        public DBQuery Limit(int limit) { _Limit = limit; return this; }
        public DBQuery Skip(int skip) { _Skip = skip; return this; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
