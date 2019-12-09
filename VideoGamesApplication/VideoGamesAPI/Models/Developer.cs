using System;
using System.Collections.Generic;

namespace VideoGamesAPI.Models
{
    public partial class Developer
    {
        public Developer()
        {
            VideoGames = new HashSet<VideoGames>();
        }

        public int DevId { get; set; }
        public string Name { get; set; }

        public ICollection<VideoGames> VideoGames { get; set; }
    }
}
