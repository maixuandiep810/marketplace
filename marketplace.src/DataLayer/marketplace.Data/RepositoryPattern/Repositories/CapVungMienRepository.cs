using System.Collections.Generic;
using System;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class CapVungMienRepository : GenericRepository<CapVungMien, int>, ICapVungMienRepository
    {
        public CapVungMienRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }

        public async Task<List<CapVungMien>> GetAllIncludeCapTinhsAsync()
        {
            return await _context.CapVungMiens.Include(x => x.CapTinhs).ToListAsync();
        }
    }
}