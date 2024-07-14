using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_DB
{
    using System;

    namespace BE_2505.Buoi14
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var computer = new Computer();
                computer.Menu();
            }
        }

        public class Computer
        {
            private readonly ProductCategoryManager productCategoryManager = new ProductCategoryManager();
            private readonly ProductManager productManager = new ProductManager();

            public void Menu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t ---- CHƯƠNG TRÌNH QUẢN LÝ Computer---");
                    Console.WriteLine("1. Quản lý loại sản phẩm.");
                    Console.WriteLine("2. Quản lý sản phẩm.");
                    Console.WriteLine("0. Nhập 0 để thoát khỏi chương trình!");
                    Console.WriteLine("\t\t ---- END ----");

                    Console.Write("Nhập lựa chọn: ");
                    int luachon = int.Parse(Console.ReadLine());
                    switch (luachon)
                    {
                        case 1:
                            MenuLoaiSanPham();
                            break;
                        case 2:
                            MenuSanPham();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ!");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            private void MenuLoaiSanPham()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t ---- QUẢN LÝ LOẠI SẢN PHẨM ----");
                    Console.WriteLine("1. Thêm thông tin loại sản phẩm.");
                    Console.WriteLine("2. Sửa thông tin loại sản phẩm.");
                    Console.WriteLine("3. Xóa thông tin loại sản phẩm.");
                    Console.WriteLine("0. Quay lại menu chính!");
                    Console.WriteLine("\t\t ---- END ----");

                    Console.Write("Nhập lựa chọn: ");
                    int luachon = int.Parse(Console.ReadLine());
                    switch (luachon)
                    {
                        case 1:
                            AddLoaiSanPham();
                            break;
                        case 2:
                            UpdateLoaiSanPham();
                            break;
                        case 3:
                            DeleteLoaiSanPham();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ!");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            private void MenuSanPham()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t ---- QUẢN LÝ SẢN PHẨM ----");
                    Console.WriteLine("1. Thêm thông tin sản phẩm.");
                    Console.WriteLine("2. Sửa thông tin sản phẩm.");
                    Console.WriteLine("3. Xóa thông tin sản phẩm.");
                    Console.WriteLine("0. Quay lại menu chính!");
                    Console.WriteLine("\t\t ---- END ----");

                    Console.Write("Nhập lựa chọn: ");
                    int luachon = int.Parse(Console.ReadLine());
                    switch (luachon)
                    {
                        case 1:
                            AddSanPham();
                            break;
                        case 2:
                            UpdateSanPham();
                            break;
                        case 3:
                            DeleteSanPham();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ!");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            private void AddLoaiSanPham()
            {
                ProductCategory productCategory = new ProductCategory();
                Console.Write("Nhập tên loại sản phẩm: ");
                productCategory.CategoryName = Console.ReadLine();
                productCategoryManager.AddProductCategory(productCategory);
                Console.WriteLine("Thêm loại sản phẩm thành công!");
                Console.ReadKey();
            }

            private void UpdateLoaiSanPham()
            {
                ProductCategory productCategory = new ProductCategory();
                Console.Write("Nhập ID loại sản phẩm cần sửa: ");
                productCategory.CategoryID = int.Parse(Console.ReadLine());
                Console.Write("Nhập tên loại sản phẩm mới: ");
                productCategory.CategoryName = Console.ReadLine();
                productCategoryManager.UpdateProductCategory(productCategory);
                Console.WriteLine("Sửa thông tin loại sản phẩm thành công!");
                Console.ReadKey();
            }

            private void DeleteLoaiSanPham()
            {
                ProductCategory productCategory = new ProductCategory();
                Console.Write("Nhập ID loại sản phẩm cần xóa: ");
                productCategory.CategoryID = int.Parse(Console.ReadLine());
                productCategoryManager.DeleteProductCategory(productCategory);
                Console.WriteLine("Xóa loại sản phẩm thành công!");
                Console.ReadKey();
            }

            private void AddSanPham()
            {
                Product product = new Product();
                Console.Write("Nhập tên sản phẩm: ");
                product.ProductName = Console.ReadLine();
                // Nhập thêm các thông tin khác cho sản phẩm tại đây nếu cần
                productManager.AddProduct(product);
                Console.WriteLine("Thêm sản phẩm thành công!");
                Console.ReadKey();
            }

            private void UpdateSanPham()
            {
                Product product = new Product();
                Console.Write("Nhập ID sản phẩm cần sửa: ");
                product.ProductID = int.Parse(Console.ReadLine());
                Console.Write("Nhập tên sản phẩm mới: ");
                product.ProductName = Console.ReadLine();
                // Cập nhật thêm các thông tin khác của sản phẩm tại đây nếu cần
                productManager.UpdateProduct(product);
                Console.WriteLine("Sửa thông tin sản phẩm thành công!");
                Console.ReadKey();
            }

            private void DeleteSanPham()
            {
                Product product = new Product();
                Console.Write("Nhập ID sản phẩm cần xóa: ");
                product.ProductID = int.Parse(Console.ReadLine());
                productManager.DeleteProduct(product);
                Console.WriteLine("Xóa sản phẩm thành công!");
                Console.ReadKey();
            }
        }
    }

