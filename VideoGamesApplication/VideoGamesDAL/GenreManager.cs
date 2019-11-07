using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDAL.Models;

namespace VideoGamesDAL
{
    public static class GenreManager
    {
        public static Genre GetGenre(int GenreID)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetGenre";
                    cmd.Parameters.AddWithValue("@GenreID", GenreID);


                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // create an object
                        Genre g = new Genre();
                        g.GenreID = reader.GetInt32(0);
                        g.Name = reader.GetString(1);
                        return g;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }
        public static List<Genre> GetGenreList()
        {
            //create empty list to hold objects
            List<Genre> genres = new List<Genre>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Genre";

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generate a new object
                        // and fill it with data from reader
                        Genre genre = new Genre();
                        genre.GenreID = reader.GetInt32(0);
                        genre.Name = reader.GetString(1);
                        //add the filled category to my list
                        genres.Add(genre);
                    }
                }
            }
            //return the list
            return genres;
        }
        public static Genre AddGenre(Genre genre)
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
                    cmd.CommandText = "InsertGenre";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@genreName", genre.Name);


                    //run the command
                    int newId = (int)cmd.ExecuteScalar();

                    //set the id with the new row id
                    genre.GenreID = newId;

                    //return the updated category object
                    //that now contains the id of the new category
                    return genre;
                }
            }
        }
        public static int DeleteGenre(int GenreID)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeleteGenre";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //the stored proc expects one parameter - id
                    cmd.Parameters.AddWithValue("@GenreID", GenreID);

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
        public static int UpdateGenre(Genre genre)
        {
            //get the connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateGenre";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //fill in all parameters that the stored proc expects
                    cmd.Parameters.AddWithValue("@GenreID", genre.GenreID);
                    cmd.Parameters.AddWithValue("@Name", genre.Name);
                    //run the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }
    }
}