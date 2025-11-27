using spotify.Data;
using spotify.Models;

namespace spotify.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly AppDbContext _context;
        public SongRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Song> CreateSongAsync(Song song)
        {
            await _context.Songs.AddAsync(song);
            await  _context.SaveChangesAsync();
            return song;
        }

        public  async Task<bool> DeleteSongAsync(Guid songId)
        {
            var existing = await _context.Songs.FindAsync(songId);

            if (existing == null)
                return false;

            _context.Songs.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song?> GetSongByIdAsync(Guid songId)
        {
            return await _context.Songs.FirstOrDefaultAsync(s => s.id == songId);
        }

        public async Task<Song> UpdateSongAsync(Song song)
        {
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
            return song;
        }
    }
}
