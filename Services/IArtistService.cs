using spotify.Models;
using spotify.Models.DTOS;

namespace spotify.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist?> GetArtistByIdAsync(Guid id);
        Task<Artist> CreateArtistAsync(CreateArtistDto request);
        Task<ArtistProfile> CreateArtistProfileAsync(Guid artistId, CreateArtistProfileDto request);
    }
}