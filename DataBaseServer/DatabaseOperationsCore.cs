using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Util;
using Newtonsoft.Json;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.Database.Internal;
using WBPlatform.StaticClasses;
using System.Configuration;
using WBPlatform.TableObject;
using System.Web;
using System.Collections;

namespace WBPlatform.Database.DBServer
{
    public static class DatabaseCore
    {
        private static SqlConnection sqlReadOnlyConnection;
        public static void InitialiseDBConnection()
        {
            SqlConnectionStringBuilder readOnlyConnectionString = new SqlConnectionStringBuilder();
            LogWritter.DebugMessage("Start Initiallising Database Connections.....");
            readOnlyConnectionString.Authentication = SqlAuthenticationMethod.SqlPassword;
            readOnlyConnectionString.DataSource = "127.0.0.1,1433";
            readOnlyConnectionString.UserID = "schoolbus_Database";
            readOnlyConnectionString.Password = "EV#WT%GTegqeraagw%#q3%GW%E$E";
            readOnlyConnectionString.TrustServerCertificate = true;
            LogWritter.DebugMessage("DB Connection String Loaded!");
            sqlReadOnlyConnection = new SqlConnection(readOnlyConnectionString.ConnectionString);
            sqlReadOnlyConnection.Open();
            LogWritter.DebugMessage("DB Connection Opened!");
        }

