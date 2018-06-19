using System;
using System.Collections.Generic;

using WBPlatform.StaticClasses;
using WBPlatform.StaticClasses.Properties;
using WBPlatform.TableObject;
using System.Linq;
using Newtonsoft.Json;

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
    public static class Database
    {
        private static readonly object LOCKER = new object();
        private static string QueryToken = "";
        //private static BmobWindows _Bmob { get; set; } = new BmobWindows();
        public static bool isInitiallised = false;
        public static void InitialiseClient()
        {
            DatabaseSocketsClient.Initialise();
            //Initial Database Authorisation Packet.....
            DatabaseSocketsClient.SendDatabaseOperations("", out string token);
            LogWritter.DebugMessage("Database Connected! Identity: " + token);
        }
        public static DatabaseOperationResult QuerySingleData<T>(DBQuery query, out T Result) where T : _DataTableObject, new()
        {
            query.Limit(1);
            DatabaseOperationResult databaseOperationResult = _DBRequestInternal(new T().table, DataBaseOperation.QuerySingle, query, null, out DBInput[] input, out QueryResultObject result);
            T t = new T();
            t.readFields(input[0]);
            Result = t;
            return databaseOperationResult;
        }
        //{
        //    Result = null;
        //    DatabaseQueryResult ret = QueryMultipleData(query, out List<T> Results, 1);
        //    try
        //    {
        //        if (ret == DatabaseQueryResult.MORE_RESULTS)
        //        {
        //            throw new Exception("Multiple results found in 'QuerySingleData' Function, unexpected data loss.");
        //        }
        //        else if (ret == DatabaseQueryResult.NO_RESULTS)
        //        {
        //            throw new Exception("No results found in 'QuerySingleData' Function, unexpected data loss.");
        //        }
        //        else
        //        {
        //            Result = Results[0];
        //        }
        //        return ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogWritter.ErrorMessage(ex.Message);
        //        return ret;
        //    }
        //}
        public static DatabaseOperationResult QueryMultipleData<T>(DBQuery query, out List<T> Result, int queryLimit = 100, int skip = 0) where T : _DataTableObject, new()
        {
            T t = new T();
            Result = null;
            return _DBRequestInternal(t.table, DataBaseOperation.QueryMulti, query, null, out DBInput[] input, out QueryResultObject @object);
        }
        //{
        //    query.Limit(queryLimit);
        //    query.Skip(skip);
        //    Result = new List<T>();
        //    try
        //    {
        //        string TableName = new T().table;
        //        var FindTask = _Bmob.FindTaskAsync<T>(TableName, query);
        //        FindTask.Wait();
        //        Result = FindTask.Result.results;
        //        switch (Result.Count)
        //        {
        //            case 0: return DatabaseQueryResult.NO_RESULTS;
        //            case 1: return DatabaseQueryResult.ONE_RESULT;
        //            default: return DatabaseQueryResult.MORE_RESULTS;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogWritter.ErrorMessage(ex.Message + "::" + ex.InnerException?.Message);
        //        return DatabaseQueryResult.INTERNAL_ERROR;
        //    }
        //}
        //
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
                DBInternalReply reply = DBInternalReply.GetParsedReply(rcvdData);
            }
            return DatabaseOperationResult.INTERNAL_ERROR;
        }
    }
}
