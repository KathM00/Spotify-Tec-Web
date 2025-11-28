using Microsoft.EntityFrameworkCore;
using spotify.Data;
using spotify.Models;

namespace spotify.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly AppDbContext _db;
        public PlaylistRepository(AppDbContext db)
        {
           _db = db;
        }

        public async Task<IEnumerable<Playlist>> GetAll()
        {
            return await _db.Playlists.ToListAsync();
        }

        public async Task<Playlist?> GetOne(Guid id)
        {
            return await _db.Playlists.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddPlaylist(Playlist playlist)
        {
            await _db.Playlists.AddAsync(playlist);
            await _db.SaveChangesAsync();
        }

        public async Task UpdatePlaylist(Playlist playlist)
        {
            _db.Playlists.Update(playlist);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePlaylist(Playlist playlist)
        {
            _db.Playlists.Remove(playlist);
            await _db.SaveChangesAsync();
        }

        public async Task AddSongToPlaylist(PlaylistSong playlistSong)
        {
             await _db.PlaylistSongs.AddAsync(playlistSong);
             await _db.SaveChangesAsync();
        }

        public async Task RemoveSongFromPlaylist(Guid playlistId, Guid songId)
        {
             var playlistSong = await _db.PlaylistSongs
                 .FirstOrDefaultAsync(ps => ps.PlaylistId == playlistId && ps.SongId == songId);

            if (playlistSong != null)
            {
                 _db.PlaylistSongs.Remove(playlistSong);
                 await _db.SaveChangesAsync();
            }
        }   
    }
}

