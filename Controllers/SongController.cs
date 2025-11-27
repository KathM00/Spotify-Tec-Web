using Microsoft.AspNetCore.Mvc;
using spotify.Models.DTOS;
using spotify.Services;

namespace spotify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            var songs = await _songService.GetAllSongsAsync();
            return Ok(songs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSongById(Guid id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null)
                return NotFound();
            return Ok(song);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSong([FromBody] CreateSongDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var song = await _songService.CreateSongAsync(dto);
            return CreatedAtAction(nameof(GetSongById), new { id = song.Id }, song);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong(Guid id, [FromBody] UpdateSongDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var song = await _songService.UpdateSongAsync(dto, id);
            return Ok(song);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(Guid id)
        {
            var result = await _songService.DeleteSongAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }

    }
}
