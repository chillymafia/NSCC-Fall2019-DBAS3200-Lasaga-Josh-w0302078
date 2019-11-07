/*
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDAL;
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
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetESRB";
                    cmd.Parameters.AddWithValue("@systemid", SystemID);


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
        public static System AddSystem(System system)
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
                    cmd.CommandText = "InsertSystem";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@systemName", system.Name);
                    cmd.Parameters.AddWithValue("@systemCompany", system.Company);


                    //run the command
                    int newId = (int)cmd.ExecuteScalar();

                    //set the id with the new row id
                    system.SystemID = newId;

                    //return the updated category object
                    //that now contains the id of the new category
                    return system;
                }
            }
        }
        public static int DeleteSystem(int SystemID)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeleteSystem";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //the stored proc expects one parameter - id
                    cmd.Parameters.AddWithValue("@systemid", SystemID);

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
        public static int UpdateSystem(System system)
        {
            //get the connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateSystem";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //fill in all parameters that the stored proc expects
                    cmd.Parameters.AddWithValue("@systemid", system.SystemID);
                    cmd.Parameters.AddWithValue("@name", system.Name);
                    //run the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }
    }
}