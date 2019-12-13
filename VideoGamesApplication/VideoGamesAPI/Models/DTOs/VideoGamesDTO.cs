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

        public SystemDTO System { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ESRBDTO ESRB { get; set; }

        public PublisherDTO Publisher { get; set; }

        public DeveleoperDTO Developer { get; set; }

        public GameGenreDTO GameGenre { get; set; }
    }
}

