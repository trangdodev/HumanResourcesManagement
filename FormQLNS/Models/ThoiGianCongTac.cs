namespace FormQLNS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThoiGianCongTac")]
    public partial class ThoiGianCongTac
    {
        [Key]
        [StringLength(10)]
        public string MaNV { get; set; }

        public int? MaCV { get; set; }

        public DateTime? NgayNhanChuc { get; set; }

        public virtual ChucVu ChucVu { get; set; }
    }
}
