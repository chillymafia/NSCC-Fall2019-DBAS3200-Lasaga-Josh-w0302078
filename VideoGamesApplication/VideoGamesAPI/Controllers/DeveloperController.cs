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
    public class DeveloperController : ControllerBase
    {
        // GET: api/Developer
        [HttpGet]
        public IEnumerable<Developer> Get()
        {
            return DeveloperManager.GetDeveloperList();
        }

        // GET: api/Developer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Developer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Developer/5
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
