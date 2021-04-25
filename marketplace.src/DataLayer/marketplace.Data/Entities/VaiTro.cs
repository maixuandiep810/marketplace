using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;

namespace marketplace.Data.Entities
{
    public class VaiTro : IdentityRole<Guid>, IBaseEntity<Guid>
    {
        public string MoTa { get; set; }
    }
}
