using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CineMaks
{
    public partial class CineMaksContext : DbContext
    {
        public CineMaksContext()
        {
        }

        public CineMaksContext(DbContextOptions<CineMaksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<FilmType> FilmTypes { get; set; } = null!;
        public virtual DbSet<Hall> Halls { get; set; } = null!;
        public virtual DbSet<OrderCart> OrderCarts { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= TEMP1; Database=CineMaks; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.IdFilm);

                entity.ToTable("Film");

                entity.Property(e => e.IdFilm)
                    .ValueGeneratedNever()
                    .HasColumnName("idFilm");

                entity.Property(e => e.Country)
                    .HasMaxLength(45)
                    .HasColumnName("country");

                entity.Property(e => e.IdType).HasColumnName("idType");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ShortDesc)
                    .HasMaxLength(100)
                    .HasColumnName("shortDesc");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Film_FilmType");
            });

            modelBuilder.Entity<FilmType>(entity =>
            {
                entity.HasKey(e => e.IdType);

                entity.ToTable("FilmType");

                entity.Property(e => e.IdType)
                    .ValueGeneratedNever()
                    .HasColumnName("idType");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(e => e.IdHall);

                entity.ToTable("Hall");

                entity.Property(e => e.IdHall)
                    .ValueGeneratedNever()
                    .HasColumnName("idHall");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<OrderCart>(entity =>
            {
                entity.HasKey(e => e.IdOrderCart);

                entity.ToTable("OrderCart");

                entity.Property(e => e.IdOrderCart)
                    .ValueGeneratedNever()
                    .HasColumnName("idOrderCart");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.OrderCarts)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderCart_User");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.IdSession);

                entity.ToTable("Session");

                entity.Property(e => e.IdSession)
                    .ValueGeneratedNever()
                    .HasColumnName("idSession");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdFilm).HasColumnName("idFilm");

                entity.Property(e => e.IdHall).HasColumnName("idHall");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Film");

                entity.HasOne(d => d.IdHallNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.IdHall)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Hall");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket);

                entity.ToTable("Ticket");

                entity.Property(e => e.IdTicket)
                    .ValueGeneratedNever()
                    .HasColumnName("idTicket");

                entity.Property(e => e.IdSession).HasColumnName("idSession");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.HasOne(d => d.IdSessionNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdSession)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Session");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Ticket_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("idUser");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
