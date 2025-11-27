using Microsoft.EntityFrameworkCore;
using spotify.Models;

namespace spotify.Data
{

    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Song> Songs => Set<Song>();
        public DbSet<PlaylistSong> PlaylistSongs => Set<PlaylistSong>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasOne<Artist>(a=>a.Artist)
                .WithMany(s=>s.Songs)
                .HasForeignKey(s=>s.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlaylistSong>()
                .HasKey(pls=> new {pls.SongId, pls.PlaylistId});

        }
    }
}
