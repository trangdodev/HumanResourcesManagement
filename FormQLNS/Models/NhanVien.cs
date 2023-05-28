namespace FormQLNS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            Luongs = new HashSet<Luong>();
        }

        [Key]
        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        [Required]
        [StringLength(50)]
        public string PhongBan { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        public bool? GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string TrinhDoHocVan { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? MaPB { get; set; }

        public int? MaCV { get; set; }

        public int? MaTDHV { get; set; }

        [StringLength(10)]
        public string MaPQ { get; set; }

        public virtual ChucVu ChucVu1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luong> Luongs { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }

        public virtual PhongBan PhongBan1 { get; set; }

        public virtual TrinhDoHocVan TrinhDoHocVan1 { get; set; }
    }
}
