﻿using System;
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
    public class VideoGamesController : ControllerBase
    {
        private readonly VideoGamesDBContext _context;

        public VideoGamesController(VideoGamesDBContext context)
        {
            _context = context;
        }

        // GET: api/VideoGames
        [HttpGet]
        public IEnumerable<VideoGames> GetVideoGames()
        {
            return _context.VideoGames;
        }

        // GET: api/VideoGames/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVideoGames([FromRoute] int id)
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

            return Ok(videoGames);
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