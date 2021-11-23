using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_020_A.Models
{
    public partial class PenjualanBarangContext : DbContext
    {
        public PenjualanBarangContext()
        {
        }

        public PenjualanBarangContext(DbContextOptions<PenjualanBarangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Bonu> Bonus { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Barang");

                entity.Property(e => e.IdBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_barang");

                entity.Property(e => e.JenisBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Barang");

                entity.Property(e => e.NamaBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Barang");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithOne(p => p.Barang)
                    .HasForeignKey<Barang>(d => d.IdBarang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Barang_Customer");
            });

            modelBuilder.Entity<Bonu>(entity =>
            {
                entity.HasKey(e => e.IdBonus);

                entity.Property(e => e.IdBonus)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Bonus");

                entity.Property(e => e.JumlahBonus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jumlah_Bonus");

                entity.HasOne(d => d.IdBonusNavigation)
                    .WithOne(p => p.Bonu)
                    .HasForeignKey<Bonu>(d => d.IdBonus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bonus_Transaksi");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Barang");

                entity.Property(e => e.IdBayar).HasColumnName("ID_Bayar");

                entity.Property(e => e.IdHarga).HasColumnName("ID_Harga");

                entity.Property(e => e.IdJumlah).HasColumnName("ID_Jumlah");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithOne(p => p.Transaksi)
                    .HasForeignKey<Transaksi>(d => d.IdBarang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksi_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
