using System.Linq;
using System;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class CapHuyenRepository : GenericRepository<CapHuyen, int>, ICapHuyenRepository
    {
        public CapHuyenRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }
        public async Task<CapHuyen> GetByUrl(string url)
        {
            return await Find(x => x.TenUrl == url).Select(x => x).FirstOrDefaultAsync();
        }
    }
}