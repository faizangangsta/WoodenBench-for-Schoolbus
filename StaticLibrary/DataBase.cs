using System;
using System.Collections.Generic;

using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.tools;

using WBServicePlatform.StaticClasses;
using WBServicePlatform.StaticClasses.Properties;
using WBServicePlatform.TableObject;

namespace WBServicePlatform.Databases
{
    public static class Database
    {
        private static BmobWindows _Bmob { get; set; } = new BmobWindows();
        public static void Initialise()
        {
            BmobDebug.Register(LogWritter.BmobDebugMsg, BmobDebug.Level.TRACE);
            _Bmob.initialize(Resources.BmobDatabaseApplicationID, Resources.BmobDatabaseREST);
        }

        public static int QueryData<T>(DatabaseQuery query, out List<T> Result) where T : BmobTable, new()
        {
            query.Limit(100);
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
            catch (Exception ex) { throw new Exception("数据库请求失败", ex); }
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
                return -1;
                throw ex;
            }
        }

        public static int UpdateData<T>(T item) where T : DataTable
        {
            try
            {
                _Bmob.UpdateTaskAsync(item).Wait();
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
        public static int CreateData<T>(T data) where T : DataTable
        {
            try
            {
                _Bmob.CreateTaskAsync(data).Wait();
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
                throw ex;
            }
        }
    }

    public class DatabaseQuery : BmobQuery
    {
        public new DatabaseQuery WhereEqualTo(string column, object value) => (DatabaseQuery)base.WhereEqualTo(column, value);
        public new DatabaseQuery WhereContainedIn<T>(string column, params T[] values) => (DatabaseQuery)base.WhereContainedIn<T>(column, values);
    }
}

namespace WBServicePlatform.TableObject
{
    public class DataTable : BmobTable { }
}
