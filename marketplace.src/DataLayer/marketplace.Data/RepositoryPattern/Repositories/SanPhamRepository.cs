using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class SanPhamRepository : GenericRepository<SanPham, int>, ISanPhamRepository
    {
        public SanPhamRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
    }
}