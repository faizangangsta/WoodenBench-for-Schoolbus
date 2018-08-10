using System.Collections.Generic;
using Newtonsoft.Json;

namespace WBPlatform.Database
{
    public class DBQuery
    {
        public DBQuery(string SortedBy = nameof(DataTableObject.UpdatedAt), bool IsAscending = false)
        {
            this.SortedBy(SortedBy);
            var _ = IsAscending ? Ascending() : Descending();
        }
        public bool _Ascending { get; set; }
        public int _Limit { get; set; }
        public int _Skip { get; set; }
        public string _SortedBy { get; set; }

        public Dictionary<string, object> EqualTo { get; private set; } = new Dictionary<string, object>();
        public Dictionary<string, string> Contains { get; private set; } = new Dictionary<string, string>();
        public Dictionary<string, List<string>> ContainedInArray { get; private set; } = new Dictionary<string, List<string>>();

        public DBQuery WhereValueContainedInArray<T>(string column, params T[] values)
        {
            ContainedInArray.Add(column, new List<string>());
            foreach (T item in values)
            {
                ContainedInArray[column].Add(item.ToString());
            }
            return this;
        }

        public DBQuery SortedBy(string column) { _SortedBy = column; return this; }
        public DBQuery WhereEqualTo(string column, object value) { EqualTo.Add(column, value); return this; }
        public DBQuery WhereRecordContainsValue(string column, string value) { Contains.Add(column, value); return this; }
        public DBQuery Limit(int limit) { _Limit = limit; return this; }
        public DBQuery Skip(int skip) { _Skip = skip; return this; }
        public DBQuery Ascending() { _Ascending = true; return this; }
        public DBQuery Descending() { _Ascending = false; return this; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
