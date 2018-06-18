using System;
using System.Collections.Generic;

//using cn.bmob.api;
//using cn.bmob.io;
//using cn.bmob.tools;
using WBPlatform.Databases.DataBaseCore;
using WBPlatform.StaticClasses;
using WBPlatform.StaticClasses.Properties;
using WBPlatform.TableObject;
using System.Linq;
using Newtonsoft.Json;

namespace WBPlatform.Databases
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
        //private static BmobWindows _Bmob { get; set; } = new BmobWindows();
        public static bool isInitiallised = false;
        public static void InitialiseClient()
        {
            DatabaseSocketsClient.Initialise();

            //LogWritter.DebugMessage("Database Initialising...");
            //BmobDebug.Register(LogWritter.BmobDebugMsg, BmobDebug.Level.TRACE);
            //_Bmob.initialize(Resources.BmobDatabaseApplicationID, Resources.BmobDatabaseREST);
        }
        public static DatabaseQueryResult QuerySingleData<T>(DataBaseQuery query, out T Result) where T : DataTableObject, new()
        {
            Result = null;
            return DatabaseQueryResult.INTERNAL_ERROR;
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
        public static DatabaseQueryResult QueryMultipleData<T>(DataBaseQuery query, out List<T> Result, int queryLimit = 100, int skip = 0) where T : DataTableObject, new()
        {
            Result = null;
            return DatabaseQueryResult.INTERNAL_ERROR;
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
        public static int DeleteData(string Table, string ObjectID) => 0;
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
        public static int UpdateData<T>(T item) where T : DataTableObject, new() { return 0; }
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
        public static int CreateData<T>(T data, out string objectId) where T : DataTableObject, new() { objectId = ""; return 0; }
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
    }

    public class DataBaseQuery : AutoDictionary<string, string>
    {
        public int DBOperation { get; set; }
        public string Table { get; set; }
        private AutoDictionary<string, object> whereEqualTo { get; set; } = new AutoDictionary<string, object>();
        private AutoDictionary<string, List<object>> whereContains { get; set; } = new AutoDictionary<string, List<object>>();

        public DataBaseQuery() { }

        public DataBaseQuery WhereEqualTo(string column, object value)
        {
            whereEqualTo.Add(column, value);
            return this;
        }
        public DataBaseQuery WhereExistsInArray<T>(string column, params T[] values)
        {
            whereContains.Add(column, new List<object>());
            foreach (T item in values)
            {
                whereContains[column].Add(item);
            }
            return this;
        }
    }
    public class AutoDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get { if (ContainsKey(key)) { return base[key]; } else { return default(TValue); } }
            set { if (ContainsKey(key)) { base[key] = value; } else { Add(key, value); } }
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class DataBaseInput
    {
        public DataBaseInput(IDictionary<string, object> data) { real = data; }
        public string getString(string Key) => GetT<string>(Key);
        public List<T> getList<T>(string Key) => GetT<List<T>>(Key);
        public bool getBoolean(string Key) => GetT<bool>(Key);
        public int getInt(string Key) => GetT<int>(Key);
        private T GetT<T>(string Key)
        {
            if (real.ContainsKey(Key)) return (T)real[Key];
            else throw new KeyNotFoundException("真的没有这个键..." + Key);
        }
        public IDictionary<string, object> real;
    }

    public class DataBaseOutput
    {
        public void Put(string column, object data)
        {
            if (real.ContainsKey(column))
            {
                real.Remove(column);
                real.Add(column, data);
            }
            else
            {
                real.Add(column, data);
            }
        }
        public IDictionary<string, object> GetData() => real;
        public IDictionary<string, object> real;
    }

    public class DataTableObject
    {
        public virtual string table => GetType().Name;
        public string objectId { get; set; }
        public string createdAt { get; internal set; }
        public string updatedAt { get; internal set; }

        public virtual void readFields(DataBaseInput input)
        {
            objectId = input.getString("objectId");
            createdAt = input.getString("createdAt");
            updatedAt = input.getString("updatedAt");
        }

        // Token: 0x0600018E RID: 398 RVA: 0x00005844 File Offset: 0x00003A44
        public virtual void write(DataBaseOutput output, bool all)
        {
            if (all)
            {
                output.Put("objectId", this.objectId);
                output.Put("createdAt", this.createdAt);
                output.Put("updatedAt", this.updatedAt);
            }
        }
    }
}
