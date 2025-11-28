using spotify.Models;
using spotify.Models.DTOS;

namespace spotify.Services
{
    public interface ISongService
    {
        Task<Song> CreateSongAsync(CreateSongDto dto);
        Task<Song?> GetSongByIdAsync(Guid songId);
        Task<IEnumerable<Song>> GetAllSongsAsync();
        Task<Song> UpdateSongAsync(UpdateSongDto dto, Guid id);
        Task<bool> DeleteSongAsync(Guid songId);
    }
}
