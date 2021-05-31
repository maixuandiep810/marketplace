using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.DTO.Catalog.Category;
using marketplace.DTO.Common;
using marketplace.DTO.SystemManager.User;

namespace marketplace.ApiService
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> LoginAsync(LoginDTO request);
    }
}