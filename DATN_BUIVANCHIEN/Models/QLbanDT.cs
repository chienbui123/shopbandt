using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DATN_BUIVANCHIEN.Models
{
    public partial class QLbanDT : DbContext
    {
        public QLbanDT()
            : base("name=QLbanDT")
        {
        }

        public virtual DbSet<CHITIETDONTHANG> CHITIETDONTHANG { get; set; }
        public virtual DbSet<DIENTHOAI> DIENTHOAI { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANG { get; set; }
        public virtual DbSet<HDH> HDH { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBAN { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONTHANG>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.Giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.Anhbia)
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .HasMany(e => e.CHITIETDONTHANG)
                .WithRequired(e => e.DIENTHOAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CHITIETDONTHANG)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienthoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<DATN_BUIVANCHIEN.Models.Admin> Admins { get; set; }
    }
}
