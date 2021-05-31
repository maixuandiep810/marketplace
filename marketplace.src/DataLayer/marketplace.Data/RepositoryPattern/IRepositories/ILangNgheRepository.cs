using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface ILangNgheRepository : IGenericRepository<LangNghe, int>
    {
        Task<LangNghe> GetByCodeAsync(string code);
        Task<List<string>> GetAllCodeValueAsync();
    }
}