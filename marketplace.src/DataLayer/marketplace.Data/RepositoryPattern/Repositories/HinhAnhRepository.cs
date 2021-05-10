using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class HinhAnhRepository : GenericRepository<HinhAnh, int>, IHinhAnhRepository
    {
        public HinhAnhRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {
        }

        public async Task<List<HinhAnh>> GetImagesAsync(string type, string entityId)
        {
            try
            {
                var images = await (Find(x => x.Loai == type && x.DoiTuongId == entityId)).ToListAsync();
                return images;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}   