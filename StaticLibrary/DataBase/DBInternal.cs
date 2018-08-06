using System;
using System.Collections;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.Internal
{
    public class DBInternal
    {
        public DBVerbs Verb { get; set; }
        public DBQueryStatus ResultCode { get; set; }

        public string TableName { get; set; } = "";
        public DBQuery Query { get; set; } 
        public DataBaseIO[] DBObjects { get; set; } 

        public string Message { get; set; } = "";
        public DataBaseException Exception { get; set; }
    }
    public class DataBaseException : Exception
    {
        public DataBaseException() : base() { }
        public DataBaseException(string message) : base(message) { }
        public DataBaseException(string message, Exception inner) : base(message, inner) { }
    }
}
