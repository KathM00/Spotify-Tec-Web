namespace spotify.Services
{
    public interface IPlaylistSongService
    {
        Task AddSongToPlaylistAsync(Guid playlistId, Guid songId);
        Task RemoveSongFromPlaylistAsync(Guid playlistId, Guid songId);
        
    }
}
