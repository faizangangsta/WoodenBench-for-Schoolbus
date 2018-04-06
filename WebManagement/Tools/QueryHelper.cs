using System;
using System.Collections.Generic;

using cn.bmob.io;

using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Tools
{
    public static class QueryHelper
    {
        public static int BmobQueryData<T>(BmobQuery query, out List<T> Result) where T : BmobTable, new()
        {
            query.Limit(100);
            Result = new List<T>();
            try
            {
                string TableName = new T().table;
                var FindTask = _Bmob.FindTaskAsync<T>(TableName, query);
                FindTask.Wait();
                if (FindTask.IsCompletedSuccessfully)
                {
                    Result = FindTask.Result.results;
                    return Result.Count;
                }
                else return -1;
            }
            catch (Exception ex) { throw new Exception("数据库请求失败", ex); }
        }
    }
}
