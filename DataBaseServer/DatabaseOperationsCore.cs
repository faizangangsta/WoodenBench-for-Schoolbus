using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WBPlatform.StaticClasses;

namespace WBPlatform.Database.DBServer
{
    public static class DatabaseCore
    {
        private static SqlConnection connection;
        static SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        public static void InitialiseConnection()
        {
            LogWritter.DebugMessage("Start Initiallising Database Connections.....");
            stringBuilder.Authentication = SqlAuthenticationMethod.SqlPassword;
            stringBuilder.DataSource = "127.0.0.1,1433";
            stringBuilder.UserID = "schoolbus_Database";
            stringBuilder.Password = "EV#WT%GTegqeraagw%#q3%GW%E$E";
            stringBuilder.TrustServerCertificate = true;
            connection = new SqlConnection(stringBuilder.ConnectionString);
            connection.Open();
            LogWritter.DebugMessage("DB Connection Opened!");
            SqlCommand command = connection.CreateCommand();
        }

        public static string ProcessRequest(string requestString)
        {
            DBInternalQuery query = JsonConvert.DeserializeObject<DBInternalQuery>(requestString);
            DataBaseOperation operation = (DataBaseOperation)query.operation;
            DBOutput output = JsonConvert.DeserializeObject<DBOutput>(query.queryObjectString);
            DBQuery dbQuery = JsonConvert.DeserializeObject<DBQuery>(query.queryString);
            if ((operation == DataBaseOperation.QueryMulti || operation == DataBaseOperation.QuerySingle || operation == DataBaseOperation.Change || operation == DataBaseOperation.Delete) && query == null)
            {
                throw new ArgumentNullException("When using Query Single/Multi and Change, Delete. Arg: query cannot be null");
            }
            if ((operation == DataBaseOperation.Create || operation == DataBaseOperation.Change) && output == null)
            {
                throw new ArgumentNullException("When using Query Create and Change. Arg: output cannot be null");
            }
            switch (operation)
            {
                case DataBaseOperation.Create:
                    break;
                case DataBaseOperation.QuerySingle:
                case DataBaseOperation.QueryMulti:
                    string sqlCommand = "SELECT TOP(" + dbQuery._Limit + ") * FROM " + query.TableName + " WHERE ";
                    if (dbQuery.EqualTo.Count > 0)
                    {
                        foreach (var item in dbQuery.EqualTo)
                        {
                            sqlCommand += item.Key + " = '" + item.Value + "' AND ";
                        }
                        sqlCommand = new string(sqlCommand.Take(sqlCommand.Length - 4).ToArray());
                    }
                    if (dbQuery.Contain.Count > 0)
                    {
                        foreach (var item in dbQuery.Contain)
                        {

                        }
                    }
                    SqlDataAdapter sda = new SqlDataAdapter(sqlCommand, connection);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
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
                    DBInternalReply reply = new DBInternalReply();
                    reply.resultObjectString = JsonConvert.SerializeObject(results);
                    return JsonConvert.SerializeObject(reply);
                case DataBaseOperation.Change:
                    break;
                case DataBaseOperation.Delete:
                    break;
                default:
                    break;
            }

            return "";
        }
    }
}
