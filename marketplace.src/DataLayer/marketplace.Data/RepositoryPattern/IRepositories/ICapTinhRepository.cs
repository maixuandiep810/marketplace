using System;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface ICapTinhRepository : IGenericRepository<CapTinh, int>
    {
         Task<CapTinh> GetByUrl(string url);
    }
}