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
                        v.Genre = reader.GetString(3);
                        v.ReleaseDate = reader.GetString(4);
                        v.ESRB = reader.GetString(5);
                        v.Publisher = reader.GetString(6);
                        v.Developer = reader.GetString(7);
                        return v;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }
        public static List<VideoGame> GetVideoGameList()
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
                    cmd.CommandText = "SELECT * FROM VideoGames";

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //generate a new object
                        // and fill it with data from reader
                        VideoGame videogame = new VideoGame();
                        videogame.GameID = reader.GetInt32(0);
                        videogame.Title = reader.GetString(1);
                        videogame.System = reader.GetString(2);
                        videogame.Genre = reader.GetString(3);
                        videogame.ReleaseDate = reader.GetString(4);
                        videogame.ESRB = reader.GetString(5);
                        videogame.Publisher = reader.GetString(6);
                        videogame.Developer = reader.GetString(7);
                        //add the filled category to my list
                        videogames.Add(videogame);
                    }
                }
            }
            //return the list
            return videogames;
        }
    }
}
