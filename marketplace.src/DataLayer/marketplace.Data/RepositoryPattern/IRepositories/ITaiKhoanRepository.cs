using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface ITaiKhoanRepository : IGenericRepository<TaiKhoan, Guid>
    {
        Task<List<TaiKhoan>> GetPageAsync(int start, int limit);
    }
}