using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface IChiTietSanPhamRepository : IGenericRepository<ChiTietSanPham, int>
    {
        Task<ChiTietSanPham> GetByLanguageIdAsync(int productId, string languageId);
    }
}