using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_DB.CLassMain
{
    public class ThuocTinhSanPham
    {
        [Key]
        public long MaThuocTinhSanPham { get; set; }
        public string TenThuocTinh { get; set; }
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public bool DaXoa { get; set; }
        public DateTime? NgayXoa { get; set; }
        public string NguoiXoa { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }
    }
}
