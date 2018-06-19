//using cn.bmob.api;
//using cn.bmob.io;
//using cn.bmob.tools;

using WBPlatform.Database;

namespace WBPlatform.TableObject
{
    public class _DataTableObject
    {
        public virtual string table => GetType().Name;
        public string objectId { get; set; }
        public string createdAt { get; internal set; }
        public string updatedAt { get; internal set; }

        public virtual void readFields(DBInput input)
        {
            objectId = input.GetString("objectId");
            createdAt = input.GetString("createdAt");
            updatedAt = input.GetString("updatedAt");
        }

        // Token: 0x0600018E RID: 398 RVA: 0x00005844 File Offset: 0x00003A44
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
