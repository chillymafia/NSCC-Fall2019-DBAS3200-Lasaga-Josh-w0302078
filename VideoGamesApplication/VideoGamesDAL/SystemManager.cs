using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDAL.Models;

namespace VideoGamesDAL
{
    public static class SystemManager
    {
        public static System GetSystem(int SystemID)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM System WHERE ID = " + SystemID + ";";

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // create an object
                        System s = new System();
                        s.SystemID = reader.GetInt32(0);
                        s.Name = reader.GetString(1);
                        s.Company = reader.GetString(2);
                        return s;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }
        public static List<System> GetSystemList()
        {
            //create empty list to hold objects
            List<System> system = new List<System>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM System";

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generate a new object
                        // and fill it with data from reader
                        System system = new System();
                        system.SystemID = reader.GetInt32(0);
                        system.Name = reader.GetString(1);
                        system.Company = reader.GetString(2);
                        //add the filled category to my list
                        systems.Add(system);
                    }
                }
            }
            //return the list
            return systems;
        }
    }
}
