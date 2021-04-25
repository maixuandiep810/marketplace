using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class SanPhamDichThuatRepository : GenericRepository<SanPhamDichThuat, int>, ISanPhamDichThuatRepository
    {
        public SanPhamDichThuatRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}