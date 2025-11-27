using Microsoft.AspNetCore.Mvc;
using spotify.Services;

namespace spotify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistSongController : ControllerBase
    {
        private readonly IPlaylistSongService _playlistSongService;
        public PlaylistSongController(IPlaylistSongService playlistSongService)
        {
            _playlistSongService = playlistSongService;
        }
        [HttpPost("{playlistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToPlaylist(Guid playlistId, Guid songId)
        {
            await _playlistSongService.AddSongToPlaylistAsync(playlistId, songId);
            return NoContent();
        }
        [HttpDelete("{playlistId}/songs/{songId}")]
        public async Task<IActionResult> RemoveSongFromPlaylist(Guid playlistId, Guid songId)
        {
            await _playlistSongService.RemoveSongFromPlaylistAsync(playlistId, songId);
            return NoContent();
        }
    }
}
