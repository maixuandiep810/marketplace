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
        public async Task<SanPham> GetByCodeAsync(string code)
        {
            try
            {
                var product = await FirstOrDefaultAsync(x => x.MaSP == code);
                if (product == null)
                {
                    return null;
                } 
                return product;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}