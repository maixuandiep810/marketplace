using System.Threading.Tasks;
using marketplace.DTOs.Common;

namespace marketplace.ApiService
{
    public interface IBaseApiClient
    {
        Task<TResponse> GetAsync<TResponse>(string url);
        Task<ApiResult<bool>> DeleteAsync(string id);
    }
}