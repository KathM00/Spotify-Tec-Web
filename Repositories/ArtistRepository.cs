using Microsoft.EntityFrameworkCore;
using spotify.Data;
using spotify.Models;

namespace spotify.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly AppDbContext _context;

        public ArtistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            // Incluimos el perfil al traer la lista
            return await _context.Artists.Include(a => a.ArtistProfile).ToListAsync();
        }

        public async Task<Artist?> GetArtistByIdAsync(Guid id)
        {
            return await _context.Artists
                .Include(a => a.ArtistProfile)
                .Include(a => a.Songs) // Opcional: si quieres ver sus canciones
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddArtistAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
        }

        public async Task AddArtistProfileAsync(ArtistProfile profile)
        {
            await _context.ArtistProfiles.AddAsync(profile);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}