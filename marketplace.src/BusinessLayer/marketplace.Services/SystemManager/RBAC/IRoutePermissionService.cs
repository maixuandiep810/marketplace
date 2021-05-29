using System.Threading.Tasks;
using marketplace.DTO.SystemManager.RBAC;

namespace marketplace.Services.SystemManager.RBAC
{
    public interface IRoutePermissionService
    {
        // Task<bool> IsAuthenticatedRouteAsync(string path, string action);
        Task<RoutePermissionDTO> GetRoutePermissionByPathActionAsync(string path, string action);
    }
}