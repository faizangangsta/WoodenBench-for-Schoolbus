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
        public static string MessageId { get { return Cryptography.RandomString(5, false); } }
        public static void InitialiseClient(IPAddress server)
        {
            IPAddress _dbServer = server;
            bool conn = DatabaseSocketsClient.Initialise(server);
            if (!conn)
            {
                throw new DataBaseException("数据库连接失败. " + _dbServer.ToString(), DataBaseResult.NOT_CONNECTED);
            }
            else
            {
                DatabaseSocketsClient.SendDatabaseOperations("openConnection", MessageId, out string token);
                LogWritter.DebugMessage("Database Connected! Identity: " + token);
            }
        }
        public static DataBaseResult QuerySingleData<T>(DBQuery query, out T Result) where T : DataTableObject, new()
        {
            query.Limit(1);
            DataBaseResult databaseOperationResult = _DBRequestInternal(new T().table, DatabaseOperation.QuerySingle, query, null, out DBInput[] input, out DatabaseOperationMessage result);
            if (databaseOperationResult == DataBaseResult.ONE_RESULT)
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


        public static DataBaseResult QueryMultipleData<T>(DBQuery query, out List<T> Result, int queryLimit = 100, int skip = 0) where T : DataTableObject, new()
        {
            query.Limit(queryLimit);
            query.Skip(skip);
            DataBaseResult databaseOperationResult = _DBRequestInternal(new T().table, DatabaseOperation.QueryMulti, query, null, out DBInput[] inputs, out DatabaseOperationMessage @object);
            if (databaseOperationResult >= 0)
            {
                Result = new List<T>();
                foreach (DBInput item in inputs)
                {
                    T t = new T();
                    t.readFields(item);
                    Result.Add(t);
                }
            }
            else Result = null;
            return databaseOperationResult;
        }
        public static DataBaseResult DeleteData(string Table, string ObjectID)
        {
            DataBaseResult result = _DBRequestInternal(Table, DatabaseOperation.Delete, new DBQuery().WhereEqualTo("objectId", ObjectID), null, out DBInput[] inputs, out DatabaseOperationMessage resultObject);
            return result;
        }

        public static DataBaseResult UpdateData<T>(T item) where T : DataTableObject, new() => UpdateData(item, null);

        public static DataBaseResult UpdateData<T>(T item, DBQuery query) where T : DataTableObject, new()
        {
            if (query == null)
            {
                query = new DBQuery();
                query.WhereEqualTo("objectId", item.objectId);
            }
            DBOutput output = new DBOutput();
            item.write(output, false);
            return _DBRequestInternal(item.table, DatabaseOperation.Update, query, output, out DBInput[] inputs, out DatabaseOperationMessage message);
        }

        public static DataBaseResult CreateData<T>(T data, out T dataOut) where T : DataTableObject, new()
        {
            DBOutput output = new DBOutput();
            data.objectId = Cryptography.RandomString(10, false);
            data.write(output, false);
            DataBaseResult rst = _DBRequestInternal(data.table, DatabaseOperation.Create, null, output, out DBInput[] inputs, out DatabaseOperationMessage message);
            if (rst == DataBaseResult.INTERNAL_ERROR)
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

        private static DataBaseResult _DBRequestInternal(string Table, DatabaseOperation operation, DBQuery query, DBOutput output, out DBInput[] inputs, out DatabaseOperationMessage message)
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

                DBInternalReply reply;
                string _MessageId = MessageId;
                if (!DatabaseSocketsClient.SendDatabaseOperations(internalQueryString, _MessageId, out string rcvdData))
                {
                    inputs = null;
                    message = null;
                    throw new InvalidOperationException("Database is not connected currently...");
                }
                reply = DBInternalReply.FromJSONString(rcvdData);
                if (reply == null) throw new ArgumentNullException("DBInternalReply", "Database Result null");
                message = reply.Result;
                switch (message.DBResultCode)
                {
                    case DataBaseResult.INJECTION_DETECTED:
                        throw new DataBaseException("INJECTION DETECTED.", DataBaseResult.INJECTION_DETECTED, message.Exception);
                    case DataBaseResult.INTERNAL_ERROR:
                        throw new DataBaseException("Database Server Internal Error", DataBaseResult.INTERNAL_ERROR, message.Exception);
                }
                switch (operation)
                {
                    case DatabaseOperation.QuerySingle:
                    case DatabaseOperation.QueryMulti:
                    case DatabaseOperation.Create:
                    case DatabaseOperation.Update:
                        List<Dictionary<string, object>> objectsResults = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(reply.objectString);
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
                message.DBResultCode = DataBaseResult.INTERNAL_ERROR;
                message.Exception = new DataBaseException("进行数据库操作时出现一个或多个错误", DataBaseResult.INTERNAL_ERROR, ex);
                LogWritter.ErrorMessage(message.ToString());
                return DataBaseResult.INTERNAL_ERROR;
            }
        }
    }
}
