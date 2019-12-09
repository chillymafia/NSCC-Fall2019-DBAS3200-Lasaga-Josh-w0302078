using System;
using System.Collections.Generic;

namespace VideoGamesUI.Models
{
    public partial class System
    {
        public System()
        {
            VideoGames = new HashSet<VideoGames>();
        }

        public int SystemId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }

        public ICollection<VideoGames> VideoGames { get; set; }
    }
}
