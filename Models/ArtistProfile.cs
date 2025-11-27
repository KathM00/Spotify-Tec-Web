using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace spotify.Models
{
    public class ArtistProfile
    {
        [Key]
        public Guid Id { get; set; }
        public string Biography { get; set; }
        public string SocialMedia { get; set; }
        public DateTime DebutDate { get; set; }

        // Clave foránea
        public Guid ArtistId { get; set; }

        // Propiedad de navegación
        [ForeignKey("ArtistId")]
        [JsonIgnore]
        public virtual Artist? Artist { get; set; }
    }
}