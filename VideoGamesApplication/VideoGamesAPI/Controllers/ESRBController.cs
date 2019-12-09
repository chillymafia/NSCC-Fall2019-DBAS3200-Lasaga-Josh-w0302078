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
    public class ESRBController : ControllerBase
    {
        // GET: api/ESRB
        [HttpGet]
        public IEnumerable<ESRB> Get()
        {
            return ESRBManager.GetESRBList();
        }

        // GET: api/ESRB/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ESRB
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ESRB/5
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
