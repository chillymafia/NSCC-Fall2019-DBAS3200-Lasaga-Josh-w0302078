using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesAPI.Models.DTOs
{
    public class VideoGamesDTO
    {
        public int VideoGamesID { get; set; }
        public string Title { get; set; }

        public List<SystemDTO> System { get; set; }
    }
}

