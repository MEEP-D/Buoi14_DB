using Buoi14_DB.CLassMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_DB.DAL
{
    public class Nhom
    {
        private readonly ComputerDBContext _dbContext;
        private readonly ValidateData _validateData;

        public Nhom()
        {
            _dbContext = new ComputerDBContext();
            _validateData = new ValidateData();
        }

        public List<cc> GetListProductGroups()
        {
            try
            {
                return _dbContext.ProductGroups.ToList();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi lấy danh sách nhóm sản phẩm: {ex.Message}");
                return null;
            }
        }

        public void ThemNhom(NhomSanPham nhom)
        {
            try
            {
                ReturnData returnData = _validateData.ValidateProductGroupInput(nhom);
                if (returnData.ResponseCode != ReturnCodes.Success)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    return;
                }

                _dbContext.ProductGroups.Add(nhom);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi thêm nhóm sản phẩm: {ex.Message}");
            }
        }

        public void XoaNhom(long MaNhomSanPham)
        {
            try
            {
                var nhom = _dbContext.ProductGroups.FirstOrDefault(c => c.ProductGroupID == MaNhomSanPham);
                if (nhom == null)
                {
                    Console.WriteLine("Không tìm thấy nhóm sản phẩm để xóa.");
                    return;
                }

                _dbContext.ProductGroups.Remove(nhom);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi xóa nhóm sản phẩm: {ex.Message}");
            }
        }

        public void SuaNhom(NhomSanPham nhom)
        {
            try
            {
                ReturnData returnData = _validateData.ValidateProductGroupInput(nhom);
                if (returnData.ResponseCode != ReturnCodes.Success)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    return;
                }

                _dbContext.ProductGroups.AddOrUpdate(nhom);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleError($"Lỗi khi cập nhật nhóm sản phẩm: {ex.Message}");
            }
        }

        private void HandleError(string errorMessage)
        {
            Console.WriteLine($"Lỗi: {errorMessage}");

        }
    }
}

