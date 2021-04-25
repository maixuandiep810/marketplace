using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class SanPhamDanhMucRepository : GenericRepository<SanPhamDanhMuc, int>, ISanPhamDanhMucRepository
    {
        public SanPhamDanhMucRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}