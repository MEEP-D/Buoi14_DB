using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_DB.DAL
{
    public class SanPham

    {
        private readonly ComputerDBContext _dbContext;
        private readonly ValidateData _validateData;

        public SanPham()
        {
            _dbContext = new ComputerDBContext();
            _validateData = new ValidateData();
        }

        public List<SanPham> GetListProducts()
        {
            try
            {
                return _dbContext.Products.ToList();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi lấy danh sách sản phẩm: {ex.Message}");
                return null;
            }
        }

        public void ThemSanPham(SanPham sanpham)
        {
            try
            {
                ReturnData returnData = _validateData.ValidateProductInput(sanpham);
                if (returnData.ResponseCode != ReturnCodes.Success)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    return;
                }

                _dbContext.Products.Add(sanpham);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi thêm sản phẩm: {ex.Message}");
            }
        }

        public void XoaSanPham(long productId)
        {
            try
            {
                var product = _dbContext.Products.FirstOrDefault(p => p.ProductID == productId);
                if (product == null)
                {
                    Console.WriteLine("Không tìm thấy sản phẩm để xóa.");
                    return;
                }

                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi xóa sản phẩm: {ex.Message}");
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                ReturnData returnData = _validateData.ValidateProductInput(product);
                if (returnData.ResponseCode != ReturnCodes.Success)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    return;
                }

                _dbContext.Products.AddOrUpdate(product);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
            }
        }

        private void HandleError(string errorMessage)
        {
            Console.WriteLine($"Lỗi: {errorMessage}");
            // Environment.Exit(1); // Consider removing this line depending on your application's error handling strategy.
        }
    }
}
