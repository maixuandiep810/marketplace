using System;
using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class SellerDetail : IBaseEntity<int>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public Guid ApplicationUserId { set; get; }
        public int StoreId { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Store Store { get; set; }
        public virtual List<StoreInOrder> StoreInOrders { get; set; }
    }
}