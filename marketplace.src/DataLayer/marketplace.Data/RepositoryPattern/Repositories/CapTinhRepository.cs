using System;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class CapTinhRepository : GenericRepository<CapTinh, int>, ICapTinhRepository
    {
        public CapTinhRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
        public async Task<CapTinh> GetByUrl(string url)
        {
            return await Find(x => x.TenUrl == url).Select(x => x).FirstOrDefaultAsync();
        }
    }
}