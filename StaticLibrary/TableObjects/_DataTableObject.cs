//using cn.bmob.api;
//using cn.bmob.io;
//using cn.bmob.tools;

using System;
using WBPlatform.Database;

namespace WBPlatform.TableObject
{
    public class _DataTableObject
    {
        public virtual string table => GetType().Name;
        public string objectId { get; set; }
        public DateTime createdAt { get; internal set; }
        public DateTime updatedAt { get; internal set; }

        public virtual void readFields(DBInput input)
        {
            objectId = input.GetString("objectId");
            createdAt = input.GetDate("createdAt");
            updatedAt = input.GetDate("updatedAt");
        }
        
        public virtual void write(DBOutput output, bool all)
        {
            if (all)
            {
                output.Put("objectId", objectId);
                output.Put("createdAt", createdAt);
                output.Put("updatedAt", updatedAt);
            }
        }
    }
    public class QueryResultObject : _DataTableObject { }
}
