
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using WBPlatform.Database;
using WBPlatform.Database.DBIOCommand;
using WBPlatform.Database.Internal;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.DBServer
{
    public static class DatabaseCore
    {
        private static SqlConnection sqlConnection;
        public static void InitialiseDBConnection()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            LW.D("Start Initiallising Database Connections.....");
            conn.DataSource = XConfig.Current.Database.SQLServerIP + "," + XConfig.Current.Database.SQLServerPort;
            conn.UserID = XConfig.Current.Database.DatabaseUserName;
            conn.Password = XConfig.Current.Database.DatabasePassword;
            conn.TrustServerCertificate = true;
            LW.D("DB Connection String Loaded!");
            sqlConnection = new SqlConnection(conn.ConnectionString);
            sqlConnection.Open();
            LW.D("DB Connection Opened!");
        }

        public static string ProcessRequest(DBInternal request)
        {
            DBInternal reply = new DBInternal();
            try
            {
                if (request == null) throw new NullReferenceException("Null Request....");

                if (request.Verb != DBVerbs.Create)
                {
                    if (request.Query == null)
                        throw new ArgumentNullException("When using Query Single/Multi/Change/Delete. Arg: query cannot be null");
                }

                if (request.Verb == DBVerbs.Create || request.Verb == DBVerbs.Update)
                {
                    if (request.DBObjects == null)
                        throw new ArgumentNullException("When using Create and Update. Arg: output cannot be null");
                }

                int rowModified = 0;
                reply.Verb = request.Verb;
                switch (request.Verb)
                {
                    case DBVerbs.Create:
                        rowModified = CommandCreate(request.TableName, request.DBObjects[0]);
                        reply.ResultCode = (DBQueryStatus)rowModified;
                        reply.DBObjects = GetFirstRecord(request.TableName, "objectId", request.DBObjects[0]["objectId"]);
                        break;

                    case DBVerbs.QuerySingle:
                    ///There shouldn't be QuerySingle... <see cref="DataBaseOperation.QueryMultipleData{T}(DBQuery, out List{T}, int, int)"/> 
                    case DBVerbs.QueryMulti:
                        var results = SQLQueryCommand(BuildQueryString(request.TableName, request.Query));
                        rowModified = results.Length;
                        reply.DBObjects = results.ToArray();
                        reply.ResultCode = results.Length >= 2 ? DBQueryStatus.MORE_RESULTS : (DBQueryStatus)results.Length;
                        break;
                    case DBVerbs.Update:
                        //Only Support first thing....
                        var dict = SQLQueryCommand(BuildQueryString(request.TableName, request.Query));
                        if (dict.Length != 1)
                        {
                            throw new KeyNotFoundException("DBServerCore-->ProcessRequest->Update: Cannot find Specific Record by Query, so Failed to update....");
                        }
                        rowModified = CommandUpdate(request.TableName, dict[0]["objectId"].ToString(), request.DBObjects[0]);
                        reply.ResultCode = (DBQueryStatus)rowModified;
                        reply.DBObjects = GetFirstRecord(request.TableName, "objectId", dict[0]["objectId"]);

                        break;
                    case DBVerbs.Delete:
                        rowModified = CommandDelete(request.TableName, request.Query.EqualTo["objectId"].ToString());
                        reply.ResultCode = (DBQueryStatus)rowModified;
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
                reply.ResultCode = DBQueryStatus.INTERNAL_ERROR;
                reply.Message = ex.Message;
                reply.Exception = new DataBaseException("DBServer Process Exception", ex);
                LW.E("Exception! => \r\n" + ex);
            }
            return reply.ToParsedString();
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

        private static int CommandCreate(string TableName, DataBaseIO output)
        {
            string sqlCommand_Create =
                $"INSERT INTO {TableName} " +
                $"({string.Join(",", output.Data.Keys)}, createdAt, updatedAt)" +
                $" VALUES " +
                $"('{string.Join("','", (from val in output.Data.Values select (PublicTools.EncodeString(val))).ToArray())}', '{DateTime.Now}', '{DateTime.Now}')";
            SqlCommand command_Create = new SqlCommand(sqlCommand_Create, sqlConnection);
            return command_Create.ExecuteNonQuery();
        }

        private static int CommandUpdate(string TableName, string ObjectID, DataBaseIO output)
        {
            string sqlCommand_Update =
                $"UPDATE {TableName} " +
                $"SET {string.Join(",", (from q in output.Data select $"{q.Key} = '{PublicTools.EncodeString(q.Value)}' ").ToArray())}, updatedAt = '{DateTime.Now}' " +
                $"WHERE objectId = '{ObjectID}'";

            SqlCommand command_Update = new SqlCommand(sqlCommand_Update, sqlConnection);
            return command_Update.ExecuteNonQuery();
        }

        private static DataBaseIO[] GetFirstRecord(string tableName, string Column, object Value)
            => SQLQueryCommand($"SELECT TOP(1) * FROM {tableName} WHERE {Column} = '{PublicTools.EncodeString(Value)}' ");

        private static int CommandDelete(string TableName, string ObjectID)
        {
            string sqlCommand_Del = $"DELETE FROM {TableName} WHERE objectId = '{ObjectID}'";
            SqlCommand command = new SqlCommand(sqlCommand_Del, sqlConnection);
            return command.ExecuteNonQuery();
        }

        private static DataBaseIO[] SQLQueryCommand(string sqlCommand)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand, sqlConnection);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            sda.Dispose();
            List<DataBaseIO> results = new List<DataBaseIO>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Dictionary<string, object> tmp = new Dictionary<string, object>();
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    tmp.Add(ds.Tables[0].Columns[i].ColumnName, PublicTools.DecodeObject(item.ItemArray[i]));
                }
                results.Add(new DataBaseIO(tmp));
            }
            return results.ToArray();
        }
    }
}
