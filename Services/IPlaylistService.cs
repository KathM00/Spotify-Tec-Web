using spotify.Models.DTOS;
using spotify.Models;

namespace spotify.Services
{
    public interface IPlaylistService
    {
        Task<IEnumerable<Playlist>> GetAll();
        Task<Playlist> GetOne(Guid id);
        Task<Playlist> Create(CreatePlaylistDto dto);
        Task<Playlist> Update(UpdatePlaylistDto dto, Guid id);
        Task Delete(Guid id);
        Task AddSong(Guid playlistId, AddSongToPlaylistDto dto);
        Task RemoveSong(Guid playlistId, Guid songId);
    }
}
