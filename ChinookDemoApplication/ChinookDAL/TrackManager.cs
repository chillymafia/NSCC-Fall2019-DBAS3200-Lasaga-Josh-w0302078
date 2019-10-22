using ChinookDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookDAL
{
    public static class TrackManager
    {
        public static List<Track> GetGenreTracks(int genreID)
        {
            List<Track> tracks = new List<Track>();

            using (SqlConnection conn = DB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Track WHERE GenreId = @genreId;";
                    cmd.Parameters.AddWithValue("@genreId", genreId);
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Track t = new Track();
                        t.TrackId = reader.GetInt32(0);
                        t.Name = reader.GetString(1);
                        t.AlbumId = reader.GetInt32(2);
                        t.MediaTypeId = reader.GetInt32(3);
                        t.GenreId = reader.GetInt32(4);
                        t.Composer = reader.IsDBNull(5) ? null : reader.GetString(5);
                        t.Milliseconds = reader.GetInt32(6);
                        t.Bytes = reader.GetInt32(7);
                        //t.UnitPrice = reader.GetSqlMoney(8);

                        //add to the list
                        tracks.Add(t);
                    }

                }
            }

            return tracks;
        }
    }
}
