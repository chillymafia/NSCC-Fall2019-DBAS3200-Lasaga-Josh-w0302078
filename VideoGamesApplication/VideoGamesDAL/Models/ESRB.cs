using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesDAL.Models
{
    public class ESRB
    {
        //SCALAR PROPERTIES
        public int ESRBID { get; set; }
        public string Rating { get; set; }


        private List<VideoGame> _videogames;
        public List<VideoGame> VideoGames
        {
            get
            {
                if (_videogames == null)
                {
                    _videogames = VideoGamesManager.GetVideoGameList(ESRBID);
                }
                return _videogames;
            }
        }
    }

}
