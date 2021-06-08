using System.IO;
using FluentValidation;
using marketplace.Data.Entities;
using marketplace.DTO.Enum;

namespace marketplace.DTO.SystemManager.RBAC
{
    public class RoutePermissionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; } 
        public string PathRegex { get; set; }
        public bool IsAuthenticatedRoute { get; set; }
        public Status Status { get; set; }

        public RoutePermissionDTO(QuyenRoute quyenRoute)
        {
            Id = quyenRoute.Id;
            Name = quyenRoute.Ten;
            Action = quyenRoute.HanhDong;
            PathRegex = quyenRoute.PathRegex;
            IsAuthenticatedRoute = quyenRoute.LaRouteCanXacThuc;
            Status = (Status) quyenRoute.TrangThai;
        }
    }
}