using System.ComponentModel.DataAnnotations;

namespace spotify.Models.DTOS
{
    public class CreateSongDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
    }
}
