using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;

namespace marketplace.Data.Entities
{
    public class ApplicationRole : IdentityRole<Guid>, IBaseEntity<Guid>
    {
        public string Description { get; set; }

        public virtual List<PermissionInRole> PermissionInRoles { get; set; }
    }
}
