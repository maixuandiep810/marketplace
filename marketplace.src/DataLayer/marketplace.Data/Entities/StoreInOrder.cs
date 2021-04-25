using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class StoreInOrder : IBaseEntity<int>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        
        public int StoreId { get; set; }
        public int OrderId { get; set; }
        public int? SellerDetailId { get; set; }


        public virtual Store Store { get; set; }
        public virtual Order Order { get; set; }
        public virtual SellerDetail SellerDetail { get; set; }
    }
}
