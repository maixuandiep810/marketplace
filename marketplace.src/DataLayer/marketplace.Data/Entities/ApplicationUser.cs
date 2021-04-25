using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity;

namespace marketplace.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, IBaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        

        public virtual CustomerDetail CustomerDetail { get; set; }
        public virtual SellerDetail SellerDetail { get; set; }
        public virtual List<UserInEntityPermission> UserInEntityPermissions { get; set; }
    }
}