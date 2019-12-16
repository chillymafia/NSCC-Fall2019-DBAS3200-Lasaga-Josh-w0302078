using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesAPI.Models.DTOs
{
    public class DeveloperDTO
    {
        public int DevID { get; set; }

        public string Name { get; set; }
        public List<VideoGamesDTO> VideoGames { get; set; }
    }
}
