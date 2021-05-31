using System.Collections.Generic;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class LangNgheRepository : GenericRepository<LangNghe, int>, ILangNgheRepository
    {
        public LangNgheRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }

        public async Task<LangNghe> GetByCodeAsync(string code)
        {
            try
            {
                var branch = await FirstOrDefaultAsync(x => x.MaLN == code);
                return branch;
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
                var codes = await _entities.Select(x => x.MaLN).ToListAsync();
                return codes;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}