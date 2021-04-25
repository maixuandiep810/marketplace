using System;
using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class CustomerDetail : IBaseEntity<int>
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual List<Cart> Carts { get; set; }
        public virtual List<Order> Orders { get; set; }
        // public virtual List<Transaction> Transactions { get; set; }
    }
}