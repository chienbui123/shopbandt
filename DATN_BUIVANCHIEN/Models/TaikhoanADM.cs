using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DATN_BUIVANCHIEN.Models
{
    public partial class TaikhoanADM : DbContext
    {
        public TaikhoanADM()
            : base("name=TaikhoanADM")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<DATN_BUIVANCHIEN.Models.KHACHHANG> KHACHHANGs { get; set; }

        public System.Data.Entity.DbSet<DATN_BUIVANCHIEN.Models.DONDATHANG> DONDATHANGs { get; set; }
    }
}
