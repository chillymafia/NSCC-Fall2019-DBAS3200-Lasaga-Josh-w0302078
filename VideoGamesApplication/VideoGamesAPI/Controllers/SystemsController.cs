using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGamesAPI.Models;

namespace VideoGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemsController : ControllerBase
    {
        private readonly VideoGamesDBContext _context;

        public SystemsController(VideoGamesDBContext context)
        {
            _context = context;
        }

        // GET: api/Systems
        [HttpGet]
        public IEnumerable<VideoGamesAPI.Models.System> GetSystem()
        {
            //LINQ query language
            return _context.System;
        }

        // GET: api/Systems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSystem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var system = await _context.System.FindAsync(id);

            if (system == null)
            {
                return NotFound();
            }

            return Ok(system);
        }

        // PUT: api/Systems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystem([FromRoute] int id, [FromBody] VideoGamesAPI.Models.System system)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != system.SystemId)
            {
                return BadRequest();
            }

            _context.Entry(system).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Systems
        [HttpPost]
        public async Task<IActionResult> PostSystem([FromBody] VideoGamesAPI.Models.System system)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.System.Add(system);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystem", new { id = system.SystemId }, system);
        }

        // DELETE: api/Systems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var system = await _context.System.FindAsync(id);
            if (system == null)
            {
                return NotFound();
            }

            _context.System.Remove(system);
            await _context.SaveChangesAsync();

            return Ok(system);
        }

        private bool SystemExists(int id)
        {
            return _context.System.Any(e => e.SystemId == id);
        }
    }
}