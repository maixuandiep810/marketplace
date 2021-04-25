using System;
namespace marketplace.Data.Entities
{
    public class PermissionInRole : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public Guid ApplicationRoleId { get; set; }

        public virtual ApplicationRole ApplicationRole { get; set; }
        public virtual Permission Permission { get; set; }
    }
}