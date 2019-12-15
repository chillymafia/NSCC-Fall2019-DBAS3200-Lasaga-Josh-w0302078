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

        public int System { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int ESRB { get; set; }

        public int Publisher { get; set; }

        public int Developer { get; set; }


    }
}

