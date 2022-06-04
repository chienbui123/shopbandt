namespace DATN_BUIVANCHIEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONTHANG")]
    public partial class CHITIETDONTHANG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Đơn Hàng")]
        public int MaDonHang { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Điện Thoại")]
        public int MaDT { get; set; }
        [DisplayName("Số lượng")]
        public int? Soluong { get; set; }
        [DisplayName("Đơn Giá")]

        public decimal? Dongia { get; set; }

        public virtual DONDATHANG DONDATHANG { get; set; }

        public virtual DIENTHOAI DIENTHOAI { get; set; }
        public Double Thanhtien
        {
            get { return (double)(Soluong * Dongia); }
        }
    }
}
