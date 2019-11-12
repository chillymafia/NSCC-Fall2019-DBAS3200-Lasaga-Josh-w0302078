using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesDAL.Models
{
    public class Publisher
    {
        //SCALAR PROPERTIES
        public int PubID { get; set; }
        public string Name { get; set; }
    }
    private List<VideoGame> _videogames;
    public List<VideoGame> VideoGames
    {
        get
        {
            if (_videogames == null)
            {
                _videogames = VideoGamesManager.GetVideoGameList(PubID);
            }
            return _videogames;
        }
    }
}