        public static string ProcessRequest(string requestString)
        {
            DBOutput output = null;
            DBQuery dbQuery = null;
            DBInternalReply reply = new DBInternalReply();
            try
            {
                DBInternalRequest request = DBInternalRequest.FromJSONString(requestString);
                if (request == null)
                {
                    throw new NullReferenceException("JSON Parsing Error, check request...");
                }
                reply.Result.DBOperation = request.operation;
                DatabaseOperation operation = request.operation = reply.Result.DBOperation;
                if (operation == DatabaseOperation.QueryMulti || operation == DatabaseOperation.QuerySingle || operation == DatabaseOperation.Update || operation == DatabaseOperation.Delete)
                {
                    if (request.Query == null) throw new ArgumentNullException("When using Query Single/Multi/Change/Delete. Arg: query cannot be null");
                    else dbQuery = request.Query;
                }
                if (operation == DatabaseOperation.Create || operation == DatabaseOperation.Update)
                {
                    if (string.IsNullOrEmpty(request.objectString)) throw new ArgumentNullException("When using Query Create and Change. Arg: output cannot be null");
                    else output = new DBOutput(request.objectString);
                }
                switch (operation)
                {
                    case DatabaseOperation.Create:
                        string sqlCommand_Create = $"INSERT INTO {request.TableName} ({string.Join(",", output.GetData().Keys)}, createdAt, updatedAt) VALUES ('{string.Join("','", (from val in output.GetData().Values select (EncodeString(val))).ToArray())}', '{DateTime.Now}', '{DateTime.Now}')";
                        SqlCommand command_Create = new SqlCommand(sqlCommand_Create, sqlReadOnlyConnection);
                        int rowModified_Create = command_Create.ExecuteNonQuery();
                        reply.Result.DBResultCode = (DataBaseResult)rowModified_Create;
                        reply.Result.Message = "操作成功完成(" + rowModified_Create + ")";

                        reply.objectString = JsonConvert.SerializeObject(SQLQueryCommand($"SELECT TOP(1) * FROM {request.TableName} WHERE objectId = '{output.GetData()["objectId"]}' "));
                        break;

                    case DatabaseOperation.QuerySingle:
                    case DatabaseOperation.QueryMulti:
                        string sqlCommand_Query = "SELECT TOP(" + dbQuery._Limit + ") * FROM " + request.TableName + ((dbQuery.EqualTo.Count > 0 || dbQuery.ContainedInArray.Count > 0) ? " WHERE " : "");

                        if (dbQuery.EqualTo.Count > 0)
                        {
                            string[] queriesStringCollection = (from q in dbQuery.EqualTo select $"{q.Key} = '{EncodeString(q.Value.ToString())}'").ToArray();
                            sqlCommand_Query += string.Join(" AND ", queriesStringCollection);
                            sqlCommand_Query += (dbQuery.ContainedInArray.Count > 0 || dbQuery.Contains.Count > 0) ? " AND " : string.Empty;
                        }

                        if (dbQuery.ContainedInArray.Count > 0)
                        {
                            //string[] queriesStringCollection = from q in dbQuery.ContainedInArray select $"WHERE {q.Key} LIKE ''";
                            sqlCommand_Query += (dbQuery.Contains.Count > 0) ? " AND " : string.Empty;
                        }

                        if (dbQuery.Contains.Count > 0)
                        {
                            string[] queriesStringCollection = (from q in dbQuery.Contains select $"{q.Key} LIKE '%{EncodeString(q.Value)}%'").ToArray();
                            sqlCommand_Query += string.Join(" AND ", queriesStringCollection);
                        }


                        List<Dictionary<string, object>> results = SQLQueryCommand(sqlCommand_Query);
                        reply.objectString = JsonConvert.SerializeObject(results);
                        reply.Result.DBResultCode = results.Count >= 2 ? DataBaseResult.MORE_RESULTS : (DataBaseResult)results.Count;
                        reply.Result.Message = "操作成功完成(" + results.Count + ")";
                        break;
                    case DatabaseOperation.Update:
                        string sqlCommand_Update = $"UPDATE {request.TableName} SET {string.Join(",", (from q in output.GetData() select ($"{q.Key} = '{EncodeString(q.Value)}' ")).ToArray())}, updatedAt = '{DateTime.Now}' WHERE objectId = '{dbQuery.EqualTo["objectId"]}'";

                        SqlCommand command_Update = new SqlCommand(sqlCommand_Update, sqlReadOnlyConnection);
                        int rowModified_Update = command_Update.ExecuteNonQuery();
                        reply.Result.DBResultCode = (DataBaseResult)rowModified_Update;
                        reply.Result.Message = "操作成功完成(" + rowModified_Update + ")";

                        reply.objectString = JsonConvert.SerializeObject(SQLQueryCommand($"SELECT TOP(1) * FROM {request.TableName} WHERE objectId = '{output.GetData()["objectId"]}' "));
                        break;
                    case DatabaseOperation.Delete:
                        string sqlCommand_Del = $"DELETE FROM {request.TableName} WHERE objectId = '{dbQuery.EqualTo["objectId"]}'";
                        SqlCommand command = new SqlCommand(sqlCommand_Del, sqlReadOnlyConnection);
                        int rowModified = command.ExecuteNonQuery();
                        reply.Result.DBResultCode = (DataBaseResult)rowModified;
                        reply.Result.Message = "操作成功完成(" + rowModified + ")";
                        break;
                    default:
                        HttpUtility.UrlEncode("!@#$%^&*()_+");
                        break;
                }
            }
            catch (Exception ex)
            {
                reply.Result.DBResultCode = DataBaseResult.INTERNAL_ERROR;
                reply.Result.Message = ex.Message;
                reply.Result.Exception = ex;
            }
            return reply.ToString();
        }

        private static List<Dictionary<string, object>> SQLQueryCommand(string sqlCommand)
        {
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
                    tmp.Add(ds.Tables[0].Columns[i].ColumnName, DecodeObject(item.ItemArray[i]));
                }
                results.Add(tmp);
            }

            return results;
        }

        private static object EncodeString(object item)
        {
            if (item is string)
            {
                return HttpUtility.UrlEncode(item as string);
            }
            else return item;
        }
        private static object DecodeObject(object item)
        {
            if (item is string)
            {
                return HttpUtility.UrlDecode(item as string);
            }
            else return item;
        }
    }
}
