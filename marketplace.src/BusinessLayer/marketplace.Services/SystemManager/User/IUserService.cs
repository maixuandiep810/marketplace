using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.DTO.Common;
using marketplace.DTO.SystemManager.User;

namespace marketplace.Services.SystemManager.User
{
    public interface IUserService
    {
        Task<ApiResult<bool>> RegisterAsync(RegisterDTO request);
        Task<ApiResult<UserDTO>> LoginAsync(LoginDTO request);
        Task<List<string>> GetRoleNameAsync(string userId);
        Task<ApiResult<UserDTO>> GetByUserNameAsync(string userName);
        Task<ApiResult<PageEntityDTO<UserDTO>>> GetPageAsync(int? page);
        Task<ApiResult<bool>> ConfirmUserEmail(string userEmail, string token);
        Task<ApiResult<bool>> ResendConfirmEmail(string userEmail);
        Task<ApiResult<bool>> DeleteAsync(string userName);
        Task<ApiResult<bool>> ChangeStatusAsync(string userName, bool status);
    }
}