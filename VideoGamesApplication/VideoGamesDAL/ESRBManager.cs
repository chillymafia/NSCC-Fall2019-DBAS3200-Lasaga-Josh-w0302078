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
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetESRB";
                    cmd.Parameters.AddWithValue("@esrbid", ESRBID);


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

        public static ESRB AddESRB(ESRB esrb)
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
                    cmd.CommandText = "InsertESRB";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ESRBRating", esrb.Rating);


                    //run the command
                    int newId = (int)cmd.ExecuteScalar();

                    //set the id with the new row id
                    esrb.ESRBID = newId;

                    //return the updated category object
                    //that now contains the id of the new category
                    return esrb;
                }
            }
        }

        public static int DeleteESRB(int esrbid)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeleteESRB";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //the stored proc expects one parameter - id
                    cmd.Parameters.AddWithValue("@esrbid", esrbid);

                    //run command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }


            //clean up your 
        }
        public static int UpdateESRB(ESRB esrb)
        {
            //get the connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateESRB";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //fill in all parameters that the stored proc expects
                    cmd.Parameters.AddWithValue("@esrbid", esrb.ESRBID);
                    cmd.Parameters.AddWithValue("@rating", esrb.Rating);
                    //run the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }

    }
}