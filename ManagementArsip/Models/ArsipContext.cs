using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ManagementArsip.Models
{
    public partial class ArsipContext : DbContext
    {
        public ArsipContext()
        {
        }

        public ArsipContext(DbContextOptions<ArsipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<JenisBarang> JenisBarangs { get; set; }
        public virtual DbSet<Lokasi> Lokasis { get; set; }
        public virtual DbSet<Peminjaman> Peminjamen { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Barang");

                entity.Property(e => e.IdBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("id_barang");

                entity.Property(e => e.DeskripsiBarang)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("deskripsi_barang");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.KodeBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kode_barang");

                entity.Property(e => e.MerkBarang)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("merk_barang");

                entity.Property(e => e.StatusBarang)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status_barang");

                entity.Property(e => e.TahunPengadaan)
                    .HasColumnType("datetime")
                    .HasColumnName("tahun_pengadaan");

                entity.Property(e => e.TanggalMasuk)
                    .HasColumnType("datetime")
                    .HasColumnName("tanggal_masuk");
            });

            modelBuilder.Entity<JenisBarang>(entity =>
            {
                entity.HasKey(e => e.IdJenisbarang);

                entity.ToTable("JenisBarang");

                entity.Property(e => e.IdJenisbarang)
                    .ValueGeneratedNever()
                    .HasColumnName("id_jenisbarang");

                entity.Property(e => e.IdBarang).HasColumnName("id_barang");

                entity.Property(e => e.NamaJenisbarang)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nama_jenisbarang");
            });

            modelBuilder.Entity<Lokasi>(entity =>
            {
                entity.HasKey(e => e.IdLokasi);

                entity.ToTable("Lokasi");

                entity.Property(e => e.IdLokasi)
                    .ValueGeneratedNever()
                    .HasColumnName("id_lokasi");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.NamaLokasi)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nama_lokasi");
            });

            modelBuilder.Entity<Peminjaman>(entity =>
            {
                entity.HasKey(e => e.IdPeminjaman);

                entity.ToTable("Peminjaman");

                entity.Property(e => e.IdPeminjaman)
                    .ValueGeneratedNever()
                    .HasColumnName("id_peminjaman");

                entity.Property(e => e.DeskripsiPeminjaman)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("deskripsi_peminjaman");

                entity.Property(e => e.IdBarang).HasColumnName("id_barang");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.JumlahPeminjaman).HasColumnName("jumlah_peminjaman");

                entity.Property(e => e.TanggalPeminjaman)
                    .HasColumnType("datetime")
                    .HasColumnName("tanggal_peminjaman");

                entity.Property(e => e.TanggalPengembalian)
                    .HasColumnType("datetime")
                    .HasColumnName("tanggal_pengembalian");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nama_User");

                entity.Property(e => e.Nip)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("NIP");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_HP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
