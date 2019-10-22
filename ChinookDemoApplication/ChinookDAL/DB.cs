using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookDAL
{
    //connection
    public class DB
    {
        public static SqlConnection GetConnection()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            return conn;
        }
    }
}
