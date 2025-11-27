using Microsoft.EntityFrameworkCore;
using spotify.Data;
using spotify.Models;

namespace spotify.Repositories
{
    public class PlaylistSongRepository : IPlaylistSongRepository
    {
        private readonly AppDbContext _context;
        public PlaylistSongRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PlaylistSong> AddAsync(PlaylistSong playlistSong)
        {
            await _context.PlaylistSongs.AddAsync(playlistSong);
            await _context.SaveChangesAsync();
            return playlistSong;
        }
        public async Task<bool> ExistsAsync(Guid playlistId, Guid songId)
        {
            return await _context.PlaylistSongs.AnyAsync(ps => ps.PlaylistId == playlistId && ps.SongId == songId);
        }

        public async  Task<IEnumerable<PlaylistSong>> GetByPlaylistIdAsync(Guid playlistId)
        {
            return await _context.PlaylistSongs
                .Where(ps => ps.PlaylistId == playlistId)
                .ToListAsync();
        }

        public async Task<bool> RemoveAsync(Guid playlistId, Guid songId)
        {
            var entity = await _context.PlaylistSongs.FirstOrDefaultAsync(ps => ps.PlaylistId == playlistId && ps.SongId == songId);

            if (entity == null)
                return false;

            _context.PlaylistSongs.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
