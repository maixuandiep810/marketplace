using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using FluentValidation;
using marketplace.Data.Entities;
using marketplace.DTO.Enum;
using marketplace.DTO.Common;

namespace marketplace.DTO.Catalog.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageDTO ImageDTO { get; set; }

        public CategoryDTO()
        {

        }

        public CategoryDTO(DanhMuc danhMuc) : this()
        {
            if (danhMuc != null)
            {

                Id = danhMuc.Id;
                Code = danhMuc.MaSo;
                Status = (Status)((int)danhMuc.TrangThai);
                Name = "";
                Description = "";
            }
        }

        public CategoryDTO(DanhMuc danhMuc, ImageDTO imageDTO) : this(danhMuc)
        {
            ImageDTO = imageDTO;
        }
    }
}