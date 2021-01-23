using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace classProject.Models
{
    public partial class HimalayanDbContext : DbContext
    {
        public HimalayanDbContext()
        {
        }

        public HimalayanDbContext(DbContextOptions<HimalayanDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expedition> Expeditions { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Peak> Peaks { get; set; }
        public virtual DbSet<TrekkingAgency> TrekkingAgencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=HimalayanConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expedition>(entity =>
            {
                entity.ToTable("Expedition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.Property(e => e.PeakId).HasColumnName("PeakID");

                entity.Property(e => e.Season).HasMaxLength(10);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TerminationReason).HasMaxLength(80);

                entity.Property(e => e.TrekkingAgencyId).HasColumnName("TrekkingAgencyID");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Expeditions)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("Expedition_FK_Login");

                entity.HasOne(d => d.Peak)
                    .WithMany(p => p.Expeditions)
                    .HasForeignKey(d => d.PeakId)
                    .HasConstraintName("Expedition_FK_Peak");

                entity.HasOne(d => d.TrekkingAgency)
                    .WithMany(p => p.Expeditions)
                    .HasForeignKey(d => d.TrekkingAgencyId)
                    .HasConstraintName("Expedition_FK_TrekkingAgency");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password).HasMaxLength(31);

                entity.Property(e => e.Username).HasMaxLength(31);
            });

            modelBuilder.Entity<Peak>(entity =>
            {
                entity.ToTable("Peak");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TrekkingAgency>(entity =>
            {
                entity.ToTable("TrekkingAgency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
