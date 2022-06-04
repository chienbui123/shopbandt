namespace DATN_BUIVANCHIEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CHITIETDONTHANG = new HashSet<CHITIETDONTHANG>();
        }

        [Key]
        [DisplayName("Mã Đơn Hàng")]
        public int MaDonHang { get; set; }
        [DisplayName("Đã Thanh Toán")]

        public bool? Dathanhtoan { get; set; }
        [DisplayName("Tình Trạng Giao Hàng")]

        public bool? Tinhtranggiaohang { get; set; }
        [DisplayName("Ngày Đặt")]

        public DateTime? Ngaydat { get; set; }
        [DisplayName("Ngày giao")]

        public DateTime? Ngaygiao { get; set; }
        [DisplayName("Mã khách Hàng")]

        public int? MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONTHANG> CHITIETDONTHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
