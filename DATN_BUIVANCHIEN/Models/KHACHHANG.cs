namespace DATN_BUIVANCHIEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONDATHANG = new HashSet<DONDATHANG>();
        }

        [Key]
        [DisplayName("Mã Khách Hàng")]
        public int MaKH { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [DisplayName("Tài Khoản")]
        public string Taikhoan { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Mật Khẩu")]
        public string Matkhau { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        [DisplayName("Địa Chỉ Khách Hàng")]
        public string DiachiKH { get; set; }

        [StringLength(50)]
        [DisplayName("Số Điện Thoại")]
        public string DienthoaiKH { get; set; }
        [DisplayName("Ngày Sinh")]

        public DateTime? Ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANG { get; set; }
    }
}
