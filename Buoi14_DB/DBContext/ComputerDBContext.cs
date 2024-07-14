using Buoi14_DB.CLassMain;
using Buoi14_DB.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_DB.DBContext
{
    public class ComputerDBContext : DbContext
    {
        public ComputerDBContext() : base("name=Computer")
        { }

        public virtual DbSet<SanPham> _SanPham { get; set; }
        public virtual DbSet<ThuocTinhSanPham> _ThuocTinhSanPham { get; set; }
        public virtual DbSet<ChiTietThuocTinhSanPham> _ChiTietThuocTinhSanPham { get; set; }
        public virtual DbSet<DanhMucSanPham> _DanhMucSanPham { get; set; }
        public virtual DbSet<NhomSanPham> _NhomSanPham { get; set; }
        public virtual DbSet<ThuocTinhNhomSanPham> _ThuocTinhNhomSanPham { get; set; }
        public virtual DbSet<ChiTietThuocTinhNhomSanPham> _ChiTietThuocTinhNhomSanPham { get; set; }
        public virtual DbSet<GiaNhomSanPham> _GiaNhomSanPham { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Thiết lập các cấu hình cho các đối tượng trong cơ sở dữ liệu
            modelBuilder.Entity<SanPham>()
                .Property(p => p.TenSanPham)
                .IsRequired();

            modelBuilder.Entity<DanhMucSanPham>()
                .Property(c => c.TenDanhMuc)
                .IsRequired();

            modelBuilder.Entity<NhomSanPham>()
                .HasOptional(g => g.MaNhomCha)
                .WithMany()
                .HasForeignKey(g => g.MaNhomCha);

            modelBuilder.Entity<ChiTietThuocTinhSanPham>()
                .HasRequired(d => d.ThuocTinhSanPham)
                .WithMany()
                .HasForeignKey(d => d.MaThuocTinhSanPham);

            modelBuilder.Entity<ChiTietThuocTinhNhomSanPham>()
                .HasRequired(d => d.MaChiTietThuocTinhNhomSanPham)
                .WithMany()
                .HasForeignKey(d => d.MaChiTietThuocTinhNhomSanPham);

            base.OnModelCreating(modelBuilder);
        }
    }
}
