using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cinema.Models
{
    public partial class cinemadbContext : DbContext
    {
        public cinemadbContext()
        {
        }

        public cinemadbContext(DbContextOptions<cinemadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Projection> Projection { get; set; }
        public virtual DbSet<Projectionhour> Projectionhour { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<Theater> Theater { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;Database=cinemadb;user=root;password=mysqlpao;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Nit).IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Projection>(entity =>
            {
                entity.HasIndex(e => e.MovieId)
                    .HasName("fk_MovieTheater_Movie1_idx");

                entity.HasIndex(e => e.ProjectionHourId)
                    .HasName("fk_Ticket_ProjectionHour1_idx");

                entity.HasIndex(e => e.TheaterId)
                    .HasName("fk_Ticket_Theater1_idx");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Projection)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MovieTheater_Movie1");

                entity.HasOne(d => d.ProjectionHour)
                    .WithMany(p => p.Projection)
                    .HasForeignKey(d => d.ProjectionHourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ticket_ProjectionHour1");

                entity.HasOne(d => d.Theater)
                    .WithMany(p => p.Projection)
                    .HasForeignKey(d => d.TheaterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ticket_Theater1");
            });

            modelBuilder.Entity<Projectionhour>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_Receipt_Client1_idx");

                entity.HasIndex(e => e.TicketId)
                    .HasName("fk_Receipt_Ticket1_idx");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Receipt_Client1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Receipt_Ticket1");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasIndex(e => e.TheaterId)
                    .HasName("fk_Seat_Theater1_idx");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Theater)
                    .WithMany(p => p.Seat)
                    .HasForeignKey(d => d.TheaterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Seat_Theater1");
            });

            modelBuilder.Entity<Theater>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasIndex(e => e.ProjectionId)
                    .HasName("fk_Ticket_Projection1_idx");

                entity.HasIndex(e => e.SeatId)
                    .HasName("fk_Ticket_Seat1_idx");

                entity.HasOne(d => d.Projection)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.ProjectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ticket_Projection1");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ticket_Seat1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
