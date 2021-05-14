using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using marketplace.Utilities.Const;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class ChiTietSanPhamRepository : GenericRepository<ChiTietSanPham, int>, IChiTietSanPhamRepository
    {
        public ChiTietSanPhamRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }

        public async Task<ChiTietSanPham> GetByLanguageIdAsync(int productId, string languageId)
        {
            try
            {
                var detailProduct = await FirstOrDefaultAsync(x => x.SanPhamId == productId && x.NgonNguId == languageId);
                if (detailProduct == null)
                {
                    switch (languageId)
                    {
                        case LaunguageConst.DEFAULT:
                            return null;
                        default:
                            detailProduct = await FirstOrDefaultAsync(x => x.SanPhamId == productId && x.NgonNguId == LaunguageConst.DEFAULT);
                            if (detailProduct == null)
                            {
                                return null;
                            }
                            else
                            {
                                break;
                            }
                    }
                }
                return detailProduct;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}