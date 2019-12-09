using System;
using System.Collections.Generic;

namespace VideoGamesAPI.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            VideoGames = new HashSet<VideoGames>();
        }

        public int PubId { get; set; }
        public string Name { get; set; }

        public ICollection<VideoGames> VideoGames { get; set; }
    }
}
