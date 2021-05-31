using System.Collections.Generic;
using marketplace.Data.Entities;
using marketplace.DTO.Common;
using marketplace.DTO.SystemManager.RBAC;
using marketplace.DTO.SystemManager.User;
using marketplace.DTO.Catalog.Category;
using marketplace.DTO.Catalog.Product;
using marketplace.Data.Enums;

namespace marketplace.Services.Utils
{
    public static class ConverterDTOEntity
    {
        public static ImageDTO GetImageDTOFromHinhAnh(HinhAnh hinh)
        {
            return new ImageDTO(hinh);
        }
        public static List<ImageDTO> GetImageDTOsFromHinhAnhs(List<HinhAnh> images)
        {
            if (images == null)
            {
                return null;
            }
            var imageDTOs = new List<ImageDTO>();
            foreach (var item in images)
            {
                var imageDTO = GetImageDTOFromHinhAnh(item);
                imageDTOs.Add(imageDTO);
            }
            return imageDTOs;
        }

        public static CategoryDTO GetCategoryDTOFromDanhMuc(DanhMuc danhMuc)
        {
            return new CategoryDTO(danhMuc);
        }
        public static CategoryDTO GetCategoryDTOFromDanhMuc(DanhMuc danhMuc, ChiTietDanhMuc chiTietDanhMuc)
        {
            return new CategoryDTO(danhMuc, chiTietDanhMuc);
        }
        public static CategoryDTO GetCategoryDTOFromDanhMuc(DanhMuc danhMuc, ChiTietDanhMuc chiTietDanhMuc, ImageDTO imageDTO)
        {
            return new CategoryDTO(danhMuc, chiTietDanhMuc, imageDTO);
        }

        public static DanhMuc GetDanhMucFromCreateCategoryDTO(CreateCategoryDTO createCategoryDTO)
        {
            var danhMuc = new DanhMuc()
            {
                MaSo = createCategoryDTO.Code,
                TrangThai = (TrangThai)((int)createCategoryDTO.Status),
                HienThiTrangChu = createCategoryDTO.IsShownAtHome
            };
            return danhMuc;
        }

        public static ChiTietDanhMuc GetChiTietDanhMucFromDetailCategoryDTO(DetailCategoryDTO detailCD)
        {
            var chiTietDanhMuc = new ChiTietDanhMuc()
            {
                NgonNguId = detailCD.LanguageId,
                Ten = detailCD.Name,
                MoTa = detailCD.Description
            };
            return chiTietDanhMuc;
        }
        public static List<ChiTietDanhMuc> GetChiTietDanhMucsFromDetailCategoryDTOs(List<DetailCategoryDTO> detailCD)
        {
            if (detailCD == null)
            {
                return null;
            }
            var categories = new List<ChiTietDanhMuc>();
            foreach (var item in detailCD)
            {
                var category = GetChiTietDanhMucFromDetailCategoryDTO(item);
                categories.Add(category);
            }
            return categories;
        }

        public static SanPham GetSanPhamFromCreateProductDTO(CreateProductDTO createPDTO)
        {
            var sanPham = new SanPham()
            {
                MaSP = createPDTO.Code,
                DonGiaGoc = createPDTO.OriginalPrice,
                DonGia = createPDTO.OriginalPrice,
                SoLuong = createPDTO.Quantity,
                LuotXem = 0,
            };
            return sanPham;
        }











        public static TaiKhoan GetTaiKhoanFromRegisterDTO(RegisterDTO registerDTO)
        {
            var taiKhoan = new TaiKhoan()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
                HoTen = registerDTO.FullName,
                TrangThai = TrangThai.KhongHoatDong
            };
            return taiKhoan;
        }

        public static UserDTO GetUserDTOFromTaiKhoan(TaiKhoan user)
        {
            return new UserDTO(user);
        }
    }
}