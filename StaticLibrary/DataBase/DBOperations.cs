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
    public static class DataBaseOperation
    {
        private static readonly object LOCKER = new object();
        //private static string QueryToken = "";
        public static bool isInitiallised = false;
        public static string MessageId { get { return Cryptography.RandomString(5, false); } }
        public static void InitialiseClient(IPAddress server)
        {
            LW.D("Started Initialise Database Server Connection....");
            bool conn = DatabaseSocketsClient.Initialise(server);
            while (!conn)
            {
                LW.E("DBServer Initial Connection Failed!");
                conn = DatabaseSocketsClient.Initialise(server);
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
            DBQueryStatus databaseOperationResult = _DBRequestInternal(new T().Table, DBVerbs.QueryMulti, query, null, out DBInput[] inputs);
            if (databaseOperationResult >= 0)
            {
                Result = new List<T>();
                foreach (DBInput item in inputs)
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
            DBQueryStatus result = _DBRequestInternal(Table, DBVerbs.Delete, new DBQuery().WhereEqualTo("objectId", ObjectID), null, out DBInput[] inputs);
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
            DBOutput output = new DBOutput();
            item.WriteObject(output, false);
            var _result = _DBRequestInternal(item.Table, DBVerbs.Update, query, output, out DBInput[] inputs);
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
            DBOutput output = new DBOutput();
            data.ObjectId = Cryptography.RandomString(10, false);
            data.WriteObject(output, false);
            DBQueryStatus rst = _DBRequestInternal(data.Table, DBVerbs.Create, null, output, out DBInput[] inputs);
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

        private static DBQueryStatus _DBRequestInternal(string Table, DBVerbs operation, DBQuery query, DBOutput output, out DBInput[] inputs)
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
                DBInternalRequest internalQuery = new DBInternalRequest { Operation = operation, TableName = Table };
                switch (operation)
                {
                    case DBVerbs.Create:
                        internalQuery.ObjectString = output.ToString();
                        break;
                    case DBVerbs.QuerySingle:
                    case DBVerbs.QueryMulti:
                        internalQuery.Query = query;
                        break;
                    case DBVerbs.Update:
                        internalQuery.ObjectString = output.ToString();
                        internalQuery.Query = query;
                        break;
                    case DBVerbs.Delete:
                        internalQuery.Query = query;
                        break;
                }

                string internalQueryString = internalQuery.ToString();

                string _MessageId = MessageId;
                if (!DatabaseSocketsClient.SendData(internalQueryString, _MessageId, out string rcvdData))
                {
                    inputs = null;
                    throw new DataBaseException("Database is not connected currently...");
                }

                DBInternalReply reply = DBInternalReply.FromJSONString(rcvdData);
                if (reply == null) throw new DataBaseException("DBInternalReply is null");

                // THERE ARE SOME SPECIAL REPLY CODE....
                switch (reply.DBResultCode)
                {
                    case DBQueryStatus.INJECTION_DETECTED:
                        throw new DataBaseException("INJECTION DETECTED.", reply.Exception);
                    case DBQueryStatus.INTERNAL_ERROR:
                        throw new DataBaseException("Database Server Internal Error", reply.Exception);
                }

                switch (operation)
                {
                    case DBVerbs.QueryMulti:
                        List<Dictionary<string, object>> multiQueryResults = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(reply.ObjectString);
                        inputs = (from item in multiQueryResults select new DBInput(item)).ToArray();
                        break;
                    case DBVerbs.QuerySingle:
                    case DBVerbs.Create:
                    case DBVerbs.Update:
                        List<Dictionary<string, object>> singleResult = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(reply.ObjectString);
                        if (singleResult.Count > 1)
                        {
                            throw new DataBaseException("QuerySingle, Create, Change require only one Return result...");
                        }
                        if (operation == DBVerbs.QuerySingle)
                        {
                            //Allow No results....
                            inputs =
                                singleResult.Count == 0
                                ? new DBInput[0]
                                : new DBInput[] { new DBInput(singleResult[0]) };
                        }
                        else
                        {
                            //DisAllow Empty Results....
                            inputs =
                                singleResult.Count == 0
                                ? throw new DataBaseException("Create Update functions expect one result...")
                                : new DBInput[] { new DBInput(singleResult[0]) };
                        }
                        break;
                    case DBVerbs.Delete:
                        inputs = null;
                        break;
                    default: throw new DataBaseException("Database Operation " + operation + " is not Supported!");
                }
                return reply.DBResultCode;
            }
            catch (DataBaseException ex)
            {
                inputs = null;
                LW.E(ex);
                return DBQueryStatus.INTERNAL_ERROR;
            }
        }
    }
}
