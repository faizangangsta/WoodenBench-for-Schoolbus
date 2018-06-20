using System;
using System.Collections.Generic;

using WBPlatform.StaticClasses;
using WBPlatform.StaticClasses.Properties;
using WBPlatform.TableObject;
using System.Linq;
using Newtonsoft.Json;
using System.Net;

namespace WBPlatform.Database
{
    public enum DataBaseOperation
    {
        Create = 0,
        QuerySingle = 1,
        QueryMulti = 2,
        Change = 3,
        Delete = 4
    }
    public static class DBOperations
    {
        private static readonly object LOCKER = new object();
        private static string QueryToken = "";
        //private static BmobWindows _Bmob { get; set; } = new BmobWindows();
        public static bool isInitiallised = false;
        public static void InitialiseClient(IPAddress server)
        {
            DatabaseSocketsClient.Initialise(server);
            DatabaseSocketsClient.SendDatabaseOperations("", out string token);
            LogWritter.DebugMessage("Database Connected! Identity: " + token);
        }
        public static DatabaseOperationResult QuerySingleData<T>(DBQuery query, out T Result) where T : _DataTableObject, new()
        {
            query.Limit(1);
            DatabaseOperationResult databaseOperationResult = _DBRequestInternal(new T().table, DataBaseOperation.QuerySingle, query, null, out DBInput[] input, out QueryResultObject result);
            if (databaseOperationResult == DatabaseOperationResult.ONE_RESULT)
            {
                T t = new T();
                t.readFields(input[0]);
                Result = t;
                return databaseOperationResult;
            }
            else
            {
                throw new Exception("数据库返回无效内容, " + databaseOperationResult.ToString());
            }
        }
        public static DatabaseOperationResult QueryMultipleData<T>(DBQuery query, out List<T> Result, int queryLimit = 100, int skip = 0) where T : _DataTableObject, new()
        {
            query.Limit(queryLimit);
            query.Skip(skip);
            DatabaseOperationResult databaseOperationResult = _DBRequestInternal(new T().table, DataBaseOperation.QueryMulti, query, null, out DBInput[] inputs, out QueryResultObject @object);
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
        public static DatabaseOperationResult DeleteData(string Table, string ObjectID) => 0;
        //{
        //    try
        //    {
        //        var p = _Bmob.DeleteTaskAsync(Table, ObjectID);
        //        p.Wait();
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogWritter.ErrorMessage(ex.Message + "::" + ex.InnerException?.Message);
        //        return -1;
        //    }
        //}
        //
        public static DatabaseOperationResult UpdateData<T>(T item) where T : _DataTableObject, new() { return 0; }
        //{
        //    try
        //    {
        //        _Bmob.UpdateTaskAsync(item).Wait();
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogWritter.ErrorMessage(ex.Message + "::" + ex.InnerException?.Message);
        //        return -1;
        //    }
        //}
        public static DatabaseOperationResult CreateData<T>(T data, out string objectId) where T : _DataTableObject, new() { objectId = ""; return 0; }
        //{
        //    objectId = "";
        //    try
        //    {
        //        var wait = _Bmob.CreateTaskAsync(data);
        //        wait.Wait();
        //        objectId = wait.Result.objectId;
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogWritter.ErrorMessage(ex.Message + "::" + ex.InnerException?.Message);
        //        return -1;
        //    }
        //}

        private static DatabaseOperationResult _DBRequestInternal(string Table, DataBaseOperation operation, DBQuery query, DBOutput output, out DBInput[] inputs, out QueryResultObject result)
        {
            if ((operation == DataBaseOperation.QueryMulti || operation == DataBaseOperation.QuerySingle || operation == DataBaseOperation.Change || operation == DataBaseOperation.Delete) && query == null)
            {
                throw new ArgumentNullException("When using Query Single/Multi and Change, Delete. Arg: query cannot be null");
            }
            if ((operation == DataBaseOperation.Create || operation == DataBaseOperation.Change) && output == null)
            {
                throw new ArgumentNullException("When using Query Create and Change. Arg: output cannot be null");
            }
            DBInternalQuery internalQuery = new DBInternalQuery();
            internalQuery.operation = (int)operation;
            internalQuery.TableName = Table;
            switch (operation)
            {
                case DataBaseOperation.Create:
                    internalQuery.queryObjectString = output.ToString();
                    break;
                case DataBaseOperation.QuerySingle:
                case DataBaseOperation.QueryMulti:
                    internalQuery.queryString = query.ToString();
                    break;
                case DataBaseOperation.Change:
                    internalQuery.queryObjectString = output.ToString();
                    internalQuery.queryString = query.ToString();
                    break;
                case DataBaseOperation.Delete:
                    internalQuery.queryString = query.ToString();
                    break;
            }
            string internalQueryString = internalQuery.ToString();
            //...................ATOM.OPERATION.....................
            lock (LOCKER)
            {
                inputs = null;
                result = null;
                if (!DatabaseSocketsClient.SendDatabaseOperations(internalQueryString, out string rcvdData))
                {
                    inputs = null;
                    result = null;
                    return DatabaseOperationResult.NOT_CONNECTED;
                }
                DBInternalReply reply = DBInternalReply.FromJSONString(rcvdData);
                List<Dictionary<string, object>> DBQueryResultsCollection = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(reply.resultObjectString);

                if (DBQueryResultsCollection.Count != reply.DBResultCode)
                {
                    throw new IndexOutOfRangeException("Database Result doesn't match with parsed object.");
                }
                else
                {
                    List<DBInput> inputsRAW = new List<DBInput>(reply.DBResultCode);
                    foreach (var item in DBQueryResultsCollection)
                    {
                        inputsRAW.Add(new DBInput(item));
                    }
                    inputs = inputsRAW.ToArray();
                    return (DatabaseOperationResult)reply.DBResultCode;
                }
            }
        }
    }
}
