using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;

using System;
using System.Collections.Generic;

using WBPlatform.StaticClasses;
using WBPlatform.StaticClasses.Properties;
using WBPlatform.TableObject;

namespace WBPlatform.Databases
{
    public static class Database
    {
        private static BmobWindows _Bmob { get; set; } = new BmobWindows();
        public static void Initialise()
        {
            BmobDebug.Register(LogWritter.BmobDebugMsg, BmobDebug.Level.TRACE);
            _Bmob.initialize(Resources.BmobDatabaseApplicationID, Resources.BmobDatabaseREST);
        }
        public static int QuerySingleData<T>(DatabaseQuery query, out T Result) where T : DataTable, new()
        {
            Result = null;
            try
            {
                int ret = QueryMultipleData(query, out List<T> Results, 1);
                if (ret > 1)
                {
                    throw new Exception("Multiple results found in 'QuerySingleData' Function, unexpected data loss.");
                }
                else if (ret == 0)
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
                return 2;
            }
        }
        public static int QueryMultipleData<T>(DatabaseQuery query, out List<T> Result, int queryLimit = 100) where T : DataTable, new()
        {
            query.Limit(queryLimit);
            Result = new List<T>();
            try
            {
                string TableName = new T().table;
                var FindTask = _Bmob.FindTaskAsync<T>(TableName, query);
                FindTask.Wait();
                if (FindTask.IsCompleted)
                {
                    Result = FindTask.Result.results;
                    return Result.Count;
                }
                else return -1;
            }
            catch (Exception ex)
            {
                LogWritter.ErrorMessage(ex.Message + "::" + ex.InnerException?.Message);
                return -1;
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
        public static int CreateData<T>(T data) where T : DataTable, new()
        {
            try
            {
                _Bmob.CreateTaskAsync(data).Wait();
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
        public new DatabaseQuery WhereContainedIn<T>(string column, params T[] values) => (DatabaseQuery)base.WhereContainedIn<T>(column, values);
    }
}

namespace WBPlatform.TableObject
{
    public class DataTable : BmobTable { }
}
