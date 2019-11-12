using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesDAL.Models
{
    public class System
    {
        //SCALAR PROPERTIES
        public int SystemID { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
    }
    private List<VideoGame> _videogames;
    public List<VideoGame> VideoGames
    {
        get
        {
            if (_videogames == null)
            {
                _videogames = VideoGamesManager.GetVideoGameList(SystemID);
            }
            return _videogames;
        }
    }
}
