namespace DATN_BUIVANCHIEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAXUATBAN")]
    public partial class NHAXUATBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAXUATBAN()
        {
            DIENTHOAI1 = new HashSet<DIENTHOAI>();
        }

        [Key]
        
        public int MaNXB { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên Nhà Xuất Bản")]
        public string TenNXB { get; set; }

        [StringLength(200)]
        [DisplayName("Địa Chỉ")]
        public string Diachi { get; set; }

        [StringLength(50)]
        [DisplayName("Điện Thoại")]
        public string DienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIENTHOAI> DIENTHOAI1 { get; set; }
    }
}
