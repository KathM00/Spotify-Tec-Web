using spotify.Models;

namespace spotify.Repositories
{
    public interface ISongRepository
    {
       
        Task<Song> CreateSongAsync(Song song);
        Task<Song?> GetSongByIdAsync(Guid songId);
        Task<IEnumerable<Song>> GetAllSongsAsync();
        Task<Song> UpdateSongAsync(Song song);
        Task<bool> DeleteSongAsync(Guid songId);


    }
}
