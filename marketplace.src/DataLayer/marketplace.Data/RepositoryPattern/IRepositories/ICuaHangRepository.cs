using System;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface ICuaHangRepository : IGenericRepository<CuaHang, int>
    {
        Task<CuaHang> GetBySellerIdAsync(string userId);
    }
}