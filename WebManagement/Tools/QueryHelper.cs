using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBServicePlatform.TableObject;
using static WBServicePlatform.WebManagement.Program;

namespace WBServicePlatform.WebManagement.Tools
{
    public static class QueryHelper
    {
        public static int BmobQueryData<T>(BmobQuery query, out List<T> Result) where T : BmobTable, new()
        {
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
            catch (Exception) { return -1; }
        }
    }
}
