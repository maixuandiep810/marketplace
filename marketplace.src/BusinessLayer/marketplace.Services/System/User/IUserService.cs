using System.Threading.Tasks;
using marketplace.DTOs.Common;
using marketplace.DTOs.System.Users;

namespace marketplace.Services.System.User
{
    public interface IUserService
    {
        Task<ApiResult<bool>> RegisterAsync(RegisterRequest request);
    }
}