using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface ISanPhamRepository : IGenericRepository<SanPham, int>
    {
        Task<SanPham> GetByCodeAsync(string code);
    }
}