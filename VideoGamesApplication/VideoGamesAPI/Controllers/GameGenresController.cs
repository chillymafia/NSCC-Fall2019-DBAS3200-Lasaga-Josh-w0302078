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
    public class GameGenresController : ControllerBase
    {
        private readonly VideoGamesDBContext _context;

        public GameGenresController(VideoGamesDBContext context)
        {
            _context = context;
        }

        // GET: api/GameGenres
        [HttpGet]
        public IEnumerable<GameGenre> GetGameGenre()
        {
            return _context.GameGenre;
        }

        // GET: api/GameGenres/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameGenre([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameGenre = await _context.GameGenre.FindAsync(id);

            if (gameGenre == null)
            {
                return NotFound();
            }

            return Ok(gameGenre);
        }

        // PUT: api/GameGenres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameGenre([FromRoute] int id, [FromBody] GameGenre gameGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameGenre.GameGenreId)
            {
                return BadRequest();
            }

            _context.Entry(gameGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameGenreExists(id))
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

        // POST: api/GameGenres
        [HttpPost]
        public async Task<IActionResult> PostGameGenre([FromBody] GameGenre gameGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GameGenre.Add(gameGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameGenre", new { id = gameGenre.GameGenreId }, gameGenre);
        }

        // DELETE: api/GameGenres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameGenre([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameGenre = await _context.GameGenre.FindAsync(id);
            if (gameGenre == null)
            {
                return NotFound();
            }

            _context.GameGenre.Remove(gameGenre);
            await _context.SaveChangesAsync();

            return Ok(gameGenre);
        }

        private bool GameGenreExists(int id)
        {
            return _context.GameGenre.Any(e => e.GameGenreId == id);
        }
    }
}