using System.Threading.Tasks;
using marketplace.DTO.Catalog.Product;
using marketplace.DTO.Common;
namespace marketplace.Services.Catalog.Product
{
    public interface IProductService
    {
        Task<ApiResult<ProductDTO>> GetProductByCodeAsync(string productCode);
    }
}