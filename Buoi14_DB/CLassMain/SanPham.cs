using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_DB.CLassMain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace BE_2505.Buoi14.ClassDB
    {
        public class SanPham
        {
            [Key]
            public long MaSanPham { get; set; }

            [ForeignKey("DanhMucSanPham")]
            public long MaDanhMuc { get; set; }
            public string TenSanPham { get; set; }
            public bool TrangThai { get; set; }
            public DateTime NgayTao { get; set; }
            public string NguoiTao { get; set; }
            public bool DaXoa { get; set; }
            public DateTime? NgayXoa { get; set; }
            public string NguoiXoa { get; set; }
            public DateTime NgayCapNhat { get; set; }
            public string NguoiCapNhat { get; set; }
            public virtual DanhMucSanPham DanhMucSanPham { get; set; }
        }
        public class DanhMucSanPham
        {
            [Key]
            public long MaDanhMuc { get; set; }
            public string TenDanhMuc { get; set; }
            public virtual ICollection<SanPham> SanPhams { get; set; }
        }
    }

}

