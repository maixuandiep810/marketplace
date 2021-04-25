using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class DonHangRepository : GenericRepository<DonHang, int>, IDonHangRepository
    {
        public DonHangRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}