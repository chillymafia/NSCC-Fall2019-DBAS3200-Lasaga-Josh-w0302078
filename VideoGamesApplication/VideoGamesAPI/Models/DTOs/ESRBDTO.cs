using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesAPI.Models.DTOs
{
    public class ESRBDTO
    {
        public int ESRBID { get; set; }

        public string Rating { get; set; }
        public List<VideoGamesDTO> VideoGames { get; set; }
    }
}
