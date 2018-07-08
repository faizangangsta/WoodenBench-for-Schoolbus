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
    public static class DatabaseOperation
    {
        private static readonly object LOCKER = new object();
        //private static string QueryToken = "";
        public static bool isInitiallised = false;
        public static string MessageId { get { return Cryptography.RandomString(5, false); } }
        public static void InitialiseClient(IPAddress server)
        {
            LogWritter.DebugMessage("Started Initialise Database Server Connection....");
            bool conn = DatabaseSocketsClient.Initialise(server);
            if (!conn)
            {
                throw new DataBaseException("数据库连接失败. " + server.ToString(), DBQueryStatus.NOT_CONNECTED);
            }
            else
            {
                DatabaseSocketsClient.SendDatabaseOperations("openConnection", MessageId, out string token);
                LogWritter.DebugMessage("Database Connected! Identity: " + token);
            }
        }
        public static DBQueryStatus QuerySingleData<T>(DBQuery query, out T Result) where T : DataTableObject, new()
        {
            query.Limit(1);
            DBQueryStatus databaseOperationResult = _DBRequestInternal(new T().table, DBOperation.QuerySingle, query, null, out DBInput[] input, out DataBaseStatus result);
            if (databaseOperationResult == DBQueryStatus.ONE_RESULT)
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


        public static DBQueryStatus QueryMultipleData<T>(DBQuery query, out List<T> Result, int queryLimit = 100, int skip = 0) where T : DataTableObject, new()
        {
            query.Limit(queryLimit);
            query.Skip(skip);
            DBQueryStatus databaseOperationResult = _DBRequestInternal(new T().table, DBOperation.QueryMulti, query, null, out DBInput[] inputs, out DataBaseStatus @object);
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
        public static DBQueryStatus DeleteData(string Table, string ObjectID)
        {
            DBQueryStatus result = _DBRequestInternal(Table, DBOperation.Delete, new DBQuery().WhereEqualTo("objectId", ObjectID), null, out DBInput[] inputs, out DataBaseStatus resultObject);
            return result;
        }

        public static DBQueryStatus UpdateData<T>(T item) where T : DataTableObject, new() => UpdateData(item, null);

        public static DBQueryStatus UpdateData<T>(T item, DBQuery query) where T : DataTableObject, new()
        {
            if (query == null)
            {
                query = new DBQuery();
                query.WhereEqualTo("objectId", item.objectId);
            }
            DBOutput output = new DBOutput();
            item.write(output, false);
            return _DBRequestInternal(item.table, DBOperation.Update, query, output, out DBInput[] inputs, out DataBaseStatus message);
        }

        public static DBQueryStatus CreateData<T>(T data, out T dataOut) where T : DataTableObject, new()
        {
            DBOutput output = new DBOutput();
            data.objectId = Cryptography.RandomString(10, false);
            data.write(output, false);
            DBQueryStatus rst = _DBRequestInternal(data.table, DBOperation.Create, null, output, out DBInput[] inputs, out DataBaseStatus message);
            if (rst == DBQueryStatus.INTERNAL_ERROR)
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

        private static DBQueryStatus _DBRequestInternal(string Table, DBOperation operation, DBQuery query, DBOutput output, out DBInput[] inputs, out DataBaseStatus dbStatus)
        {
            try
            {
                if ((operation == DBOperation.QueryMulti || operation == DBOperation.QuerySingle || operation == DBOperation.Update || operation == DBOperation.Delete) && query == null)
                {
                    throw new ArgumentNullException("When using Query Single/Multi and Change, Delete. Arg: query cannot be null");
                }
                if ((operation == DBOperation.Create || operation == DBOperation.Update) && output == null)
                {
                    throw new ArgumentNullException("When using Query Create and Change. Arg: output cannot be null");
                }
                DBInternalRequest internalQuery = new DBInternalRequest();
                internalQuery.operation = operation;
                internalQuery.TableName = Table;
                switch (operation)
                {
                    case DBOperation.Create:
                        internalQuery.objectString = output.ToString();
                        break;
                    case DBOperation.QuerySingle:
                    case DBOperation.QueryMulti:
                        internalQuery.Query = query;
                        break;
                    case DBOperation.Update:
                        internalQuery.objectString = output.ToString();
                        internalQuery.Query = query;
                        break;
                    case DBOperation.Delete:
                        internalQuery.Query = query;
                        break;
                }
                string internalQueryString = internalQuery.ToString();

                DBInternalReply reply;
                string _MessageId = MessageId;
                if (!DatabaseSocketsClient.SendDatabaseOperations(internalQueryString, _MessageId, out string rcvdData))
                {
                    inputs = null;
                    dbStatus = null;
                    throw new InvalidOperationException("Database is not connected currently...");
                }
                reply = DBInternalReply.FromJSONString(rcvdData);
                if (reply == null) throw new ArgumentNullException("DBInternalReply", "Database Result null");
                switch (reply.Result.DBResultCode)
                {
                    case DBQueryStatus.INJECTION_DETECTED:
                        throw new DataBaseException("INJECTION DETECTED.", DBQueryStatus.INJECTION_DETECTED, reply.Result.Exception);
                    case DBQueryStatus.INTERNAL_ERROR:
                        throw new DataBaseException("Database Server Internal Error", DBQueryStatus.INTERNAL_ERROR, reply.Result.Exception);
                }
                switch (operation)
                {
                    case DBOperation.QueryMulti:
                        List<Dictionary<string, object>> multiQueryResults = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(reply.objectString);
                        inputs = (from item in multiQueryResults select new DBInput(item)).ToArray();
                        break;
                    case DBOperation.QuerySingle:
                    case DBOperation.Create:
                    case DBOperation.Update:
                        List<Dictionary<string, object>> singleResult = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(reply.objectString);
                        if (singleResult.Count > 1)
                        {
                            throw new IndexOutOfRangeException("QuerySingle, Create, Change require only one Return result...");
                        }
                        if (operation == DBOperation.QuerySingle)
                        {
                            //Allow No results....
                            inputs = singleResult.Count == 0 ? new DBInput[0] : new DBInput[] { new DBInput(singleResult[0]) };
                        }
                        else
                        {
                            //DisAllow Empty Results....
                            inputs =
                                singleResult.Count == 0
                                ? throw new IndexOutOfRangeException("Create Update functions expect one result...")
                                : new DBInput[] { new DBInput(singleResult[0]) };
                        }
                        break;
                    case DBOperation.Delete:
                        inputs = null;
                        break;
                    default: throw new NotSupportedException("Database Operation " + operation + " is not Supported!");
                }
                dbStatus = reply.Result;
                return reply.Result.DBResultCode;
            }
            catch (Exception ex)
            {
                inputs = null;
                dbStatus = new DataBaseStatus();
                dbStatus.DBResultCode = DBQueryStatus.INTERNAL_ERROR;
                dbStatus.Exception = new DataBaseException("进行数据库操作时出现一个或多个错误", DBQueryStatus.INTERNAL_ERROR, ex);
                LogWritter.ErrorMessage(dbStatus.ToString());
                return DBQueryStatus.INTERNAL_ERROR;
            }
        }
    }
}
