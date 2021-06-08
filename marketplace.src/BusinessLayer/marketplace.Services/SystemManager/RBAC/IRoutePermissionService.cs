using System.Threading.Tasks;
using marketplace.DTO.Common;
using marketplace.DTO.SystemManager.RBAC;

namespace marketplace.Services.SystemManager.RBAC
{
    public interface IRoutePermissionService
    {
        //v2
        Task<RoutePermissionDTO> GetRoutePermissionDTOAsync(string path, string action);
        //v1
        // Task<bool> IsAuthenticatedRouteAsync(string path, string action);
        Task<ApiResult<PageEntityDTO<RoutePermissionDTO>>> GetPageByIdAsync(int? page = 0);
    }
}