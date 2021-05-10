using System.Collections.Generic;
using FluentValidation;
using marketplace.Data.Entities;
using marketplace.DTO.Common;
using Microsoft.AspNetCore.Http;

namespace marketplace.DTO.Catalog.Product
{
    public class CreateProductDTO
    {
        public string Code { get; set; }
        public decimal OriginalPrice { set; get; }
        public int Quantity { set; get; }
        public List<DetailProductDTO> DetailProductDTOs { get; set; }
        public List<CreateImageDTO> Images { get; set; }

        public static SanPham CreateProductDTOToSanPham(CreateProductDTO createPDTO)
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
    }

    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            // RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.")
            //     .Length(4, 32).WithMessage("Code length must be between 4 and 14 characters.");
        }
    }
}