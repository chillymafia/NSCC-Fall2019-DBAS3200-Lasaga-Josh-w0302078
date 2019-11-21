using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace VideoGamesDAL
{
    public static class DB
    {

        public static SqlConnection GetConnection()
        {
            //string connString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VideoGamesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //string connString = @"Data Source=videogamesazure.database.windows.net;Initial Catalog=VideoGamesAzure;User ID=W0302078;Password=AzurePassw0rd;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string activeCS = ConfigurationManager.AppSettings["activeConnectionString"];

            string connString = ConfigurationManager.ConnectionStrings[activeCS].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            return conn;
        }
        
    }
}
