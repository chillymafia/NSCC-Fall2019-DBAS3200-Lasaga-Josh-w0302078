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
    public class EsrbsController : ControllerBase
    {
        private readonly VideoGamesDBContext _context;

        public EsrbsController(VideoGamesDBContext context)
        {
            _context = context;
        }

        // GET: api/Esrbs
        [HttpGet]
        public IEnumerable<Esrb> GetEsrb()
        {
            return _context.Esrb;
        }

        // GET: api/Esrbs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEsrb([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var esrb = await _context.Esrb.FindAsync(id);

            if (esrb == null)
            {
                return NotFound();
            }

            return Ok(esrb);
        }

        // PUT: api/Esrbs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEsrb([FromRoute] int id, [FromBody] Esrb esrb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != esrb.Esrbid)
            {
                return BadRequest();
            }

            _context.Entry(esrb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EsrbExists(id))
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

        // POST: api/Esrbs
        [HttpPost]
        public async Task<IActionResult> PostEsrb([FromBody] Esrb esrb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Esrb.Add(esrb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEsrb", new { id = esrb.Esrbid }, esrb);
        }

        // DELETE: api/Esrbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEsrb([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var esrb = await _context.Esrb.FindAsync(id);
            if (esrb == null)
            {
                return NotFound();
            }

            _context.Esrb.Remove(esrb);
            await _context.SaveChangesAsync();

            return Ok(esrb);
        }

        private bool EsrbExists(int id)
        {
            return _context.Esrb.Any(e => e.Esrbid == id);
        }
    }
}