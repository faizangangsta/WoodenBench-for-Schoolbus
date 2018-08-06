using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


using WBPlatform.Database.Connection;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.Database.Internal;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database
{
    public static class DataBaseOperation
    {
        private static readonly object LOCKER = new object();
        //private static string QueryToken = "";
        public static bool isInitiallised = false;
        public static string MessageId { get { return Cryptography.RandomString(5, false); } }
        public static void InitialiseClient()
        {
            LW.D("Started Initialise Database Server Connection....");
            bool conn = DatabaseSocketsClient.Initialise(IPAddress.Parse(XConfig.Current.Database.DBServerIP), XConfig.Current.Database.DBServerPort);
            while (!conn)
            {
                LW.E("DBServer Initial Connection Failed!");
                conn = DatabaseSocketsClient.Initialise(IPAddress.Parse(XConfig.Current.Database.DBServerIP), XConfig.Current.Database.DBServerPort);
            }
        }
        public static DBQueryStatus QuerySingleData<T>(DBQuery query, out T Result) where T : DataTableObject, new()
        {
            //query.Limit(1);
            //DBQueryStatus databaseOperationResult = _DBRequestInternal(new T().Table, DBVerbs.QuerySingle, query, null, out DBInput[] input);
            //if (databaseOperationResult == DBQueryStatus.ONE_RESULT)
            //{
            //    T t = new T();
            //    t.ReadFields(input[0]);
            //    Result = t;
            //    return databaseOperationResult;
            //}
            //else
            //{
            //    Result = null;
            //    return databaseOperationResult;
            //}
            var _Status = QueryMultipleData(query, out List<T> results, 1);
            Result = _Status > 0 ? results[0] : null;
            return _Status;
        }


        public static DBQueryStatus QueryMultipleData<T>(DBQuery query, out List<T> Result, int queryLimit = 100, int skip = 0) where T : DataTableObject, new()
        {
            query.Limit(queryLimit);
            query.Skip(skip);
            DBQueryStatus databaseOperationResult = _DBRequestInternal(new T().Table, DBVerbs.QueryMulti, query, null, out DataBaseIO[] inputs);
            if (databaseOperationResult >= 0)
            {
                Result = new List<T>();
                foreach (DataBaseIO item in inputs)
                {
                    T t = new T();
                    t.ReadFields(item);
                    Result.Add(t);
                }
            }
            else Result = null;
            return databaseOperationResult;
        }
        public static DBQueryStatus DeleteData(string Table, string ObjectID)
        {
            DBQueryStatus result = _DBRequestInternal(Table, DBVerbs.Delete, new DBQuery().WhereEqualTo("objectId", ObjectID), null, out DataBaseIO[] inputs);
            return result;
        }

        public static DBQueryStatus UpdateData<T>(ref T item) where T : DataTableObject, new() => UpdateData(ref item, null);
        public static DBQueryStatus UpdateData<T>(ref T item, DBQuery query) where T : DataTableObject, new()
        {
            if (query == null)
            {
                query = new DBQuery().WhereEqualTo("objectId", item.ObjectId);
            }
            query.Limit(1);
            DataBaseIO output = new DataBaseIO();
            item.WriteObject(output, false);
            var _result = _DBRequestInternal(item.Table, DBVerbs.Update, query, output, out DataBaseIO[] inputs);
            if (_result != DBQueryStatus.ONE_RESULT)
            {
                LW.E("DBInternalLog: UpdateData Process Failed!");
                return DBQueryStatus.INTERNAL_ERROR;
            }
            item = new T();
            item.ReadFields(inputs[0]);
            return _result;
        }

        public static DBQueryStatus CreateData<T>(ref T data) where T : DataTableObject, new() => CreateData(data, out data);
        private static DBQueryStatus CreateData<T>(T data, out T dataOut) where T : DataTableObject, new()
        {
            DataBaseIO output = new DataBaseIO();
            data.ObjectId = Cryptography.RandomString(10, false);
            data.WriteObject(output, false);
            DBQueryStatus rst = _DBRequestInternal(data.Table, DBVerbs.Create, null, output, out DataBaseIO[] inputs);
            if (rst == DBQueryStatus.INTERNAL_ERROR)
            {
                dataOut = null;
                return rst;
            }
            T t = new T();
            t.ReadFields(inputs[0]);
            dataOut = t;
            return rst;
        }

        private static DBQueryStatus _DBRequestInternal(string Table, DBVerbs operation, DBQuery query, DataBaseIO output, out DataBaseIO[] results)
        {
            try
            {
                if ((operation == DBVerbs.QueryMulti || operation == DBVerbs.QuerySingle || operation == DBVerbs.Update || operation == DBVerbs.Delete) && query == null)
                {
                    throw new ArgumentNullException("When using Query Single/Multi and Change, Delete. Arg: query cannot be null");
                }
                if ((operation == DBVerbs.Create || operation == DBVerbs.Update) && output == null)
                {
                    throw new ArgumentNullException("When using Query Create and Change. Arg: output cannot be null");
                }
                DBInternal internalQuery = new DBInternal { Verb = operation, TableName = Table };
                switch (operation)
                {
                    case DBVerbs.Create:
                        internalQuery.DBObjects = output.MoveToArray();
                        break;
                    case DBVerbs.QuerySingle:
                    case DBVerbs.QueryMulti:
                        internalQuery.Query = query;
                        break;
                    case DBVerbs.Update:
                        internalQuery.DBObjects = output.MoveToArray();
                        internalQuery.Query = query;
                        break;
                    case DBVerbs.Delete:
                        internalQuery.Query = query;
                        break;
                }

                string internalQueryString = internalQuery.ToParsedString();

                string _MessageId = MessageId;
                if (!DatabaseSocketsClient.SendData(internalQueryString, _MessageId, out string rcvdData))
                {
                    results = null;
                    throw new DataBaseException("Database is not connected currently...");
                }

                if (!rcvdData.ToParsedObject(out DBInternal reply)) throw new DataBaseException("DBInternalReply is null");

                // THERE ARE SOME SPECIAL REPLY CODE....
                switch (reply.ResultCode)
                {
                    case DBQueryStatus.INJECTION_DETECTED:
                        throw new DataBaseException("INJECTION DETECTED.", reply.Exception);
                    case DBQueryStatus.INTERNAL_ERROR:
                        throw new DataBaseException("Database Server Internal Error", reply.Exception);
                }

                switch (operation)
                {
                    case DBVerbs.QueryMulti:
                        results = reply.DBObjects;
                        break;
                    case DBVerbs.QuerySingle:
                    case DBVerbs.Create:
                    case DBVerbs.Update:
                        var singleResult = reply.DBObjects;
                        if (singleResult.Length > 1)
                        {
                            throw new DataBaseException("QuerySingle, Create, Change require only one Return result...");
                        }
                        if (operation == DBVerbs.QuerySingle)
                        {
                            //Allow No results....
                            results =
                                singleResult.Length == 0
                                ? new DataBaseIO[0]
                                : singleResult;
                        }
                        else
                        {
                            //DisAllow Empty Results....
                            results =
                                singleResult.Length == 0
                                ? throw new DataBaseException("Create Update functions expect one result...")
                                : singleResult;
                        }
                        break;
                    case DBVerbs.Delete:
                        results = null;
                        break;
                    default: throw new DataBaseException("Database Operation " + operation + " is not Supported!");
                }
                return reply.ResultCode;
            }
            catch (DataBaseException ex)
            {
                results = null;
                LW.E(ex);
                return DBQueryStatus.INTERNAL_ERROR;
            }
        }
    }
}
