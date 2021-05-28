using System.ComponentModel;
using System.Collections.Generic;
using FluentValidation;
using marketplace.Data.Entities;
using marketplace.Data.Enums;
using marketplace.DTO.Enum;
using marketplace.DTO.Common;

namespace marketplace.DTO.Catalog.Category
{
    public class CreateCategoryDTO
    {
        public string Code { get; set; }
        public Status Status { get; set; }
        public bool IsShownAtHome { get; set; }
        public List<DetailCategoryDTO> DetailCategoryDTOs { get; set; }
        public CreateImageDTO Image { get; set; }

        public static DanhMuc ToDanhMuc(CreateCategoryDTO createCDTO)
        {
            var danhMuc = new DanhMuc()
            {
                MaSo = createCDTO.Code,
                TrangThai = (TrangThai)((int)createCDTO.Status),
                HienThiTrangChu = createCDTO.IsShownAtHome
            };
            return danhMuc;
        }
    }

    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            // RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.")
            //     .Length(4, 32).WithMessage("Code length must be between 4 and 14 characters.");
        }
    }
}