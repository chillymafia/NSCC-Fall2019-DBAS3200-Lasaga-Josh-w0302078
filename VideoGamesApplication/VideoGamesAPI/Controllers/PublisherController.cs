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
    public class PublisherController : ControllerBase
    {
        // GET: api/Publisher
        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            return PublisherManager.GetPublisherList();
        }

        // GET: api/Publisher/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Publisher
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Publisher/5
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
