using Microsoft.AspNetCore.Mvc;
using spotify.Models.DTOS;
using spotify.Services;

namespace spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist == null) return NotFound();
            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistDto artistDto)
        {
            var createdArtist = await _artistService.CreateArtistAsync(artistDto);
            return CreatedAtAction(nameof(GetById), new { id = createdArtist.Id }, createdArtist);
        }

        // Endpoint especial para crear el perfil del artista
        [HttpPost("{id}/profile")]
        public async Task<IActionResult> CreateProfile(Guid id, [FromBody] CreateArtistProfileDto profileDto)
        {
            try
            {
                var createdProfile = await _artistService.CreateArtistProfileAsync(id, profileDto);
                return Ok(createdProfile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}