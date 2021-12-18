using Microsoft.EntityFrameworkCore;
using System;
using Timeline.Entity.Models;

namespace Timeline.Data
{
    public class TimelineDbContext : DbContext
    {
        public TimelineDbContext(DbContextOptions<TimelineDbContext> options)
            : base(options)
        {

        }

        public DbSet<Series> Series { get; set; }
        public DbSet<World> World { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

            });

            modelBuilder.Entity<World>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);
            });
        }
    }
}
