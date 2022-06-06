using Microsoft.EntityFrameworkCore;
using RatingAPIWebApp.Models;

namespace RatingAPIWebApp.Models
{
    public class RatingAPIContext : DbContext
    {
        public RatingAPIContext()
        {
        }
        public RatingAPIContext(DbContextOptions<RatingAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Racer> Racers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id)
                     .UseIdentityColumn();
                entity.Property(e => e.Name)
                      .HasMaxLength(255);
            });
            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.Id)
                     .UseIdentityColumn();
                entity.Property(e => e.Name)
                     .HasMaxLength(255);
                entity.Property(e => e.Year);
                entity.HasOne(e => e.Racer)
                     .WithMany(p => p.Races)
                     .HasForeignKey(d => d.RacerId)
                     .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Racer>(entity =>
            {
                entity.Property(e => e.Id)
                     .UseIdentityColumn();
                entity.Property(e => e.Name)
                     .HasMaxLength(255);
                entity.Property(e => e.Surname)
                     .HasMaxLength(255);
                entity.Property(e => e.DateOfBirth)
                     .HasColumnType("datetime");
                entity.Property(e => e.Wins);
                entity.HasOne(e => e.Team)
                     .WithMany(p => p.Racers)
                     .HasForeignKey(d => d.TeamId)
                     .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Country)
                     .WithMany(p => p.Racers)
                     .HasForeignKey(d => d.CountryId)
                     .OnDelete(DeleteBehavior.Cascade);

            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id)
                     .UseIdentityColumn();
                entity.Property(e => e.Name)
                     .HasMaxLength(255);
                entity.HasOne(e => e.Country)
                     .WithMany(p => p.Teams)
                     .HasForeignKey(d => d.CountryId)
                     .OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}
