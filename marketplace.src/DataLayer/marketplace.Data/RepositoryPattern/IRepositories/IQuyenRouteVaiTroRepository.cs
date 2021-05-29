using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface IQuyenRouteVaiTroRepository : IGenericRepository<QuyenRouteVaiTro, int>
    {
        Task<List<string>> GetRouteIdByPermissionIdAsync(int permissionId);
    }
}