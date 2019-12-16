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
    public class DevelopersController : ControllerBase
    {
        private readonly VideoGamesDBContext _context;

        public DevelopersController(VideoGamesDBContext context)
        {
            _context = context;
        }

        // GET: api/Developers
        [HttpGet]
        public IEnumerable<DeveloperDTO> GetDeveloper()
        {
            List<Developer> developers = _context.Developer.Include(dv => dv.VideoGames).ToList();

            List<DeveloperDTO> developerDTOList = new List<DeveloperDTO>();

            foreach (Developer dv in developers)
            {
                List<VideoGamesDTO> videogamesDTOList = new List<VideoGamesDTO>();
                foreach (VideoGames vg in dv.VideoGames)
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

                DeveloperDTO dvdto = new DeveloperDTO()
                {
                    DevID = dv.DevId,
                    Name = dv.Name
                };

                developerDTOList.Add(dvdto);
            }

            return developerDTOList;
        }

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeveloper([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var developer = await _context.Developer.Include(dv => dv.VideoGames).FirstAsync(dv => dv.DevId == id);

            if (developer == null)
            {
                return NotFound();
            }
            DeveloperDTO dto = new DeveloperDTO()
            {
                DevID = developer.DevId,
                Name = developer.Name,
                VideoGames = new List<VideoGamesDTO>()
            };

            foreach (VideoGames vg in developer.VideoGames)
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

                dto.VideoGames.Add(vgdto);
            }

            return Ok(dto);

        }

        // PUT: api/Developers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeveloper([FromRoute] int id, [FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != developer.DevId)
            {
                return BadRequest();
            }

            _context.Entry(developer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(id))
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

        // POST: api/Developers
        [HttpPost]
        public async Task<IActionResult> PostDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Developer.Add(developer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeveloper", new { id = developer.DevId }, developer);
        }

        // DELETE: api/Developers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeveloper([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var developer = await _context.Developer.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }

            _context.Developer.Remove(developer);
            await _context.SaveChangesAsync();

            return Ok(developer);
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developer.Any(e => e.DevId == id);
        }
    }
}