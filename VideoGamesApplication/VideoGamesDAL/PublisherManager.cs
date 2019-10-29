using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDAL.Models;

namespace VideoGamesDAL
{
    public static class PublisherManager
    {
        public static ESRB GetPublisher(int PubID)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetPublisher";
                    cmd.Parameters.AddWithValue("PubID", PubID);


                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // create an object
                        Publisher p = new Publisher();
                        p.PubID = reader.GetInt32(0);
                        p.Name = reader.GetString(1);
                        return p;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }
        public static List<Publisher> GetPublisherList()
        {
            //create empty list to hold objects
            List<Publisher> publishers = new List<Publisher>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Publisher";

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generate a new object
                        // and fill it with data from reader
                        Publisher publisher = new Publisher();
                        publisher.PubID = reader.GetInt32(0);
                        publisher.Name = reader.GetString(1);
                        //add the filled category to my list
                        publishers.Add(publisher);
                    }
                }
            }
            //return the list
            return publishers;
        }
        public static Publisher AddPublisher(Publisher publisher)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //define a command
                using (SqlCommand cmd = new SqlCommand())
                {
                    //NOTE: this is done with SQL in the code...
                    //You are expected to create a Stored Proc
                    //to do the insert. Refer to update and delete
                    //examples

                    cmd.Connection = conn;
                    cmd.CommandText = "InsertPublisher";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@publsiherName", publisher.Name);


                    //run the command
                    int newId = (int)cmd.ExecuteScalar();

                    //set the id with the new row id
                    publisher.PubID = newId;

                    //return the updated category object
                    //that now contains the id of the new category
                    return publisher;
                }
            }
        }
        public static int DeletePublisher(int PubID)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeletePublisher";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //the stored proc expects one parameter - id
                    cmd.Parameters.AddWithValue("@PubID", PubID);

                    //run command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }


            //clean up your 
        }

        /// <summary>
        /// Update an existing category
        /// </summary>
        /// <param name="category">The category (object) to update</param>
        /// <returns>Number of rows affected</returns>
        public static int UpdatePublisher(Publisher publisher)
        {
            //get the connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdatePublisher";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //fill in all parameters that the stored proc expects
                    cmd.Parameters.AddWithValue("@cpublisherid", publisher.PubID);
                    cmd.Parameters.AddWithValue("@name", publisher.Name);
                    //run the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }
    }
}