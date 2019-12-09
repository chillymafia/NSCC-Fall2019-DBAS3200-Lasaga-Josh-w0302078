using System;
using System.Collections.Generic;

namespace VideoGamesUI.Models
{
    public partial class GameGenre
    {
        public int GameGenreId { get; set; }
        public int GenreId { get; set; }
        public int GameId { get; set; }

        public VideoGames Game { get; set; }
        public Genre Genre { get; set; }
    }
}
