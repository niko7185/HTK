using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HTK.Entitties
{
    public partial class HTKContext : DbContext
    {
        public HTKContext()
        {
        }

        public HTKContext(DbContextOptions<HTKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courts> Courts { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Ranks> Ranks { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=HTK;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courts>(entity =>
            {
                entity.HasKey(e => e.CourtId);

                entity.Property(e => e.CourtId).HasColumnName("CourtID");

                entity.Property(e => e.CourtName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.MemberAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.MemberBirthDate).HasColumnType("datetime");

                entity.Property(e => e.MemberMail)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.MemberPhone)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.RankId).HasColumnName("RankID");

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_Ranks");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK_Members_Reservations");
            });

            modelBuilder.Entity<Ranks>(entity =>
            {
                entity.HasKey(e => e.RankId);

                entity.Property(e => e.RankId).HasColumnName("RankID");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.ReservationId);

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.CourtId).HasColumnName("CourtID");

                entity.Property(e => e.ReservationEnd).HasColumnType("datetime");

                entity.Property(e => e.ReservationStart).HasColumnType("datetime");

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CourtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Courts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
