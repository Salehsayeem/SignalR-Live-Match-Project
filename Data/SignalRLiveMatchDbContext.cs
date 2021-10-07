using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SignalRLiveMatchProject.Models;

#nullable disable

namespace SignalRLiveMatchProject.Data
{
    public partial class SignalRLiveMatchDbContext : DbContext
    {
        public SignalRLiveMatchDbContext()
        {
        }

        public SignalRLiveMatchDbContext(DbContextOptions<SignalRLiveMatchDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.TeamLogo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
