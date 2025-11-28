using Microsoft.EntityFrameworkCore;
using spotify.Models;

namespace spotify.Data
{

    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Domain sets
        public DbSet<Song> Songs => Set<Song>();
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<User> Users => Set<User>();
        public DbSet<ArtistProfile> ArtistProfiles => Set<ArtistProfile>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Song -> Artist (many songs to one artist)
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            
            

            



            base.OnModelCreating(modelBuilder);
        }
    }
}
