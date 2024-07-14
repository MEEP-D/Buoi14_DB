using Buoi14_DB.CLassMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_DB.DAL
{
    public class DanhMuc
    {
        private readonly ComputerDBContext _dbContext;
        private readonly ValidateData _validateData;

        public DanhMuc()
        {
            _dbContext = new ComputerDBContext();
            _validateData = new ValidateData();
        }

        public List<DanhMucSanPham> GetListProductCategories()
        {
            try
            {
                return _dbContext.ProductCategories.ToList();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi lấy danh sách danh mục sản phẩm: {ex.Message}");
                return null;
            }
        }

        public void ThemDanhMuc(DanhMucSanPham danhmuc)
        {
            try
            {
                ReturnData returnData = _validateData.ValidateProductCategoryInput(danhmuc);
                if (returnData.ResponseCode != ReturnCodes.Success)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    return;
                }

                _dbContext.ProductCategories.Add(danhmuc);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi thêm danh mục sản phẩm: {ex.Message}");
            }
        }

        public void XoaDanhMuc(long MaDanhMuc)
        {
            try
            {
                var danhmuc = _dbContext.ProductCategories.FirstOrDefault(c => c.CategoryID == MaDanhMuc);
                if (danhmuc == null)
                {
                    Console.WriteLine("Không tìm thấy danh mục sản phẩm để xóa.");
                    return;
                }

                _dbContext.ProductCategories.Remove(danhmuc);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi xóa danh mục sản phẩm: {ex.Message}");
            }
        }

        public void SuaDanhMuc(DanhMucSanPham danhmuc)
        {
            try
            {
                ReturnData returnData = _validateData.ValidateProductCategoryInput(danhmuc);
                if (returnData.ResponseCode != ReturnCodes.Success)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    return;
                }

                _dbContext.ProductCategories.AddOrUpdate(danhmuc);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi cập nhật danh mục sản phẩm: {ex.Message}");
            }
        }

        private void HandleError(string errorMessage)
        {
            Console.WriteLine($"Lỗi: {errorMessage}");
        }
    }
}
