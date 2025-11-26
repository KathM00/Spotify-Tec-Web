namespace spotify.Models
{
    public class Song
    {
        Guid id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

    }
}
