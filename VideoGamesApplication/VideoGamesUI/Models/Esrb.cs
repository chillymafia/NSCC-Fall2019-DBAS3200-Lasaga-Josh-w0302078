using System;
using System.Collections.Generic;

namespace VideoGamesUI.Models
{
    public partial class Esrb
    {
        public Esrb()
        {
            VideoGames = new HashSet<VideoGames>();
        }

        public int Esrbid { get; set; }
        public string Rating { get; set; }

        public ICollection<VideoGames> VideoGames { get; set; }
    }
}
