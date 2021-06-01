using System.Linq;
using System;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class VaiTroRepository : GenericRepository<VaiTro, Guid>, IVaiTroRepository
    {
        public VaiTroRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }

        public bool CheckRoleInRoleGroup(List<string> roleNames, string roleGroup)
        {
            if (Find(x => x.NhomVT == roleGroup && roleNames.Contains(x.Name) == true).Count() > 0)
            {
                return true;
            };
            return false;
        }

        public async Task<List<VaiTro>> GetPageAsync(int start, int limit)
        {
            return await _entities.Select(x => x).OrderByDescending(x => x.Name).Skip(start).Take(limit).ToListAsync();
        }
    }
}