using System;
using System.Data.SqlClient;

namespace ADONetDemoApp
{
    internal class StoredProcExample
    {
        private string connectionString;

        public StoredProcExample(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void RunDemo()
        {
            //connect to database SqlConnection
            SqlConnection connection = new SqlConnection(this.connectionString);

            //open connection
            connection.Open();


            //define the command to run a stored procedure
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Ten Most Expensive Products";
            cmd.Connection = connection;

            //run the command
            SqlDataReader reader = cmd.ExecuteReader();

            //read the reader
            while (reader.Read())
            {
                Console.WriteLine(string.Format("{0}, {1}", reader.GetString(0), reader.GetSqlMoney(1)));
            }

            //acknowledgement
            //close the connection
            connection.Close();
        }
    }
}