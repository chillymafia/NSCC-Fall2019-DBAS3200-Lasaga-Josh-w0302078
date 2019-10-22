using System;
using System.Data.SqlClient;

namespace ADONetDemoApp
{
    internal class StoredProcExampleWithParams
    {
        private string connectionString;

        public StoredProcExampleWithParams(string connectionString)
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
            cmd.CommandText = "SalesByCategory";
            cmd.Connection = connection;

            //add in the required parameters for our stored proc
            cmd.Parameters.Add("@CategoryName", System.Data.SqlDbType.NVarChar).Value = "Produce";
            cmd.Parameters.Add("@OrdYear", System.Data.SqlDbType.NVarChar).Value = "1799";

            //run the command
            SqlDataReader reader = cmd.ExecuteReader();

            //read the reader
            while (reader.Read())
            {
                Console.WriteLine(string.Format("{0}, {1}", reader.GetString(0), reader.GetDecimal(1)));
            }

            //acknowledgement
            //close the connection
            connection.Close();
        }
    }
}