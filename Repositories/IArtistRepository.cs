using spotify.Models;

namespace spotify.Repositories
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist?> GetArtistByIdAsync(Guid id);
        Task AddArtistAsync(Artist artist);
        Task AddArtistProfileAsync(ArtistProfile profile); // Método para añadir el perfil
        Task SaveChangesAsync();
    }
}