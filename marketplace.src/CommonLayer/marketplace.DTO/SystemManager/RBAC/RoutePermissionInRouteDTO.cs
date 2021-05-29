using marketplace.Data.Entities;

namespace marketplace.DTO.SystemManager.RBAC
{
    public class RoutePermissionInRouteDTO
    {
        public int Id { get; set; }
        public int RoutePermissionId { get; set; }
        public string RoleId { get; set; }

        public RoutePermissionInRouteDTO(QuyenRouteVaiTro quyenRouteVaiTro)
        {
            Id = quyenRouteVaiTro.Id;
            RoutePermissionId = quyenRouteVaiTro.QuyenRouteId;
            RoleId = quyenRouteVaiTro.VaiTroId.ToString();
        }
    }
}