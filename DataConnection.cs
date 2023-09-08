using System;
using System.Data.SqlClient;

namespace BT_nhom_C_
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            var datasource = @"DESKTOP-SAC71PM";
            var database = "CMCIT";
            var username = "admin";
            var password = "admin";

            conStr = @"Data Source=" + datasource + ";Initial Catalog=" + database +
                ";Persist Security Info=True;User ID=" + username + ";Password=" + password
                + ";Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True";
            
        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(conStr);
        }
    }
}
