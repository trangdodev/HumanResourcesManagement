namespace FormQLNS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Luong")]
    public partial class Luong
    {
        [Key]
        [StringLength(10)]
        public string MaLuong { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNV { get; set; }

        public int? LuongCB { get; set; }

        public int? HeSoLuong { get; set; }

        public int? LuongChinhThuc { get; set; }

        public int? HeSoPhuCap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
