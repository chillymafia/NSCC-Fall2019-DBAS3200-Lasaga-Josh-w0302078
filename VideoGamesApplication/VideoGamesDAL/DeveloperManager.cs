using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDAL.Models;

namespace VideoGamesDAL
{
    public static class DeveloperManager
    {
        public static Developer GetDeveloper(int DevID)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Developer WHERE ID = " + DevID + ";";

                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.HasRows)
                    {
                        // create an object
                        Developer d = new Developer();
                        d.DevID = reader.GetInt32(0);
                        d.Name = reader.GetString(1);
                        return d;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }
        public static List<Developer> GetDeveloperList()
        {
            //create empty list to hold objects
            List<Developer> developers = new List<Developer>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Developer";

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generate a new object
                        // and fill it with data from reader
                        Developer developer = new Developer();
                        developer.DevID = reader.GetInt32(0);
                        developer.Name = reader.GetString(1);
                        //add the filled category to my list
                        developers.Add(developer);
                    }
                }
            }
            //return the list
            return developers;
        }
    }
}
