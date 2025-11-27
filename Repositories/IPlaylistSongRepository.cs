using spotify.Models;

namespace spotify.Repositories
{
    public interface IPlaylistSongRepository
    {
        Task <PlaylistSong> AddAsync(PlaylistSong playlistSong);
        Task<bool> RemoveAsync(Guid playlistId, Guid songId);
        Task<IEnumerable<PlaylistSong>> GetByPlaylistIdAsync(Guid playlistId);
        Task<bool> ExistsAsync(Guid playlistId, Guid songId);
    }
}
