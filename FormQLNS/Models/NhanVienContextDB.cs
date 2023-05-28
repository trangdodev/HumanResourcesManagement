using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FormQLNS.Models
{
    public partial class NhanVienContextDB : DbContext
    {
        public NhanVienContextDB()
            : base("name=NhanVienContextDB")
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThoiGianCongTac> ThoiGianCongTacs { get; set; }
        public virtual DbSet<TrinhDoHocVan> TrinhDoHocVans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Luong>()
                .Property(e => e.MaLuong)
                .IsFixedLength();

            modelBuilder.Entity<Luong>()
                .Property(e => e.MaNV)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.CMND)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaPQ)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Luongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.MaPQ)
                .IsFixedLength();

            modelBuilder.Entity<ThoiGianCongTac>()
                .Property(e => e.MaNV)
                .IsFixedLength();

            modelBuilder.Entity<TrinhDoHocVan>()
                .Property(e => e.TenTDHV)
                .IsFixedLength();
        }
    }
}
