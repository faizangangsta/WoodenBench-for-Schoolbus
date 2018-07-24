using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WBPlatform.Database.DBIOCommand;

namespace WBPlatform.Database
{
    public abstract class DataTableObject
    {
        public abstract string Table { get; }
        public string ObjectId { get; set; }
        public DateTime CreatedAt { get; internal set; }
        public DateTime UpdatedAt { get; internal set; }


        public virtual void ReadFields(DBInput input)
        {
            ObjectId = input.GetString("objectId");
            CreatedAt = input.GetDate("createdAt");
            UpdatedAt = input.GetDate("updatedAt");
        }

        public virtual void WriteObject(DBOutput output, bool all)
        {
            output.Put("objectId", ObjectId);
            if (all)
            {
                output.Put("createdAt", CreatedAt);
                output.Put("updatedAt", UpdatedAt);
            }
        }
        public override abstract string ToString();
    }

    public class DataTableComparer<T> : IEqualityComparer<T> where T : DataTableObject, new()
    {
        public static DataTableComparer<T> Default { get; } = new DataTableComparer<T>();
        public bool Equals(T x, T y) => x.ObjectId == y.ObjectId;
        public int GetHashCode(T obj) => obj.ObjectId.GetHashCode();
    }
}
