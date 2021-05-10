using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface IChiTietDanhMucRepository : IGenericRepository<ChiTietDanhMuc, int>
    {
        Task<ChiTietDanhMuc> GetByLanguageIdAsync(int categoryId, string languageId);
    }
}