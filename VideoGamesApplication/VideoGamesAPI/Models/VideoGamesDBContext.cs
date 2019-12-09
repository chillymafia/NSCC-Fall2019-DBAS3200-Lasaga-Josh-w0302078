using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VideoGamesAPI.Models
{
    public partial class VideoGamesDBContext : DbContext
    {
        public VideoGamesDBContext()
        {
        }

        public VideoGamesDBContext(DbContextOptions<VideoGamesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Developer> Developer { get; set; }
        public virtual DbSet<Esrb> Esrb { get; set; }
        public virtual DbSet<GameGenre> GameGenre { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<System> System { get; set; }
        public virtual DbSet<VideoGames> VideoGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=VideoGamesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>(entity =>
            {
                entity.HasKey(e => e.DevId);

                entity.Property(e => e.DevId).HasColumnName("DevID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Esrb>(entity =>
            {
                entity.ToTable("ESRB");

                entity.Property(e => e.Esrbid).HasColumnName("ESRBID");

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.Property(e => e.GameGenreId).HasColumnName("GameGenreID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameGenre)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game-Genre_ToGame");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GameGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game-Genre_ToGenre");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PubId);

                entity.Property(e => e.PubId).HasColumnName("PubID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<System>(entity =>
            {
                entity.Property(e => e.SystemId).HasColumnName("SystemID");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<VideoGames>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Esrb).HasColumnName("ESRB");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.DeveloperNavigation)
                    .WithMany(p => p.VideoGames)
                    .HasForeignKey(d => d.Developer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoGames_ToDeveloper");

                entity.HasOne(d => d.EsrbNavigation)
                    .WithMany(p => p.VideoGames)
                    .HasForeignKey(d => d.Esrb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoGames_ToESRB");

                entity.HasOne(d => d.PublisherNavigation)
                    .WithMany(p => p.VideoGames)
                    .HasForeignKey(d => d.Publisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoGames_ToPublisher");

                entity.HasOne(d => d.SystemNavigation)
                    .WithMany(p => p.VideoGames)
                    .HasForeignKey(d => d.System)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoGames_ToSystem");
            });
        }
    }
}
