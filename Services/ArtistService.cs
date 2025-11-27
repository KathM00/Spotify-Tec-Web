using spotify.Models;
using spotify.Models.DTOS;
using spotify.Repositories;

namespace spotify.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _repository;

        public ArtistService(IArtistRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _repository.GetAllArtistsAsync();
        }

        public async Task<Artist?> GetArtistByIdAsync(Guid id)
        {
            return await _repository.GetArtistByIdAsync(id);
        }

        public async Task<Artist> CreateArtistAsync(CreateArtistDto request)
        {
            var newArtist = new Artist
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                OriginCountry = request.OriginCountry
            };

            await _repository.AddArtistAsync(newArtist);
            await _repository.SaveChangesAsync();
            return newArtist;
        }

        public async Task<ArtistProfile> CreateArtistProfileAsync(Guid artistId, CreateArtistProfileDto request)
        {
            // Verificamos si el artista existe
            var artist = await _repository.GetArtistByIdAsync(artistId);
            if (artist == null) throw new Exception("Artist not found");

            var newProfile = new ArtistProfile
            {
                Id = Guid.NewGuid(),
                Biography = request.Biography,
                SocialMedia = request.SocialMedia,
                DebutDate = request.DebutDate,
                ArtistId = artistId
            };

            await _repository.AddArtistProfileAsync(newProfile);
            await _repository.SaveChangesAsync();
            return newProfile;
        }
    }
}