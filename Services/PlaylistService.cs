using System.Security.Claims;
using spotify.Data;
using spotify.Models;
using spotify.Models.DTOS;
using spotify.Repositories;


namespace spotify.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _repo;
        private readonly AppDbContext _db;
        private readonly IHttpContextAccessor _context;

        public PlaylistService(IPlaylistRepository repo, AppDbContext db, IHttpContextAccessor context)
        {
            _repo = repo;
            _db = db;
            _context = context;
        }

        public async Task<IEnumerable<Playlist>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Playlist> GetOne(Guid id)
        {
            var playlist = await _repo.GetOne(id);
            if (playlist == null) throw new Exception("Playlist not found.");
            return playlist;
        }

        public async Task<Playlist> Create(CreatePlaylistDto dto)
        {
            var userId = Guid.Parse(
                _context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
            );

            var playlist = new Playlist
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                IsPublic = dto.IsPublic,
                UserId = userId
            };

            await _repo.AddPlaylist(playlist);
            return playlist;
        }

        public async Task<Playlist> Update(UpdatePlaylistDto dto, Guid id)
        {
            var playlist = await _repo.GetOne(id);
            if (playlist == null) throw new Exception("Playlist not found.");

            if (!string.IsNullOrEmpty(dto.Name))
                playlist.Name = dto.Name;
            if (dto.IsPublic.HasValue)
                playlist.IsPublic = dto.IsPublic.Value;

            await _repo.UpdatePlaylist(playlist);
            return playlist;
        }

        public async Task Delete(Guid id)
        {
            var playlist = await _repo.GetOne(id);
            if (playlist == null) throw new Exception("Playlist not found.");
            await _repo.DeletePlaylist(playlist);
        }

        public async Task AddSong(Guid playlistId, AddSongToPlaylistDTO dto)
        {
            var playlist = await _repo.GetOne(playlistId);
            if (playlist == null) throw new Exception("Playlist not found.");

            var song = await _db.Songs.FindAsync(dto.SongId);
            if (song == null) throw new Exception("Song not found.");
            await _repo.AddSongToPlaylist(playlist, song);
        }

        public async Task RemoveSong(Guid playlistId, Guid songId)
        {
            var playlist = await _repo.GetOne(playlistId);
            if (playlist == null) throw new Exception("Playlist not found.");

            var song = playlist.Songs.FirstOrDefault(x => x.Id == songId);
            if (song == null) throw new Exception("Song not found in playlist.");
            await _repo.RemoveSongFromPlaylist(playlist, song);
        }
    }
}