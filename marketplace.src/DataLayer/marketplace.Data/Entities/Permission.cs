using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class Permission : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRoutePermission { get; set; }
        public bool IsEntityPermission { get; set; }

        public virtual List<PermissionInRole> PermissionInRoles { get; set; }
        public virtual EntityPermission EntityPermission { get; set; }
        public virtual RoutePermission RoutePermission { get; set; }
    }
}