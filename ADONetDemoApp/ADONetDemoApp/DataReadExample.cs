using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetDemoApp
{
    public class DataReadExample
    {
        private string connectionString;
        //constructor
        public DataReadExample(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //create a method to call
        public void RunDemo()
        {
            //Establish a connection
            SqlConnection conn = new SqlConnection(this.connectionString);

            //Open it
            conn.Open();


            //Pass the connection to some functionality that will 
            //read data
            SqlCommand cmd
                = new SqlCommand("SELECT CompanyName, City, Phone FROM Customers", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            //Display the data
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
                Console.WriteLine(reader.GetString(1));
                Console.WriteLine(reader.GetString(2));
                Console.WriteLine();
            }


            //Close the connection
            conn.Close();
        }

       
    }
}
