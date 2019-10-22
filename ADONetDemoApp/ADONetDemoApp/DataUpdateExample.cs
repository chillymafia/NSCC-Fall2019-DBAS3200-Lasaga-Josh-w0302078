using System;
using System.Data.SqlClient;

namespace ADONetDemoApp
{
    internal class DataUpdateExample
    {
        private string connectionString;

        //constructor
        public DataUpdateExample(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void RunDemo()
        {
            //connect to database SqlConnection
            SqlConnection connection = new SqlConnection(this.connectionString);

            //open connection
            connection.Open();

            //send db a command   SqlCommand
            SqlCommand cmd 
                = new SqlCommand("UPDATE categories SET CategoryName='Libations' WHERE CategoryID = 1;");
            cmd.Connection = connection;


            //make a change to the data
            int rowsAffected = cmd.ExecuteNonQuery();

            Console.WriteLine("{0} row(s) affected", rowsAffected);

            //acknowledgement
            //close the connection
            connection.Close();
        }
    }
}