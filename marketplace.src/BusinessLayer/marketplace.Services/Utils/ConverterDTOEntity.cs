using System;
using System.Collections.Generic;
using marketplace.Data.Entities;
using marketplace.DTO.Common;
using marketplace.DTO.SystemManager.RBAC;
using marketplace.DTO.SystemManager.User;
using marketplace.DTO.Catalog.Category;
using marketplace.DTO.Catalog.Product;
using marketplace.Data.Enums;
using marketplace.DTO.Catalog.Branch;
using marketplace.DTO.Catalog.Address;

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
        public static CategoryDTO GetCategoryDTOFromDanhMuc(DanhMuc danhMuc, ImageDTO imageDTO)
        {
            return new CategoryDTO(danhMuc, imageDTO);
        }

        public static DanhMuc GetDanhMucFromCreateCategoryDTO(CreateCategoryDTO createCategoryDTO)
        {
            var danhMuc = new DanhMuc()
            {
                MaSo = createCategoryDTO.Code,
                TrangThai = (TrangThai)((int)createCategoryDTO.Status),
            };
            return danhMuc;
        }


        public static ProductDTO GetProductDTOFromProduct(SanPham product)
        {
            return new ProductDTO(product);
        }


        public static SanPham GetSanPhamFromCreateProductDTO(CreateProductDTO createPDTO)
        {
            var sanPham = new SanPham()
            {
                MaSo = createPDTO.Code,
                DonGiaGoc = createPDTO.OriginalPrice,
                DonGia = createPDTO.OriginalPrice,
                SoLuong = createPDTO.Quantity,
                LuotXem = 0,
            };
            return sanPham;
        }


















        public static RoleDTO GetRoleDTOFromVaiTro(VaiTro vaiTro)
        {
            return new RoleDTO(vaiTro);
        }



        public static RoutePermissionDTO GetRoutePermissionDTOFromQuyenRoute(QuyenRoute quyenRoute)
        {
            return new RoutePermissionDTO(quyenRoute);
        }





















        public static BranchDTO GetBranchDTOFromLangNghe(LangNghe langNghe)
        {
            return new BranchDTO(langNghe);
        }
        public static LangNghe GetLangNgheFromCreateBranchDTO(CreateBranchDTO createBranchDTO)
        {
            var langNghe = new LangNghe()
            {
                TrangThai = (TrangThai)((int)createBranchDTO.Status),
                Ten = createBranchDTO.Name,
                TenDayDu = createBranchDTO.FullName,
                MoTa = createBranchDTO.Description,
                DiaChi = createBranchDTO.Address
            };
            return langNghe;
        }




    }
}


// public static JwtToken GetJwtTokenFromUser(Guid userId, string token)
// {
//     var jwtToken = new JwtToken() {
//         TaiKhoanId = userId,
//         Token = token
//     };
//     return jwtToken;
// }