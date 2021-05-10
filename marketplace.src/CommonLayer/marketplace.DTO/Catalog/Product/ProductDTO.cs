using System.Collections.Generic;
using marketplace.Data.Entities;
using marketplace.DTO.Common;

namespace marketplace.DTO.Catalog.Product
{
    public class ProductDTO
    {
        public int Id { set; get; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Quantity { set; get; }
        public int ViewCount { set; get; }
        public List<ImageDTO> ImageDTOs { get; set; }

        public ProductDTO()
        {
        }

        public ProductDTO(SanPham prd, ChiTietSanPham detail) : this()
        {
            Id = prd.Id;
            Code = prd.MaSP;
            Price = prd.DonGia;
            OriginalPrice = prd.DonGiaGoc;
            Quantity = prd.SoLuong;
            ViewCount = prd.LuotXem;
            Name = detail.Ten;
            FullName = detail.TenDayDu;
            Description = detail.MoTa;
        }

        public ProductDTO(SanPham prd, ChiTietSanPham detail, List<ImageDTO> imageDTOs) : this(prd, detail)
        {
            ImageDTOs = new List<ImageDTO>();
            ImageDTOs = imageDTOs;
        }
    }
}