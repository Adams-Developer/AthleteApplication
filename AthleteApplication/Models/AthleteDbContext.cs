using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AthleteApplication.Models
{
    public partial class AthleteDbContext : DbContext
    {
        public AthleteDbContext()
        {
        }

        public AthleteDbContext(DbContextOptions<AthleteDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Athletes> Athletes { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<States> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TTLN1EM6;Database=AthleteApplicationDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athletes>(entity =>
            {
                entity.HasKey(e => e.AthleteId)
                    .HasName("PK_AthleteId");

                entity.Property(e => e.ApartmentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstagramHandle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MerchSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TwitterHandle)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasColumnName("State_Code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Sizes>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Size)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sports>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Sport)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.StateCode)
                    .HasName("PK__States__205FB8AD520D6715");

                entity.Property(e => e.StateCode)
                    .HasColumnName("State_Code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(22)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
