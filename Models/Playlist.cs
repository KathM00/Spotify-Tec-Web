using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using spotify.Models;

namespace spotify.Models
{
    public class Playlist
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public bool IsPublic { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
