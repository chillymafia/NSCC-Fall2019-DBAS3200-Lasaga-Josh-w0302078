using ChinookDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookDAL
{
    public static class GenreManager
    {
        public static Genre GetGenreById(int id)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT GenreId, Name FROM Genre WHERE GenreId = @genreId;";
                    cmd.Parameters.AddWithValue("@genreId", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    //read the one row returned
                    if (reader.Read())
                    {
                        Genre g = new Genre();
                        g.GenreId = reader.GetInt32(0);
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
    }
}
