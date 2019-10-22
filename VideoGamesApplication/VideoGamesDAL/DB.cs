using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesDAL
{
    public static class DB
    {
        public static string ConnectionString
        {
            get
            {
                string connectionString
                    = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = VideoGamesDB; Integrated Security = True";

                    return connectionString;
            }

        }

        public static SqlConnection GetConnection()
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            return connection;
        }
        
    }
}
