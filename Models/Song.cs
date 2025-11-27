namespace spotify.Models
{
    public class Song
    {
        public Guid id { get; set; }
        public string Title { get; set; } =default!;
        public int Duration { get; set; }
        public string Description { get; set; }
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; } = default!;
        public ICollection <PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
    }
}

