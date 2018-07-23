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
        private static SqlConnection sqlConnection;
        public static void InitialiseDBConnection()
        {
            SqlConnectionStringBuilder readOnlyConnectionString = new SqlConnectionStringBuilder();
            LW.D("Start Initiallising Database Connections.....");
            readOnlyConnectionString.DataSource = "118.190.144.179,1433";
            readOnlyConnectionString.UserID = "schoolbus_Database";
            readOnlyConnectionString.Password = "EV#WT%GTegqeraagw%#q3%GW%E$E";
            readOnlyConnectionString.TrustServerCertificate = true;
            LW.D("DB Connection String Loaded!");
            sqlConnection = new SqlConnection(readOnlyConnectionString.ConnectionString);
            sqlConnection.Open();
            LW.D("DB Connection Opened!");
        }

        public static string ProcessRequest(DBInternalRequest request)
        {
            DBOutput dbOutputData = null;
            DBQuery dbQuery = null;
            DBInternalReply reply = new DBInternalReply();
            try
            {
                if (request == null) throw new NullReferenceException("Null Request....");

                if (request.Operation != DBVerbs.Create)
                {
                    if (request.Query == null)
                        throw new ArgumentNullException("When using Query Single/Multi/Change/Delete. Arg: query cannot be null");
                    else dbQuery = request.Query;
                }

                if (request.Operation == DBVerbs.Create || request.Operation == DBVerbs.Update)
                {
                    var real = JsonConvert.DeserializeObject<Dictionary<string, object>>(request.ObjectString);
                    dbOutputData = new DBOutput(real ?? throw new ArgumentNullException("When using Query Create and Change. Arg: output cannot be null"));
                }

                int rowModified = 0;
                reply.DBOperation = request.Operation;
                switch (request.Operation)
                {
                    case DBVerbs.Create:
                        rowModified = CommandCreate(request.TableName, dbOutputData);
                        reply.DBResultCode = (DBQueryStatus)rowModified;
                        reply.ObjectString = JsonConvert.SerializeObject(GetFirstRecord(request.TableName, "objectId", dbOutputData["objectId"]));
                        break;

                    case DBVerbs.QuerySingle:
                    case DBVerbs.QueryMulti:
                        List<Dictionary<string, object>> results = SQLQueryCommand(BuildQueryString(request.TableName, dbQuery));
                        rowModified = results.Count;
                        reply.ObjectString = JsonConvert.SerializeObject(results);
                        reply.DBResultCode = results.Count >= 2 ? DBQueryStatus.MORE_RESULTS : (DBQueryStatus)results.Count;
                        break;
                    case DBVerbs.Update:
                        //Only Support first thing....
                        var _ = SQLQueryCommand(BuildQueryString(request.TableName, dbQuery));
                        if (_.Count != 1)
                        {
                            throw new KeyNotFoundException("DBServerCore-->ProcessRequest->Update: Cannot find Specific Record by Query, so Failed to update....");
                        }
                        rowModified = CommandUpdate(request.TableName, _[0]["objectId"].ToString(), dbOutputData);
                        reply.DBResultCode = (DBQueryStatus)rowModified;
                        reply.ObjectString = JsonConvert.SerializeObject(GetFirstRecord(request.TableName, "objectId", _[0]["objectId"]));

                        break;
                    case DBVerbs.Delete:
                        rowModified = CommandDelete(request.TableName, dbQuery.EqualTo["objectId"].ToString());
                        reply.DBResultCode = (DBQueryStatus)rowModified;
                        break;
                    default:
                        //HttpUtility.UrlEncode("!@#$%^&*()_+");
                        //break;
                        throw new NotSupportedException("What The Hell you are doing....");
                }
                reply.Message = "操作成功完成(" + rowModified + ")";
            }
            catch (Exception ex)
            {
                reply.DBResultCode = DBQueryStatus.INTERNAL_ERROR;
                reply.Message = ex.Message;
                reply.Exception = new DataBaseException("DBServer Process Exception", ex);
                LW.E("Exception! => \r\n" + ex);
            }
            return reply.ToString();
        }

        private static string BuildQueryString(string TableName, DBQuery dbQuery)
        {
            string sqlCommand_Query = $"SELECT TOP({dbQuery._Limit}) * FROM {TableName}{((dbQuery.EqualTo.Count > 0 || dbQuery.Contains.Count > 0 || dbQuery.ContainedInArray.Count > 0) ? " WHERE " : "")}";

            if (dbQuery.EqualTo.Count > 0)
            {
                string[] queriesStringCollection = (from q in dbQuery.EqualTo select $"{q.Key} = '{PublicTools.EncodeString(q.Value.ToString())}'").ToArray();
                sqlCommand_Query += "(" + string.Join(" AND ", queriesStringCollection) + ")";
                sqlCommand_Query += (dbQuery.ContainedInArray.Count > 0 || dbQuery.Contains.Count > 0) ? " AND " : string.Empty;
            }

            if (dbQuery.ContainedInArray.Count > 0)
            {
                List<string> containsSQLList = new List<string>();
                foreach (var item in dbQuery.ContainedInArray)
                {
                    containsSQLList.Add($"( {item.Key} IN ('{string.Join("', '", item.Value)}'))");
                }
                string finalQueryString = string.Join(" OR ", containsSQLList.ToArray());

                sqlCommand_Query += "(" + finalQueryString + ")";
                sqlCommand_Query += (dbQuery.Contains.Count > 0) ? " AND " : string.Empty;
            }

            if (dbQuery.Contains.Count > 0)
            {
                string[] queriesStringCollection = (from q in dbQuery.Contains select $"{q.Key} LIKE '%{PublicTools.EncodeString(q.Value)}%'").ToArray();
                sqlCommand_Query += string.Join(" AND ", queriesStringCollection);
            }

            return sqlCommand_Query;
        }

        private static int CommandCreate(string TableName, DBOutput output)
        {
            string sqlCommand_Create =
                $"INSERT INTO {TableName} " +
                $"({string.Join(",", output.Data.Keys)}, createdAt, updatedAt)" +
                $" VALUES " +
                $"('{string.Join("','", (from val in output.Data.Values select (PublicTools.EncodeString(val))).ToArray())}', '{DateTime.Now}', '{DateTime.Now}')";
            SqlCommand command_Create = new SqlCommand(sqlCommand_Create, sqlConnection);

            return command_Create.ExecuteNonQuery();
        }

        private static int CommandUpdate(string TableName, string ObjectID, DBOutput output)
        {
            string sqlCommand_Update =
                $"UPDATE {TableName} " +
                $"SET {string.Join(",", (from q in output.Data select $"{q.Key} = '{PublicTools.EncodeString(q.Value)}' ").ToArray())}, updatedAt = '{DateTime.Now}' " +
                $"WHERE objectId = '{ObjectID}'";

            SqlCommand command_Update = new SqlCommand(sqlCommand_Update, sqlConnection);
            return command_Update.ExecuteNonQuery();
        }

        private static List<Dictionary<string, object>> GetFirstRecord(string tableName, string Column, object Value)
            => SQLQueryCommand($"SELECT TOP(1) * FROM {tableName} WHERE {Column} = '{PublicTools.EncodeString(Value)}' ");

        private static int CommandDelete(string TableName, string ObjectID)
        {
            string sqlCommand_Del = $"DELETE FROM {TableName} WHERE objectId = '{ObjectID}'";
            SqlCommand command = new SqlCommand(sqlCommand_Del, sqlConnection);
            return command.ExecuteNonQuery();
        }

        private static List<Dictionary<string, object>> SQLQueryCommand(string sqlCommand)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand, sqlConnection);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            sda.Dispose();
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Dictionary<string, object> tmp = new Dictionary<string, object>();
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    tmp.Add(ds.Tables[0].Columns[i].ColumnName, PublicTools.DecodeObject(item.ItemArray[i]));
                }
                results.Add(tmp);
            }
            return results;
        }

    }
}
