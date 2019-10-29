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
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetDeveloper";
                    cmd.Parameters.AddWithValue("@DevID", DevID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
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
        public static Developer AddDeveloper(Developer developer)
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
                    cmd.CommandText = "InsertDeveloper";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@developerName", developer.Name);


                    //run the command
                    int newId = (int)cmd.ExecuteScalar();

                    //set the id with the new row id
                    developer.DevID = newId;

                    //return the updated category object
                    //that now contains the id of the new category
                    return developer;
                }
            }
        }
        public static int DeleteDeveloper(int DevID)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeleteDeveloper";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //the stored proc expects one parameter - id
                    cmd.Parameters.AddWithValue("@DevID", DevID);

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
        public static int UpdateCategory(Developer developer)
        {
            //get the connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateDeveloper";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //fill in all parameters that the stored proc expects
                    cmd.Parameters.AddWithValue("@developerid", developer.DevID);
                    cmd.Parameters.AddWithValue("@name", developer.Name);
                    //run the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }
    }
}