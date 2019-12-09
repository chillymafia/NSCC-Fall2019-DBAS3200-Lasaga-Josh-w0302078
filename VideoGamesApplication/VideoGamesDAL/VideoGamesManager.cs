
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDAL.Models;

namespace VideoGamesDAL
{
    public static class VideoGamesManager
    {
        public static VideoGame GetVideoGame(int GameID)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM VideoGames WHERE ID = " + GameID + ";";

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // create an object
                        VideoGame v = new VideoGame();
                        v.GameID = reader.GetInt32(0);
                        v.Title = reader.GetString(1);
                        v.System = reader.GetString(2);
                        v.ReleaseDate = reader.GetString(3);
                        v.ESRB = reader.GetString(4);
                        v.Publisher = reader.GetString(5);
                        v.Developer = reader.GetString(6);
                        return v;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }
        public static List<VideoGame> GetVideoGameList(int GameID)
        {
            //create empty list to hold objects
            List<VideoGame> videogames = new List<VideoGame>();

            //get a connection from DB class
            using (SqlConnection conn = DB.GetConnection())
            {
                //Create a comnmand using the connection
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM VideoGames WHERE GenreID = @GenreID;";
                    cmd.Parameters.AddWithValue("@GenreID", GameID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generate a new object
                        // and fill it with data from reader
                        VideoGame videogame = new VideoGame();
                        videogame.GameID = reader.GetInt32(0);
                        videogame.Title = reader.GetString(1);
                        videogame.System = reader.GetString(2);
                        videogame.ReleaseDate = reader.GetString(3);
                        videogame.ESRB = reader.GetString(4);
                        videogame.Publisher = reader.GetString(5);
                        videogame.Developer = reader.GetString(6);
                        //add the filled category to my list
                        videogames.Add(videogame);
                    }
                }
            }
            //return the list
            return videogames;
        }

        public static VideoGame AddVideoGame(VideoGame videogame)
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
                    cmd.CommandText = "InsertVideoGame";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@videogameTitle", videogame.Title);


                    //run the command
                    int newId = (int)cmd.ExecuteScalar();

                    //set the id with the new row id
                    videogame.GameID = newId;

                    //return the updated category object
                    //that now contains the id of the new category
                    return videogame;

                }
            }
        }
        public static int DeleteVideoGame(int GameID)
        {
            //get connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //create command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DeleteVideoGame";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //the stored proc expects one parameter - id
                    cmd.Parameters.AddWithValue("@GameID", GameID);

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
        public static int UpdateVideoGame(VideoGame videogame)
        {
            //get the connection
            using (SqlConnection conn = DB.GetConnection())
            {
                //define the command
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateVideoGame";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //fill in all parameters that the stored proc expects
                    cmd.Parameters.AddWithValue("@GameID", videogame.GameID);
                    cmd.Parameters.AddWithValue("@Title", videogame.Title);
                    cmd.Parameters.AddWithValue("@ReleaseDate", videogame.ReleaseDate);
                    cmd.Parameters.AddWithValue("@System", videogame.System);
                    cmd.Parameters.AddWithValue("@ESRB", videogame.ESRB);
                    cmd.Parameters.AddWithValue("@Publisher", videogame.Publisher);
                    cmd.Parameters.AddWithValue("@Developer", videogame.Developer);

                    //run the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }
    }
}