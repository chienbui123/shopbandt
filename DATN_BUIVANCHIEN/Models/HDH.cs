namespace DATN_BUIVANCHIEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDH")]
    public partial class HDH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HDH()
        {
            DIENTHOAI = new HashSet<DIENTHOAI>();
        }

        [Key]
        
       
        public int MaHDH { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên Hệ Điều Hành")]
        public string TenHDH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIENTHOAI> DIENTHOAI { get; set; }
    }
}
