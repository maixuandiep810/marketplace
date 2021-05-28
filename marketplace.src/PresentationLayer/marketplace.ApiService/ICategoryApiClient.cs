using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.DTO.Catalog.Category;
using marketplace.DTO.Common;

namespace marketplace.ApiService
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<List<CategoryDTO>>> GetAllCategoryAsync();
    }
}