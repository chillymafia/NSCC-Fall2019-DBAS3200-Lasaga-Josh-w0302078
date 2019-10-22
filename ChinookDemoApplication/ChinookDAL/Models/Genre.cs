using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookDAL.Models
{
    public class Genre
    {
        //SCALAR PROPERTIES
        public int GenreId { get; set; }
        public string Name { get; set; }

        //NAVIGATION PROPERtIES\
        private List<Track> _tracks;
        public List<Track> Tracks {
            get {
                if (_tracks == null)
                {
                    _tracks = TrackManager.GetGenreTracks(GenreId); 
                }

                return _tracks;
            }

            
        }

        //Genre g = new Genre()

        //g.Tracks
    }
}
