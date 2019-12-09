using System;
using System.Collections.Generic;

namespace VideoGamesAPI.Models
{
    public partial class VideoGames
    {
        public VideoGames()
        {
            GameGenre = new HashSet<GameGenre>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int System { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Esrb { get; set; }
        public int Publisher { get; set; }
        public int Developer { get; set; }

        public Developer DeveloperNavigation { get; set; }
        public Esrb EsrbNavigation { get; set; }
        public Publisher PublisherNavigation { get; set; }
        public System SystemNavigation { get; set; }
        public ICollection<GameGenre> GameGenre { get; set; }
    }
}
