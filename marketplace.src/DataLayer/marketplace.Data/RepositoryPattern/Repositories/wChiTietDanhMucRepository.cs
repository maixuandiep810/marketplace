// using marketplace.Data.RepositoryPattern.IRepositories;
// using marketplace.Data.Entities;
// using marketplace.Data.EF;
// using System.Threading.Tasks;
// using marketplace.Utilities.Const;

// namespace marketplace.Data.RepositoryPattern.Repositories
// {
//     public class ChiTietDanhMucRepository : GenericRepository<ChiTietDanhMuc, int>, IChiTietDanhMucRepository
//     {
//         public ChiTietDanhMucRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
//         {

//         }

//         public async Task<ChiTietDanhMuc> GetByLanguageIdAsync(int categoryId, string languageId)
//         {
//             try
//             {
//                 var detailCategory = await FirstOrDefaultAsync(x => x.DanhMucId == categoryId && x.NgonNguId == languageId);
//                 if (detailCategory == null)
//                 {
//                     switch (languageId)
//                     {
//                         case LaunguageConst.DEFAULT:
//                             return null;
//                         default:
//                             detailCategory = await FirstOrDefaultAsync(x => x.DanhMucId == categoryId && x.NgonNguId == LaunguageConst.DEFAULT);
//                             if (detailCategory == null)
//                             {
//                                 return null;
//                             }
//                             else
//                             {
//                                 break;
//                             }
//                     }
//                 }
//                 return detailCategory;
//             }
//             catch (System.Exception ex)
//             {
//                 throw ex;
//             }
//         }
//     }
// }