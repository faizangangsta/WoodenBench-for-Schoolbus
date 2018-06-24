using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WBPlatform.Database.DBIOCommand;

namespace WBPlatform.Database
{
    public class DataTableObject
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
            output.Put("objectId", objectId);
            if (all)
            {
                output.Put("createdAt", createdAt);
                output.Put("updatedAt", updatedAt);
            }
        }
    }
}
