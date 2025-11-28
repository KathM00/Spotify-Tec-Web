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
        Task AddSongToPlaylist(Playlist playlist, Song song);
        Task RemoveSongFromPlaylist(Playlist playlist, Song song);

    }
}
