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
        public static Publisher GetPublisher(int PubID)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Publisher WHERE ID = " + PubID + ";";

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
    }
}
