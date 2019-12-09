using System;
using System.Collections.Generic;

namespace VideoGamesUI.Models
{
    public partial class Genre
    {
        public Genre()
        {
            GameGenre = new HashSet<GameGenre>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<GameGenre> GameGenre { get; set; }
    }
}
