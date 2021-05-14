using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.DTO.Catalog.Category;
using marketplace.DTO.Common;

namespace marketplace.Services.Catalog.Category
{
    public interface ICategoryService
    {
        Task<ApiResult<List<CategoryDTO>>> GetAllCategoryAsync(string languageId);
        Task<ApiResult<CategoryDTO>> GetCategoryByCodeAsync(string categoryCode, string languageId);
        Task<ApiResult<List<string>>> GetAllCategoryCodeAsync();
        Task<ApiResult<bool>> CreateAsync(CreateCategoryDTO req);
        Task<ApiResult<bool>> DeleteAsync(string productCode);
    }
}