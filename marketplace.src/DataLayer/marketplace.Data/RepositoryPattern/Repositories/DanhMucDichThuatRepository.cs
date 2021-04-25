using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class DanhMucDichThuatRepository : GenericRepository<DanhMucDichThuat, int>, IDanhMucDichThuatRepository
    {
        public DanhMucDichThuatRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}