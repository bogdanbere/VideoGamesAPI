using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGamesCollection.Data;
using VideoGamesCollection.Models;

namespace VideoGamesCollection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGameController : ControllerBase
    {
        private readonly VideoGameDbContext _db;

        public VideoGameController(VideoGameDbContext db) => _db = db;

        [HttpGet(Name = "GetVideoGames")]
        public async Task<IEnumerable<VideoGame>> Get() =>
            await _db.VideoGames.ToListAsync();

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var vgGetbyId = await _db.VideoGames.FindAsync(id);
            if (vgGetbyId is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vgGetbyId);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(VideoGame game)
        {
            await _db.VideoGames.AddAsync(game);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { name = game.Title }, game);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, VideoGame game)
        {
            if (id != game.Id)
                return BadRequest();

            _db.Entry(game).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var gameExists = await _db.VideoGames.FindAsync(id);
            if (gameExists is null)
            {
                return NotFound();
            }
            else
            {
                _db.VideoGames.Remove(gameExists);
                await _db.SaveChangesAsync();
                return NoContent();
            }




        }

    }
}