using System.Threading.Tasks;
using marketplace.DTO.Common;
using marketplace.DTO.SystemManager.User;

namespace marketplace.Services.SystemManager.User
{
    public interface IUserService
    {
        Task<ApiResult<bool>> RegisterAsync(RegisterDTO request);
    }
}