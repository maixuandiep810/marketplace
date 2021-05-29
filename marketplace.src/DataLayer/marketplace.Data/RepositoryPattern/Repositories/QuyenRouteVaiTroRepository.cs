using System.Linq;
using marketplace.Data.RepositoryPattern.IRepositories;
using marketplace.Data.Entities;
using marketplace.Data.EF;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.RepositoryPattern.Repositories
{
    public class QuyenRouteVaiTroRepository : GenericRepository<QuyenRouteVaiTro, int>, IQuyenRouteVaiTroRepository
    {
        public QuyenRouteVaiTroRepository(marketplaceDbContext marketplaceDbContext) : base(marketplaceDbContext)
        {

        }

        public async Task<List<string>> GetRouteIdByPermissionIdAsync(int permissionId)
        {
            return await Find(x => x.QuyenRouteId == permissionId).Select(x => x.VaiTroId.ToString()).ToListAsync();
        }
    }
}