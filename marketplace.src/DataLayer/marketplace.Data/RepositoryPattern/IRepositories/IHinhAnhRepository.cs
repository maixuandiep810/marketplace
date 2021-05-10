using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Data.Entities;

namespace marketplace.Data.RepositoryPattern.IRepositories
{
    public interface IHinhAnhRepository : IGenericRepository<HinhAnh, int>
    {
        Task<HinhAnh> GetImageAsync(string type, string entityId);
        Task<List<HinhAnh>> GetImagesAsync(string type, string entityId);
    }
}