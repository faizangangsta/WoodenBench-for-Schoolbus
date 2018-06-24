using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Newtonsoft.Json;

using WBPlatform.Database.Connection;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.Database.Internal;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database
{
    public static class DBOperations
    {
        private static readonly object LOCKER = new object();
        //private static string QueryToken = "";
        public static bool isInitiallised = false;
        public static void InitialiseClient(IPAddress server)
        {
#if DEBUG
            IPAddress _dbServer = IPAddress.Loopback;
            bool conn = DatabaseSocketsClient.Initialise(IPAddress.Loopback);
#else
            IPAddress _dbServer = server;
            bool conn = DatabaseSocketsClient.Initialise(server);
#endif
            if (!conn)
            {
                throw new DataBaseException("数据库连接失败. " + _dbServer.ToString(), DatabaseResult.NOT_CONNECTED);
            }
            else
            {
                DatabaseSocketsClient.SendDatabaseOperations("", out string token);
                LogWritter.DebugMessage("Database Connected! Identity: " + token);
            }
        }
        public static DatabaseResult QuerySingleData<T>(DBQuery query, out T Result) where T : DataTableObject, new()
        {
            query.Limit(1);
            DatabaseResult databaseOperationResult = _DBRequestInternal(new T().table, DatabaseOperation.QuerySingle, query, null, out DBInput[] input, out DatabaseOperationMessage result);
            if (databaseOperationResult == DatabaseResult.ONE_RESULT)
            {
                T t = new T();
                t.readFields(input[0]);
                Result = t;
                return databaseOperationResult;
            }
            else
            {
                Result = null;
                return databaseOperationResult;
            }
        }


        public static DatabaseResult QueryMultipleData<T>(DBQuery query, out List<T> Result, int queryLimit = 100, int skip = 0) where T : DataTableObject, new()
        {
            query.Limit(queryLimit);
            query.Skip(skip);
            DatabaseResult databaseOperationResult = _DBRequestInternal(new T().table, DatabaseOperation.QueryMulti, query, null, out DBInput[] inputs, out DatabaseOperationMessage @object);
            if (databaseOperationResult >= 0)
            {
                List<T> _results = new List<T>((int)databaseOperationResult);
                foreach (DBInput item in inputs)
                {
                    T t = new T();
                    t.readFields(item);
                    _results.Add(t);
                }
                Result = _results;
            }
            else Result = null;
            return databaseOperationResult;
        }
        public static DatabaseResult DeleteData(string Table, string ObjectID)
        {
            DatabaseResult result = _DBRequestInternal(Table, DatabaseOperation.Delete, new DBQuery().WhereEqualTo("objectId", ObjectID), null, out DBInput[] inputs, out DatabaseOperationMessage resultObject);
            return result;
        }

        public static DatabaseResult UpdateData<T>(T item) where T : DataTableObject, new()
        {
            DBQuery query = new DBQuery();
            query.WhereEqualTo("objectId", item.objectId);
            DBOutput output = new DBOutput();
            item.write(output, false);
            return _DBRequestInternal(item.table, DatabaseOperation.Update, query, output, out DBInput[] inputs, out DatabaseOperationMessage message);
        }
        
        public static DatabaseResult CreateData<T>(T data, out T dataOut) where T : DataTableObject, new()
        {
            DBOutput output = new DBOutput();
            data.objectId = Cryptography.RandomString(10, false);
            data.write(output, false);
            DatabaseResult rst = _DBRequestInternal(data.table, DatabaseOperation.Create, null, output, out DBInput[] inputs, out DatabaseOperationMessage message);
            if (rst == DatabaseResult.INTERNAL_ERROR)
            {
                dataOut = null;
                LogWritter.ErrorMessage(message.ToString());
                return rst;
            }
            T t = new T();
            t.readFields(inputs[0]);
            dataOut = t;
            return rst;
        }

        private static DatabaseResult _DBRequestInternal(string Table, DatabaseOperation operation, DBQuery query, DBOutput output, out DBInput[] inputs, out DatabaseOperationMessage message)
        {
            try
            {
                if ((operation == DatabaseOperation.QueryMulti || operation == DatabaseOperation.QuerySingle || operation == DatabaseOperation.Update || operation == DatabaseOperation.Delete) && query == null)
                {
                    throw new ArgumentNullException("When using Query Single/Multi and Change, Delete. Arg: query cannot be null");
                }
                if ((operation == DatabaseOperation.Create || operation == DatabaseOperation.Update) && output == null)
                {
                    throw new ArgumentNullException("When using Query Create and Change. Arg: output cannot be null");
                }
                DBInternalRequest internalQuery = new DBInternalRequest();
                internalQuery.operation = operation;
                internalQuery.TableName = Table;
                switch (operation)
                {
                    case DatabaseOperation.Create:
                        internalQuery.objectString = output.ToString();
                        break;
                    case DatabaseOperation.QuerySingle:
                    case DatabaseOperation.QueryMulti:
                        internalQuery.Query = query;
                        break;
                    case DatabaseOperation.Update:
                        internalQuery.objectString = output.ToString();
                        internalQuery.Query = query;
                        break;
                    case DatabaseOperation.Delete:
                        internalQuery.Query = query;
                        break;
                }
                string internalQueryString = internalQuery.ToString();
                //...................ATOM.OPERATION.....................
                DBInternalReply reply;
                //lock (LOCKER)
                {
                    if (!DatabaseSocketsClient.SendDatabaseOperations(internalQueryString, out string rcvdData))
                    {
                        inputs = null;
                        message = null;
                        throw new InvalidOperationException("Database is not connected currently...");
                    }
                    reply = DBInternalReply.FromJSONString(rcvdData);
                }
                if (reply == null) throw new ArgumentNullException("DBInternalReply", "Database Result null");
                message = reply.Result;
                switch (message.DBResultCode)
                {
                    case DatabaseResult.INJECTION_DETECTED:
                        throw new DataBaseException("INJECTION DETECTED.", DatabaseResult.INJECTION_DETECTED, message.Exception);
                    case DatabaseResult.INTERNAL_ERROR:
                        throw new DataBaseException("Database Server Internal Error", DatabaseResult.INTERNAL_ERROR, message.Exception);
                }
                switch (operation)
                {
                    case DatabaseOperation.QuerySingle:
                    case DatabaseOperation.QueryMulti:
                    case DatabaseOperation.Create:
                    case DatabaseOperation.Update:
                        List<Dictionary<string, object>> objectsResults = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(reply.objectString);
                        //if (objectsResults.Count != (int)reply.Result.DBResultCode) throw new IndexOutOfRangeException("Database Result doesn't match with parsed object.");
                        if ((int)operation != 2 && (int)operation != 4)
                        {
                            if (objectsResults.Count > 1)
                            {
                                throw new IndexOutOfRangeException("QuerySingle, Create, Change require only one Return result...");
                            }
                            inputs = new DBInput[] { new DBInput(objectsResults[0]) };
                        }
                        else inputs = (from item in objectsResults select new DBInput(item)).ToArray();
                        break;
                    case DatabaseOperation.Delete:
                        inputs = null;
                        break;
                    default: throw new NotSupportedException("Database Operation " + operation + " is not Supported!");
                }
                return reply.Result.DBResultCode;
            }
            catch (Exception ex)
            {
                inputs = null;
                message = new DatabaseOperationMessage();
                message.DBResultCode = DatabaseResult.INTERNAL_ERROR;
                message.Exception = new DataBaseException("进行数据库操作时出现一个或多个错误", DatabaseResult.INTERNAL_ERROR, ex);
                return DatabaseResult.INTERNAL_ERROR;
            }
        }
    }
}
