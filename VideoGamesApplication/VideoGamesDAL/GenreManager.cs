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
                    cmd.CommandText = "SELECT * FROM Genre WHERE ID = " + GenreID + ";";

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
    }
}
