using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDAL;
using VideoGamesDAL.Models;

namespace VideoGamesDAL.Models
{
    public class VideoGame
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }

        // foreign keys
        public string System { get; set; }
        //public string Genre { get; set; }
        public string ESRB { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }

        //navigation properties
        //private Genre _genre;
        //public Genre Genre
        //{
        //    get
        //    {
        //        if(_genre == null)
        //        {
        //            _genre = GenreManager.GetGenre(GenreID);
        //        }
        //    }
        //    return _genre;
        //}

        //private ESRB _esrb;
        //public ESRB ESRB
        //{
        //    get
        //    {
        //        if (_ESRB == null)
        //        {
        //            _esrb = GenreManager.GetGenre(ESRBID);
        //        }
        //    }
        //    return _esrb;
        //}

    }
}
