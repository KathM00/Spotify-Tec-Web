namespace spotify.Models
{
    public class PlaylistSong
    {
        public Guid SongId { get; set; }
        public Song Song { get; set; } = default!;
        
        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
