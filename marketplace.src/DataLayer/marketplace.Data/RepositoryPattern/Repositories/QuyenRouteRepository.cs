using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class QuyenRouteRepository : GenericRepository<QuyenRoute, int>, IQuyenRouteRepository
    {
        public QuyenRouteRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}