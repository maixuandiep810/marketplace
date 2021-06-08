using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface IVaiTroRepository : IGenericRepository<VaiTro, Guid>
    {
        Task<VaiTro> GetByNameAsync(string roleName);
        Task<List<VaiTro>> GetPageAsync(int start, int limit);
    }
}