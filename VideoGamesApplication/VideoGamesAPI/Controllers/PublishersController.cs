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
    public class PublishersController : ControllerBase
    {
        private readonly VideoGamesDBContext _context;

        public PublishersController(VideoGamesDBContext context)
        {
            _context = context;
        }

        // GET: api/Publishers
        [HttpGet]
        public IEnumerable<PublisherDTO> GetPublisher()
        {
            List<Publisher> publishers = _context.Publisher.Include(pb => pb.VideoGames).ToList();

            List<PublisherDTO> publisherDTOList = new List<PublisherDTO>();

            foreach(Publisher pb in publishers)
            {
                List<VideoGamesDTO> videogamesDTOList = new List<VideoGamesDTO>();
                foreach(VideoGames vg in pb.VideoGames)
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

                PublisherDTO dto = new PublisherDTO()
                {
                    PubID = pb.PubId,
                    Name = pb.Name
                };

                publisherDTOList.Add(dto);
            }

            return publisherDTOList;
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publisher = await _context.Publisher.Include(pb => pb.VideoGames).FirstAsync(pb => pb.PubId == id);

            if (publisher == null)
            {
                return NotFound();
            }

            PublisherDTO dto = new PublisherDTO()
            {
                PubID = publisher.PubId,
                Name = publisher.Name,
                VideoGames = new List<VideoGamesDTO>()
            };

            foreach(VideoGames vg in publisher.VideoGames)
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

        // PUT: api/Publishers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher([FromRoute] int id, [FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publisher.PubId)
            {
                return BadRequest();
            }

            _context.Entry(publisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
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

        // POST: api/Publishers
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Publisher.Add(publisher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublisher", new { id = publisher.PubId }, publisher);
        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publisher = await _context.Publisher.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _context.Publisher.Remove(publisher);
            await _context.SaveChangesAsync();

            return Ok(publisher);
        }

        private bool PublisherExists(int id)
        {
            return _context.Publisher.Any(e => e.PubId == id);
        }
    }
}