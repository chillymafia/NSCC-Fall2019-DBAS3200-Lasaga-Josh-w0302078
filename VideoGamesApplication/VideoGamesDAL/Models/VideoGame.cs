using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesDAL.Models
{
    public class VideoGame
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }

        // foreign keys
        public string System { get; set; }
        public string Genre { get; set; }
        public string ESRB { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
    }
}
