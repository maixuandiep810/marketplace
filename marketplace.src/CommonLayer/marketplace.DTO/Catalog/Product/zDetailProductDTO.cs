// using FluentValidation;
// using marketplace.Data.Entities;

// namespace marketplace.DTO.Catalog.Product
// {
//     public class DetailProductDTO
//     {
//         public int ProductId { get; set; }
//         public string LanguageId { get; set; }


//         public static ChiTietSanPham ToChiTietSanPham(DetailProductDTO detailPD)
//         {
//             var chiTietSp = new ChiTietSanPham() {
//                 NgonNguId = detailPD.LanguageId,
//                 Ten = detailPD.Name,
//                 TenDayDu = detailPD.FullName,
//                 MoTa = detailPD.Description
//             };
//             return chiTietSp;
//         }
//     }

//     public class DetailProductDTOValidator : AbstractValidator<DetailProductDTO>
//     {
//         public DetailProductDTOValidator()
//         {
//             // RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.")
//             //     .Length(4, 32).WithMessage("Code length must be between 4 and 14 characters.");
//         }
//     }
// }