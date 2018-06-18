using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WBPlatform.Databases.DataBaseCore
{
    public static class DatabaseOperationsCore
    {
        static SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        public static void Initialise()
        {
            stringBuilder.Authentication = SqlAuthenticationMethod.SqlPassword;
            stringBuilder.DataSource = "127.0.0.1,1433";
            stringBuilder.UserID = "schoolbus_Database";
            stringBuilder.Password = "EV#WT%GTegqeraagw%#q3%GW%E$E";
            stringBuilder.TrustServerCertificate = true;
            SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            
        }
    }
}
