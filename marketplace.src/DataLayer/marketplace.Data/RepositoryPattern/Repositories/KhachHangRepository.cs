using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class KhachHangRepository : GenericRepository<KhachHang, int>, IKhachHangRepository
    {
        public KhachHangRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}