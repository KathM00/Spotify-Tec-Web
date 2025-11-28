using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spotify.Models;
using spotify.Models.DTOS;
using spotify.Services;

namespace spotify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _service;
        public PlaylistController(IPlaylistService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPlaylists()
        {
            var items = await _service.GetAll();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var playlist = await _service.GetOne(id);
            return Ok(playlist);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePlaylist([FromBody] CreatePlaylistDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var playlist = await _service.Create(dto);

            return CreatedAtAction(nameof(GetOne), new { id = playlist.Id }, playlist);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdatePlaylist(Guid id, [FromBody] UpdatePlaylistDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var playlist = await _service.Update(dto, id);
            return Ok(playlist);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeletePlaylist(Guid id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        [HttpPost("{id:guid}/songs")]
        [Authorize]
        public async Task<IActionResult> AddSongToPlaylist(Guid id, [FromBody] AddSongToPlaylistDto dto)
        {
            await _service.AddSong(id, dto);
            return Ok(new { message = "Song added to playlist successfully" });
        }

        [HttpDelete("{playlistId:guid}/songs/{songId:guid}")]
        [Authorize]
        public async Task<IActionResult> RemoveSongFromPlaylist(Guid playlistId, Guid songId)
        {
            await _service.RemoveSong(playlistId, songId);
            return NoContent();
        }
    }
}
