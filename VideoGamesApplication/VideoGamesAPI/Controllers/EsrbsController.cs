using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGamesAPI.Models;
using VideoGamesAPI.Models.DTOs;

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
        public IEnumerable<ESRBDTO> GetEsrb()
        {
            List<Esrb> esrb = _context.Esrb.Include(es => es.VideoGames).ToList();

            List<ESRBDTO> esrbDTOList = new List<ESRBDTO>();

            foreach (Esrb es in esrb)
            {
                List<VideoGamesDTO> videogamesDTOList = new List<VideoGamesDTO>();
                foreach (VideoGames vg in es.VideoGames)
                {
                    VideoGamesDTO vgDTO = new VideoGamesDTO()
                    {
                        VideoGamesID = vg.Id,
                        Title = vg.Title,
                        System = vg.System,
                        ReleaseDate = vg.ReleaseDate,
                        ESRB = vg.Esrb,
                        Publisher = vg.Publisher,
                        Developer = vg.Developer
                    };

                    videogamesDTOList.Add(vgDTO);
                }

                ESRBDTO esdto = new ESRBDTO()
                {
                    ESRBID = es.Esrbid,
                    Rating = es.Rating
                };

                esrbDTOList.Add(esdto);
            }

            return esrbDTOList;
        }

        // GET: api/Esrbs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEsrb([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var esrb = await _context.Esrb.Include(es => es.VideoGames).FirstAsync(es => es.Esrbid == id);

            if (esrb == null)
            {
                return NotFound();
            }

            ESRBDTO esdto = new ESRBDTO()
            {
                ESRBID = esrb.Esrbid,
                Rating = esrb.Rating,
                VideoGames = new List<VideoGamesDTO>()
            };

            foreach (VideoGames vg in esrb.VideoGames)
            {
                VideoGamesDTO vgdto = new VideoGamesDTO()
                {
                    VideoGamesID = vg.Id,
                    Title = vg.Title,
                    System = vg.System,
                    ReleaseDate = vg.ReleaseDate,
                    ESRB = vg.Esrb,
                    Publisher = vg.Publisher,
                    Developer = vg.Developer
                };

                esdto.VideoGames.Add(vgdto);
            }

            return Ok(esdto);
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