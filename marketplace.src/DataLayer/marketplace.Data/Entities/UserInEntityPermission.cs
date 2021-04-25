using System;
using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class UserInEntityPermission : IBaseEntity<int>
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public int PermissionId { get; set; }
        public string EntityId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual EntityPermission EntityPermission { get; set; }
    }
}