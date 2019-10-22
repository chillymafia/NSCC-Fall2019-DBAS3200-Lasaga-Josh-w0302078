using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDAL.Models;

namespace VideoGamesDAL
{
    public static class ESRBManager
    {
        public static ESRB GetESRB(int ESRBID)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM ESRB WHERE ID = " + ESRBID + ";";

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // create an object
                        ESRB e = new ESRB();
                        e.ESRBID = reader.GetInt32(0);
                        e.Rating = reader.GetString(1);
                        return e;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }
        public static List<ESRB> GetESRBList()
        {
            //create empty list to hold objects
            List<ESRB> esrbs = new List<ESRB>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM ESRB";

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generate a new object
                        // and fill it with data from reader
                        ESRB esrb = new ESRB();
                        esrb.ESRBID = reader.GetInt32(0);
                        esrb.Rating = reader.GetString(1);
                        //add the filled category to my list
                        esrbs.Add(esrb);
                    }
                }
            }
            //return the list
            return esrbs;
        }
    }
}
