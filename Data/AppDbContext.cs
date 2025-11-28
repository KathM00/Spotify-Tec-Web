using Microsoft.EntityFrameworkCore;
using spotify.Models;

namespace spotify.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Playlists)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

         
            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Songs)
                .WithMany(s => s.Playlists)
                .UsingEntity(j => j.ToTable("PlaylistSongs"));
           
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Playlist>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Song>()
                .Property(s => s.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
