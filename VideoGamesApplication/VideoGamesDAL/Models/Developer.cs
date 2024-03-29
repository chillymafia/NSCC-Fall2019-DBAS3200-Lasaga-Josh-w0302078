﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesDAL.Models
{
    public class Developer
    {
        //SCALAR PROPERTIES
        public int DevID { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        private List<VideoGame> _videogames;
        public List<VideoGame> VideoGames
        {
            get
            {
                if (_videogames == null)
                {
                    _videogames = VideoGamesManager.GetVideoGameList(DevID);
                }
                return _videogames;
            }
        }
    }
}
