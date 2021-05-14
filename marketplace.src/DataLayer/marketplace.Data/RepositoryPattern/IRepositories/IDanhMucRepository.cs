using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface IDanhMucRepository : IGenericRepository<DanhMuc, int>
    {
        Task<DanhMuc> GetByCodeAsync(string code);
        Task<List<string>> GetAllCodeValueAsync();
    }
}