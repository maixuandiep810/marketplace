using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;

namespace marketplace.Data.Entities
{
    public class VaiTro : IdentityRole<Guid>, IBaseEntity<Guid>
    {
        public bool DaXoa { get; set; }
        public string MoTa { get; set; }
    }
}
