using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Newtonsoft.Json;

using WBPlatform.StaticClasses;
using WBPlatform.TableObject;

namespace WBPlatform.Database.DBServer
{
    public static class DatabaseCore
    {
        private static SqlConnection sqlReadOnlyConnection;
        public static void InitialiseConnection()
        {
            SqlConnectionStringBuilder readOnlyString = new SqlConnectionStringBuilder();
            LogWritter.DebugMessage("Start Initiallising Database Connections.....");
            readOnlyString.Authentication = SqlAuthenticationMethod.SqlPassword;
            readOnlyString.DataSource = "127.0.0.1,1433";
            readOnlyString.UserID = "schoolbus_Database";
            readOnlyString.Password = "EV#WT%GTegqeraagw%#q3%GW%E$E";
            readOnlyString.TrustServerCertificate = true;
            sqlReadOnlyConnection = new SqlConnection(readOnlyString.ConnectionString);
            sqlReadOnlyConnection.Open();
            LogWritter.DebugMessage("DB Connection Opened!");
            SqlCommand command = sqlReadOnlyConnection.CreateCommand();
        }

        public static string ProcessRequest(string requestString)
        {
            DBInternalQuery query = JsonConvert.DeserializeObject<DBInternalQuery>(requestString);
            DBOutput output = null;
            DBQuery dbQuery = null;
            DBInternalReply reply = new DBInternalReply();
            try
            {
                reply.DBOperation = query.operation;
                DataBaseOperation operation = (DataBaseOperation)query.operation;
                if (operation == DataBaseOperation.QueryMulti || operation == DataBaseOperation.QuerySingle || operation == DataBaseOperation.Change || operation == DataBaseOperation.Delete)
                {
                    if (string.IsNullOrEmpty(query.queryString)) throw new ArgumentNullException("When using Query Single/Multi and Change, Delete. Arg: query cannot be null");
                    else dbQuery = JsonConvert.DeserializeObject<DBQuery>(query.queryString);
                }
                if (operation == DataBaseOperation.Create || operation == DataBaseOperation.Change)
                {
                    if (string.IsNullOrEmpty(query.queryObjectString)) throw new ArgumentNullException("When using Query Create and Change. Arg: output cannot be null");
                    else output = JsonConvert.DeserializeObject<DBOutput>(query.queryObjectString);
                }
                switch (operation)
                {
                    case DataBaseOperation.Create:
                        break;
                    case DataBaseOperation.QuerySingle:
                    case DataBaseOperation.QueryMulti:
                        string sqlCommand = "SELECT TOP(" + dbQuery._Limit + ") * FROM " + query.TableName + ((dbQuery.EqualTo.Count > 0 || dbQuery.Contain.Count > 0) ? " WHERE " : "");
                        List<string> queriesStringCollection = new List<string>();
                        if (dbQuery.EqualTo.Count > 0)
                        {
                            queriesStringCollection.Clear();
                            foreach (var item in dbQuery.EqualTo) { queriesStringCollection.Add($"{item.Key} = '{item.Value}'"); }
                        }
                        //output.Put("", "");
                        sqlCommand += string.Join(" AND ", queriesStringCollection);
                        if (dbQuery.Contain.Count > 0)
                        {
                            queriesStringCollection.Clear();
                            foreach (var item in dbQuery.EqualTo) { queriesStringCollection.Add($"{item.Key} LIKE '%{item.Value}%'"); }
                        }
                        SqlDataAdapter sda = new SqlDataAdapter(sqlCommand, sqlReadOnlyConnection);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        sda.Dispose();
                        List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Dictionary<string, object> tmp = new Dictionary<string, object>();
                            for (int i = 0; i < item.ItemArray.Length; i++)
                            {
                                tmp.Add(ds.Tables[0].Columns[i].ColumnName, item.ItemArray[i]);
                            }
                            results.Add(tmp);
                        }
                        reply.resultObjectString = JsonConvert.SerializeObject(results);
                        reply.DBResultCode = results.Count;
                        reply.Message = "操作成功完成(" + results.Count + ")";
                        //reply.resultString = queryResult.ToString();
                        break;
                    case DataBaseOperation.Change:
                        break;
                    case DataBaseOperation.Delete:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                reply.DBResultCode = (int)DatabaseOperationResult.INTERNAL_ERROR;
                reply.Message = ex.Message;
            }
            return reply.ToString();
        }
    }
}
