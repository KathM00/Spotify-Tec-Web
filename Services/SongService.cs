using spotify.Models;
using spotify.Models.DTOS;
using spotify.Repositories;

namespace spotify.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }
        public async Task<Song> CreateSongAsync(CreateSongDto dto)
        {
            var song = new Song
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                ArtistId = dto.ArtistId,
                Duration = dto.Duration,
            };
            await _songRepository.CreateSongAsync(song);
            return song;
        }

        public async Task<bool> DeleteSongAsync(Guid songId)
        {
            Song? song = (await _songRepository.GetSongByIdAsync(songId));
            if (song == null)
                return false;
            await _songRepository.DeleteSongAsync(songId);
            return true;
        }

        public Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            return _songRepository.GetAllSongsAsync();
        }

        public Task<Song?> GetSongByIdAsync(Guid songId)
        {
            return _songRepository.GetSongByIdAsync(songId);
        }

        public async Task<Song> UpdateSongAsync(UpdateSongDto dto, Guid id)
        {
            var existingSong = await _songRepository.GetSongByIdAsync(id);
            if (existingSong == null)
            {
                throw new Exception("Song not found");
            }
            existingSong.Title = dto.Title;
           
            existingSong.Duration = dto.Duration;
            existingSong.Description = dto.Description;
            await _songRepository.UpdateSongAsync(existingSong);
            return existingSong;

        }
    }
}
