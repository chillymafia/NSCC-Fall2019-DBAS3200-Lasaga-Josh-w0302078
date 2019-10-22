using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookDAL.Models
{
    //ScalarProperties
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public double UnitPrice { get; set; }

        //NAVIGATION PROPERTIES
        private Genre _genre;
        public Genre Genre
        { //ONE
            get
            {
                if (_genre == null)
                {
                    _genre = GenreManager.GetGenreById(GenreId);
                }

                return _genre;
            }
        }
    }
}
