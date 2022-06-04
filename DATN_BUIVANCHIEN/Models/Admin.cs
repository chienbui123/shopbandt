namespace DATN_BUIVANCHIEN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int MaTK { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [DisplayName("Tài Khoản")]
        public string Taikhoan { get; set; }

        [Required]
        [DisplayName("Mật Khẩu")]
        [StringLength(50)]
        public string Matkhau { get; set; }
    }
}
