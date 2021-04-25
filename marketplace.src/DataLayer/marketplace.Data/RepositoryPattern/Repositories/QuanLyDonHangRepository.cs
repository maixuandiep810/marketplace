using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class QuanLyDonHangRepository : GenericRepository<QuanLyDonHang, int>, IQuanLyDonHangRepository
    {
        public QuanLyDonHangRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}