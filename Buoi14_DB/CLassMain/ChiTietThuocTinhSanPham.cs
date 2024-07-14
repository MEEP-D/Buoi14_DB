using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_DB.CLassMain
{
    public class ChiTietThuocTinhSanPham
    {
        [Key]
        public long MaNhomSanPham { get; set; }
        [ForeignKey("ThuocTinhSanPham")]
        public long MaThuocTinhSanPham { get; set; }
        public string GiaTriThuocTinh { get; set; }
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public bool DaXoa { get; set; }
        public DateTime NgayXoa { get; set; }
        public string NguoiXoa { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }
        public virtual ThuocTinhSanPham ThuocTinhSanPham { get; set; }
    }

    public class ThuocTinhSanPham
    {
        [Key]
        public long MaThuocTinhSanPham { get; set; }
        public string TenThuocTinh { get; set; }
        // Điều hướng đến các chi tiết thuộc tính sản phẩm
        public virtual ICollection<ChiTietThuocTinhSanPham> ChiTietThuocTinhs { get; set; }
    }
}
