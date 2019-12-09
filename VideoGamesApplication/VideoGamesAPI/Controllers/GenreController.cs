using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGamesDAL;
using VideoGamesDAL.Models;

namespace VideoGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        // GET: api/Genre
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return GenreManager.GetGenreList();
        }

        // GET: api/Genre/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST: api/Genre
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
