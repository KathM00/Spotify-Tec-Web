using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace spotify.Models
{
    public class Artist
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }

        // Relación 1 a 1: Un artista tiene un perfil
        public virtual ArtistProfile? ArtistProfile { get; set; }

        // Relación 1 a muchos: Un artista tiene muchas canciones
        // [JsonIgnore] evita ciclos infinitos al serializar si Song tiene referencia de vuelta
        [JsonIgnore]
        public virtual ICollection<Song>? Songs { get; set; }
    }
}