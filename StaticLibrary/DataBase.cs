using System;
using System.Collections.Generic;

using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;

using WBPlatform.StaticClasses;
using WBPlatform.StaticClasses.Properties;
using WBPlatform.TableObject;

namespace WBPlatform.Databases
{
    public static class Database
    {
        private static BmobWindows _Bmob { get; set; } = new BmobWindows();
        public static bool isInitiallised = false;
        public static void Initialise()
        {
            LogWritter.DebugMessage("Database Initialising...");
            BmobDebug.Register(LogWritter.BmobDebugMsg, BmobDebug.Level.TRACE);
            _Bmob.initialize(Resources.BmobDatabaseApplicationID, Resources.BmobDatabaseREST);
        }
        public static DatabaseQueryResult QuerySingleData<T>(DatabaseQuery query, out T Result) where T : DataTable, new()
        {
            Result = null;
            DatabaseQueryResult ret = QueryMultipleData(query, out List<T> Results, 1);
            try
            {
                if (ret == DatabaseQueryResult.MORE_RESULTS)
                {
                    throw new Exception("Multiple results found in 'QuerySingleData' Function, unexpected data loss.");
                }
                else if (ret == DatabaseQueryResult.NO_RESULTS)
                {
                    throw new Exception("No results found in 'QuerySingleData' Function, unexpected data loss.");
                }
                else
                {
                    Result = Results[0];
                }
                return ret;
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage(ex.Message);
                return ret;
            }
        }
        public static DatabaseQueryResult QueryMultipleData<T>(DatabaseQuery query, out List<T> Result, int queryLimit = 100, int skip = 0) where T : DataTable, new()
        {
            query.Limit(queryLimit);
            query.Skip(skip);
            Result = new List<T>();
            try
            {
                string TableName = new T().table;
                var FindTask = _Bmob.FindTaskAsync<T>(TableName, query);
                FindTask.Wait();
                if (FindTask.IsCompleted)
                {
                    Result = FindTask.Result.results;
                    switch (Result.Count)
                    {
                        case 0: return DatabaseQueryResult.NO_RESULTS;
                        case 1: return DatabaseQueryResult.ONE_RESULT;
                        default: return DatabaseQueryResult.MORE_RESULTS;
                    };
                }
                else return DatabaseQueryResult.INTERNAL_ERROR;
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage(ex.Message + "::" + ex.InnerException?.Message);
                return DatabaseQueryResult.INTERNAL_ERROR;
            }
        }

        public static int DeleteData(string Table, string ObjectID)
        {
            try
            {
                var p = _Bmob.DeleteTaskAsync(Table, ObjectID);
                p.Wait();
                return 0;
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage(ex.Message + "::" + ex.InnerException?.Message);
                return -1;
            }
        }

        public static int UpdateData<T>(T item) where T : DataTable, new()
        {
            try
            {
                _Bmob.UpdateTaskAsync(item).Wait();
                return 0;
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage(ex.Message + "::" + ex.InnerException?.Message);
                return -1;
            }
        }
        public static int CreateData<T>(T data, out string objectId) where T : DataTable, new()
        {
            objectId = "";
            try
            {
                var wait = _Bmob.CreateTaskAsync(data);
                wait.Wait();
                objectId = wait.Result.objectId;
                return 0;
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage(ex.Message + "::" + ex.InnerException?.Message);
                return -1;
            }
        }
    }

    public class DatabaseQuery : BmobQuery
    {
        public new DatabaseQuery WhereEqualTo(string column, object value) => (DatabaseQuery)base.WhereEqualTo(column, value);
        public new DatabaseQuery WhereContainedIn<T>(string column, params T[] values) => (DatabaseQuery)base.WhereContainedIn(column, values);
        public new DatabaseQuery WhereContainsAll<T>(string column, params T[] values) => (DatabaseQuery)base.WhereContainsAll(column, values);
    }
}

namespace WBPlatform.TableObject
{
    public class DataTable : BmobTable
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
