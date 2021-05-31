using System.Linq;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class DanhMucRepository : GenericRepository<DanhMuc, int>, IDanhMucRepository
    {
        public DanhMucRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }

        public async Task<DanhMuc> GetByCodeAsync(string code)
        {
            try
            {
                var category = await FirstOrDefaultAsync(x => x.MaSo == code);
                // KO CAN VI AUTO NULL voi CLASS
                // if (category == null)
                // {
                //     return null;
                // }
                return category;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<string>> GetAllCodeValueAsync()
        {
            try
            {
                var codes = await _entities.Select(x => x.MaSo).ToListAsync();
                return codes;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}