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
    public class VideoGamesController : ControllerBase
    {
        private readonly VideoGamesDBContext _context;

        public VideoGamesController(VideoGamesDBContext context)
        {
            _context = context;
        }

        // GET: api/VideoGames
        [HttpGet]
        public IEnumerable<VideoGamesDTO> GetVideoGames()
        {
            //return _context.VideoGames.Include(vg => vg.System);
            List<VideoGames> videoGames = _context
                .VideoGames
                .Include(vg => vg.GameGenre).ToList();

            List<VideoGamesDTO> videoGamesDTOList = new List<VideoGamesDTO>();

            //loop through the videogames list and make a new dto for each one
            //and add to the dto list
            foreach(VideoGames vg in videoGames)
            {
                //make a list of system dtos from the current videogame
                List<GameGenreDTO> GameGenreDTOList = new List<GameGenreDTO>();
                foreach(GameGenre gg in vg.GameGenre)
                {
                    //make a system dto
                    GameGenreDTO ggdto = new GameGenreDTO()
                    {
                        GameGenreID = gg.GameGenreId,
                        GenreID = gg.GenreId
                        
                    };

                    GameGenreDTOList.Add(ggdto);
                }


                //make an new dto
                VideoGamesDTO dto = new VideoGamesDTO()
                {
                    VideoGamesID = vg.Id,
                    Title = vg.Title,
                    System = new SystemDTO(),
                    ReleaseDate = vg.ReleaseDate,
                    ESRB = new ESRBDTO(),
                    Publisher = new PublisherDTO(),
                    GameGenre = new GameGenreDTO()

                };

                //add the dto to the dto list
                videoGamesDTOList.Add(dto);
            }

            //return the dto list
            return videoGamesDTOList;

        }

        // GET: api/VideoGames/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVideoGames([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var videoGames = await _context.VideoGames.Include(vg => vg.SystemNavigation).FirstAsync(vg => vg.Id == id);

            if (videoGames == null)
            {
                return NotFound();
            }

            //make a video game dto
            VideoGamesDTO dto = new VideoGamesDTO()
            {
                VideoGamesID = videoGames.Id,
                Title = videoGames.Title,
               // System = s
            };

            //foreach(VideoGamesAPI.Models.System sys in videoGames.SystemNavigation)
            {
                SystemDTO sysdto = new SystemDTO()
                {
                  //  SystemID = sys.SystemID,
                  //  Name = sys.Name,
                  //  Company = sys.Company
                };

                //add the system to the videogames system
               // dto.System.Add(sysdto);

            }

            return Ok(dto);
        }

        // PUT: api/VideoGames/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoGames([FromRoute] int id, [FromBody] VideoGames videoGames)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != videoGames.Id)
            {
                return BadRequest();
            }

            _context.Entry(videoGames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGamesExists(id))
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

        // POST: api/VideoGames
        [HttpPost]
        public async Task<IActionResult> PostVideoGames([FromBody] VideoGames videoGames)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VideoGames.Add(videoGames);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoGames", new { id = videoGames.Id }, videoGames);
        }

        // DELETE: api/VideoGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGames([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var videoGames = await _context.VideoGames.FindAsync(id);
            if (videoGames == null)
            {
                return NotFound();
            }

            _context.VideoGames.Remove(videoGames);
            await _context.SaveChangesAsync();

            return Ok(videoGames);
        }

        private bool VideoGamesExists(int id)
        {
            return _context.VideoGames.Any(e => e.Id == id);
        }
    }
}