namespace spotify.Models
{

    public class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public bool IsPublic { get; set; }
        public User User { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
    }
}
