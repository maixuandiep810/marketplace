using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.DTO.SystemManager.RBAC;

namespace marketplace.Services.SystemManager.RBAC
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetRoleDTOsByRoutePermissionAsync(RoutePermissionDTO routePermissionDTO);
        Task<List<string>> GetRoleNameByPathActionPermissionAsync(string path, string action);
    }
}