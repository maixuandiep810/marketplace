using System;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class TaiKhoanRepository : GenericRepository<TaiKhoan, Guid>, ITaiKhoanRepository
    {
        public TaiKhoanRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }

        public async Task<List<TaiKhoan>> GetPageAsync(int start, int limit) {
            return await _entities.Select(x => x).OrderByDescending(x => x.UserName).Skip(start).Take(limit).ToListAsync();
        }
    }
}