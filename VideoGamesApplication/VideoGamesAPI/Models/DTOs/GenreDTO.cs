using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesAPI.Models.DTOs
{
    public class GenreDTO
    {
        public int GenreID { get; set; }
        public string Name { get; set; }

        public ICollection<VideoGames> VideoGames { get; set; }

    }
}
