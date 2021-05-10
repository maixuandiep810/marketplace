using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface IHinhAnhRepository : IGenericRepository<HinhAnh, int>
    {
         Task<List<HinhAnh>> GetImagesAsync(string type, string entityId);
    }
}