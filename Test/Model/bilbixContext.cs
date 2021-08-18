using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test.Model
{
    public partial class bilbixContext : DbContext
    {
        public bilbixContext()
        {
        }

        public bilbixContext(DbContextOptions<bilbixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Produkter> Produkters { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=94.177.229.154;user=Lazirr;password=Wkt67ssv;database=bilbix", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.10-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.EjerId, "user");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("orderID");

                entity.Property(e => e.EjerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ejerID");

                entity.Property(e => e.SlutDato)
                    .HasColumnType("date")
                    .HasColumnName("slutDato");

                entity.Property(e => e.StartDato)
                    .HasColumnType("date")
                    .HasColumnName("startDato");

                entity.HasOne(d => d.Ejer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EjerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.OrderLines)
                    .HasName("PRIMARY");

                entity.ToTable("orderLines");

                entity.HasIndex(e => e.OrderId, "orders");

                entity.HasIndex(e => e.ProduktId, "produkter");

                entity.Property(e => e.OrderLines)
                    .HasColumnType("int(11)")
                    .HasColumnName("orderLines");

                entity.Property(e => e.Antal)
                    .HasColumnType("int(11)")
                    .HasColumnName("antal");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("orderID");

                entity.Property(e => e.ProduktId)
                    .HasColumnType("int(11)")
                    .HasColumnName("produktID");

                entity.Property(e => e.SamletPris)
                    .HasColumnType("int(11)")
                    .HasColumnName("samletPris");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders");

                entity.HasOne(d => d.Produkt)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ProduktId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produkter");
            });

            modelBuilder.Entity<Produkter>(entity =>
            {
                entity.HasKey(e => e.ProduktId)
                    .HasName("PRIMARY");

                entity.ToTable("produkter");

                entity.Property(e => e.ProduktId)
                    .HasColumnType("int(11)")
                    .HasColumnName("produktID");

                entity.Property(e => e.Pris)
                    .HasColumnType("int(11)")
                    .HasColumnName("pris");

                entity.Property(e => e.ProduktNavn)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("produktNavn");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.UserGroup)
                    .HasColumnType("int(11)")
                    .HasColumnName("userGroup");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
