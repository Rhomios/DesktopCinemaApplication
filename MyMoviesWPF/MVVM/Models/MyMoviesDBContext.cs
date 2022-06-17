using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyMoviesWPF.Models
{
    public partial class MyMoviesDBContext : DbContext
    {
        public MyMoviesDBContext()
        {
        }

        public MyMoviesDBContext(DbContextOptions<MyMoviesDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<ActorList> ActorLists { get; set; } = null!;
        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = mssql; Database = gr602_horse; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.Idactor);

                entity.Property(e => e.Idactor).HasColumnName("IDActor");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ActorList>(entity =>
            {
                entity.HasKey(e => e.IdactorList);

                entity.ToTable("ActorList");

                entity.Property(e => e.IdactorList).HasColumnName("IDActorList");

                entity.Property(e => e.Idactor).HasColumnName("IDActor");

                entity.HasOne(d => d.IdactorNavigation)
                    .WithMany(p => p.ActorLists)
                    .HasForeignKey(d => d.Idactor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorList_Actors");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalog");

                entity.Property(e => e.CatalogId).HasColumnName("CatalogID");

                entity.Property(e => e.Idmovie).HasColumnName("IDMovie");

                entity.Property(e => e.Title).HasMaxLength(20);

                entity.HasOne(d => d.IdmovieNavigation)
                    .WithMany(p => p.Catalogs)
                    .HasForeignKey(d => d.Idmovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalog_Movie");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.Idgenre);

                entity.Property(e => e.Idgenre).HasColumnName("IDGenre");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Idmovie);

                entity.ToTable("Movie");

                entity.Property(e => e.Idmovie).HasColumnName("IDMovie");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.IdactorList).HasColumnName("IDActorList");

                entity.Property(e => e.Idgenre).HasColumnName("IDGenre");

                entity.Property(e => e.Idorder).HasColumnName("IDOrder");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Languages).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductYear).HasColumnType("date");

                entity.Property(e => e.Trailer).HasMaxLength(255);

                //entity.HasOne(d => d.IdactorListNavigation)
                //    .WithMany(p => p.Movies)
                //    .HasForeignKey(d => d.IdactorList)
                //    .HasConstraintName("FK_Movie_ActorList");

                entity.HasOne(d => d.IdgenreNavigation)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.Idgenre)
                    .HasConstraintName("FK_Movie_Genres1");

                entity.HasOne(d => d.IdorderNavigation)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.Idorder)
                    .HasConstraintName("FK_Movie_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Idorder);

                entity.ToTable("Order");

                entity.Property(e => e.Idorder).HasColumnName("IDOrder");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Idpayment).HasColumnName("IDPayment");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.IdpaymentNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Idpayment)
                    .HasConstraintName("FK_Order_Payment1");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Users1");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Idpayment);

                entity.ToTable("Payment");

                entity.Property(e => e.Idpayment).HasColumnName("IDPayment");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.PaymentType).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.Sum).HasColumnType("money");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.EMail)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("eMail");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
