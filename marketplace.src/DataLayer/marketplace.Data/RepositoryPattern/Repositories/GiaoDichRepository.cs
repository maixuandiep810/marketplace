using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class GiaoDichRepository : GenericRepository<GiaoDich, int>, IGiaoDichRepository
    {
        public GiaoDichRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}