using Buoi14_DB.CLassMain;
using Buoi14_DB.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_DB.Validate
{
    public class ValidateData
    {
        private readonly ValidateDataHelper validator = new ValidateDataHelper();

        public ReturnData ValidateProductCategoryInput(DanhMucSanPham danhmuc)
        {
            ReturnData returnData = new ReturnData();

            if (danhmuc == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo.";
                return returnData;
            }

            if (string.IsNullOrEmpty(danhmuc.TenDanhMuc))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Tên loại sản phẩm không được để trống.";
                return returnData;
            }

            returnData.ResponseCode = 1;
            return returnData;
        }

        public ReturnData ValidateProductInput(SanPham sanpham)
        {
            ReturnData returnData = new ReturnData();

            if (sanpham == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo.";
                return returnData;
            }

            if (!validator.IsValidCategoryId(sanpham.MaDanhMuc))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "CategoryID không hợp lệ.";
                return returnData;
            }

            if (string.IsNullOrEmpty(sanpham.TenSanPham))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Tên sản phẩm không được để trống.";
                return returnData;
            }

            returnData.ResponseCode = 1;
            return returnData;
        }

        public ReturnData ValidateProductGroupInput(NhomSanPham nhom)
        {
            ReturnData returnData = new ReturnData();

            if (nhom == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo.";
                return returnData;
            }

            if (nhom.MaSanPham <= 0)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "ProductID không hợp lệ.";
                return returnData;
            }

            if (nhom.MaThuocTinhNhomSanPham <= 0)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "ProductGroupAttributeID không hợp lệ.";
                return returnData;
            }

            if (nhom.MaNhomCha < 0)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "ParentID không hợp lệ.";
                return returnData;
            }

            // Các kiểm tra khác có thể được bổ sung tại đây nếu cần

            returnData.ResponseCode = 1;
            return returnData;
        }
    }
}
