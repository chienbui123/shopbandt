namespace DATN_BUIVANCHIEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIENTHOAI")]
    public partial class DIENTHOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIENTHOAI()
        {
            CHITIETDONTHANG = new HashSet<CHITIETDONTHANG>();
        }

        [Key]
        [DisplayName("Mã Điện Thoại")]
        public int MaDT { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên Điện Thoại")]
        public string TenDT { get; set; }

        [DisplayName("Giá Bán")]

        public decimal? Giaban { get; set; }

        [StringLength(10)]
        [DisplayName("Màn Hình")]
        public string Manhinh { get; set; }

        [StringLength(10)]
        public string Ram { get; set; }

        [StringLength(10)]
        public string Rom { get; set; }

        [StringLength(10)]
        public string cammera { get; set; }
        [DisplayName("Mô Tả")]

        public string Mota { get; set; }

        [StringLength(50)]
        [DisplayName("Ảnh Sản Phẩm")]
        public string Anhbia { get; set; }
        [DisplayName("Ngày Cập Nhật")]

        public DateTime? Ngaycapnhat { get; set; }
        [DisplayName("Số Lượng Tồn")]

        public int? Soluongton { get; set; }

        public int? MaHDH { get; set; }

        public int? MaNXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONTHANG> CHITIETDONTHANG { get; set; }

        public virtual HDH HDH { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }
    }
}
