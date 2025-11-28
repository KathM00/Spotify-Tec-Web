using spotify.Models;

namespace spotify.Repositories
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetAll();
        Task<Playlist?> GetOne(Guid id);
        Task AddPlaylist(Playlist playlist);
        Task UpdatePlaylist(Playlist playlist);
        Task DeletePlaylist(Playlist playlist);
        Task AddSongToPlaylist(PlaylistSong playlistSong);
        Task RemoveSongFromPlaylist(Guid playlistId, Guid songId);
    }
}
