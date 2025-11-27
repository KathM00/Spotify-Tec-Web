
using spotify.Models;
using spotify.Repositories;

namespace spotify.Services
{
    public class PlaylistSongService : IPlaylistSongService
    {
        private readonly IPlaylistSongRepository _repo;
        public PlaylistSongService(IPlaylistSongRepository repo)
        {
            _repo = repo;
        }
        public async Task AddSongToPlaylistAsync(Guid playlistId, Guid songId)
        {
            bool alreadyExists = await _repo.ExistsAsync(playlistId, songId);
            if (alreadyExists)
                throw new Exception("The song is alredy on the playlist.");

            
            var entity = new PlaylistSong
            {
                PlaylistId = playlistId,
                SongId = songId
            };

            
            await _repo.AddAsync(entity);
        }

        public async Task RemoveSongFromPlaylistAsync(Guid playlistId, Guid songId)
        {
            bool removed = await _repo.RemoveAsync(playlistId, songId);

            if (!removed)
                throw new Exception("The song is not on the playlist.");
        }
    }
}
