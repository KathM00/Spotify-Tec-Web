using System.ComponentModel.DataAnnotations;

namespace spotify.Models.DTOS
{
    public class AddSongToPlaylistDto
    {
        [Required]
        public Guid SongId { get; set; }

        [Required]
        public Guid PlaylistId { get; set; }
    }

}
