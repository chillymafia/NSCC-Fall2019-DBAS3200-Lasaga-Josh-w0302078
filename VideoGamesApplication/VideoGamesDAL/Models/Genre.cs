﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesDAL.Models
{
    public class Genre
    {
        //SCALAR PROPERTIES
        public int GenreID { get; set; }
        public string Name { get; set; }

        //navigation properties
        private List<VideoGame> _videogames;

        public List<VideoGame> VideoGames
        {
            get
            {
                if(_videogames == null)
                {
                    _videogames = VideoGamesManager.GetVideoGameList(GenreID);
                }
                return _videogames;
            }
        }
    }
}
