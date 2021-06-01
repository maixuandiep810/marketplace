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

        public ProductDTO(SanPham prd) : this()
        {
            Id = prd.Id;
            Code = prd.MaSo;
            Price = prd.DonGia;
            OriginalPrice = prd.DonGiaGoc;
            Quantity = prd.SoLuong;
            ViewCount = prd.LuotXem;
            Name = prd.Ten;
            FullName = prd.TenDayDu;
            Description = prd.MoTa;
        }

        public ProductDTO(SanPham prd, List<ImageDTO> imageDTOs) : this(prd)
        {
            ImageDTOs = new List<ImageDTO>();
            ImageDTOs = imageDTOs;
        }
    }
}