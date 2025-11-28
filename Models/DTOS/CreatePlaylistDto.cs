using System.ComponentModel.DataAnnotations;

namespace spotify.Models.DTOS
{
    public class CreatePlaylistDto
    {
        [Required]

        [MaxLength(50)]
        public string Name { get; set; }
        public bool IsPublic { get; set; }
    }
}
