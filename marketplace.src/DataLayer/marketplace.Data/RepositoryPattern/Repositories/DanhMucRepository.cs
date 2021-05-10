using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;

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
    }
}